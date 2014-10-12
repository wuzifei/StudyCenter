using System.Data.Entity;
using System.Runtime.Remoting.Messaging;
using StudyCenter.Model;

namespace StudyCenter.EFDAL
{
    public class EfDbContextFactory
    {
        public static DbContext GetCurrectDbContext()
        {
            var db = CallContext.GetData("DbContext") as DbContext;
            if (db == null)
            {
                //TODO:建议使用依赖注入
                db = new ModelContainer();
                CallContext.SetData("DbContext",db);
            }
            return db;
        }
    }
}
