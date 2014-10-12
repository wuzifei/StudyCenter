using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using StudyCenter.Common;
using StudyCenter.IBLL;
using StudyCenter.Model;
using System.Web.SessionState;
using StudyCenter.Model.ViewModel;
using StudyCenter.UI.Filters;
using StudyCenter.UI.ViewModel;

namespace StudyCenter.UI
{
    /// <summary>
    /// 操作上下文
    /// </summary>
    public class OperateContext
    {

        #region Session中的键名
        const string UserCookiePath = "/user/";//用户cookie路径
        const string UserCookiekey = "userId";//用户Id cookie键
        const string UserSessionKey = "userInfo";//用户Session键
        const string UserRoleKey = "userRole";//用户角色键
        const string UserPermissionKey = "userPermission";//用户权限键 
        #endregion
        
        #region 业务仓储 +IBLL.IBLLSession BLLSession
        /// <summary>
        /// 业务仓储
        /// </summary>
        public IBllSession BllSession;

        /// <summary>
        /// 0.2实例构造函数 初始化 业务仓储
        /// </summary>
        public OperateContext()
        {
            BllSession = SpringHelper.GetObject("BllSession")　as IBllSession;
        }
        #endregion

        #region  Http上下文 及 相关属性
        /// <summary>
        /// Http上下文
        /// </summary>
        HttpContext ContextHttp
        {
            get
            {
                return HttpContext.Current;
            }
        }


        HttpRequest Request
        {
            get
            {
                return ContextHttp.Request;
            }
        }

        HttpSessionState Session
        {
            get
            {
                return ContextHttp.Session;
            }
        }
        #endregion

        #region  用户角色 +List<MODEL.Role> UserRole
        // <summary>
        // 用户角色
        // </summary>
        public List<Role> UserRole
        {
            get
            {
                if (Session[UserRoleKey] == null)
                {
                    var userWithRoles = BllSession.UserService.LoadEntities(u => u.ID == CurrentUser.ID, u => u.Role).Single();
                    if (userWithRoles == null)
                        Session[UserRoleKey] = null;
                    else
                    {
                        var userRoles = userWithRoles.Role.ToList();
                        Session[UserRoleKey] = userRoles;
                        return userRoles;
                    }
                    return Session[UserRoleKey] as List<Role>;
                }
                return Session[UserRoleKey] as List<Role>;
            }
            set
            {
                Session[UserRoleKey] = value;
            }
        }
        #endregion

