using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Microsoft.Ajax.Utilities;
using StudyCenter.BLL;
using StudyCenter.Common;
using StudyCenter.IBLL;
using StudyCenter.Model;
using StudyCenter.Model.ViewModel;
using StudyCenter.UI.App_Code;
using StudyCenter.UI.ViewModel;

namespace StudyCenter.UI.Controllers
{
    public class QuestionController : Controller
    {
        #region 数据服务实例
        private IChoiceQuestionService choiceQuestionService = BllFactory.Current.ChoiceQuestionService;
        private IFillingQuestionService fillingQuestionService = BllFactory.Current.FillingQuestionService;
        private ITrueFalseQuestionService trueFalseQuestionService = BllFactory.Current.TrueFalseQuestionService;
        private IShortQuestionService shortQuestionService = BllFactory.Current.ShortQuestionService;
        private ICourseService courseService = BllFactory.Current.CourseService;
        #endregion

        public ActionResult Index()
        {
            return View();
        }


        #region 根据问题类型和页码获取一页数据
        [HttpGet]
        public ActionResult List(int pageSize, int pageIndex, string questionType="choice")
        {
            pageSize += 1;
            string qType = questionType;
            int total;
            ViewBag.Title = qType;
            var allQuestions = new QuestionLists()
            {
                ChoiceQuestions = null,
                FillingQuestions = null,
                TrueFalseQuestions = null,
                ShortQuestions = null,
            };
            bool isPublic = bool.Parse(Request.QueryString["isPublic"]);
            bool isPersonal = bool.Parse(Request.QueryString["isPersonal"]);
            bool isPersonalAll = bool.Parse(Request.QueryString["isPersonalAll"]);
            var list = new HashSet<User>();
            int userId = OperateContext.Current.CurrentUser.ID; 
            Expression<Func<ChoiceQuestion, bool>> cqWhereLambda = (q => q.IsPublic == isPublic && q.IsDeleted == 0 );
            if(isPersonal)
                cqWhereLambda = (q => q.IsPublic == isPublic && q.IsDeleted == 0 && q.PublisherID == userId);
            if (isPersonal && isPersonalAll)
                cqWhereLambda = (q => q.IsDeleted == 0 && q.PublisherID == userId);
            switch (qType.ToLower())
            {
                case "choice":
                    ViewData["QuestionType"] = "选择题";
                    allQuestions.ChoiceQuestions = choiceQuestionService.LoadPageEntities(pageSize, pageIndex,
                        out total, cqWhereLambda, q => q.SubTime, q => q.Publisher, false);
                    break;
                case "truefalse":
                    Expression<Func<TrueFalseQuestion, bool>> tfqWhereLambda = (q => q.IsPublic == isPublic && q.IsDeleted == 0 );
                    if (isPersonal)
                        tfqWhereLambda = (q => q.IsPublic == isPublic && q.IsDeleted == 0 && q.PublisherID == userId);
                    if (isPersonal && isPersonalAll)
                        tfqWhereLambda = (q => q.IsDeleted == 0 && q.PublisherID == userId);
                    ViewData["QuestionType"] = "判断题";
                    allQuestions.TrueFalseQuestions = trueFalseQuestionService.LoadPageEntities(pageSize, pageIndex, out total,
                         tfqWhereLambda, q => q.SubTime, q => q.Publisher, false);
                    break;
                case "filling":
                    Expression<Func<FillingQuestion, bool>> fqWhereLambda = (q => q.IsPublic == isPublic && q.IsDeleted == 0);
                    if (isPersonal)
                        fqWhereLambda = (q => q.IsPublic == isPublic && q.IsDeleted == 0 && q.PublisherID == userId);
                    if (isPersonal && isPersonalAll)
                        fqWhereLambda = (q => q.IsDeleted == 0 && q.PublisherID == userId);

                    ViewData["QuestionType"] = "填空题";
                    allQuestions.FillingQuestions = fillingQuestionService.LoadPageEntities(pageSize, pageIndex, out total,
                        fqWhereLambda, q => q.SubTime, q => q.Publisher, false);
                    break;
                case "short":
                    Expression<Func<ShortQuestion, bool>> sqWhereLambda = (q => q.IsPublic == isPublic && q.IsDeleted == 0);
                    if (isPersonal)
                        sqWhereLambda = (q => q.IsPublic == isPublic && q.IsDeleted == 0 && q.PublisherID == userId);
                    if (isPersonal && isPersonalAll)
                        sqWhereLambda = (q => q.IsDeleted == 0 && q.PublisherID == userId);
                    ViewData["QuestionType"] = "简答题";
                    allQuestions.ShortQuestions = shortQuestionService.LoadPageEntities(pageSize, pageIndex, out total,
                 sqWhereLambda, q => q.SubTime, q => q.Publisher, false);
                    break;
                default:
                    ViewData["QuestionType"] = "选择题";
                    allQuestions.ChoiceQuestions = choiceQuestionService.LoadPageEntities(pageSize, pageIndex, out total,
                cqWhereLambda, q => q.SubTime, q => q.Publisher, false);
                    break;
            }
            ViewBag.TotalRecords = total;
            ViewBag.TotalPage = (int)Math.Ceiling((double)total/pageSize);
            ViewBag.PageIndex = int.Parse(Request.QueryString["pageIndex"]);
            //if (total == 0)
            //    return Content("无数据了...");
            return View(allQuestions);

        }    
        #endregion

