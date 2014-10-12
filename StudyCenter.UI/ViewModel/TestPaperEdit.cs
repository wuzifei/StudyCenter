using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudyCenter.Model;

namespace StudyCenter.UI.ViewModel
{
    public class TestPaperEdit
    {
        public TestPaper TestPaper { get; set; }
        public List<BigQuestionInfo> BigQuestions { get; set; }
        public TestPaperInfo PaperData { get; set; }
        public String JavaScript { get; set; }
        public String CqList { get; set; }
        public String FqList { get; set; }
        public String TqList { get; set; }
        public String SqList { get; set; }
        public bool IsPublishToAll { get; set; }
    }

    public class BigQuestionInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Remark { get; set; }
        public DateTime SubTime { get; set; }
        public int Score { get; set; }
        public List<QuestionInfo> SmallQustions { get; set; }
    }

}