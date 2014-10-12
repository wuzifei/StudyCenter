using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudyCenter.UI.App_Code;

namespace StudyCenter.UI.Controllers
{
    /// <summary>
    /// 自定义的认证控制器基类
    /// </summary>
    public class AuthorizedController : Controller
    {
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!OperateContext.Current.IsLogin())
            {
                filterContext.Result = new RedirectResult("/user/login");
            }
            else
                filterContext.Controller.ViewBag.UserName = OperateContext.Current.CurrentUser.UserName;
        }
    }
}
