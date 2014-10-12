using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using StudyCenter.Model;

namespace StudyCenter.UI.ViewModel
{
    public class TestPaperIndex
    {
        public Pagination Pagination { get; set; }
        public IEnumerable<TestPaper> TestPapers { get; set; }
    }
}