        #region 根据问题的种类,ID及操作类型，对问题进行对应操作
		[ValidateInput(false)]
        public ActionResult Operate(string qType="chioce", string qId="1", string qOperateType="view")
        {
            TempData["qType"] = qType;
            TempData["qId"] = qId;
            TempData["qOperateType"] = qOperateType;
            TempData["qCourseList"] = GetSelectListCourses();
            int[] intIds =qId.ToInts(new []{'|'});//StringsToInts(qId);
            dynamic service = null;
            List<dynamic> questions = null;
            GetService(qType, out service, out questions, intIds);

            if (string.IsNullOrEmpty(qOperateType))
                qOperateType = "view";
            switch (qOperateType)
            {
                case "add":
                    if(Request.HttpMethod.ToLower()=="post")
                        return AddOrUpdateQuestion(qType, qOperateType, Request.Form);
                    return AddQuestion(qType);
                case "update":
                    return AddOrUpdateQuestion(qType, qOperateType, Request.Form);
                case "view":
                    return ViewQuestion(intIds[0], qType);
                case "delete":
                    Delete(questions, service);
                    break;
            }
            service.Savechanges();
            var msg = new AjaxMessage()
            {
                Status = "success",
                Message = "操作成功",
                BackUrl = Request.RawUrl,
                Data = intIds
            };
            return OperateContext.RedirectAjax(msg);
        } 
        #endregion

        #region 获取相应问题详细
        [HttpGet]
        public ActionResult ChoiceQuestion(int id)
        {
            var question = choiceQuestionService.LoadEntities(q => q.ID == id && q.IsDeleted != 0,q=>q.Course).SingleOrDefault();
            return View("ChoiceQuestion", question);
        }
        [HttpGet]
        public ActionResult FillingQuestion(int id)
        {
            var question = fillingQuestionService.LoadEntities(q => q.ID == id && q.IsDeleted != 0, q => q.Course).SingleOrDefault();
            return View("FillingQuestion", question);
        }

        [HttpGet]
        public ActionResult TrueFalseQuestion(int id)
        {
            var question = trueFalseQuestionService.LoadEntities(q => q.ID == id && q.IsDeleted != 0, q => q.Course).SingleOrDefault();
            return View("TrueFalseQuestion", question);
        }

        [HttpGet]
        public ActionResult ShortQuestion(int id)
        {
            var question = shortQuestionService.LoadEntities(q => q.ID == id && q.IsDeleted != 0, q => q.Course).SingleOrDefault();
            return View("ShortQuestion", question);
        }
        
        #endregion

