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
    
    public partial class Article
    {
        public Article()
        {
            this.IsDeleted = 0;
            this.Remark = "请填写您的说明信息";
            this.Title = "标题";
            this.Content = "内容";
            this.LikePoint = 0;
            this.RecommendPoint = 0;
            this.DislikePoint = 0;
            this.ReadTimes = 0;
            this.IsItemUseToTitle = false;
            this.IsItemUseToContent = false;
            this.Attachment = new HashSet<File>();
            this.CollectUser = new HashSet<User>();
            this.Comment = new HashSet<Comment>();
        }
    
        public int ID { get; set; }
        public short IsDeleted { get; set; }
        public string Remark { get; set; }
        public Nullable<System.DateTime> SubTime { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public Nullable<System.DateTime> PublishTime { get; set; }
        public ArticleType ArticleType { get; set; }
        public Nullable<int> LikePoint { get; set; }
        public int RecommendPoint { get; set; }
        public int DislikePoint { get; set; }
        public int ReadTimes { get; set; }
        public string Tips { get; set; }
        public bool IsItemUseToTitle { get; set; }
        public Nullable<bool> IsItemUseToContent { get; set; }
        public int PublisherID { get; set; }
    
        public virtual User Publisher { get; set; }
        public virtual ICollection<File> Attachment { get; set; }
        public virtual ICollection<User> CollectUser { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
    }
}
