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
    
    public partial class User
    {
        public  User ToPoco()
        {
            return new User()
            {
              ID = this.ID,
              UserNumber = this.UserNumber,
              UserName = this.UserName,
              NickName = this.NickName,
              UserPwd = this.UserPwd,
              Experiences = this.Experiences,
              Golds = this.Golds,
              LastLoginTime = this.LastLoginTime,
              Email = this.Email,
              SafeQuestion = this.SafeQuestion,
              SafeAnswer = this.SafeAnswer,
              IsDeleted = this.IsDeleted,
              Remark = this.Remark,
              SubTime = this.SubTime,
              IsLocked = this.IsLocked,
              ClassInfoID = this.ClassInfoID,
              IsItemUsedToNickName = this.IsItemUsedToNickName,
              AcademyID = this.AcademyID,
              VoteID = this.VoteID,
              StudentPaper = this.StudentPaper,
              ClassInfo = this.ClassInfo,
              Academy = this.Academy,
              Department = this.Department,
              Role = this.Role,
              VerifyPaper = this.VerifyPaper,
              CheckPaper = this.CheckPaper,
              FillingQuestion = this.FillingQuestion,
              ShortQuestion = this.ShortQuestion,
              TrueFalseQuestion = this.TrueFalseQuestion,
              SpecialPermission = this.SpecialPermission,
              Article = this.Article,
              File = this.File,
              FavoriteArticle = this.FavoriteArticle,
              UserItem = this.UserItem,
              TestPaper = this.TestPaper,
              ChoiceQuestion = this.ChoiceQuestion,
              UserInfo = this.UserInfo,
              Answer = this.Answer,
              Voted = this.Voted,
              Vote = this.Vote,
            };
    
        }
    
    
    }
}
