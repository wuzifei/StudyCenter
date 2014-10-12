using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using System.Web.WebPages;
using StudyCenter.BLL;
using StudyCenter.Common;
using StudyCenter.Model;
using StudyCenter.Model.ViewModel;
using StudyCenter.UI.ViewModel;

namespace StudyCenter.UI.Controllers
{
    public class TestPaperController :AuthorizedController
    {
        //
        // GET: /TestPaper/

        public ActionResult Index()
        {
            return List(1, 6);

        }
        //获取试卷基本信息列表
        public ActionResult List(int pageIndex,int pageSize)
        {
            int total;
            var testpapers = BllFactory.Current.TestPaperService.LoadPageEntities(pageSize, pageIndex, out total, tp => tp.IsDeleted == 0, tp => tp.PaperDate, false).ToArray();
            var pageination = new Pagination
            {
                PageSize = pageSize,
                ControllerName = "testpaper",
                ActionName = "list",
                CurrentPage = pageIndex,
                TotalRecords = total,
            };
            return View("Index",new TestPaperIndex
            {
                Pagination = pageination,
                TestPapers = testpapers
            });
        }

        [HttpGet]//添加试卷页面
        public ActionResult Add()
        {
            var courses = BllFactory.Current.CourseService.LoadEntities(c => c.IsDeleted == 0).ToArray();
            var bigCategory = BllFactory.Current.PaperCategoryService.LoadEntities(pc => pc.ParentID==0).ToArray();
            var firstBig = bigCategory.First();
            //TODO:查询条件中不可使用‘跟踪实体作为查询条件’
            var smalCategory = BllFactory.Current.PaperCategoryService.LoadEntities(pc => pc.ParentID == firstBig.ID).ToArray();
            var courseList = from c in courses
                select new SelectListItem
                {
                    Text = c.CourseName,
                    Value = c.ID.ToString(CultureInfo.InvariantCulture)
                };
            var categoryList = from ctg in bigCategory
                select new SelectListItem
                {
                    Text = ctg.Name,
                    Value = ctg.ID.ToString(CultureInfo.InvariantCulture)
                };
            var smallCategory =
                from sctg in smalCategory
                select new SelectListItem
                {
                    Text = sctg.Name,
                    Value = sctg.ID.ToString(CultureInfo.InvariantCulture),
                    Selected = categoryList.Select(c=>c.Value ==sctg.ParentID.ToString()).Any()
                }; 
            categoryList.FirstOrDefault().Selected = true;
            var fisrtCategory = categoryList.FirstOrDefault().Selected;
            var paperInfo = new TestPaperInfo()
            {
                Courses = courseList,
                BigCategory = categoryList,
                SmallCategory = smallCategory
            };
            return View(paperInfo);
        }

        [HttpPost]//添加试卷基本信息
        public ActionResult Add(FormCollection formCollection)
        {
            var tp = new TestPaper();
            tp.PaperType = PaperType.ForTest;
            tp.PaperType = PaperType.Public;
            return View();
        }

