using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using StudyCenter.Model;

namespace StudyCenter.IBLL 
{
    /// <summary>
    /// 对所有实体共有的服务进行约束抽象化
    /// </summary>
    public interface  IBaseService<T> where T:class,new()
    {
        //T Add();
        //int Add(int[] ids);
        //bool Update(T model);
        //bool Update(T[] models);
        //bool Delete(T model);
        //bool Delete(Func<T,bool> byWhichProperty);
        //bool Delete(T[] models);

        /// <summary>
        /// 添加，返回添加成功的实体
        /// </summary>
        /// <param name="model">要添加的实体</param>
        /// <returns></returns>
        T Add(T model);

        /// <summary>
        /// 判断给定Id实体是否已存在于数据库中
        /// </summary>
        /// <param name="id">实体主键</param>
        /// <returns>存在返回true</returns>
        bool Exist(int id);

        /// <summary>
        /// 根据实体更新
        /// </summary>
        /// <param name="model">要更新的实体</param>
        /// <returns></returns>
        bool Update(T model);

        /// <summary>
        /// 根据实体更新
        /// </summary>
        /// <param name="model">要更新的实体</param>
        /// <param name="proNames">要更新的属性数组</param>
        /// <returns>影响到的字段数</returns>
        int Update(T model, params string[] proNames);

        /// <summary>
        /// 批量实体更新
        /// </summary>
        /// <param name="model">要更新的实体</param>
        /// <param name="whereLambda">刷选条件</param>
        /// <param name="modifiedProNames">刷选属性</param>
        /// <returns></returns>
        int Update(T model, Expression<Func<T, bool>> whereLambda, params string[] modifiedProNames);

        /// <summary>
        /// 根据实体删除
        /// </summary>
        /// <param name="model">要删除的实体</param>
        /// <returns></returns>
        bool Delete(T model);

        /// <summary>
        /// 根据实体主键Id删除
        /// </summary>
        /// <param name="ids">需要删除的实体主键数组</param>
        /// <returns></returns>
        int Delete(params int[] ids);       
        
        /// <summary>
        /// 根据条件删除
        /// </summary>
        /// <param name="whereLambda">条件</param>
        /// <returns></returns>
        int Delete(Expression<Func<T,bool>> whereLambda);


        /// <summary>
        /// 根据Lambda表达式进行查询对应实体
        /// </summary>
        /// <param name="whereLambda">Lambda表达式</param>
        /// <returns></returns>
        IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda);//规约设计模式。 where a>10

        /// <summary>
        /// 根据lambda表达式查询实体且加载相应的外键实体
        /// </summary>
        /// <typeparam name="TProperty">需要加载的外键实体属性名</typeparam>
        /// <param name="whereLambda">lambda查询表达式</param>
        /// <param name="path">lambda外键实体表达式</param>
        /// <returns></returns>
        IQueryable<T> LoadEntities<TProperty>(Expression<Func<T, bool>> whereLambda,
                                                Expression<Func<T, TProperty>> path);


        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <typeparam name="S">排序的参数类型，ID则为int,Name则为String</typeparam>
        /// <param name="pageSize">页大小</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="total">总页数</param>
        /// <param name="whereLambda">条件筛选表达式</param>
        /// <param name="orderbyLambda">排序表达式</param>
        /// <param name="isAsc">是否升序</param>
        /// <returns>返回所有查询到得结果</returns>
        IQueryable<T> LoadPageEntities<S>(int pageSize, int pageIndex, out int total,
                                                  Func<T, bool> whereLambda
                                                  , Func<T, S> orderbyLambda, bool isAsc);

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <typeparam name="TOrderProperty">排序的属性名</typeparam>
        /// <typeparam name="TProperty">要加载的外键属性名</typeparam>
        /// <param name="pageSize">页大小</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="total">总页数</param>
        /// <param name="whereLambda">条件筛选表达式</param>
        /// <param name="orderbyLambda">排序表达式</param>
        /// <param name="path">外键实体加载</param>
        /// <param name="isAsc">是否升序</param>
        /// <returns>返回所有查询到得结果</returns>
        IQueryable<T> LoadPageEntities<TOrderProperty, TProperty>(int pageSize, int pageIndex, out int total,
            Expression<Func<T, bool>> whereLambda,
            Expression<Func<T, TOrderProperty>> orderbyLambda, Expression<Func<T, TProperty>> path, bool isAsc);

        int[] GetIds(Func<AllId, bool> whereLambda);
        int[] GetIds(params SqlParameter[] parameters);
        int[] GetIds(string propertyName, object propertyValue);

        int Savechanges();
    }
}
