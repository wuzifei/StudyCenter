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
    
    public partial class Course
    {
        public  Course ToPoco()
        {
            return new Course()
            {
              ID = this.ID,
              IsDeleted = this.IsDeleted,
              SubTime = this.SubTime,
              Remark = this.Remark,
              CourseName = this.CourseName,
              Description = this.Description,
              TestPaper = this.TestPaper,
              ChoiceQuestion = this.ChoiceQuestion,
              FillingQuestion = this.FillingQuestion,
              ShortQuestion = this.ShortQuestion,
              TrueFalseQuestion = this.TrueFalseQuestion,
              Academy = this.Academy,
            };
    
        }
    
    
    }
}
