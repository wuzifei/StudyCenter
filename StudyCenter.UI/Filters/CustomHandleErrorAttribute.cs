using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudyCenter.Model.ViewModel;
using StudyCenter.UI.ViewModel;

namespace StudyCenter.UI.Filters
{
    public class CustomHandleErrorAttribute:HandleErrorAttribute
    {
        public  override void OnException(ExceptionContext filterContext)
        {
            //对错误进行日志
            var log = log4net.LogManager.GetLogger("DefaultErrorHandle");
            //记录到数据库(只有Error及以上才会记录进数据)
            log.Error(filterContext.Exception.ToString());
            //记录到文件(Debug及以上都会记录到文件中)
            log.Debug(filterContext.Exception.ToString());
            base.OnException(filterContext);
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                OperateContext.RedirectAjax(new AjaxMessage()
                {
                    Data = null,
                    BackUrl = "",
                    Message = "服务器错误!",
                    Status = "error"
                });
            }
            else
            {
                filterContext.HttpContext.Response.Redirect("/shared/error");
            }
        }
    }
}