using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCenter.Model.ViewModel
{
    public class AnswerTestpaper
    {
        public AnswerTestpaper()
        {
            BigQuestions = new List<BigQuestionInfo>();
            UserAnswers = new List<Answer>();
        }

        public TestPaper TestPaper { get; set; }
        public StudentPaper StudentPaper { get; set; }
        public List<BigQuestionInfo> BigQuestions { get; set; }
        public List<Answer> UserAnswers { get; set; } 
    }
}
