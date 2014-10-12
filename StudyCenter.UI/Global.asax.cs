using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using log4net;
using StudyCenter.Common;
using StudyCenter.Model;
using StudyCenter.UI.App_Code;
using StudyCenter.UI.App_Start;


namespace StudyCenter.UI 
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication 
    {
        protected void Application_Start() 
        {
            AreaRegistration.RegisterAllAreas();

            //数据库数据初始化,没有反应，不知为何
            //var modelContainer = new ModelContainer();
            //modelContainer.Database.Initialize(true);
            //Database.SetInitializer(new MyDatabaseInit<ModelContainer>());

            //初始化log4net
            log4net.Config.XmlConfigurator.Configure();
            //初始化Spring.net
            SpringHelper.SpringInit("~/App_Start/Objects.xml");

            ////自定义数据库初始化
            //var db = new MyDatabaseInit<ModelContainer>();
            //db.Seed(new ModelContainer());

            ////映射关系初始化
            //var er = new MyEntityRelationInit<ModelContainer>();

            ////加载外键实体测试
            //var dbReference = new DbReference();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }

        protected void Application_Error()
        {
            
        }
    }
}