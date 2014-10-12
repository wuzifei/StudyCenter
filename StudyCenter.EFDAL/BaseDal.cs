using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using StudyCenter.Model;

namespace StudyCenter.EFDAL
{

    /// <summary>
    /// 把数据库访问层公共的方法抽像出来进行实现。
    /// </summary>
    /// <typeparam name="T">Model</typeparam>
    public class BaseDal<T> where T : class , new()
    {      
        #region DbContext线程唯一实例
        ///上下文直接New。那么这样不行。我们要保证上下文实例是线程内唯一。
        ///问题：把保证EF上下文实例唯一的代码写在这个地方合适吗？
        ///考虑思路：第一当前类的职责是什么？当前的需求跟当前类的职责是否是一致的？
        ///Model.ModelContainer db =new ModelContainer();
        /// <summary>
        /// 线程唯一实例
        /// </summary>
        public DbContext CurrentDbContext
        {
            get
            {
                return EfDbContextFactory.GetCurrectDbContext();
            }
        } 
        #endregion

        #region 新增 +T Add(T model)
        /// <summary>
        /// 添加模型，需要主动调用SaveChange()方法
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual T Add(T model)
        {
            CurrentDbContext.Set<T>().Add(model);
            //CurrentDbContext.SaveChanges();
            return model;
        } 
        #endregion

        /// <summary>
        /// 判断给定Id实体是否已存在于数据库中
        /// </summary>
        /// <param name="id">实体主键</param>
        /// <returns>存在返回true</returns>
        public bool Exist(int id)
        {
            var model = CurrentDbContext.Set<T>().Find(id);
            if (model != null)
                return true;
            return false;
        }

        #region 修改 +bool Update(T model)
        /// <summary>
        /// 更新模型，需要主动调用SaveChange()方法
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual bool Update(T model)
        {
            //db.Set<T>().Attach(entity); 内部就是只是把实体的 状态改成unchange跟数据库查询出来的状态时一样的。
            CurrentDbContext.Entry(model).State = EntityState.Modified;
            //return CurrentDbContext.SaveChanges()>0;
            return true;
        }      
        #endregion

        #region  修改 +int Update(T model, params string[] proNames)
        /// <summary>
        /// 4.0 修改实体的特定属性，如：
        /// T u = new T() { uId = 1, uLoginName = "asdfasdf" };
        /// this.Update(u, "uLoginName","uId");
        /// </summary>
        /// <param name="model">要修改的实体对象</param>
        /// <param name="proNames">要修改的 属性 名称</param>
        /// <returns>更新实体的个数</returns>
        public virtual int Update(T model, params string[] proNames)
        {
            //4.1将 对象 添加到 EF中
            DbEntityEntry entry = CurrentDbContext.Entry(model);
            //4.2先设置 对象的包装 状态为 Unchanged
            entry.State = EntityState.Unchanged;
            //4.3循环 被修改的属性名 数组
            foreach(string proName in proNames)
            {
                //4.4将每个 被修改的属性的状态 设置为已修改状态;后面生成update语句时，就只为已修改的属性 更新
                entry.Property(proName).IsModified = true;
            }
            //4.4一次性 生成sql语句到数据库执行
            //CurrentDbContext.SaveChanges();
            return 1;
        }
        #endregion

        #region 修改(反射版) +int Update(T model, Expression<Func<T, bool>> whereLambda, params string[] modifiedProNames)
        /// <summary>
        /// 批量属性修改反射版
        /// </summary>
        /// <param name="model">要修改的实体对象</param>
        /// <param name="whereLambda">查询条件</param>
        /// <param name="proNames">要修改的 属性 名称</param>
        /// <returns></returns>
        public int Update(T model, Expression<Func<T, bool>> whereLambda, params string[] modifiedProNames)
        {
            //4.1查询要修改的数据
            List<T> listModifing = CurrentDbContext.Set<T>().Where(whereLambda).ToList();

            //获取 实体类 类型对象
            Type t = typeof(T); // model.GetType();
            //获取 实体类 所有的 公有属性
            List<PropertyInfo> proInfos = t.GetProperties(BindingFlags.Instance | BindingFlags.Public).ToList();
            //创建 实体属性 字典集合
            Dictionary<string, PropertyInfo> dictPros = new Dictionary<string, PropertyInfo>();
            //将 实体属性 中要修改的属性名 添加到 字典集合中 键：属性名  值：属性对象
            proInfos.ForEach(p =>
            {
                if(modifiedProNames.Contains(p.Name))
                {
                    dictPros.Add(p.Name, p);
                }
            });

            //4.3循环 要修改的属性名
            foreach(string proName in modifiedProNames)
            {
                //判断 要修改的属性名是否在 实体类的属性集合中存在
                if(dictPros.ContainsKey(proName))
                {
                    //如果存在，则取出要修改的 属性对象
                    PropertyInfo proInfo = dictPros[proName];
                    //取出 要修改的值
                    object newValue = proInfo.GetValue(model, null); //object newValue = model.uName;

                    //4.4批量设置 要修改 对象的 属性
                    foreach(T usrO in listModifing)
                    {
                        //为 要修改的对象 的 要修改的属性 设置新的值
                        proInfo.SetValue(usrO, newValue, null); //usrO.uName = newValue;
                    }
                }
            }
            //4.4一次性 生成sql语句到数据库执行
            return 1;
        }
        #endregion

