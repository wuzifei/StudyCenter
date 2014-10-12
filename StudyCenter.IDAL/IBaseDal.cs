using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using StudyCenter.Model;

namespace StudyCenter.IDAL {
    public interface IBaseDal<T> where T:class ,new()
    {
        T Add(T model);
        bool Exist(int id);
        bool Update(T model); 
        int Update(T model, params string[] proNames);
        int Update(T model, Expression<Func<T, bool>> whereLambda, params string[] modifiedProNames);
        bool Delete(T model);
        int Delete(int[] ids);
        int Delete(Expression<Func<T, bool>> whereLambda);
        IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda);
        IQueryable<T> LoadEntities<TProperty>(Expression<Func<T, bool>> whereLambda,
                                                        Expression<Func<T, TProperty>> path);
        IQueryable<T> LoadPageEntities<TProperty>(int pageSize, int pageIndex, out int total, Func<T, bool> whereLambda,
            Func<T, TProperty> orderbyLambda, bool isAsc);

        IQueryable<T> LoadPageEntities<TOrderProperty, TProperty>(int pageSize, int pageIndex, out int total,
            Expression<Func<T, bool>> whereLambda,
            Expression<Func<T, TOrderProperty>> orderbyLambda, Expression<Func<T, TProperty>> path, bool isAsc);

        int[] GetIds(Func<AllId, bool> whereLambda);
        int[] GetIds(params SqlParameter[] parameters);
        int[] GetIds(string propertyName, object propertyValue);
    }
}
