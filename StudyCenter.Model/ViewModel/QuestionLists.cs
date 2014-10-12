using System.Linq;

namespace StudyCenter.Model.ViewModel
{
    public class QuestionLists
    {
        public IQueryable<Model.ChoiceQuestion> ChoiceQuestions { get; set; }
        public IQueryable<Model.FillingQuestion> FillingQuestions { get; set; }
        public IQueryable<Model.TrueFalseQuestion> TrueFalseQuestions { get; set; }
        public IQueryable<Model.ShortQuestion> ShortQuestions { get; set; }
    }
}