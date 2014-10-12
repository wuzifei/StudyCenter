using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyCenter.UI.ViewModel
{
    public class QuestionLists
    {
        public IQueryable<Model.ChoiceQuestion> ChoiceQuestions { get; set; }
        public IQueryable<Model.FillingQuestion> FillingQuestions { get; set; }
        public IQueryable<Model.TrueFalseQuestion> TrueFalseQuestions { get; set; }
        public IQueryable<Model.ShortQuestion> ShortQuestions { get; set; }
    }
}