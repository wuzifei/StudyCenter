using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using StudyCenter.UI.App_Code;
using ActionFilterAttribute = System.Web.Http.Filters.ActionFilterAttribute;

namespace StudyCenter.UI.Filters
{
    public class LoginOnlyAttribute:AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!OperateContext.Current.IsLogin())
            {
                filterContext.Result = new RedirectResult("/user/login");
            }
            else
                filterContext.Controller.ViewBag.UserName = OperateContext.Current.CurrentUser.UserName;    
            //base.OnAuthorization(filterContext);
        }
    }
}