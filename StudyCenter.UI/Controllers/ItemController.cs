using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudyCenter.UI.Controllers
{
    public class ItemController : AuthorizedController
    {
        //
        // GET: /Item/

        public ActionResult Index()
        {
            return View();
        }

    }
}
