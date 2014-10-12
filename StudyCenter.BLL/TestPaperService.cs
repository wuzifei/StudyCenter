using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyCenter.Model;
using StudyCenter.Model.ViewModel;

namespace StudyCenter.BLL
{
    partial class TestPaperService
    {
        public AnswerTestpaper SaveAnswer(int testpaperId, int userId,NameValueCollection form)
        {
            #region 试卷数据准备
            //查询相应试卷
            var testpaper = BllFactory.Current.TestPaperService.LoadEntities(t => t.ID == testpaperId).FirstOrDefault();
            //查询试卷所有大题
            var bigQuestions =
                BllFactory.Current.BigQuestionService.LoadEntities(b => b.TestPaperID == testpaperId).ToArray();
            //查询大题所有的小题
            var smallQuestions = new List<SmallQuestion>();
            foreach (var bigQuestion in bigQuestions)
            {
                var smallQuestion =
                    BllFactory.Current.SmallQuestionService.LoadEntities(s => s.BigQuestionID == bigQuestion.ID)
                        .ToArray();
                smallQuestions.AddRange(smallQuestion);
            }
            //获取试卷所有试题信息
            var cqId = from c in smallQuestions where c.QuestionType == QuestionType.ChoiceQuestion select c.QuestionID;
            var fqId = from c in smallQuestions where c.QuestionType == QuestionType.FillingQuestion select c.QuestionID;
            var tqId = from c in smallQuestions where c.QuestionType == QuestionType.TrueFalseQuestion select c.QuestionID;
            var sqId = from c in smallQuestions where c.QuestionType == QuestionType.ShortQuestion select c.QuestionID;
            var cqList = BllFactory.Current.ChoiceQuestionService.LoadEntities(cq => cq.IsDeleted == 0 && cqId.Contains(cq.ID)).ToArray();
            var fqList = BllFactory.Current.FillingQuestionService.LoadEntities(cq => cq.IsDeleted == 0 && fqId.Contains(cq.ID)).ToArray();
            var tqList = BllFactory.Current.TrueFalseQuestionService.LoadEntities(cq => cq.IsDeleted == 0 && tqId.Contains(cq.ID)).ToArray();
            var sqList = BllFactory.Current.ShortQuestionService.LoadEntities(cq => cq.IsDeleted == 0 && sqId.Contains(cq.ID)).ToArray();
            #endregion 

            #region 对比客观题答案，客观评分，并将答案存入数据库
            var oldStudentPaper = BllFactory.Current.StudentPaperService.LoadEntities(sp => sp.TestPaperID == testpaperId && sp.UserID == userId)
                .ToArray().FirstOrDefault();
            //删除原有的答案
            if (oldStudentPaper != null)
            {
                foreach (var bigQuestion in bigQuestions)
                {
                    BigQuestion question = bigQuestion;
                    BllFactory.Current.AnswerService.Delete(a => a.BigQuestionID == question.ID);
                }
                BllFactory.Current.AnswerService.Savechanges();
            }
				//保存新提交的答案，并重新评分 
            int allScore;
            var answerList = AnswerList(userId, form, smallQuestions, cqList, tqList, out allScore);
            #endregion

            #region 添加或更新学生答卷 更新时将删除原有该试卷所有试题的用户答案
            StudentPaper newStudentPaper ;
            //数据库中已经有，则更新
            if (oldStudentPaper!=null)
            {
                oldStudentPaper.PaperScore = (short) allScore;
                oldStudentPaper.StartTime = DateTime.Now;
                oldStudentPaper.SubmitTime = DateTime.Now;
                BllFactory.Current.StudentPaperService.Update(oldStudentPaper);
                newStudentPaper = oldStudentPaper;
            }
            else//第一次提交试卷
            {
                var studentPaper = new StudentPaper()
                                        {
                                            PaperScore = (short)allScore,
                                            IsDeleted = 0,
                                            Remark = "",
                                            //TODO:开始做卷时间
                                            StartTime = DateTime.Now,
                                            SubmitTime = DateTime.Now,
                                            TeacherWords = "",
                                            TestPaperID = testpaperId,
                                            UserID = userId,
                                        };
                BllFactory.Current.StudentPaperService.Add(studentPaper);
                newStudentPaper = studentPaper;
            }
            BllFactory.Current.StudentPaperService.Savechanges();
            #endregion

            #region 返回数据，以便生成做题报告
            return new AnswerTestpaper
            {
                StudentPaper = newStudentPaper,
                TestPaper = testpaper,
                UserAnswers = answerList
            };
            #endregion
        }