        //修改试卷基本信息
        public ActionResult Edit(int id)
        {
            //TODO:没有查询到，让它报错？
            var testpaper =
                BllFactory.Current.TestPaperService.LoadEntities(t => t.ID == id && t.IsDeleted == 0).ToArray().First();
            var bigQuestionList =
                BllFactory.Current.BigQuestionService.LoadEntities(bq => bq.TestPaperID == testpaper.ID).ToArray();
            var allBigQuestions = new List<BigQuestionInfo>();  
            var cqS = new StringBuilder("");
            var fqS = new StringBuilder("");
            var tqS = new StringBuilder("");
            var sqS = new StringBuilder("");
            var bigCategoryList = new List<SelectListItem>();
            var smallCategoryList = new List<SelectListItem>();
            var courses = BllFactory.Current.CourseService.LoadEntities(c => c.IsDeleted==0).ToArray();
            var courseList = new List<SelectListItem>();
            foreach (var course in courses)
            {
                courseList.Add(new SelectListItem()
                {
                    Text = course.CourseName,
                    Value = course.ID.ToString(),
                    Selected = course.ID==testpaper.CourseID
                });
            }
            if (bigQuestionList.Any())
            {
                #region 获取大题小题
                foreach (var bigQuestion in bigQuestionList)
                {
                    var bigId = bigQuestion.ID;
                    var smallQuestionList =
                        BllFactory.Current.SmallQuestionService.LoadEntities(sq => sq.BigQuestionID == bigId).ToArray();
                    //清空小题数据
                    var cqString = new StringBuilder("");
                    var fqString = new StringBuilder("");
                    var tqString = new StringBuilder("");
                    var sqString = new StringBuilder("");
                    foreach (var smallQuestion in smallQuestionList)
                    {
                        switch (smallQuestion.QuestionType)
                        {
                            case QuestionType.ChoiceQuestion:
                                cqString.Append(smallQuestion.QuestionID +",");
                                break;
                            case QuestionType.FillingQuestion:
                                fqString.Append(smallQuestion.QuestionID + ",");
                                break;
                            case QuestionType.TrueFalseQuestion:
                                tqString.Append(smallQuestion.QuestionID + ",");
                                break;
                            case QuestionType.ShortQuestion:
                                sqString.Append(smallQuestion.QuestionID + ",");
                                break;
                        }
                    }
                    cqS.Append(cqString.ToString());
                    fqS.Append(fqString.ToString());
                    tqS.Append(tqString.ToString());
                    sqS.Append(sqString.ToString());
                    List<QuestionInfo> questionList = null;
                    var count = GetSmallQuestions(cqString.ToString().ToInts(new[] {','}),
                        fqString.ToString().ToInts(new[] {','}), tqString.ToString().ToInts(new[] {','}),
                        sqString.ToString().ToInts(new[] {','}), out questionList,bigQuestion.ID);
                
                    allBigQuestions.Add(new BigQuestionInfo()
                    {
                        Id = bigQuestion.ID,
                        Title = bigQuestion.Title,
                        Remark = bigQuestion.Remark,
                        SubTime = bigQuestion.SubTime,
                        Score =  bigQuestion.Score,
                        SmallQustions = questionList
                    });
                }
                #endregion            
            }
            var smalllCategory =
                BllFactory.Current.PaperCategoryService.LoadEntities(s => s.ID == testpaper.CategoryID).ToArray().FirstOrDefault();
            var bigCategory =
                BllFactory.Current.PaperCategoryService.LoadEntities(b => b.ID == smalllCategory.ParentID).ToArray().FirstOrDefault();
            var allReleatedSmallCategory =
                BllFactory.Current.PaperCategoryService.LoadEntities(pc => pc.ParentID == bigCategory.ID).ToArray();
            var allBigCategory =
                BllFactory.Current.PaperCategoryService.LoadEntities(b => b.ParentID == 0).ToArray();
            foreach (var category in allBigCategory)
            {
                bigCategoryList.Add(new SelectListItem()
                {
                    Text = category.Name,
                    Value = category.ID.ToString(),
                    Selected = category.ID == bigCategory.ID//不可能为空
                });
            }
            foreach (var category in allReleatedSmallCategory)
            {
                smallCategoryList.Add(new SelectListItem()
                {
                    Text = category.Name,
                    Value = category.ID.ToString(),
                    Selected = category.ID == smalllCategory.ID//不可能为空
                });
            }

            var isToAll =
                BllFactory.Current.TestpaperTargetService.LoadEntities(
                    tpt => tpt.TestPaperID == testpaper.ID && tpt.TargetType == TestpaperTargetType.ToAll).ToArray().Any();
            return View(new TestPaperEdit()
            {
                TestPaper = testpaper,
                BigQuestions = allBigQuestions,
                CqList = cqS.ToString(),
                FqList = fqS.ToString(),
                SqList = sqS.ToString(),
                TqList = tqS.ToString(),
                JavaScript = "<script type='text/javascript'>$.ready(function(){alert('Hello From Server');});</script>",
                PaperData = new TestPaperInfo()
                {
                    BigCategory = bigCategoryList,
                    SmallCategory = smallCategoryList,
                    Courses = courseList
                },
                IsPublishToAll = isToAll
            });;
        }

        [HttpGet]
        public ActionResult Do(int id)
        {     
            var testpaper = BllFactory.Current.TestPaperService.LoadEntities(t => t.ID == id).FirstOrDefault();
            if (testpaper==null)
            {
                return OperateContext.RedirectAjax(new AjaxMessage()
                {
                     Status = "error",
                     Message = "试卷不存在"
                });
            }

            var bigQuestions =
                BllFactory.Current.BigQuestionService.LoadEntities(b => b.TestPaperID == testpaper.ID).ToArray();
            var bigQuestionInfo = new List<BigQuestionInfo>();

            foreach (var bigQuestion in bigQuestions)
            {
                var questionList = new List<QuestionInfo>();
                var count = GetSmallQuestions(bigQuestion.ID, out questionList);
                var TotalScore = 0;
                foreach (var q in questionList)
                {
                    TotalScore += q.Score;
                }
                bigQuestionInfo.Add(new BigQuestionInfo()
                {
                    Id = bigQuestion.ID,
                    Remark = bigQuestion.Remark,
                    Score = TotalScore,
                    SubTime = bigQuestion.SubTime,
                    Title = bigQuestion.Title,
                    SmallQustions = questionList
                });
            }

            var courseName = testpaper.Course.CourseName;
            var category =
                BllFactory.Current.PaperCategoryService.LoadEntities(p => p.ID == testpaper.CategoryID).FirstOrDefault();

            return View(new TestPaperDo
            {
                TestPaper = testpaper,
                BigQuestionInfos = bigQuestionInfo,
                SmallQuestionCount = 1,
                CategoryName = category.Name,
                //TODO:学校发布的考试注意事项或者通知
                NoticeFromSchool = ""
            });
        }

