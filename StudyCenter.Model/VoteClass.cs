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
    
    public partial class VoteClass
    {
        public VoteClass()
        {
            this.IsDeleted = false;
            this.Remark = "无说明";
            this.Vote = new HashSet<Vote>();
        }
    
        public int ID { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> SubTime { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
    
        public virtual ICollection<Vote> Vote { get; set; }
    }
}
