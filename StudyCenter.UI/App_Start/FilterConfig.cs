using System.Web;
using System.Web.Mvc;
using StudyCenter.UI.Filters;

namespace StudyCenter.UI 
{
    public class FilterConfig 
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) 
        {
            filters.Add(new CustomHandleErrorAttribute());
        }
    }
}