		/// <summary>
		/// 根据学生答案生成 已答卷报告
		/// </summary>
		/// <param name="id">试卷ID</param>
		/// <param name="formCollection"></param>
		/// <returns>答卷报告</returns>
		[HttpPost]
		[ValidateInput(false)]
        public ActionResult Report(int id,FormCollection formCollection)
        {
            var answerTestpaper = BllFactory.Current.TestPaperService.SaveAnswer(id, OperateContext.Current.CurrentUser.ID,
                Request.Form);
			var isSuccess = GetTestPaperInfo(id,ref answerTestpaper);
			  if (!isSuccess)
				  return Content("试卷不存在！");
			  return View(answerTestpaper);
        }


	    /// <summary>
		/// Get试卷报告
		/// </summary>
		/// <param name="id">试卷Id</param>
		/// <returns></returns>
		[HttpGet]
		public ActionResult Report(int id)
	    {
			var testpaper = BllFactory.Current.TestPaperService.LoadEntities(tp => tp.ID == id).FirstOrDefault();
			var studentpaper =
				BllFactory.Current.StudentPaperService.LoadEntities(
					sp => sp.TestPaperID == id && sp.UserID == OperateContext.Current.CurrentUser.ID).FirstOrDefault();
			if (testpaper == null || studentpaper == null)
			{
				//Response.SetStatus(HttpStatusCode.NotFound);
				return Content("试卷不存在或您还没有做过该试卷！");
			}

		    var answerTestpaper = new AnswerTestpaper();
		    GetTestPaperInfo(id, ref answerTestpaper);
		    answerTestpaper.TestPaper = testpaper; 
		    answerTestpaper.StudentPaper = studentpaper;


			return View(answerTestpaper);
		}

		/// <summary>
		/// 获取学生试卷详细信息
		/// </summary>
		/// <param name="testpaperId">试卷id</param>
		/// <param name="answerTestpaper">返回的答卷数据</param>
		/// <returns>是否获取成功</returns>
		private bool GetTestPaperInfo(int testpaperId, ref AnswerTestpaper answerTestpaper)
		{
			var testpaper = BllFactory.Current.TestPaperService.LoadEntities(t => t.ID == testpaperId && t.IsDeleted == 0).FirstOrDefault();
			if (testpaper == null)
			{
				return false;
				//return Content("该试卷已被删除,或不存在");
			}
			var bigQuestions =
				BllFactory.Current.BigQuestionService.LoadEntities(b => b.TestPaperID == testpaper.ID).ToArray();
			var smallQuestions = new List<SmallQuestion>();
			foreach (var bigQuestion in bigQuestions)
			{
				var smallQuestion =
					BllFactory.Current.SmallQuestionService.LoadEntities(s => s.BigQuestionID == bigQuestion.ID)
						.ToArray();
				smallQuestions.AddRange(smallQuestion);
			}
			#region 获取所有大题中的小题内容

			//当请求为Get的时候需要获取用户答案，post则不需要，因为用户提交报文中含有
			if (Request.RequestType.ToLower() == "get")
			{
				var bigQuestionsIds =( from bq in bigQuestions select bq.ID).ToArray();
				var userAnswers = BllFactory.Current.AnswerService.LoadEntities(a => bigQuestionsIds.Contains(a.BigQuestionID)).ToArray();
				answerTestpaper.UserAnswers = userAnswers.ToList();
			}

			foreach (var bigQuestion in bigQuestions)
			{
				var questions = new List<QuestionInfo>();
				GetSmallQuestions(bigQuestion.ID, out questions);
				//TODO:将TestPaper Report中需要的数据join到questions中
				var userAnswers = BllFactory.Current.AnswerService.LoadEntities(a => a.BigQuestionID == bigQuestion.ID);
				var userAnswerWithQuestionInfo = from answer in answerTestpaper.UserAnswers
												 join question in questions
													 on new
													 {
														 id = answer.QuestionID.Value,
														 qType = answer.QuestionType
													 } equals
													 new
													 {
														 id = question.Id,
														 qType = question.EnumQuestionType
													 }
												 //into answerquestion
												 //from aq in answerquestion
												 select new QuestionInfo
												 {
													 Id = question.Id,
													 Title = question.Title,
													 Answer = question.Answer,
													 QuestionType = question.QuestionType,
													 Choices = question.Choices,
													 IsMutilSelect = question.IsMutilSelect,
													 Score = question.Score,
													 GetScore = (int)answer.Score,
													 EnumQuestionType = question.EnumQuestionType,
													 UserAnswer = answer.AnswerContent,
													 BigQuestionId = answer.BigQuestionID,
													 TestPaperId = testpaper.ID,
													 //TODO:试题详解从何处来？
													 QuestionRemark = question.QuestionRemark,
												 };
				var bigQuestionTotalScore = 0;
				var bigQuestionGetScore = 0;
				//转换下
				var answerWithQuestionInfo = userAnswerWithQuestionInfo as QuestionInfo[] ?? userAnswerWithQuestionInfo.ToArray();
				foreach (var questionInfo in answerWithQuestionInfo)
				{
					bigQuestionTotalScore += questionInfo.Score;
					if(questionInfo.GetScore!=-1)
					{
						bigQuestionGetScore += questionInfo.GetScore;
					}
				}
				answerTestpaper.BigQuestions.Add(new BigQuestionInfo
				{
					Id = bigQuestion.ID,
					Title = bigQuestion.Title,
					Remark = bigQuestion.Remark,
					Score = bigQuestion.Score,
					SubTime = bigQuestion.SubTime,
					SmallQustionInfos = answerWithQuestionInfo,
					TotalScore = bigQuestionTotalScore,
					TotalGetScore = bigQuestionGetScore
				});
			}
			#endregion
			return true;
		}


