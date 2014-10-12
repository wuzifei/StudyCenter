
using StudyCenter.IDAL;
using StudyCenter.EFDAL;

namespace StudyCenter.DalFactory
{
	/// <summary>
	/// 数据仓储类，所有实体的数据操作都可以从这里获取
	/// </summary>
	public partial class DbSession:IDbSession
	{
	
		private IAcademyDal _academyDal;
		public  IAcademyDal Academy 
		{
			get
			{
				if(_academyDal != null)
					return _academyDal;
				_academyDal = new AcademyDal();
				return _academyDal;
			}
		}
	
		private IAnswerDal _answerDal;
		public  IAnswerDal Answer 
		{
			get
			{
				if(_answerDal != null)
					return _answerDal;
				_answerDal = new AnswerDal();
				return _answerDal;
			}
		}
	
		private IArticleDal _articleDal;
		public  IArticleDal Article 
		{
			get
			{
				if(_articleDal != null)
					return _articleDal;
				_articleDal = new ArticleDal();
				return _articleDal;
			}
		}
	
		private IBigQuestionDal _bigquestionDal;
		public  IBigQuestionDal BigQuestion 
		{
			get
			{
				if(_bigquestionDal != null)
					return _bigquestionDal;
				_bigquestionDal = new BigQuestionDal();
				return _bigquestionDal;
			}
		}
	
		private IChoiceQuestionDal _choicequestionDal;
		public  IChoiceQuestionDal ChoiceQuestion 
		{
			get
			{
				if(_choicequestionDal != null)
					return _choicequestionDal;
				_choicequestionDal = new ChoiceQuestionDal();
				return _choicequestionDal;
			}
		}
	
		private IClassInfoDal _classinfoDal;
		public  IClassInfoDal ClassInfo 
		{
			get
			{
				if(_classinfoDal != null)
					return _classinfoDal;
				_classinfoDal = new ClassInfoDal();
				return _classinfoDal;
			}
		}
	
		private ICommentDal _commentDal;
		public  ICommentDal Comment 
		{
			get
			{
				if(_commentDal != null)
					return _commentDal;
				_commentDal = new CommentDal();
				return _commentDal;
			}
		}
	
		private ICourseDal _courseDal;
		public  ICourseDal Course 
		{
			get
			{
				if(_courseDal != null)
					return _courseDal;
				_courseDal = new CourseDal();
				return _courseDal;
			}
		}
	
		private IDepartmentDal _departmentDal;
		public  IDepartmentDal Department 
		{
			get
			{
				if(_departmentDal != null)
					return _departmentDal;
				_departmentDal = new DepartmentDal();
				return _departmentDal;
			}
		}
	
		private IFileDal _fileDal;
		public  IFileDal File 
		{
			get
			{
				if(_fileDal != null)
					return _fileDal;
				_fileDal = new FileDal();
				return _fileDal;
			}
		}
	
		private IFillingQuestionDal _fillingquestionDal;
		public  IFillingQuestionDal FillingQuestion 
		{
			get
			{
				if(_fillingquestionDal != null)
					return _fillingquestionDal;
				_fillingquestionDal = new FillingQuestionDal();
				return _fillingquestionDal;
			}
		}
	
		private IFriendDal _friendDal;
		public  IFriendDal Friend 
		{
			get
			{
				if(_friendDal != null)
					return _friendDal;
				_friendDal = new FriendDal();
				return _friendDal;
			}
		}
	
		private IItemDal _itemDal;
		public  IItemDal Item 
		{
			get
			{
				if(_itemDal != null)
					return _itemDal;
				_itemDal = new ItemDal();
				return _itemDal;
			}
		}
	
		private ILogDal _logDal;
		public  ILogDal Log 
		{
			get
			{
				if(_logDal != null)
					return _logDal;
				_logDal = new LogDal();
				return _logDal;
			}
		}
	
		private IPaperCategoryDal _papercategoryDal;
		public  IPaperCategoryDal PaperCategory 
		{
			get
			{
				if(_papercategoryDal != null)
					return _papercategoryDal;
				_papercategoryDal = new PaperCategoryDal();
				return _papercategoryDal;
			}
		}
	