        #region 更新相应问题
        [HttpPost]
		[ValidateInput(false)]
        public ActionResult ChoiceQuestion(ChoiceQuestion model)
        {
            choiceQuestionService.Update(model);
            choiceQuestionService.Savechanges();
            return View("ChoiceQuestion", model);
        }

		[HttpPost]
		[ValidateInput(false)]
		public ActionResult FillingQuestion(FillingQuestion model)
        {
            fillingQuestionService.Update(model);
            fillingQuestionService.Savechanges();
            return View("FillingQuestion", model);
        }
		[HttpPost]
		[ValidateInput(false)]
		public ActionResult TrueFalseQuestion(TrueFalseQuestion model)
        {
            trueFalseQuestionService.Update(model);
            trueFalseQuestionService.Savechanges();
            return View("TrueFalseQuestion", model);
        }
		[HttpPost]
		[ValidateInput(false)]
		public ActionResult ShortQuestion(ShortQuestion model)
        {
            shortQuestionService.Update(model);
            shortQuestionService.Savechanges();
            return View("ShortQuestion", model);
        }
        
        #endregion

        #region 根据问题类型获取Services实例,question实例
        private void GetService(string qType,out dynamic service,out List<dynamic> questions,params int[] intIds)
        {                        
            questions = new List<dynamic>();
            
            switch (qType)
            {
                case "choice":
                    service = BllFactory.Current.ChoiceQuestionService;
                    foreach (var qid in intIds)
                    {
                        questions.Add(new ChoiceQuestion() { ID = qid });
                    }
                    break;
                case "filling":
                    service = BllFactory.Current.FillingQuestionService;
                    foreach (var qid in intIds)
                    {
                        questions.Add(new FillingQuestion() { ID = qid });
                    }
                    break;
                case "truefalse":
                    service = BllFactory.Current.TrueFalseQuestionService;
                    foreach (var qid in intIds)
                    {
                        questions.Add(new TrueFalseQuestion() { ID = qid });
                    }
                    break;
                case "short":
                    service = BllFactory.Current.ShortQuestionService;
                    foreach (var qid in intIds)
                    {
                        questions.Add(new ShortQuestion() { ID = qid });
                    }
                    break;
                default:
                    service = BllFactory.Current.ChoiceQuestionService;
                    foreach (var qid in intIds)
                    {
                        questions.Add(new ChoiceQuestion() { ID = qid });
                    }
                    break;
            }
             
        }
        #endregion