	    [HttpPost]
        public ActionResult Delete(int id)
        {
            var tp = BllFactory.Current.TestPaperService.LoadEntities(t => t.ID == id).First();
            tp.IsDeleted = 1;
            BllFactory.Current.TestPaperService.Update(tp);
            BllFactory.Current.TestPaperService.Savechanges();
            return Content("ok");
        }

        public ActionResult Save(int courseId, int categoryId, string paperName, string paperDescription,string startTime,string endTime,int testMinutes,short paperScore,int testPaperId,string paperType,string knowledge)
        {
            var pType = PaperType.Public;
            switch (paperType)
            {
                case "ToTest":pType = PaperType.ForTest;break;
                case "ToPublic":pType = PaperType.Public;break;;
                case "ToPrivate" :pType = PaperType.Private;break;
                case "ToHomeWork":pType = PaperType.HomeWork;break;
            }
            var testpaper =
                BllFactory.Current.TestPaperService.LoadEntities(tp => tp.IsDeleted == 0 && tp.ID == testPaperId).ToArray();
            TestPaper newPaper = null;
            //试卷被保存过
            if (testpaper.Any())
            {
                 newPaper = testpaper.First();
            }
            else//尚不存在，新建
            {
                newPaper = new TestPaper();
                newPaper.SubTime = DateTime.Now;
                //TODO:下面这些属性需要动态设置
            }  
            newPaper.PaperType = pType;     
            newPaper.Knowledge = knowledge;
            newPaper.PaperDate = DateTime.Now;
            newPaper.CourseID = courseId;
            newPaper.CategoryID = categoryId;
            newPaper.PaperName = paperName;
            newPaper.PaperDescription = paperDescription;
            //TODO:日期格式化转换
             var t = Convert.ToDateTime(startTime,new DateTimeFormatInfo(){LongDatePattern = "MM/dd/yyyy HH:MM"});;
            newPaper.StartTime =  t;
            t = Convert.ToDateTime(endTime, new DateTimeFormatInfo() { LongDatePattern = "MM/dd/yyyy HH:MM" });
            newPaper.EndTime = t;
            newPaper.TestMinutes = testMinutes;
            newPaper.PaperScore = paperScore;
            newPaper.PublisherID = OperateContext.Current.CurrentUser.ID;
            var testpaperId = testPaperId;
            if (testpaper.Any())
            {
                BllFactory.Current.TestPaperService.Update(newPaper);  
                BllFactory.Current.TestPaperService.Savechanges();
            }
            else
            {
                var tp = BllFactory.Current.TestPaperService.Add(newPaper);
                BllFactory.Current.TestPaperService.Savechanges();
                testpaperId = tp.ID;
            }

            //TODO:是否需要启用事务 保存发布对象信息
            SavePublishToIds(Request.QueryString["publishToIds"].Split(','), testpaperId);
            return OperateContext.RedirectAjax(new AjaxMessage()
            {
                Data = testpaperId,
                Status = "ok"
            });

        }

        private void SavePublishToIds(string[] ids,int testpaperId)
        {
            //TODO:新增的增加（有的则忽略），原先有的，新增的没有则删除
            BllFactory.Current.TestpaperTargetService.Delete(tt => tt.TestPaperID == testpaperId);
            BllFactory.Current.TestpaperTargetService.Savechanges();
            //var newTargetList = new List<TestpaperTarget>();
            foreach (var idInfo in ids)
            {
                var nameId = idInfo.Split('-');
                var name = nameId[0];
                var id = nameId[1];
                var tt = QuestionType.ChoiceQuestion;
                var testpaperTarget = TestpaperTargetType.ToAll;
                switch (name)
                {
                    case "Academy":
                        testpaperTarget = TestpaperTargetType.ToAcademy;
                        break;
                    case "Class":
                        testpaperTarget = TestpaperTargetType.ToClass;
                        break;
                    case "Dep":
                        testpaperTarget = TestpaperTargetType.ToDepartment;
                        break;
                    case "All":
                        testpaperTarget = TestpaperTargetType.ToAll;
                        break;
                }
                var newEntity = new TestpaperTarget()
                {
                    TargetType = testpaperTarget,
                    TargetID = int.Parse(id),
                    TestPaperID = testpaperId,
                };
                //newTargetList.Add(newEntity);
                BllFactory.Current.TestpaperTargetService.Add(newEntity);
            }
            //新的没有的，老的里面的应该删除,交集保留，老的差集删除，新的差集添加
            //var exceptToDelete = oldTarget.Except(newTargetList);  
            //var exceptToAdd = newTargetList.Except(oldTarget);

            //foreach (var delete in exceptToDelete)
            //{
            //    BllFactory.Current.TestpaperTargetService.Delete(tt=>tt.ID==delete.ID);
            //}
            //BllFactory.Current.TestpaperTargetService.Savechanges();
            //foreach (var add in exceptToAdd)
            //{
            //    BllFactory.Current.TestpaperTargetService.Add(add);
            //}
            BllFactory.Current.TestpaperTargetService.Savechanges();
        }