        #region 删除 +bool Delete(T model)
        /// <summary>
        /// 删除模型，需要主动调用SaveChange()方法
        /// </summary>
        /// <param name="model">要删除的实体</param>
        /// <returns></returns>
        public virtual bool Delete(T model)
        {
            CurrentDbContext.Entry(model).State = EntityState.Deleted;
            //return CurrentDbContext.SaveChanges() > 0;
            //只管返回成功就好了，异常会在日志中处理
            return true;
        } 
        #endregion

        #region 根据主键ID删除多个 +int Delete(params int[] ids)
        /// <summary>
        /// 根据主键Id删除数据
        /// </summary>
        /// <param name="ids">主键ID</param>
        /// <returns>删除的个数</returns>
        public virtual int Delete(params int[] ids)
        {
            //T entity =new T();
            //entity.ID
            //首先可以通过  泛型的基类的约束来实现对id字段赋值。
            //也可也使用反射的方式。
            foreach(var item in ids)
            {
                var entity = CurrentDbContext.Set<T>().Find(item);//如果实体已经在内存中，那么就直接从内存拿，如果内存中跟踪实体没有，那么才查询数据库。
                CurrentDbContext.Set<T>().Remove(entity);
            }
            return ids.Count();

        } 
        #endregion

        #region 条件删除 +int Delete(Expression<Func<T, bool>> whereLambda)
        /// <summary>
        /// 根据条件删除对应的实体
        /// </summary>
        /// <param name="whereLambda">条件查询表达式</param>
        /// <returns>返回删除的实体个数</returns>
        /// 之所以不用Func,因为Func有性能问题,它是Expression的已编译版本
        /// Expression的活性更好,会生成更好的sql语句
        //public int Delete(Func<T, bool> whereLambda)
        public virtual int Delete(Expression<Func<T, bool>> whereLambda)
        {
            //首先根据条件查出所有要删除实体
            var entitys = CurrentDbContext.Set<T>().Where(whereLambda).ToArray();
            //逐一标记为删除状态
            foreach(var entiity in entitys)
            {
                CurrentDbContext.Set<T>().Attach(entiity);
                CurrentDbContext.Set<T>().Remove(entiity);
            }
            //返回删除的条数
            return entitys.Count();
        }
        
        #endregion

        #region 条件查询 +IQueryable<T> LoadEntities(Func<T, bool> whereLambda)
        /// <summary>
        /// 根据lambda表达式查询
        /// </summary>
        /// <param name="whereLambda">lambda查询条件</param>
        /// <returns></returns>
        public virtual IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda)
        {
            return CurrentDbContext.Set<T>().Where(whereLambda).AsQueryable();
        }
        
        #endregion

        #region 条件查询 +IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda,Expression<Func<T, TProperty>> path)
        /// <summary>
        /// 根据lambda表达式查询,且加载相应外键实体
        /// </summary>
        /// <typeparam name="TProperty">外键实体名</typeparam>
        /// <param name="whereLambda">lambd查询条件</param>
        /// <param name="path">外键实体查询条件</param>
        /// <returns></returns>
        public IQueryable<T> LoadEntities<TProperty>(Expression<Func<T, bool>> whereLambda,
                                                        Expression<Func<T, TProperty>> path)
        {
            return CurrentDbContext.Set<T>().Where(whereLambda).Include(path).AsQueryable();
            //return CurrentDbContext.Set<T>().Where(whereLambda).Include("Role");
        } 
        #endregion

