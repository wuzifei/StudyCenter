using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyCenter.Common;
using StudyCenter.EFDAL;
using StudyCenter.IDAL;
using System.Runtime.Remoting.Messaging;

namespace StudyCenter.DalFactory 
{
    public class DbSessionFactory
    {
        private static IDbSession _dbSession;
        public static IDbSession GetCurrentDbSession()
        {
            //从当前线程获取数据仓储类实例
           _dbSession = CallContext.GetData("DbSession") as IDbSession;
            //获取到时，直接返回该实例
           if(_dbSession != null)
                return _dbSession;
           //没有获取到，先创建，再存入，最后返回创建的实例
           _dbSession = SpringHelper.GetObject("DbSession") as IDbSession;
           CallContext.SetData("DbSession",_dbSession);
           return _dbSession;
        }

        public static int SaveChanges()
        {
            return EfDbContextFactory.GetCurrectDbContext().SaveChanges();
        }
    }
}
