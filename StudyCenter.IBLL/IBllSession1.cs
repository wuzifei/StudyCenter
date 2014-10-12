
 
using StudyCenter.Model;
using StudyCenter.IBLL;

namespace StudyCenter.IBLL
{
   	 public partial interface IBllSession
    {

		IAcademyService AcademyService {get;}
	

		IAnswerService AnswerService {get;}
	

		IArticleService ArticleService {get;}
	

		IBigQuestionService BigQuestionService {get;}
	

		IChoiceQuestionService ChoiceQuestionService {get;}
	

		IClassInfoService ClassInfoService {get;}
	

		ICommentService CommentService {get;}
	

		ICourseService CourseService {get;}
	

		IDepartmentService DepartmentService {get;}
	

		IFileService FileService {get;}
	

		IFillingQuestionService FillingQuestionService {get;}
	

		IFriendService FriendService {get;}
	

		IItemService ItemService {get;}
	

		ILogService LogService {get;}
	

		IPaperCategoryService PaperCategoryService {get;}
	

		IPermissionService PermissionService {get;}
	

		IRoleService RoleService {get;}
	

		IShortQuestionService ShortQuestionService {get;}
	

		ISmallQuestionService SmallQuestionService {get;}
	

		ISpecialPermissionService SpecialPermissionService {get;}
	

		IStudentPaperService StudentPaperService {get;}
	

		ITestPaperService TestPaperService {get;}
	

		ITestpaperTargetService TestpaperTargetService {get;}
	

		ITrueFalseQuestionService TrueFalseQuestionService {get;}
	

		IUserService UserService {get;}
	

		IUserInfoService UserInfoService {get;}
	

		IUserItemService UserItemService {get;}
	

		IVoteService VoteService {get;}
	

		IVoteClassService VoteClassService {get;}
	

		IVotedService VotedService {get;}
	
	}
}