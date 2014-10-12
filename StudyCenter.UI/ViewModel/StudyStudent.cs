using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudyCenter.Model;

namespace StudyCenter.UI.ViewModel
{

    public class StudentPaperInfo
    {
        public IEnumerable<StudyStudent> HomeWork {get; set; } 
        public int UndoneHomeWorkCount { get; set; }
        public IEnumerable<StudyStudent> ForTest {get; set; }
        public int UndoneForTestCount { get; set; }
        public IEnumerable<StudyStudent> ToPublic {get; set; }
        public int UndoneToPublicCount { get; set; }

    }

    public class StudyStudent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public DateTime TestDate { get; set; }
        public PaperType? PaperType { get; set; }
        public short TotalScore { get; set; }
        public short GetScore { get; set; }
    }
}