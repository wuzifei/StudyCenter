using System.Collections.Specialized;
using StudyCenter.Model;
using StudyCenter.Model.ViewModel;

namespace StudyCenter.IBLL
{
    public partial interface  ITestPaperService
    {
        /// <summary>
        /// 保存用户的答案，并返回相应的含有答案的实体
        /// </summary>
        /// <param name="testpaperId">试卷Id</param>
        /// <param name="userId">用户Id</param>
        /// <param name="form">Request.Form</param>
        /// <returns>AnswerTestpaper</returns>
        AnswerTestpaper SaveAnswer(int testpaperId,int userId,NameValueCollection form);

        /// <summary>
        /// 比较答案，正确返回true，否则返回false
        /// </summary>
        /// <param name="answer">正确答案</param>
        /// <param name="userAnswer">用户答案</param>
        /// <param name="qType">问题种类：仅支持选择题和判断题</param>
        /// <returns>答案是否正确</returns>
        bool CompareAnswer(string answer, string userAnswer, QuestionType qType);
    }
}
