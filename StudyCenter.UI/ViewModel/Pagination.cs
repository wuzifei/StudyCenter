using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Policy;
using System.Web;
using System.Web.Routing;
using System.Web.UI;

namespace StudyCenter.UI.ViewModel
{
    /// <summary>
    /// 必须设置的字段：ActionName,ControllerName,TotalRecords
    /// </summary>
    public class Pagination
    {
        private string _actionName = "User";
        /// <summary>
        /// 动作名字
        /// </summary>
        public string ActionName
        {
            get
            {
                return _actionName;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _actionName = value;
            }
        }       
        
        private string _controllerName = "index";
        /// <summary>
        /// 控制器名字
        /// </summary>
        public string ControllerName
        {
            get
            {
                return _controllerName;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _controllerName = value;
            }
        }

        private string _pageUrl = "/user/index";

        public string PageUrl
        {
            get
            {
                _pageUrl = "/" + ControllerName + "/" + ActionName + "/?";
                return _pageUrl;
            }
            set
            {
                if(value!="")
                    _pageUrl = value;
            }
        }

        private int _currentPage = 1;
        /// <summary>
        /// 当前页码
        /// </summary>
        public int CurrentPage 
        {
            get { return _currentPage; }
            set { _currentPage = value; }
        }

        /// <summary>
        /// 下页页码
        /// </summary>
        public int NextPage 
        {
            get
            {
                if (_currentPage < TotalPage)
                    return _currentPage + 1;
                return TotalPage;
            }
        }

        /// <summary>
        /// 上页页码
        /// </summary>
        public int PrePage
        {
            get
            {
                if (CurrentPage > 1)
                    return CurrentPage - 1;
                return 1;
            }
        }

        private int _totalPage = 1;
        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPage 
        {
            get
            {
                if (TotalRecords != 0 && PageSize != 0)
                    _totalPage = (int)Math.Ceiling((double)TotalRecords/PageSize);//进一法
                else
                {
                    _totalPage = 0;
                }
                return _totalPage;
            }
            set {
                _totalPage = (value >1 ? value : 1);
            }
        }

        private int _totalRecords = 1;
        /// <summary>
        /// 所有数据记录个数
        /// </summary>
        public int TotalRecords {
            get { return _totalRecords; }
            set
            {
                if (value > 0)
                    _totalRecords = value;
                else //当为不合法数字时，直接设为0
                    _totalRecords = 0;
            }
        }

        private int _pageSize = 5;
        /// <summary>
        /// 页容量
        /// </summary>
        public int PageSize {
            get { return _pageSize; }
            set
            {
                if(value>0)
                    _pageSize = value;
                else
                {
                    _pageSize = 5;
                }
            }
        }

        public Pagination()
        {
            UrlParameters = new RouteValueDictionary();
            UrlParameters.Add("pageSize",this.PageSize);
            UrlParameters.Add("pageIndex",this.CurrentPage);
            IsAjax = false;
        }

        //默认为false
        public bool IsAjax { get; set; }

        /// <summary>
        /// 分页链接单击JS函数
        /// </summary>
        public string OnClickJsFunction
        {
            get; set;
        }

        /// <summary>
        /// 分页链接的参数，当不需要参数的时候不需要设置该属性
        /// </summary>
        public RouteValueDictionary UrlParameters { get; set; }
    }
}