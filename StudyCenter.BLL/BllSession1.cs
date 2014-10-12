
 
using StudyCenter.Model;
using StudyCenter.DalFactory;
using StudyCenter.IBLL;
using StudyCenter.IDAL;

namespace StudyCenter.BLL
{
    /// <summary>
    /// 业务仓储,提供所有Dal的入口
    /// </summary>
   	 public partial class BllSession:IBllSession
    {
		private IAcademyService _Academy;
		public IAcademyService AcademyService 
		{
			get
			{
				if( _Academy !=null)
					return  _Academy;
				 _Academy = new  AcademyService();
				 return  _Academy;
			}
		}
  	
		private IAnswerService _Answer;
		public IAnswerService AnswerService 
		{
			get
			{
				if( _Answer !=null)
					return  _Answer;
				 _Answer = new  AnswerService();
				 return  _Answer;
			}
		}
  	
		private IArticleService _Article;
		public IArticleService ArticleService 
		{
			get
			{
				if( _Article !=null)
					return  _Article;
				 _Article = new  ArticleService();
				 return  _Article;
			}
		}
  	
		private IBigQuestionService _BigQuestion;
		public IBigQuestionService BigQuestionService 
		{
			get
			{
				if( _BigQuestion !=null)
					return  _BigQuestion;
				 _BigQuestion = new  BigQuestionService();
				 return  _BigQuestion;
			}
		}
  	
		private IChoiceQuestionService _ChoiceQuestion;
		public IChoiceQuestionService ChoiceQuestionService 
		{
			get
			{
				if( _ChoiceQuestion !=null)
					return  _ChoiceQuestion;
				 _ChoiceQuestion = new  ChoiceQuestionService();
				 return  _ChoiceQuestion;
			}
		}
  	
		private IClassInfoService _ClassInfo;
		public IClassInfoService ClassInfoService 
		{
			get
			{
				if( _ClassInfo !=null)
					return  _ClassInfo;
				 _ClassInfo = new  ClassInfoService();
				 return  _ClassInfo;
			}
		}
  	
		private ICommentService _Comment;
		public ICommentService CommentService 
		{
			get
			{
				if( _Comment !=null)
					return  _Comment;
				 _Comment = new  CommentService();
				 return  _Comment;
			}
		}
  	
		private ICourseService _Course;
		public ICourseService CourseService 
		{
			get
			{
				if( _Course !=null)
					return  _Course;
				 _Course = new  CourseService();
				 return  _Course;
			}
		}
  	
		private IDepartmentService _Department;
		public IDepartmentService DepartmentService 
		{
			get
			{
				if( _Department !=null)
					return  _Department;
				 _Department = new  DepartmentService();
				 return  _Department;
			}
		}
  	
		private IFileService _File;
		public IFileService FileService 
		{
			get
			{
				if( _File !=null)
					return  _File;
				 _File = new  FileService();
				 return  _File;
			}
		}
  	
		private IFillingQuestionService _FillingQuestion;
		public IFillingQuestionService FillingQuestionService 
		{
			get
			{
				if( _FillingQuestion !=null)
					return  _FillingQuestion;
				 _FillingQuestion = new  FillingQuestionService();
				 return  _FillingQuestion;
			}
		}
  	
		private IFriendService _Friend;
		public IFriendService FriendService 
		{
			get
			{
				if( _Friend !=null)
					return  _Friend;
				 _Friend = new  FriendService();
				 return  _Friend;
			}
		}
  	
		private IItemService _Item;
		public IItemService ItemService 
		{
			get
			{
				if( _Item !=null)
					return  _Item;
				 _Item = new  ItemService();
				 return  _Item;
			}
		}
  	
		private ILogService _Log;
		public ILogService LogService 
		{
			get
			{
				if( _Log !=null)
					return  _Log;
				 _Log = new  LogService();
				 return  _Log;
			}
		}
  	
		private IPaperCategoryService _PaperCategory;
		public IPaperCategoryService PaperCategoryService 
		{
			get
			{
				if( _PaperCategory !=null)
					return  _PaperCategory;
				 _PaperCategory = new  PaperCategoryService();
				 return  _PaperCategory;
			}
		}
  	