        public ActionResult SmallCategory(int id)
        {
            var list =
                BllFactory.Current.PaperCategoryService.LoadEntities(
                    pc => pc.ParentID == id).ToArray();
            var selectList = from c in list
                select new SelectListItem()
                {
                    Text= c.Name,
                    Value = c.ID.ToString()
                };
            return OperateContext.RedirectAjax(new AjaxMessage()
            {
                Data = selectList,
                Status = "ok"
            });
        }

        [HttpPost]//添加大题
        public ActionResult AddBigQuestion(string title,string remark,int score,int testPaperId)
        {
            var form = Request.Form;
            var testPaper = new TestPaper();
            //如果testPaperId说明这是一个全新的试卷，所以新建一个试卷存入数据库
            if (testPaperId == 0)
            {
                 testPaper= BllFactory.Current.TestPaperService.Add(new TestPaper()
                {
                    PaperName =DateTime.Now.ToString("g") + "  未完成试卷",
                    PaperDate = DateTime.Now,
                    PaperScore = 100,
                    PaperType = PaperType.Private,
                    PublisherID = OperateContext.Current.CurrentUser.ID,
                    CourseID = BllFactory.Current.CourseService.LoadEntities(pc => pc.IsDeleted == 0).FirstOrDefault().ID,
                    StartTime = DateTime.Now.AddDays(1),
                    EndTime = DateTime.Now.AddDays(1).AddHours(2),
                    SubTime = DateTime.Now,
                    CategoryID = BllFactory.Current.PaperCategoryService.LoadEntities(pc=>pc.ParentID!=0).FirstOrDefault().ID
                });
                BllFactory.Current.TestPaperService.Savechanges();
            }
            else//试卷已存在
            {
                testPaper =
                    BllFactory.Current.TestPaperService.LoadEntities(tp => tp.IsDeleted == 0 && tp.ID == testPaperId)
                        .SingleOrDefault();
                if(testPaper ==null)//试卷ID有误，没有查询到，或已被删除
                    return OperateContext.RedirectAjax(new AjaxMessage()
                    {
                        Data = new
                        {
                            TestPaperId=0,
                            BigQuestionId=0
                        }, 
                        Message = "没有找到相应试卷,或已被删除！",
                        Status = "error"
                    });
            }

            var bigQuestion = BllFactory.Current.BigQuestionService.Add(
                                new BigQuestion()
                                {
                                    Title = title,
                                    Remark = remark,
                                    Score = score,
                                    SubTime = DateTime.Now,
                                    TestPaperID = testPaper.ID,
                                    IsDeleted = false,
                                });
            BllFactory.Current.BigQuestionService.Savechanges();//保存才能获取到ID,切记切记

            return OperateContext.RedirectAjax(new AjaxMessage()
            {
                Data = new
                {
                    TestPaperId = testPaper.ID,
                    BigQuestionId = bigQuestion.ID
                },
                Message = "操作成功！",
                Status = "ok"
            });
        }

        [HttpPost]//删除大题
        public ActionResult DeleteBigQuestion(int bigQuestionId)
        {           
            var deletedIds = BllFactory.Current.SmallQuestionService.GetIds("BigQuestionId",bigQuestionId);
            var bigQuestion =
                BllFactory.Current.BigQuestionService.LoadEntities(bq => bq.ID == bigQuestionId)
                    .ToArray()
                    .FirstOrDefault();
            if(bigQuestion ==null)
                return OperateContext.RedirectAjax(new AjaxMessage()
                {
                    Data = new{},//多地登录或多页面打开 同时操作会造成这种情况
                    Message = "该数据已被删除！",
                    Status = "error"
                });  
            BllFactory.Current.BigQuestionService.Delete(bigQuestionId);
            //删除大题所包含的小题
            BllFactory.Current.SmallQuestionService.Delete(sq => sq.BigQuestionID == bigQuestionId);
            BllFactory.Current.BigQuestionService.Savechanges();
            //判断该大题所属试卷是否还有大题，没有则直接删除！
            var allReleatedBigQuestion =
                BllFactory.Current.BigQuestionService.LoadEntities(bq => bq.TestPaperID == bigQuestion.TestPaperID).ToArray();
            var testPaperId = bigQuestion.TestPaperID;
            //试卷不包含任何内容，删除试卷,并重置客户端TestPaperId
            if (!allReleatedBigQuestion.Any())
            {
                BllFactory.Current.TestPaperService.Delete(bigQuestion.TestPaperID);
                testPaperId = 0;
            }
            BllFactory.Current.BigQuestionService.Savechanges();

            return OperateContext.RedirectAjax(new AjaxMessage()
            {
                Data = new { TestPaperId = testPaperId,DeleteIds =deletedIds },//最后一个大题删除时，所属试卷则也被删除，要告诉客户端重置试卷ID为0
                Message = "删除成功！",
                Status = "ok"
            });
        }

