using System.Collections.Generic;

namespace StudyCenter.Model.ViewModel
{
    public class TestPaperIndex
    {
        public Pagination Pagination { get; set; }
        public IEnumerable<TestPaper> TestPapers { get; set; }
    }
}