using System.Collections.Generic;
using StudyCenter.UI.ViewModel;

namespace StudyCenter.Model.ViewModel
{
    public class TestPaperDo
    {
        public TestPaper TestPaper { get; set; }
        public List<BigQuestionInfo> BigQuestionInfos { get; set; }
        public int Score { get; set; }
        public int SmallQuestionCount { get; set; }
        public string CategoryName { get; set; }
        public string NoticeFromSchool { get; set; }
    }
}