        #region 当前用户对象 +Model.User CurrentUser
        // <summary>
        // 保存了当前用户对象的Session(User),Cookie(UserId)
        // </summary>
        public User CurrentUser
        {
            get
            {
                return Session[UserSessionKey] as User;
            }
            set
            {
                Session[UserSessionKey] = value;
                //保存cookie
                var cookie = new HttpCookie(UserCookiekey);
                //cookie.Path = UserCookiePath;
                cookie.Expires.AddDays(7);
                cookie.Value = value.ID.ToString(CultureInfo.CurrentCulture);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }
        #endregion

        public void LogOut()
        {
            Session[UserSessionKey] = null;
            if (ContextHttp.Request.Cookies[UserCookiekey] != null )
                ContextHttp.Request.Cookies[UserCookiekey].Value = "";
        }

        #region 1.0 获取当前 操作上下文 + OperateContext Current
        /// <summary>
        /// 获取当前 操作上下文 (为每个处理浏览器请求的服务器线程 单独创建 操作上下文)
        /// </summary>
        public static OperateContext Current
        {
            get
            {
                var oContext = CallContext.GetData(typeof(OperateContext).Name) as OperateContext;
                if (oContext == null)
                {
                    oContext = new OperateContext();
                    CallContext.SetData(typeof(OperateContext).Name, oContext);
                }
                return oContext;
            }
        }
        #endregion

        //---------------------------------------------2.0 登陆权限 等系统操作--------------------

        #region 2.0 根据用户角色查询当前登录用户权限 +List<Model.Permission> UserPermission

        /// <summary>
        /// 根据用户角色查询用户权限
        /// </summary>
        private List<Permission> _userPermissions; 
        public List<Permission> UserPermission
        {
            //-------根据用户角色查询
            get
            {
                if (Session[UserPermissionKey] != null)
                    return Session[UserPermissionKey] as List<Permission>;
                _userPermissions = new List<Permission>();
                foreach (var r in UserRole)
                {
                    Role role = r;//因为不同版本EF会可能操作不一致，这样做不会有异常
                    var roleWithPermission = BllSession.RoleService.LoadEntities(rl => rl.ID == role.ID, rl => rl.Permission).SingleOrDefault();
                    if (roleWithPermission != null)
                    {
                        var pers = roleWithPermission.Permission; 
                        foreach (var per in pers)
                        {
                            if(!_userPermissions.Contains(per))
                            _userPermissions.Add(per);
                        }
                    }

                }
                Session[UserPermissionKey] = _userPermissions;
                return _userPermissions;
            }

            set { _userPermissions = value; }
        }
        #endregion


        #region 2.2 判断当前用户是否登陆 +bool IsLogin()
        /// <summary>
        /// 判断当前用户是否登陆 而且
        /// </summary>
        /// <returns></returns>
        public bool IsLogin()
        {
            //1.验证用户是否登陆(Session && Cookie)
            if (Session[UserSessionKey] == null)
            {
                if (Request.Cookies[UserCookiePath] == null)
                {
                    //重新登陆，内部已经调用了 Response.End(),后面的代码都不执行了！ (注意：如果Ajax请求，此处不合适！)
                    return false;
                }
                //如果有cookie则从cookie中获取用户id并查询相关数据存入 Session
                var httpCookie = Request.Cookies[UserCookiekey];
                if (httpCookie != null)
                {
                    var strUserId = httpCookie.Value;
                    var userId = int.Parse(strUserId);
                    var user = BllSession.UserService.LoadEntities(u => u.ID  == userId).FirstOrDefault();
                    if (user == null)
                        return false;
                    Session[UserSessionKey] = user;
                }
                return true;
            }
            return true;
        }
        #endregion


        #region  2.3 判断当前用户 是否有 访问当前页面的权限 +bool HasPemission
        /// <summary>
        /// 2.3 判断当前用户 是否有 访问当前页面的权限
        /// </summary> 
        /// <param name="areaName"></param>
        /// <param name="controllerName"></param>
        /// <param name="actionName"></param>
        /// <param name="httpMethod"></param>
        /// <returns></returns>
        public bool HasPemission(string areaName, string controllerName, string actionName, string httpMethod)
        {
            var listP = from per in UserPermission
                        where
                            string.Equals(per.Area, areaName, StringComparison.CurrentCultureIgnoreCase) &&
                            string.Equals(per.Controoller, controllerName, StringComparison.CurrentCultureIgnoreCase) &&
                            string.Equals(per.Action, actionName, StringComparison.CurrentCultureIgnoreCase) && (
                                per.HttpMethod.ToLower() == "both" ||//如果数据库保存的权限 请求方式 both 代表允许 get/post请求
                                per.HttpMethod.ToLower() == httpMethod.ToLower()
                            )
                        select per;
            return listP.Any();
        }
        #endregion


        //---------------------------------------------3.0 公用操作方法--------------------

        #region 3.1 生成 Json 格式的返回值 +ActionResult RedirectAjax(string statu, string msg, object data, string backurl)
        /// <summary>
        /// 生成 Json 格式的返回值
        /// </summary>
        /// <param name="statu">状态值ok,no</param>
        /// <param name="msg">返回的消息</param>
        /// <param name="data">返回的数据</param>
        /// <param name="backurl">跳转路径</param>
        /// <returns>json数据</returns>
        public static ActionResult RedirectAjax(string statu, string msg, object data, string backurl)
        {
            var ajax = new AjaxMessage()
            {
                Status = statu,
                Message = msg,
                Data = data,
                BackUrl = backurl
            };
             return new JsonResult(){JsonRequestBehavior = JsonRequestBehavior.AllowGet,Data = ajax ,};
        }
        #endregion

        public static ActionResult RedirectAjax(AjaxMessage message)
        {
            return RedirectAjax(message.Status, message.Message,message.Data, message.BackUrl)
            ;
        }

        #region 3.2 重定向方法 根据Action方法特性  +ActionResult Redirect(string url, ActionDescriptor action)
        /// <summary>
        /// 重定向方法 有两种情况：如果是Ajax请求，则返回 Json字符串；如果是普通请求，则 返回重定向命令
        /// </summary>
        /// <returns></returns>
        public ActionResult Redirect(string url, ActionDescriptor action)
        {
            //如果Ajax请求没有权限，就返回 Json消息
            if (action.IsDefined(typeof(AjaxOnlyAttribute), false)
            || action.ControllerDescriptor.IsDefined(typeof(AjaxOnlyAttribute), false))
            {
                return RedirectAjax("Not Login", "您没有登陆或没有权限访问此页面!", null, url);
            }
            //如果 超链接或表单 没有权限访问，则返回 302重定向命令
            return new RedirectResult(url);
        }
        #endregion

    }
}
