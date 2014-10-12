using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudyCenter.BLL;
using StudyCenter.Model;
using StudyCenter.UI.App_Code;

namespace StudyCenter.UI.Tests.BllLogic
{
    [TestClass]
    public class DbReference
    {
        private ModelContainer db = new ModelContainer();
        [TestMethod]
        public void EntityReference()
        {
            var list = BllFactory.Current.UserService.LoadEntities(u => u.IsDeleted == 0, u => u.Role);
            Assert.AreEqual(list.Count(), 2);
        }

        [TestMethod]
        public void DatabaseInit()
        {
            //自定义数据库初始化
            var db = new MyDatabaseInit<ModelContainer>();
            try
            {
                db.Seed(new ModelContainer());
            }
            catch (Exception e)
            {
                var s = e.ToString();
            }

        }

        [TestMethod]
        public void GetModelIds()
        {
            var sb = new StringBuilder("select ID from ChoiceQuestion where ID>0 ");
            var par = new SqlParameter("IsDeleted", 1);
            var name = par.ParameterName;
            par.DbType = DbType.Int16;
            par.Value = 0;
            sb.Append("and " + name + "=" + par.Value);
            var result = db.Database.SqlQuery<AllId>(sb.ToString());
            var finalResult = result.Where(q => q.ID > 10).ToArray();
            var r = result;
            var id = result.FirstOrDefault().ID;
        }

        public class IDS
        {
            public IDS()
            {
            }

            public int ID { get; set; }
        }

        [TestMethod]
        public void ModelIds()
        {
            var ids = BllFactory.Current.SmallQuestionService.GetIds("TestPaperId", 3064);
            var id = ids.FirstOrDefault();
        }

    }
}
