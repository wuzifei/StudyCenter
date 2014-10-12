using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace StudyCenter.UI 
{
    public class RouteConfig 
    {
        public static void RegisterRoutes(RouteCollection routes) 
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Question",
                url: "{controller}/{action}/{qType}-{qId}-{qOperateType}",
                defaults: new
                {
                    controller = "Question",
                    action = "Operate",
                    qType = UrlParameter.Optional,//choice,filling,truefalse,short
                    qId = UrlParameter.Optional,//1,2,3...
                    qOperateType = UrlParameter.Optional,//add,delete,update
                }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new {
                    controller = "User",
                    action = "Login",
                    id = UrlParameter.Optional
                }
            );
        }
    }
}