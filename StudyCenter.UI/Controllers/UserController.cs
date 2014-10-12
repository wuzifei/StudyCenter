using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using StudyCenter.BLL;
using StudyCenter.Common;
using StudyCenter.IBLL;
using StudyCenter.Model;
using StudyCenter.UI.App_Code;
using StudyCenter.UI.Filters;

namespace StudyCenter.UI.Controllers
{
    public class UserController : Controller
    {
        #region 获取userService
        //TODO:建议使用依赖注入
        //抽象工厂和仓储的实现虽然不错,单仍然不能完全解耦合
        //private IUserService userService = BllFactory.Current.UserService;
        //使用Spring就可以了,完全由配置文件决定
        private IUserService userService = SpringHelper.GetObject("UserService") as IUserService;
        //也可以使用下面的
        //private IUserService uService = (SpringHelper.GetObject("BLLSession") as IBllSession).UserService; 
        #endregion

        #region 登陆 Post
        [HttpPost]
        public ActionResult Login(string userId, String userPwd, String vCode)
        {
            //判断验证码是否正确
            var vCodeSession = (string)Session["VCode"];
            if (vCode != vCodeSession)
                return Content("验证码错误");

            //验证用户登录信息是否正确
            int intId;
            User user;
            if (int.TryParse(userId, out intId))
                user = userService.Login(intId, userPwd);
            else
                user = userService.Login(userId, userPwd);

            //登录信息有误
            if (user == null)
                return Content("用户名或密码不正确");
            //登录成功，进行缓存
            OperateContext.Current.CurrentUser = user;

            return Content("ok");
        } 
        #endregion

        #region 登陆页 Get
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        } 
        #endregion

        #region 验证码
        [HttpGet]
        public ActionResult VCode(int id = 0)
        {
            var vCode = new ValidateCode();
            var vcode = vCode.CreateValidateCode(4);
            vcode = "1234";
            Session["VCode"] = vcode;
            return File(vCode.CreateValidateGraphic(vcode), @"image/jpeg");
        } 
        #endregion

        #region 网站首页
        /// <summary>
        /// 网站首页
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [LoginOnly]
        public ActionResult Index()
        {
            //最多六个!!!
            var urls = new List<string>()
			{
				"/content/images/index/1.jpg",
				"/content/images/index/2.jpg",
				"/content/images/index/3.jpg",
				"/content/images/index/4.jpg",
                "/content/images/index/1.jpg",
                "/content/images/index/2.jpg",
			};
            ViewBag.Urls = urls;

            return View();
        } 
        #endregion

        #region 注销登陆
        /// <summary>
        /// 注销登录
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            OperateContext.Current.LogOut(); ;
            return Redirect("/user/login");
        } 
        #endregion

        #region 用户首页
        /// <summary>
        /// 用户首页
        /// </summary>
        /// <returns></returns>
        [LoginOnly]
        public ActionResult Home()
        {
            return View();
        } 
        #endregion
    }
}