		private IPermissionService _Permission;
		public IPermissionService PermissionService 
		{
			get
			{
				if( _Permission !=null)
					return  _Permission;
				 _Permission = new  PermissionService();
				 return  _Permission;
			}
		}
  	
		private IRoleService _Role;
		public IRoleService RoleService 
		{
			get
			{
				if( _Role !=null)
					return  _Role;
				 _Role = new  RoleService();
				 return  _Role;
			}
		}
  	
		private IShortQuestionService _ShortQuestion;
		public IShortQuestionService ShortQuestionService 
		{
			get
			{
				if( _ShortQuestion !=null)
					return  _ShortQuestion;
				 _ShortQuestion = new  ShortQuestionService();
				 return  _ShortQuestion;
			}
		}
  	
		private ISmallQuestionService _SmallQuestion;
		public ISmallQuestionService SmallQuestionService 
		{
			get
			{
				if( _SmallQuestion !=null)
					return  _SmallQuestion;
				 _SmallQuestion = new  SmallQuestionService();
				 return  _SmallQuestion;
			}
		}
  	
		private ISpecialPermissionService _SpecialPermission;
		public ISpecialPermissionService SpecialPermissionService 
		{
			get
			{
				if( _SpecialPermission !=null)
					return  _SpecialPermission;
				 _SpecialPermission = new  SpecialPermissionService();
				 return  _SpecialPermission;
			}
		}
  	
		private IStudentPaperService _StudentPaper;
		public IStudentPaperService StudentPaperService 
		{
			get
			{
				if( _StudentPaper !=null)
					return  _StudentPaper;
				 _StudentPaper = new  StudentPaperService();
				 return  _StudentPaper;
			}
		}
  	
		private ITestPaperService _TestPaper;
		public ITestPaperService TestPaperService 
		{
			get
			{
				if( _TestPaper !=null)
					return  _TestPaper;
				 _TestPaper = new  TestPaperService();
				 return  _TestPaper;
			}
		}
  	
		private ITestpaperTargetService _TestpaperTarget;
		public ITestpaperTargetService TestpaperTargetService 
		{
			get
			{
				if( _TestpaperTarget !=null)
					return  _TestpaperTarget;
				 _TestpaperTarget = new  TestpaperTargetService();
				 return  _TestpaperTarget;
			}
		}
  	
		private ITrueFalseQuestionService _TrueFalseQuestion;
		public ITrueFalseQuestionService TrueFalseQuestionService 
		{
			get
			{
				if( _TrueFalseQuestion !=null)
					return  _TrueFalseQuestion;
				 _TrueFalseQuestion = new  TrueFalseQuestionService();
				 return  _TrueFalseQuestion;
			}
		}
  	
		private IUserService _User;
		public IUserService UserService 
		{
			get
			{
				if( _User !=null)
					return  _User;
				 _User = new  UserService();
				 return  _User;
			}
		}
  	
		private IUserInfoService _UserInfo;
		public IUserInfoService UserInfoService 
		{
			get
			{
				if( _UserInfo !=null)
					return  _UserInfo;
				 _UserInfo = new  UserInfoService();
				 return  _UserInfo;
			}
		}
  	
		private IUserItemService _UserItem;
		public IUserItemService UserItemService 
		{
			get
			{
				if( _UserItem !=null)
					return  _UserItem;
				 _UserItem = new  UserItemService();
				 return  _UserItem;
			}
		}
  	
		private IVoteService _Vote;
		public IVoteService VoteService 
		{
			get
			{
				if( _Vote !=null)
					return  _Vote;
				 _Vote = new  VoteService();
				 return  _Vote;
			}
		}
  	
		private IVoteClassService _VoteClass;
		public IVoteClassService VoteClassService 
		{
			get
			{
				if( _VoteClass !=null)
					return  _VoteClass;
				 _VoteClass = new  VoteClassService();
				 return  _VoteClass;
			}
		}
  	
		private IVotedService _Voted;
		public IVotedService VotedService 
		{
			get
			{
				if( _Voted !=null)
					return  _Voted;
				 _Voted = new  VotedService();
				 return  _Voted;
			}
		}
  	
	}
	
}