        private ActionResult AddOrUpdateQuestion(string qType, string qOperateType, NameValueCollection model)
        {

            //获取课程Id号
            int courseId = int.Parse(model["Course"]);
            //获取当前用户
            var publisher = OperateContext.Current.CurrentUser;
            switch (qType)
            {
                case "choice":
                    #region 选择题的修改与添加操作
                    //对模型进行验证
                    if (model["Content"] == "" || model["Answers"] == ""
                    || model["SelectA"] == "" || model["SelectB"] == "")
                        return OperateContext.RedirectAjax("error", "实体内容且选项A,B不能为空", model, "");
                    //是否多选
                    bool isMultiSelect = model["Answers"].Length > 1;
                    var cq = new ChoiceQuestion()
                    {
                        CourseID =courseId,
                        Difficulty = short.Parse(model["Difficulty"]),
                        Content = model["Content"],
                        Answers = model["Answers"],
                        SelectA = model["SelectA"],
                        SelectB = model["SelectB"],
                        SelectC = model["SelectC"],
                        SelectD = model["SelectD"],
                        SelectE = model["SelectE"],
                        SelectF = model["SelectF"],
                        SubTime = DateTime.Now,
                        Remark = model["Remark"],
                        IsMultiSelect = isMultiSelect,
                        PublisherID = publisher.ID,
                    };
                    //默认为false
                    cq.IsPublic = false;
                    if (model["IsPublic"] == "on")
                        cq.IsPublic = true;
                    if (qOperateType == "update")
                    {
                        cq.ID = int.Parse(model["qId"]);
                        choiceQuestionService.Update(cq);
                    }
                    else
                    {
                        choiceQuestionService.Add(cq);
                    }
                    choiceQuestionService.Savechanges();
                    return OperateContext.RedirectAjax("成功", "更新完毕", model, ""); 
                    #endregion
                case "filling":
                    #region 填空题的修改与添加操作
                    //对模型进行验证
                    if (model["Content"] == "" || model["Answers"].Split(new []{'|'},StringSplitOptions.RemoveEmptyEntries).Length<1)
                        return OperateContext.RedirectAjax("error", "试题内容且答案不能为空", model, "");
                    //是否多填
                    bool isMultiFilling = model["Answers"].Split(new []{'|'},StringSplitOptions.RemoveEmptyEntries).Length>1;
                    var fq = new FillingQuestion()
                    {
                        CourseID =courseId,
                        PublisherID = publisher.ID,
                        Difficulty = short.Parse(model["Difficulty"]),
                        Content = model["Content"],
                        Answers = model["Answers"],
                        SubTime = DateTime.Now,
                        Remark = model["Remark"],
                        IsMultiFilling = isMultiFilling,
                    };
                    //默认为false
                    fq.IsPublic = false;
                    if (model["IsPublic"] == "on")
                        fq.IsPublic = true;
                    if (qOperateType == "update")
                    {
                        fq.ID = int.Parse(model["qId"]);
                        fillingQuestionService.Update(fq);
                    }
                    else
                    {
                        fillingQuestionService.Add(fq);
                    }
                    fillingQuestionService.Savechanges();
                    return OperateContext.RedirectAjax("成功", "更新完毕", model, ""); 
                    #endregion
                case "truefalse":
                    #region 判断题的修改与添加操作
                    //对模型进行验证
                    if (model["Content"] == "" )
                        return OperateContext.RedirectAjax("error", "试题内容且答案不能为空", model, "");
                    bool answer;
                    if (!bool.TryParse(model["Answers"], out answer))
                        answer = true;
                    var tfq = new TrueFalseQuestion()
                    {
                        CourseID =courseId,   
                        PublisherID = publisher.ID,
                        Difficulty = short.Parse(model["Difficulty"]),
                        Content = model["Content"],
                        Answers = answer,
                        SubTime = DateTime.Now,
                        Remark = model["Remark"],
                    };
                    //默认为false
                    tfq.IsPublic = false;
                    if (model["IsPublic"] == "on")
                        tfq.IsPublic = true;
                    if (qOperateType == "update")
                    {
                        tfq.ID = int.Parse(model["qId"]);
                        trueFalseQuestionService.Update(tfq);
                    }
                    else
                    {
                        trueFalseQuestionService.Add(tfq);
                    }
                    trueFalseQuestionService.Savechanges();
                    return OperateContext.RedirectAjax("成功", "更新完毕", model, "");
                    #endregion
                case "short":
                    #region 简答题的修改与添加操作
                    //对模型进行验证
                    if (model["Content"] == "")
                        return OperateContext.RedirectAjax("error", "试题内容且答案不能为空", model, "");
                    var sq = new ShortQuestion()
                    {
                        CourseID =courseId,
                        PublisherID = publisher.ID,
                        Difficulty = short.Parse(model["Difficulty"]),
                        Content = model["Content"],
                        Answers = model["Answers"],
                        SubTime = DateTime.Now,
                        Remark = model["Remark"],
                    };
                    //默认为false
                    sq.IsPublic = false;
                    if (model["IsPublic"] == "on")
                        sq.IsPublic = true;
                    if (qOperateType == "update")
                    {
                        sq.ID = int.Parse(model["qId"]);
                        shortQuestionService.Update(sq);
                    }
                    else
                    {
                        shortQuestionService.Add(sq);
                    }
                    shortQuestionService.Savechanges();
                    return OperateContext.RedirectAjax("成功", "更新完毕", model, "");
                    #endregion
                 default:
                    var dq = new ChoiceQuestion();
                    return View("ChoiceQuestion", dq);
            }
        }

