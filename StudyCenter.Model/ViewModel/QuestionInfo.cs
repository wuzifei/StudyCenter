using System;
using System.Collections.Generic;

namespace StudyCenter.Model.ViewModel
{
    public class QuestionInfo
    {
        public QuestionInfo()
        {
            Choices = new List<string>();
            IsMutilSelect = false;
        }

        /// <summary>
        /// 相应问题的主键ID，并非小题ID
        /// </summary>
        public int Id { get; set; }
        public String Title { get; set; }
        public String Answer { get; set; }
        public String QuestionType { get; set; }
        /// <summary>
        /// 只有选择题才有选项，其他题型默认为空
        /// </summary>
        public List<String> Choices { get; set; }
        /// <summary>
        /// 只有选择题才有选项，其他题型默认为空
        /// </summary>
        public bool? IsMutilSelect { get; set; }
        public int Score { get; set; }

        /// <summary>
        /// 问题的Enum类型
        /// </summary>
        public QuestionType EnumQuestionType { get; set; }

        /// <summary>
        /// 用户答案
        /// </summary>
        public String UserAnswer { get; set; }
        /// <summary>
        /// 所属大题Id
        /// </summary>
        public int BigQuestionId { get; set; }
        /// <summary>
        /// 所属试卷Id
        /// </summary>
        public int TestPaperId { get; set; }
        /// <summary>
        /// Question.Remark 试题详解
        /// </summary>
        public String QuestionRemark { get; set; }
        /// <summary>
        /// Answer.Score 获得分数
        /// </summary>
        public int GetScore { get; set; }

		/// <summary>
		/// 答案状态
		/// </summary>
		public AnswerStatus AnswerStatus
		{
			get;
			set;
		}
    }

	public enum AnswerStatus
	{
		Yes,
		Wrong,
		UnCorrect,
		SomeRight,
	}
}