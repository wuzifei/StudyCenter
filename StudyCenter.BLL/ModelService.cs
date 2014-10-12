
 
using StudyCenter.Model;
using StudyCenter.DalFactory;
using StudyCenter.IBLL;
using StudyCenter.IDAL;


namespace StudyCenter.BLL
{
   
	 public partial class AcademyService : BaseService<Academy>,IAcademyService
    {
		//设置为私有变量是一种方法，但效率低
		//是否可以设置为线程内唯一呢？
		//private IDbSession _dbSession;
		//public override void SetDal()
		//{
		//	if(_dbSession==null)
		//		//此处建议使用依赖注入
		//		//不然仍然是强耦合
		//		_dbSession = new DbSession();
		//	else
		//		CurrentDal=_dbSession.Academy;
		//直接使用工厂获取，而且是线程唯一实例，提升效率
		public override void SetDal()
		{
			CurrentDal = DbSessionFactory.GetCurrentDbSession().Academy;
		}
    }	
	 public partial class AnswerService : BaseService<Answer>,IAnswerService
    {
		//设置为私有变量是一种方法，但效率低
		//是否可以设置为线程内唯一呢？
		//private IDbSession _dbSession;
		//public override void SetDal()
		//{
		//	if(_dbSession==null)
		//		//此处建议使用依赖注入
		//		//不然仍然是强耦合
		//		_dbSession = new DbSession();
		//	else
		//		CurrentDal=_dbSession.Answer;
		//直接使用工厂获取，而且是线程唯一实例，提升效率
		public override void SetDal()
		{
			CurrentDal = DbSessionFactory.GetCurrentDbSession().Answer;
		}
    }	
	 public partial class ArticleService : BaseService<Article>,IArticleService
    {
		//设置为私有变量是一种方法，但效率低
		//是否可以设置为线程内唯一呢？
		//private IDbSession _dbSession;
		//public override void SetDal()
		//{
		//	if(_dbSession==null)
		//		//此处建议使用依赖注入
		//		//不然仍然是强耦合
		//		_dbSession = new DbSession();
		//	else
		//		CurrentDal=_dbSession.Article;
		//直接使用工厂获取，而且是线程唯一实例，提升效率
		public override void SetDal()
		{
			CurrentDal = DbSessionFactory.GetCurrentDbSession().Article;
		}
    }	
	 public partial class BigQuestionService : BaseService<BigQuestion>,IBigQuestionService
    {
		//设置为私有变量是一种方法，但效率低
		//是否可以设置为线程内唯一呢？
		//private IDbSession _dbSession;
		//public override void SetDal()
		//{
		//	if(_dbSession==null)
		//		//此处建议使用依赖注入
		//		//不然仍然是强耦合
		//		_dbSession = new DbSession();
		//	else
		//		CurrentDal=_dbSession.BigQuestion;
		//直接使用工厂获取，而且是线程唯一实例，提升效率
		public override void SetDal()
		{
			CurrentDal = DbSessionFactory.GetCurrentDbSession().BigQuestion;
		}
    }	
	 public partial class ChoiceQuestionService : BaseService<ChoiceQuestion>,IChoiceQuestionService
    {
		//设置为私有变量是一种方法，但效率低
		//是否可以设置为线程内唯一呢？
		//private IDbSession _dbSession;
		//public override void SetDal()
		//{
		//	if(_dbSession==null)
		//		//此处建议使用依赖注入
		//		//不然仍然是强耦合
		//		_dbSession = new DbSession();
		//	else
		//		CurrentDal=_dbSession.ChoiceQuestion;
		//直接使用工厂获取，而且是线程唯一实例，提升效率
		public override void SetDal()
		{
			CurrentDal = DbSessionFactory.GetCurrentDbSession().ChoiceQuestion;
		}
    }	
	 public partial class ClassInfoService : BaseService<ClassInfo>,IClassInfoService
    {
		//设置为私有变量是一种方法，但效率低
		//是否可以设置为线程内唯一呢？
		//private IDbSession _dbSession;
		//public override void SetDal()
		//{
		//	if(_dbSession==null)
		//		//此处建议使用依赖注入
		//		//不然仍然是强耦合
		//		_dbSession = new DbSession();
		//	else
		//		CurrentDal=_dbSession.ClassInfo;
		//直接使用工厂获取，而且是线程唯一实例，提升效率
		public override void SetDal()
		{
			CurrentDal = DbSessionFactory.GetCurrentDbSession().ClassInfo;
		}
    }	
	 public partial class CommentService : BaseService<Comment>,ICommentService
    {
		//设置为私有变量是一种方法，但效率低
		//是否可以设置为线程内唯一呢？
		//private IDbSession _dbSession;
		//public override void SetDal()
		//{
		//	if(_dbSession==null)
		//		//此处建议使用依赖注入
		//		//不然仍然是强耦合
		//		_dbSession = new DbSession();
		//	else
		//		CurrentDal=_dbSession.Comment;
		//直接使用工厂获取，而且是线程唯一实例，提升效率
		public override void SetDal()
		{
			CurrentDal = DbSessionFactory.GetCurrentDbSession().Comment;
		}
    }	
	 public partial class CourseService : BaseService<Course>,ICourseService
    {
		//设置为私有变量是一种方法，但效率低
		//是否可以设置为线程内唯一呢？
		//private IDbSession _dbSession;
		//public override void SetDal()
		//{
		//	if(_dbSession==null)
		//		//此处建议使用依赖注入
		//		//不然仍然是强耦合
		//		_dbSession = new DbSession();
		//	else
		//		CurrentDal=_dbSession.Course;
		//直接使用工厂获取，而且是线程唯一实例，提升效率
		public override void SetDal()
		{
			CurrentDal = DbSessionFactory.GetCurrentDbSession().Course;
		}
    }	
	 public partial class DepartmentService : BaseService<Department>,IDepartmentService
    {
		//设置为私有变量是一种方法，但效率低
		//是否可以设置为线程内唯一呢？
		//private IDbSession _dbSession;
		//public override void SetDal()
		//{
		//	if(_dbSession==null)
		//		//此处建议使用依赖注入
		//		//不然仍然是强耦合
		//		_dbSession = new DbSession();
		//	else
		//		CurrentDal=_dbSession.Department;
		//直接使用工厂获取，而且是线程唯一实例，提升效率
		public override void SetDal()
		{
			CurrentDal = DbSessionFactory.GetCurrentDbSession().Department;
		}
    }	
	 public partial class FileService : BaseService<File>,IFileService
    {
		//设置为私有变量是一种方法，但效率低
		//是否可以设置为线程内唯一呢？
		//private IDbSession _dbSession;
		//public override void SetDal()
		//{
		//	if(_dbSession==null)
		//		//此处建议使用依赖注入
		//		//不然仍然是强耦合
		//		_dbSession = new DbSession();
		//	else
		//		CurrentDal=_dbSession.File;
		//直接使用工厂获取，而且是线程唯一实例，提升效率
		public override void SetDal()
		{
			CurrentDal = DbSessionFactory.GetCurrentDbSession().File;
		}
    }	
	 public partial class FillingQuestionService : BaseService<FillingQuestion>,IFillingQuestionService
    {
		//设置为私有变量是一种方法，但效率低
		//是否可以设置为线程内唯一呢？
		//private IDbSession _dbSession;
		//public override void SetDal()
		//{
		//	if(_dbSession==null)
		//		//此处建议使用依赖注入
		//		//不然仍然是强耦合
		//		_dbSession = new DbSession();
		//	else
		//		CurrentDal=_dbSession.FillingQuestion;
		//直接使用工厂获取，而且是线程唯一实例，提升效率
		public override void SetDal()
		{
			CurrentDal = DbSessionFactory.GetCurrentDbSession().FillingQuestion;
		}
    }	
	 public partial class FriendService : BaseService<Friend>,IFriendService
    {
		//设置为私有变量是一种方法，但效率低
		//是否可以设置为线程内唯一呢？
		//private IDbSession _dbSession;
		//public override void SetDal()
		//{
		//	if(_dbSession==null)
		//		//此处建议使用依赖注入
		//		//不然仍然是强耦合
		//		_dbSession = new DbSession();
		//	else
		//		CurrentDal=_dbSession.Friend;
		//直接使用工厂获取，而且是线程唯一实例，提升效率
		public override void SetDal()
		{
			CurrentDal = DbSessionFactory.GetCurrentDbSession().Friend;
		}
    }	
	 public partial class ItemService : BaseService<Item>,IItemService
    {
		//设置为私有变量是一种方法，但效率低
		//是否可以设置为线程内唯一呢？
		//private IDbSession _dbSession;
		//public override void SetDal()
		//{
		//	if(_dbSession==null)
		//		//此处建议使用依赖注入
		//		//不然仍然是强耦合
		//		_dbSession = new DbSession();
		//	else
		//		CurrentDal=_dbSession.Item;
		//直接使用工厂获取，而且是线程唯一实例，提升效率
		public override void SetDal()
		{
			CurrentDal = DbSessionFactory.GetCurrentDbSession().Item;
		}
    }	
	 public partial class LogService : BaseService<Log>,ILogService
    {
		//设置为私有变量是一种方法，但效率低
		//是否可以设置为线程内唯一呢？
		//private IDbSession _dbSession;
		//public override void SetDal()
		//{
		//	if(_dbSession==null)
		//		//此处建议使用依赖注入
		//		//不然仍然是强耦合
		//		_dbSession = new DbSession();
		//	else
		//		CurrentDal=_dbSession.Log;
		//直接使用工厂获取，而且是线程唯一实例，提升效率
		public override void SetDal()
		{
			CurrentDal = DbSessionFactory.GetCurrentDbSession().Log;
		}
    }	
	 public partial class PaperCategoryService : BaseService<PaperCategory>,IPaperCategoryService
    {
		//设置为私有变量是一种方法，但效率低
		//是否可以设置为线程内唯一呢？
		//private IDbSession _dbSession;
		//public override void SetDal()
		//{
		//	if(_dbSession==null)
		//		//此处建议使用依赖注入
		//		//不然仍然是强耦合
		//		_dbSession = new DbSession();
		//	else
		//		CurrentDal=_dbSession.PaperCategory;
		//直接使用工厂获取，而且是线程唯一实例，提升效率
		public override void SetDal()
		{
			CurrentDal = DbSessionFactory.GetCurrentDbSession().PaperCategory;
		}
    }	
	 public partial class PermissionService : BaseService<Permission>,IPermissionService
    {
		//设置为私有变量是一种方法，但效率低
		//是否可以设置为线程内唯一呢？
		//private IDbSession _dbSession;
		//public override void SetDal()
		//{
		//	if(_dbSession==null)
		//		//此处建议使用依赖注入
		//		//不然仍然是强耦合
		//		_dbSession = new DbSession();
		//	else
		//		CurrentDal=_dbSession.Permission;
		//直接使用工厂获取，而且是线程唯一实例，提升效率
		public override void SetDal()
		{
			CurrentDal = DbSessionFactory.GetCurrentDbSession().Permission;
		}
    }	
	 public partial class RoleService : BaseService<Role>,IRoleService
    {
		//设置为私有变量是一种方法，但效率低
		//是否可以设置为线程内唯一呢？
		//private IDbSession _dbSession;
		//public override void SetDal()
		//{
		//	if(_dbSession==null)
		//		//此处建议使用依赖注入
		//		//不然仍然是强耦合
		//		_dbSession = new DbSession();
		//	else
		//		CurrentDal=_dbSession.Role;
		//直接使用工厂获取，而且是线程唯一实例，提升效率
		public override void SetDal()
		{
			CurrentDal = DbSessionFactory.GetCurrentDbSession().Role;
		}
    }	
	 public partial class ShortQuestionService : BaseService<ShortQuestion>,IShortQuestionService
    {
		//设置为私有变量是一种方法，但效率低
		//是否可以设置为线程内唯一呢？
		//private IDbSession _dbSession;
		//public override void SetDal()
		//{
		//	if(_dbSession==null)
		//		//此处建议使用依赖注入
		//		//不然仍然是强耦合
		//		_dbSession = new DbSession();
		//	else
		//		CurrentDal=_dbSession.ShortQuestion;
		//直接使用工厂获取，而且是线程唯一实例，提升效率
		public override void SetDal()
		{
			CurrentDal = DbSessionFactory.GetCurrentDbSession().ShortQuestion;
		}
    }	
	 public partial class SmallQuestionService : BaseService<SmallQuestion>,ISmallQuestionService
    {
		//设置为私有变量是一种方法，但效率低
		//是否可以设置为线程内唯一呢？
		//private IDbSession _dbSession;
		//public override void SetDal()
		//{
		//	if(_dbSession==null)
		//		//此处建议使用依赖注入
		//		//不然仍然是强耦合
		//		_dbSession = new DbSession();
		//	else
		//		CurrentDal=_dbSession.SmallQuestion;
		//直接使用工厂获取，而且是线程唯一实例，提升效率
		public override void SetDal()
		{
			CurrentDal = DbSessionFactory.GetCurrentDbSession().SmallQuestion;
		}
    }	
	 public partial class SpecialPermissionService : BaseService<SpecialPermission>,ISpecialPermissionService
    {
		//设置为私有变量是一种方法，但效率低
		//是否可以设置为线程内唯一呢？
		//private IDbSession _dbSession;
		//public override void SetDal()
		//{
		//	if(_dbSession==null)
		//		//此处建议使用依赖注入
		//		//不然仍然是强耦合
		//		_dbSession = new DbSession();
		//	else
		//		CurrentDal=_dbSession.SpecialPermission;
		//直接使用工厂获取，而且是线程唯一实例，提升效率
		public override void SetDal()
		{
			CurrentDal = DbSessionFactory.GetCurrentDbSession().SpecialPermission;
		}
    }	
	 public partial class StudentPaperService : BaseService<StudentPaper>,IStudentPaperService
    {
		//设置为私有变量是一种方法，但效率低
		//是否可以设置为线程内唯一呢？
		//private IDbSession _dbSession;
		//public override void SetDal()
		//{
		//	if(_dbSession==null)
		//		//此处建议使用依赖注入
		//		//不然仍然是强耦合
		//		_dbSession = new DbSession();
		//	else
		//		CurrentDal=_dbSession.StudentPaper;
		//直接使用工厂获取，而且是线程唯一实例，提升效率
		public override void SetDal()
		{
			CurrentDal = DbSessionFactory.GetCurrentDbSession().StudentPaper;
		}
    }	
	 public partial class TestPaperService : BaseService<TestPaper>,ITestPaperService
    {
		//设置为私有变量是一种方法，但效率低
		//是否可以设置为线程内唯一呢？
		//private IDbSession _dbSession;
		//public override void SetDal()
		//{
		//	if(_dbSession==null)
		//		//此处建议使用依赖注入
		//		//不然仍然是强耦合
		//		_dbSession = new DbSession();
		//	else
		//		CurrentDal=_dbSession.TestPaper;
		//直接使用工厂获取，而且是线程唯一实例，提升效率
		public override void SetDal()
		{
			CurrentDal = DbSessionFactory.GetCurrentDbSession().TestPaper;
		}
    }	
	 public partial class TestpaperTargetService : BaseService<TestpaperTarget>,ITestpaperTargetService
    {
		//设置为私有变量是一种方法，但效率低
		//是否可以设置为线程内唯一呢？
		//private IDbSession _dbSession;
		//public override void SetDal()
		//{
		//	if(_dbSession==null)
		//		//此处建议使用依赖注入
		//		//不然仍然是强耦合
		//		_dbSession = new DbSession();
		//	else
		//		CurrentDal=_dbSession.TestpaperTarget;
		//直接使用工厂获取，而且是线程唯一实例，提升效率
		public override void SetDal()
		{
			CurrentDal = DbSessionFactory.GetCurrentDbSession().TestpaperTarget;
		}
    }	
	 public partial class TrueFalseQuestionService : BaseService<TrueFalseQuestion>,ITrueFalseQuestionService
    {
		//设置为私有变量是一种方法，但效率低
		//是否可以设置为线程内唯一呢？
		//private IDbSession _dbSession;
		//public override void SetDal()
		//{
		//	if(_dbSession==null)
		//		//此处建议使用依赖注入
		//		//不然仍然是强耦合
		//		_dbSession = new DbSession();
		//	else
		//		CurrentDal=_dbSession.TrueFalseQuestion;
		//直接使用工厂获取，而且是线程唯一实例，提升效率
		public override void SetDal()
		{
			CurrentDal = DbSessionFactory.GetCurrentDbSession().TrueFalseQuestion;
		}
    }	
	 public partial class UserService : BaseService<User>,IUserService
    {
		//设置为私有变量是一种方法，但效率低
		//是否可以设置为线程内唯一呢？
		//private IDbSession _dbSession;
		//public override void SetDal()
		//{
		//	if(_dbSession==null)
		//		//此处建议使用依赖注入
		//		//不然仍然是强耦合
		//		_dbSession = new DbSession();
		//	else
		//		CurrentDal=_dbSession.User;
		//直接使用工厂获取，而且是线程唯一实例，提升效率
		public override void SetDal()
		{
			CurrentDal = DbSessionFactory.GetCurrentDbSession().User;
		}
    }	
	 public partial class UserInfoService : BaseService<UserInfo>,IUserInfoService
    {
		//设置为私有变量是一种方法，但效率低
		//是否可以设置为线程内唯一呢？
		//private IDbSession _dbSession;
		//public override void SetDal()
		//{
		//	if(_dbSession==null)
		//		//此处建议使用依赖注入
		//		//不然仍然是强耦合
		//		_dbSession = new DbSession();
		//	else
		//		CurrentDal=_dbSession.UserInfo;
		//直接使用工厂获取，而且是线程唯一实例，提升效率
		public override void SetDal()
		{
			CurrentDal = DbSessionFactory.GetCurrentDbSession().UserInfo;
		}
    }	
	 public partial class UserItemService : BaseService<UserItem>,IUserItemService
    {
		//设置为私有变量是一种方法，但效率低
		//是否可以设置为线程内唯一呢？
		//private IDbSession _dbSession;
		//public override void SetDal()
		//{
		//	if(_dbSession==null)
		//		//此处建议使用依赖注入
		//		//不然仍然是强耦合
		//		_dbSession = new DbSession();
		//	else
		//		CurrentDal=_dbSession.UserItem;
		//直接使用工厂获取，而且是线程唯一实例，提升效率
		public override void SetDal()
		{
			CurrentDal = DbSessionFactory.GetCurrentDbSession().UserItem;
		}
    }	
	 public partial class VoteService : BaseService<Vote>,IVoteService
    {
		//设置为私有变量是一种方法，但效率低
		//是否可以设置为线程内唯一呢？
		//private IDbSession _dbSession;
		//public override void SetDal()
		//{
		//	if(_dbSession==null)
		//		//此处建议使用依赖注入
		//		//不然仍然是强耦合
		//		_dbSession = new DbSession();
		//	else
		//		CurrentDal=_dbSession.Vote;
		//直接使用工厂获取，而且是线程唯一实例，提升效率
		public override void SetDal()
		{
			CurrentDal = DbSessionFactory.GetCurrentDbSession().Vote;
		}
    }	
	 public partial class VoteClassService : BaseService<VoteClass>,IVoteClassService
    {
		//设置为私有变量是一种方法，但效率低
		//是否可以设置为线程内唯一呢？
		//private IDbSession _dbSession;
		//public override void SetDal()
		//{
		//	if(_dbSession==null)
		//		//此处建议使用依赖注入
		//		//不然仍然是强耦合
		//		_dbSession = new DbSession();
		//	else
		//		CurrentDal=_dbSession.VoteClass;
		//直接使用工厂获取，而且是线程唯一实例，提升效率
		public override void SetDal()
		{
			CurrentDal = DbSessionFactory.GetCurrentDbSession().VoteClass;
		}
    }	
	 public partial class VotedService : BaseService<Voted>,IVotedService
    {
		//设置为私有变量是一种方法，但效率低
		//是否可以设置为线程内唯一呢？
		//private IDbSession _dbSession;
		//public override void SetDal()
		//{
		//	if(_dbSession==null)
		//		//此处建议使用依赖注入
		//		//不然仍然是强耦合
		//		_dbSession = new DbSession();
		//	else
		//		CurrentDal=_dbSession.Voted;
		//直接使用工厂获取，而且是线程唯一实例，提升效率
		public override void SetDal()
		{
			CurrentDal = DbSessionFactory.GetCurrentDbSession().Voted;
		}
    }	
	
}