        #region 将Id字符串转换成int数组
        public int[] StringsToInts(string qIds)
        {
            int[] intIds = { };
            if (qIds.Length == 1)
            {
                intIds = new int[1];
                intIds[0] = int.Parse(qIds);
            }
            else
            {
                var ids = qIds.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                intIds = new int[ids.Length];
                for (var i = 0; i < ids.Length; i++)
                {
                    intIds[i] = int.Parse(ids[i]);
                }
            }
            return intIds;
        } 
        #endregion

        //软删除,更新为已删除,标记后不显示
        private void Delete(dynamic models,dynamic  service)
        {
            //service.Delete(ids)
            foreach (var model in models)
            {
                model.IsDeleted = 1;
                service.Update(model,"IsDeleted");
            }
            //service.SaveChanges();
        }

        private ActionResult ViewQuestion(int id ,string qType)
        {
            switch (qType)
            {
                case "choice":
                    Expression<Func<ChoiceQuestion, bool>> cqExpression= (q => q.ID == id && q.IsDeleted == 0);
                    var cq = choiceQuestionService.LoadEntities(cqExpression).FirstOrDefault();
                    return View("ChoiceQuestion", cq);
                case "filling":
                    Expression<Func<FillingQuestion, bool>> fqExpression = (q => q.ID == id && q.IsDeleted == 0);
                    var fq = fillingQuestionService.LoadEntities(fqExpression).FirstOrDefault();
                    return View("FillingQuestion", fq);
                case "truefalse":
                    Expression<Func<TrueFalseQuestion, bool>> tfqExpression = (q => q.ID == id && q.IsDeleted == 0);
                    var tfq = trueFalseQuestionService.LoadEntities(tfqExpression).FirstOrDefault();
                    return View("TrueFalseQuestion", tfq);
                case "short":
                    Expression<Func<ShortQuestion, bool>> sqExpression = (q => q.ID == id && q.IsDeleted == 0);
                    var sq = shortQuestionService.LoadEntities(sqExpression).FirstOrDefault();
                    return View("ShortQuestion", sq);
                default:
                    Expression<Func<ChoiceQuestion, bool>> dqExpression= (q => q.ID == id && q.IsDeleted == 0);
                    var dq = choiceQuestionService.LoadEntities(dqExpression).FirstOrDefault();
                    return View("ChoiceQuestion", dq);
            }  
        }

        [HttpGet]
        private ActionResult AddQuestion(string qType)
        {
            switch (qType)
            {
                case "choice":
                    var cq = new ChoiceQuestion()
                    {
                        Content = "",
                        Remark ="",
                        CourseID = 1,
                    };
                    return View("ChoiceQuestion", cq);
                case "filling":
                    var fq = new FillingQuestion()
                    {
                        Content = "",
                        Remark = "",
                        CourseID = 1,
                    };
                    return View("FillingQuestion", fq);
                case "truefalse":
                    var tfq = new TrueFalseQuestion()
                    {
                        Content = "",
                        Remark = "",
                        CourseID = 1,
                    };
                    return View("TrueFalseQuestion", tfq);
                case "short":
                    var sq = new ShortQuestion()
                    {
                        Content = "",
                        Remark = "",
                        CourseID = 1,
                    };
                    return View("ShortQuestion", sq);
                default:
                    var dq = new ChoiceQuestion()
                    {
                        Content = "",
                        Remark = "",
                        CourseID = 1,
                    };
                    return View("ChoiceQuestion", dq);
            }
        }

        private IEnumerable<SelectListItem> GetSelectListCourses()
        {
            var couresList =  BllFactory.Current.CourseService.LoadEntities(c => c.IsDeleted == 0).ToList();
            var selectList = couresList.Select(course => new SelectListItem()
            {
                Selected = false,
                Text = course.CourseName,
                Value = course.ID.ToString(CultureInfo.CurrentCulture)
            }).ToList();

            return selectList;

        }

    }


}
