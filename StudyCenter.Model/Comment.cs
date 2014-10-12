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
    
    public partial class Comment
    {
        public Comment()
        {
            this.IsHidedByItem = false;
            this.IsDeleted = 0;
            this.Remark = "请填写您的说明信息";
            this.IsItemUsedToComent = false;
        }
    
        public int Id { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public Nullable<bool> IsHidedByItem { get; set; }
        public short IsDeleted { get; set; }
        public string Remark { get; set; }
        public Nullable<System.DateTime> SubTime { get; set; }
        public Nullable<bool> IsItemUsedToComent { get; set; }
        public int ArticleID { get; set; }
    
        public virtual Article Article { get; set; }
    }
}
