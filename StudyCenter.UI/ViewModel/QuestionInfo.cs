using System;
using System.Collections.Generic;

namespace StudyCenter.UI.ViewModel
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
        public List<String> Choices { get; set; }
        public bool? IsMutilSelect { get; set; }
        public int Score { get; set; }
    }
}