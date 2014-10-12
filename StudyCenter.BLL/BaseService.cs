using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using StudyCenter.DalFactory;
using StudyCenter.IBLL;
using StudyCenter.IDAL;
using StudyCenter.EFDAL;
using StudyCenter.Model;

namespace StudyCenter.BLL 
{
    public  class  BaseService<T> where T :class , new()
    {
        protected IBaseDal<T> CurrentDal;
        
        /// <summary>
        /// 使用控制反转，进行构造函数依赖注入
        /// </summary>
        public BaseService()
        {
            SetDal();
        }

        /// <summary>
        /// 子类必须重写该方法，否则无法使用！
        /// </summary>
        public virtual  void SetDal()
        {
        }

        public T Add(T model)
        {
            return CurrentDal.Add(model);
        }

        public bool Exist(int id)
        {
            return CurrentDal.Exist(id);
        }

        public bool Update(T model)
        {
            return CurrentDal.Update(model);
        }

        /// <summary>
        /// 根据实体更新
        /// </summary>
        /// <param name="model">要更新的实体</param>
        /// <param name="proNames">要更新的属性数组</param>
        /// <returns>影响到的字段数</returns>
        public int Update(T model, params string[] proNames)
        {
            return CurrentDal.Update(model, proNames);
        }

        /// <summary>
        /// 批量实体更新
        /// </summary>
        /// <param name="model">要更新的实体</param>
        /// <param name="whereLambda">刷选条件</param>
        /// <param name="modifiedProNames">刷选属性</param>
        /// <returns></returns>
        public  int Update(T model, Expression<Func<T, bool>> whereLambda, params string[] modifiedProNames)
        {
            return CurrentDal.Update(model, whereLambda, modifiedProNames);
        }

        public bool Delete(T model)
        {
            return CurrentDal.Delete(model);
        }

        public int Delete(params int[] ids)
        {
            return CurrentDal.Delete(ids);
        }

        public int Delete(Expression<Func<T, bool>> whereLambda)
        {
            return CurrentDal.Delete(whereLambda);
        }

        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda)
        {
            return CurrentDal.LoadEntities(whereLambda);
        }

        public IQueryable<T> LoadEntities<TProperty>(Expression<Func<T, bool>> whereLambda,
                                                        Expression<Func<T, TProperty>> path)
        {
            return CurrentDal.LoadEntities(whereLambda, path);
        }

        public IQueryable<T> LoadPageEntities<S>(int pageSize, int pageIndex, 
                                                  out int total, Func<T, bool> whereLambda, 
                                                    Func<T, S> orderbyLambda, bool isAsc)
        {
            return CurrentDal.LoadPageEntities(pageSize, pageIndex, out total, whereLambda, orderbyLambda, isAsc);
        }

        public IQueryable<T> LoadPageEntities<TOrderProperty, TProperty>(int pageSize, int pageIndex, out int total,
                    Expression<Func<T, bool>> whereLambda,
                    Expression<Func<T, TOrderProperty>> orderbyLambda,
                    Expression<Func<T, TProperty>> path, bool isAsc)
        {
            return CurrentDal.LoadPageEntities(pageSize, pageIndex, out total, whereLambda, orderbyLambda, path, isAsc);
        }

        public int[] GetIds(Func<AllId, bool> whereLambda)
        {
            return CurrentDal.GetIds(whereLambda);
        }

        public int[] GetIds(params SqlParameter[] parameters)
        {
            return CurrentDal.GetIds(parameters);
        }

        public int[] GetIds(string propertyName, object propertyValue)
        {
            return CurrentDal.GetIds(propertyName, propertyValue);
        }

        public int Savechanges()
        { 
             //建议的用法，实际上是一样的效果，调用的函数也是一样的
            return DbSessionFactory.SaveChanges(); 
            //或者
            //return EfDbContextFactory.GetCurrectDbContext().SaveChanges();
        }
    }
}