        [HttpPost]//修改大题
        public ActionResult UpdateBigQuestion(int id,string remark,string title,short score)
        {
            var bigQuestion = BllFactory.Current.BigQuestionService.LoadEntities(q => q.ID == id).First();
            bigQuestion.Remark = remark;
            bigQuestion.Title = title;
            bigQuestion.Score = score;
            bigQuestion.SubTime = DateTime.Now;
            var isOk = BllFactory.Current.BigQuestionService.Update(bigQuestion);
            BllFactory.Current.BigQuestionService.Savechanges();
            return Content(isOk.ToString());
        }

        [HttpPost]//添加小试题
        public ActionResult AddSmallQuestion(int bigQuestionId, string choiceQuestions, string fillingQuestions, 
            string truefalseQuestions, string shortQuestions,short score)
        {

            //TODO:查询该大题所属的试卷是所包含的所有相应小题，若包含，则不添加
            try
            {
                var bigQuestion = BllFactory.Current.BigQuestionService.LoadEntities(bq => bq.ID == bigQuestionId).ToArray().First();//没有查出，则报错
            }
            catch (Exception e)
            {
                return OperateContext.RedirectAjax(new AjaxMessage()
                {
                  Status = "error",
                  Message = "请检查所属大题是否被删除！"
                });
            }            
            //转换成int数组
            var cQIdList = choiceQuestions.ToInts(new []{','});
            var fQIdList = fillingQuestions.ToInts(new[] { ',' });
            var tQIdList = truefalseQuestions.ToInts(new[] { ',' });
            var sQIdList = shortQuestions.ToInts(new[] { ',' });
            //将小题添加到相应的大题
            AddSmallQuestion(cQIdList, QuestionType.ChoiceQuestion, bigQuestionId,score);
            AddSmallQuestion(fQIdList, QuestionType.FillingQuestion, bigQuestionId, score);
            AddSmallQuestion(tQIdList, QuestionType.TrueFalseQuestion, bigQuestionId, score);
            AddSmallQuestion(sQIdList, QuestionType.ShortQuestion, bigQuestionId, score);
            //查询所有相关试题信息，并返回到客户端
            List<QuestionInfo> questionList;
            var count = GetSmallQuestions(cQIdList, fQIdList, tQIdList, sQIdList, out questionList);
            return OperateContext.RedirectAjax(new AjaxMessage()
            {
                Message = "添加"+count+"个小题成功！",
                Status = "ok",
                Data = questionList,
            });
        }