        //获取答案列表和客观题总分
        private List<Answer> AnswerList(int userId, NameValueCollection form, List<SmallQuestion> smallQuestions, ChoiceQuestion[] cqList,
            TrueFalseQuestion[] tqList, out int allScore)
        {
            var answerList = new List<Answer>();
            foreach (var key in form.AllKeys)
            {
                var userAnswer = form[key];
                var splitValue = key.Split(new[] {'-'}); //key:bqid-CQ-qid
                //Request.Form中还含有其他的不是试题答案的键值对，得忽略
                if (splitValue.Length < 3)
                    continue;
                var qId = int.Parse(splitValue[2]);
                var questionType = QuestionType.ChoiceQuestion;
                var score = 0;
                switch (splitValue[1])
                {
                    case "CQ": //选择题，需客观评分
                        questionType = QuestionType.ChoiceQuestion;
                        var smallquestion = from q in smallQuestions
                            where q.QuestionType == questionType && q.QuestionID == qId
                            select q;
                        var orignalScore = smallquestion.FirstOrDefault().Score;
                        var cQuestion = from cq in cqList where cq.ID == qId select cq;
                        var answer = cQuestion.FirstOrDefault().Answers;
                        if (CompareAnswer(answer, userAnswer, questionType))
                        {
                            score = orignalScore;
                        }
                        break;
                    case "FQ":
                        questionType = QuestionType.FillingQuestion;
                        score = -1; //表示未评分
                        break;
                    case "TQ": //判断题，需客观评分
                        questionType = QuestionType.TrueFalseQuestion;
                        var squestion = from q in smallQuestions
                            where q.QuestionType == questionType && q.QuestionID == qId
                            select q;
                        var totalScore = squestion.FirstOrDefault().Score;
                        var tfQuestion = from tq in tqList where tq.ID == qId select tq;
                        var correctaAnswer = tfQuestion.FirstOrDefault().Answers;
                        if (CompareAnswer(correctaAnswer.ToString(), userAnswer, questionType))
                        {
                            score = totalScore;
                        }
                        break;
                    case "SQ":
                        questionType = QuestionType.ShortQuestion;
                        score = -1; //表示未评分
                        break;
                }


                //需存入数据库中的用户答案列表
                answerList.Add(new Answer()
                {
                    AnswerContent = userAnswer,
                    BigQuestionID = int.Parse(splitValue[0]),
                    QuestionID = int.Parse(splitValue[2]),
                    //TODO:该题得分
                    Score = (short?) score,
                    QuestionType = questionType,
                    SubTime = DateTime.Now,
                    UserID = userId
                });
            }
            //统计试卷所得分
            allScore = 0;
            //保存到数据库
            foreach (var answer in answerList)
            {
                if (answer.Score != -1 && answer.Score.HasValue)
                    allScore += (int) answer.Score;
                BllFactory.Current.AnswerService.Add(answer);
            }
            BllFactory.Current.AnswerService.Savechanges();
            return answerList;
        }

        public bool CompareAnswer(string answer, string userAnswer, QuestionType qType)
        {
            var isTrue = true;
            if (qType == QuestionType.ChoiceQuestion)//选择题判断对错
            {
                var userAnswerArray = userAnswer.Split(new[] {','},StringSplitOptions.RemoveEmptyEntries);
                var answerArraay = answer.Split(new[] {'|'},StringSplitOptions.RemoveEmptyEntries);
                if (userAnswerArray.Length == answerArraay.Length)
                {
                    foreach (var uaa in userAnswerArray)
                    {
                        if (!answerArraay.Contains(uaa))
                        {
                            isTrue = false;
                            break;
                        }
                    }
                }
                else
                {
                    isTrue = false;
                }
            }
            else//判断题
            {
                if (!answer.ToLower().Equals(userAnswer.ToLower()))
                    isTrue = false;
            }
            return isTrue;

        }

    }
}
