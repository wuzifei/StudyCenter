
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudyCenter.IDAL;
using StudyCenter.Model;

namespace StudyCenter.IDAL
{
	public interface IDbSession
	{
	  IAcademyDal Academy {get;}
	  IAnswerDal Answer {get;}
	  IArticleDal Article {get;}
	  IBigQuestionDal BigQuestion {get;}
	  IChoiceQuestionDal ChoiceQuestion {get;}
	  IClassInfoDal ClassInfo {get;}
	  ICommentDal Comment {get;}
	  ICourseDal Course {get;}
	  IDepartmentDal Department {get;}
	  IFileDal File {get;}
	  IFillingQuestionDal FillingQuestion {get;}
	  IFriendDal Friend {get;}
	  IItemDal Item {get;}
	  ILogDal Log {get;}
	  IPaperCategoryDal PaperCategory {get;}
	  IPermissionDal Permission {get;}
	  IRoleDal Role {get;}
	  IShortQuestionDal ShortQuestion {get;}
	  ISmallQuestionDal SmallQuestion {get;}
	  ISpecialPermissionDal SpecialPermission {get;}
	  IStudentPaperDal StudentPaper {get;}
	  ITestPaperDal TestPaper {get;}
	  ITestpaperTargetDal TestpaperTarget {get;}
	  ITrueFalseQuestionDal TrueFalseQuestion {get;}
	  IUserDal User {get;}
	  IUserInfoDal UserInfo {get;}
	  IUserItemDal UserItem {get;}
	  IVoteDal Vote {get;}
	  IVoteClassDal VoteClass {get;}
	  IVotedDal Voted {get;}
	}
}