		private IPermissionDal _permissionDal;
		public  IPermissionDal Permission 
		{
			get
			{
				if(_permissionDal != null)
					return _permissionDal;
				_permissionDal = new PermissionDal();
				return _permissionDal;
			}
		}
	
		private IRoleDal _roleDal;
		public  IRoleDal Role 
		{
			get
			{
				if(_roleDal != null)
					return _roleDal;
				_roleDal = new RoleDal();
				return _roleDal;
			}
		}
	
		private IShortQuestionDal _shortquestionDal;
		public  IShortQuestionDal ShortQuestion 
		{
			get
			{
				if(_shortquestionDal != null)
					return _shortquestionDal;
				_shortquestionDal = new ShortQuestionDal();
				return _shortquestionDal;
			}
		}
	
		private ISmallQuestionDal _smallquestionDal;
		public  ISmallQuestionDal SmallQuestion 
		{
			get
			{
				if(_smallquestionDal != null)
					return _smallquestionDal;
				_smallquestionDal = new SmallQuestionDal();
				return _smallquestionDal;
			}
		}
	
		private ISpecialPermissionDal _specialpermissionDal;
		public  ISpecialPermissionDal SpecialPermission 
		{
			get
			{
				if(_specialpermissionDal != null)
					return _specialpermissionDal;
				_specialpermissionDal = new SpecialPermissionDal();
				return _specialpermissionDal;
			}
		}
	
		private IStudentPaperDal _studentpaperDal;
		public  IStudentPaperDal StudentPaper 
		{
			get
			{
				if(_studentpaperDal != null)
					return _studentpaperDal;
				_studentpaperDal = new StudentPaperDal();
				return _studentpaperDal;
			}
		}
	
		private ITestPaperDal _testpaperDal;
		public  ITestPaperDal TestPaper 
		{
			get
			{
				if(_testpaperDal != null)
					return _testpaperDal;
				_testpaperDal = new TestPaperDal();
				return _testpaperDal;
			}
		}
	
		private ITestpaperTargetDal _testpapertargetDal;
		public  ITestpaperTargetDal TestpaperTarget 
		{
			get
			{
				if(_testpapertargetDal != null)
					return _testpapertargetDal;
				_testpapertargetDal = new TestpaperTargetDal();
				return _testpapertargetDal;
			}
		}
	
		private ITrueFalseQuestionDal _truefalsequestionDal;
		public  ITrueFalseQuestionDal TrueFalseQuestion 
		{
			get
			{
				if(_truefalsequestionDal != null)
					return _truefalsequestionDal;
				_truefalsequestionDal = new TrueFalseQuestionDal();
				return _truefalsequestionDal;
			}
		}
	
		private IUserDal _userDal;
		public  IUserDal User 
		{
			get
			{
				if(_userDal != null)
					return _userDal;
				_userDal = new UserDal();
				return _userDal;
			}
		}
	
		private IUserInfoDal _userinfoDal;
		public  IUserInfoDal UserInfo 
		{
			get
			{
				if(_userinfoDal != null)
					return _userinfoDal;
				_userinfoDal = new UserInfoDal();
				return _userinfoDal;
			}
		}
	
		private IUserItemDal _useritemDal;
		public  IUserItemDal UserItem 
		{
			get
			{
				if(_useritemDal != null)
					return _useritemDal;
				_useritemDal = new UserItemDal();
				return _useritemDal;
			}
		}
	
		private IVoteDal _voteDal;
		public  IVoteDal Vote 
		{
			get
			{
				if(_voteDal != null)
					return _voteDal;
				_voteDal = new VoteDal();
				return _voteDal;
			}
		}
	
		private IVoteClassDal _voteclassDal;
		public  IVoteClassDal VoteClass 
		{
			get
			{
				if(_voteclassDal != null)
					return _voteclassDal;
				_voteclassDal = new VoteClassDal();
				return _voteclassDal;
			}
		}
	
		private IVotedDal _votedDal;
		public  IVotedDal Voted 
		{
			get
			{
				if(_votedDal != null)
					return _votedDal;
				_votedDal = new VotedDal();
				return _votedDal;
			}
		}
		}
}