        private  int GetSmallQuestions(int[] cQIdList, int[] fQIdList, int[] tQIdList, int[] sQIdList,
            out List<QuestionInfo> questionList,int bigQuestionId = 0)
        {
            var cqQuestions = BllFactory.Current.ChoiceQuestionService.LoadEntities(q => cQIdList.Contains(q.ID));
            var fqQuestions = BllFactory.Current.FillingQuestionService.LoadEntities(q => fQIdList.Contains(q.ID));
            var tqQuestions = BllFactory.Current.TrueFalseQuestionService.LoadEntities(q => tQIdList.Contains(q.ID));
            var sqQuestions = BllFactory.Current.ShortQuestionService.LoadEntities(q => sQIdList.Contains(q.ID));
            var count = cQIdList.Length + fQIdList.Length + tQIdList.Length + sQIdList.Length;
            BllFactory.Current.SmallQuestionService.Savechanges();

            //大题若存在
            //还需判断小题是否存在，可能只有大题，而并不包含小题
            IEnumerable<SmallQuestion> smallQuestions = new List<SmallQuestion>();
            var bigQuestion = new BigQuestion() {ID=0};
            var score = 0;
            if (bigQuestionId != 0)
            {
                bigQuestion =
                    BllFactory.Current.BigQuestionService.LoadEntities(b => b.ID == bigQuestionId).FirstOrDefault();
                smallQuestions =
                    BllFactory.Current.SmallQuestionService.LoadEntities(s => s.BigQuestionID == bigQuestionId).ToArray();
                if (!smallQuestions.Any())
                {
                    score = bigQuestion.Score;
                }
            }
            questionList = new List<QuestionInfo>();


            foreach (var question in cqQuestions)
            {
                if (bigQuestionId != 0 && smallQuestions.Any())
                    score  =
                        BllFactory.Current.SmallQuestionService.LoadEntities(
                            q =>
                                q.BigQuestionID == bigQuestionId && q.QuestionID == question.ID &&
                                q.QuestionType == QuestionType.ChoiceQuestion).ToArray().FirstOrDefault().Score;
                questionList.Add(new QuestionInfo()
                {
                    Id = question.ID,
                    Title = question.Content,
                    Choices = new List<string>()
                    {
                        question.SelectA, 
                        question.SelectB, 
                        question.SelectC,
                        question.SelectD, 
                        question.SelectE,
                        question.SelectF,
                    },
                    IsMutilSelect = question.IsMultiSelect,
                    Answer = question.Answers,
                    QuestionType = "CQ",
                    EnumQuestionType = QuestionType.ChoiceQuestion,
                    Score = score,
                    QuestionRemark = question.Remark
                });
            }
            foreach (var question in fqQuestions)
            {
                if (bigQuestionId != 0 && smallQuestions.Any())
                    score =
                        BllFactory.Current.SmallQuestionService.LoadEntities(
                            q =>
                                q.BigQuestionID == bigQuestionId && q.QuestionID == question.ID &&
                                q.QuestionType == QuestionType.FillingQuestion).ToArray().FirstOrDefault().Score;
                questionList.Add(new QuestionInfo()
                {
                    Id = question.ID,
                    Title = question.Content,
                    Answer = question.Answers,
                    QuestionType = "FQ",
                    EnumQuestionType = QuestionType.FillingQuestion,
                    Score = score,
                    QuestionRemark = question.Remark
                });
            }
            foreach (var question in tqQuestions)
            {
                if (bigQuestionId != 0 && smallQuestions.Any())
                    score =
                        BllFactory.Current.SmallQuestionService.LoadEntities(
                            q =>
                                q.BigQuestionID == bigQuestionId && q.QuestionID == question.ID &&
                                q.QuestionType == QuestionType.TrueFalseQuestion).ToArray().FirstOrDefault().Score;
                questionList.Add(new QuestionInfo()
                {
                    Id = question.ID,
                    Title = question.Content,
                    Answer = (bool) question.Answers ? "对" : "错",
                    QuestionType = "TQ",
                    EnumQuestionType = QuestionType.TrueFalseQuestion,
                    Score = score,
                    QuestionRemark = question.Remark
                });
            }
            foreach (var question in sqQuestions)
            {
                if (bigQuestionId != 0 && smallQuestions.Any())
                    score =
                        BllFactory.Current.SmallQuestionService.LoadEntities(
                            q =>
                                q.BigQuestionID == bigQuestionId && q.QuestionID == question.ID &&
                                q.QuestionType == QuestionType.ShortQuestion).ToArray().FirstOrDefault().Score;
                questionList.Add(new QuestionInfo()
                {
                    Id = question.ID,
                    Title = question.Content,
                    Answer = question.Answers,
                    QuestionType = "SQ",
                    EnumQuestionType = QuestionType.ShortQuestion,
                    Score = score,
                    QuestionRemark = question.Remark
                });
            }
            return count;
        }

		/// <summary>
		/// 根据大题ID获取小题
		/// </summary>
		/// <param name="bigQuestionId"></param>
		/// <param name="questionList"></param>
		/// <returns></returns>
        private int GetSmallQuestions(int bigQuestionId,out List<QuestionInfo> questionList)
        {
            var smallQuestionList =
                BllFactory.Current.SmallQuestionService.LoadEntities(sq => sq.BigQuestionID == bigQuestionId).ToArray();
            //清空小题数据
            var cqString = new StringBuilder("");
            var fqString = new StringBuilder("");
            var tqString = new StringBuilder("");
            var sqString = new StringBuilder("");
            foreach (var smallQuestion in smallQuestionList)
            {
                switch (smallQuestion.QuestionType)
                {
                    case QuestionType.ChoiceQuestion:
                        cqString.Append(smallQuestion.QuestionID + ",");
                        break;
                    case QuestionType.FillingQuestion:
                        fqString.Append(smallQuestion.QuestionID + ",");
                        break;
                    case QuestionType.TrueFalseQuestion:
                        tqString.Append(smallQuestion.QuestionID + ",");
                        break;
                    case QuestionType.ShortQuestion:
                        sqString.Append(smallQuestion.QuestionID + ",");
                        break;
                }
            }
             return GetSmallQuestions(
                    cqString.ToString().ToInts(new []{','}),
                    fqString.ToString().ToInts(new []{','}),
                    tqString.ToString().ToInts(new []{','}),
                    sqString.ToString().ToInts(new []{','}),
                    out questionList,bigQuestionId);

        }

        //添加小试题
        private void AddSmallQuestion(int[] intIds,QuestionType qType,int bigQuestionId, short  score)
        {
            foreach (var cq in intIds)
            {
                BllFactory.Current.SmallQuestionService.Add(new SmallQuestion()
                {
                    BigQuestionID = bigQuestionId,
                    QuestionID = cq,
                    QuestionType = qType,
                    Score = score,
                });
            }
        }