        #region 获取分页 +IQueryable<T> LoadPageEntities<S>（....）
        /// <summary>
        /// 根据参数获取分页数据
        /// </summary>
        /// <param name="pageSize">页大小</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="total">总记录个数</param>
        /// <param name="whereLambda">选择查询表达式</param>
        /// <param name="orderbyLambda">排序表达式</param>
        /// <param name="isAsc">是否升序</param>
        /// <returns></returns>
        // ReSharper disable once InconsistentNaming
        public virtual IQueryable<T> LoadPageEntities<TProperty>(
                                                                    int pageSize, 
                                                                    int pageIndex, 
                                                                    out int total, 
                                                                    Func<T, bool> whereLambda, 
                                                                    Func<T, TProperty> orderbyLambda, 
                                                                    bool isAsc
                                                                )
        {
            total = CurrentDbContext.Set<T>().Where(whereLambda).Count();

            if(isAsc)
            {
                return
                CurrentDbContext.Set<T>()
                  .Where(whereLambda)
                  .OrderBy(orderbyLambda)
                  .Skip(pageSize * (pageIndex - 1))
                  .Take(pageSize)
                  .AsQueryable();
            }
            return
            CurrentDbContext.Set<T>()
                .Where(whereLambda) //首先筛选
                .OrderByDescending(orderbyLambda)//排序
                .Skip(pageSize * (pageIndex - 1))//需要排除的实体个数
                .Take(pageSize)//需要获取的实体个数
                .AsQueryable();
        } 
        #endregion

        #region 获取含有外键属性的分页 + IQueryable<T> LoadPageEntities<S>（....）
        public IQueryable<T> LoadPageEntities<TOrderProperty,TProperty>(int pageSize, int pageIndex, out int total,
    Expression<Func<T, bool>> whereLambda,
    Expression<Func<T, TOrderProperty>> orderbyLambda, Expression<Func<T, TProperty>> path, bool isAsc)
        {
            total = CurrentDbContext.Set<T>().Where(whereLambda).Count();
            if (isAsc)
            {
                return
                CurrentDbContext.Set<T>()
                  .Where(whereLambda)
                  .Include(path)
                  .OrderBy(orderbyLambda)
                  .Skip(pageSize * (pageIndex - 1))
                  .Take(pageSize)
                  .AsQueryable();
            }
            return
            CurrentDbContext.Set<T>()
                .Where(whereLambda) //首先筛选
                .Include(path)
                .OrderByDescending(orderbyLambda)//排序
                .Skip(pageSize * (pageIndex - 1))//需要排除的实体个数
                .Take(pageSize)//需要获取的实体个数
                .AsQueryable();
        } 
        #endregion

        #region 条件查询某些主键 低效 +int[] GetIds(Func<AllId, bool> whereLambda)
        /// <summary>
        /// 根据条件获取实体主键数组集合
        /// </summary>
        /// <param name="whereLambda">条件</param>
        /// <returns>int数组</returns>
        public virtual int[] GetIds(Func<AllId, bool> whereLambda)
        {
            var result = CurrentDbContext.Database.SqlQuery<AllId>("select ID from " + typeof(T).Name).Where(whereLambda).ToArray();
            var array = new int[result.Count()];
            for (var i = 0; i < result.Count(); i++)
            {
                array[i] = result[i].ID;
            }
            return array;
        }
        #endregion

        #region 条件查询某些主键 高效 +int[] GetIds(params SqlParameter[] parameters)
        /// <summary>
        /// 根据条件获取实体主键数组集合,建议使用单条件查询
        /// </summary>
        /// <param name="parameters">条件参数，需设置Value,ParameterName,DbType</param>
        /// <returns>int数组</returns>
        public virtual int[] GetIds(params SqlParameter[] parameters)
        {
            var sb = new StringBuilder("select ID from " + typeof(T).Name + " where ID>0 ");
            var par = new SqlParameter("IsDeleted", 1);
            foreach (var parameter in parameters)
            {
                var name = parameter.ParameterName;
                sb.Append(" and " + name + "=" + parameter.Value);
            }
            var result = CurrentDbContext.Database.SqlQuery<AllId>(sb.ToString()).ToArray();
            var idArray = new int[result.Count()];
            for (var allId = 0; allId < result.Count(); allId++)
            {
                idArray[allId] = result[allId].ID;
            }
            return idArray;
        }
        
        #endregion

        #region 条件查询某些主键 高效 +int[] GetIds(string propertyName, object propertyValue)
        /// <summary>
        /// 根据某个列的值来刷选获取主键ID
        /// </summary>
        /// <param name="propertyName">列名</param>
        /// <param name="propertyValue">值</param>
        /// <returns>int数组（主键ID）</returns>
        public virtual int[] GetIds(string propertyName, object propertyValue)
        {
            var sb = new StringBuilder("select ID from " + typeof(T).Name + " where ID>0 ");
            sb.Append(" and " + propertyName + "=" + propertyValue);
            var result = CurrentDbContext.Database.SqlQuery<AllId>(sb.ToString()).ToArray();
            var idArray = new int[result.Count()];
            for (var allId = 0; allId < result.Count(); allId++)
            {
                idArray[allId] = result[allId].ID;
            }
            return idArray;
        } 
        #endregion
    }
}

