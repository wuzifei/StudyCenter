//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudyCenter.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class TestPaper
    {
        public TestPaper()
        {
            this.IsDeleted = 0;
            this.Remark = "请填写说明信息";
            this.PaperName = "试卷";
            this.PaperDescription = "请填写试卷说明信息";
            this.PaperScore = 100;
            this.VerifyBy = new HashSet<User>();
            this.CheckBy = new HashSet<User>();
            this.StudentPaper = new HashSet<StudentPaper>();
            this.BigQuestion = new HashSet<BigQuestion>();
        }
    
        public int ID { get; set; }
        public short IsDeleted { get; set; }
        public Nullable<System.DateTime> SubTime { get; set; }
        public string Remark { get; set; }
        public string PaperName { get; set; }
        public string PaperDescription { get; set; }
        public System.DateTime PaperDate { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
        public short PaperScore { get; set; }
        public Nullable<PaperType> PaperType { get; set; }
        public int PublisherID { get; set; }
        public int CourseID { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public string Knowledge { get; set; }
        public Nullable<int> TestMinutes { get; set; }
    
        public virtual ICollection<User> VerifyBy { get; set; }
        public virtual ICollection<User> CheckBy { get; set; }
        public virtual ICollection<StudentPaper> StudentPaper { get; set; }
        public virtual ICollection<BigQuestion> BigQuestion { get; set; }
        public virtual User Publisher { get; set; }
        public virtual Course Course { get; set; }
    }
}