        public ActionResult DeleteSmallQuestion(int bigQUestionId,int qId,string qType)
        {
            var result = 0;
            switch (qType.ToUpper())
            {
                case "CQ":
                   result= BllFactory.Current.SmallQuestionService.Delete(
                        q =>
                            q.BigQuestionID == bigQUestionId && q.QuestionID == qId &&
                            q.QuestionType == QuestionType.ChoiceQuestion);
                    break;
                case "FQ":
                    result =BllFactory.Current.SmallQuestionService.Delete(
                        q =>
                            q.BigQuestionID == bigQUestionId && q.QuestionID == qId &&
                            q.QuestionType == QuestionType.FillingQuestion);
                    break;
                case "TQ":
                    result =BllFactory.Current.SmallQuestionService.Delete(
                        q =>
                            q.BigQuestionID == bigQUestionId && q.QuestionID == qId &&
                            q.QuestionType == QuestionType.TrueFalseQuestion);
                    break;
                case "SQ":
                    result =BllFactory.Current.SmallQuestionService.Delete(
                        q =>
                            q.BigQuestionID == bigQUestionId && q.QuestionID == qId &&
                            q.QuestionType == QuestionType.ShortQuestion);
                    break;
            }
            BllFactory.Current.SmallQuestionService.Savechanges();
            if(result ==1)
                return OperateContext.RedirectAjax(new AjaxMessage()
                {
                    Message = "删除小题成功",
                    Status = "ok"
                });
            return OperateContext.RedirectAjax(new AjaxMessage()
            {
                Message = "请检查该小题是否已被删除！",
                Status = "error"
            });
        }

        public ActionResult ChangeSmallQuestionScore(int qid,string qType,int bQId,short score)
        {
            var questionType = QuestionType.ChoiceQuestion;
            switch (qType)
            {
                case "CQ":
                    questionType = QuestionType.ChoiceQuestion;break;
                case "FQ":
                    questionType = QuestionType.FillingQuestion;
                    break;
                case "TQ":
                    questionType = QuestionType.TrueFalseQuestion;
                    break;
                case "SQ":
                    questionType = QuestionType.ShortQuestion;break;;
            }
            var smallQuestion =
                BllFactory.Current.SmallQuestionService.LoadEntities(
                    q => q.BigQuestionID == bQId && q.QuestionType == questionType && q.QuestionID == qid).First();
            smallQuestion.Score = score;
            BllFactory.Current.SmallQuestionService.Update(smallQuestion);
            BllFactory.Current.SmallQuestionService.Savechanges();
            return OperateContext.RedirectAjax(new AjaxMessage()
            {
                Data = null,
                BackUrl = "",
                Message = "修改成功！",
                Status = "ok"
            });
        }
        
        [HttpGet]
        public ActionResult GetAcademyDepartment(int id=0)
        {
            var academyList = BllFactory.Current.AcademyService.LoadEntities(a => a.IsDeleted == 0, a => a.ClassInfo);
            var depList = BllFactory.Current.DepartmentService.LoadEntities(d => d.IsDeleted == 0);
            BllFactory.Current.AcademyService.Savechanges();//调用任何的SaveChanges()都可以
            IEnumerable<TestpaperTarget> testpaperTargets = new List<TestpaperTarget>();
            if (id != 0)
            {
                testpaperTargets = BllFactory.Current.TestpaperTargetService.LoadEntities(t => t.TestPaperID == id).ToArray();
            }
            var treeData = new List<EasyUiTreeData>();
            foreach (var academy in academyList)
            {
                var curData = new EasyUiTreeData()
                {
                    id = "Academy-" + academy.ID,
                    text = academy.Name,
                    Checked = testpaperTargets.Where(tp=>tp.TargetType==TestpaperTargetType.ToAcademy && tp.TargetID ==academy.ID).Any()
                };
                if (academy.ClassInfo.Any())
                {
                    foreach (var c in academy.ClassInfo)
                    {
                        //curData.Children = new List<EasyUiTreeData>();
                        curData.children.Add(new EasyUiTreeData()
                        {
                            id ="Class-" + c.ID,
                            text = c.ClassName,
                            children = null,
                            Checked = testpaperTargets.Where(tp => tp.TargetType == TestpaperTargetType.ToClass && tp.TargetID == c.ID).Any()
                        });
                    }
                }
                treeData.Add(curData);
            }



            foreach (var dep in depList)
            {
                treeData.Add(new EasyUiTreeData()
                {
                    id = "Dep-" + dep.ID, 
                    text = dep.Name, 
                    children = null,
                    Checked = testpaperTargets.Where(tp => tp.TargetType == TestpaperTargetType.ToDepartment && tp.TargetID == dep.ID).Any()
                });
            }
            return Json(treeData, JsonRequestBehavior.AllowGet);
        }


    }
}
