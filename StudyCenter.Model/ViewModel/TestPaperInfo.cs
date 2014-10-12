using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudyCenter.UI.ViewModel
{
    public class TestPaperInfo
    {
        public IEnumerable<SelectListItem> BigCategory { get; set; }
        public IEnumerable<SelectListItem> Courses { get; set; }
        public IEnumerable<SelectListItem> SmallCategory { get; set; }
    }
}