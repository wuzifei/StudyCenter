using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using StudyCenter.BLL;
using StudyCenter.IBLL;
using StudyCenter.Model;
using StudyCenter.Model.ViewModel;
using StudyCenter.UI.ViewModel;

namespace StudyCenter.UI.Controllers
{
    public class StudyController : AuthorizedController
    {
        //
        // GET: /Study/
        private IStudentPaperService studentPaper = BllFactory.Current.StudentPaperService;
        public ActionResult Index()
        {
            return View();
            //return RedirectToAction("Student");
        }

        /// <summary>
        /// 学生作业
        /// </summary>
        /// <returns></returns>
        public ActionResult HomeWork( )
        {

            int pageIndex;
            int pageSize;
            if (!int.TryParse( Request.QueryString["pageSize"],out pageSize))
                pageSize = 5;
            if (!int.TryParse(Request.QueryString["pageIndex"], out pageIndex))
                pageIndex = 1;
            int total;
            var studentPapers = studentPaper.LoadPageEntities(pageSize, pageIndex, out total,
                                        s => s.IsDeleted == 0, s => s.StartTime, true).ToArray();
            ViewBag.StudentPapers = studentPapers;
            ViewBag.TotalPage = total/pageSize +1;
            ViewBag.PageIndex = pageIndex;
            return View(studentPapers);
        }

        public ActionResult TaskList()
        {

            return View();
        }

        public ActionResult Task(int id)
        {

            return View();
        }

        public ActionResult TeacherCenter()
        {
            return View();
        }

        public ActionResult Student()
        {
            var userId = OperateContext.Current.CurrentUser.ID;
            var academyId = OperateContext.Current.CurrentUser.AcademyID;
            var classInfoId = OperateContext.Current.CurrentUser.ClassInfoID;
            var deps = OperateContext.Current.CurrentUser.Department.ToArray();
            var depids = new List<int>();
            foreach (var department in deps)
            {
                depids.Add(department.ID);
            }
            var targets = BllFactory.Current.TestpaperTargetService.LoadEntities(
                t=>(t.TargetID==academyId && t.TargetType==TestpaperTargetType.ToAcademy)
                    || 
                    (t.TargetID==classInfoId && t.TargetType== TestpaperTargetType.ToClass)
                    ||
                    (depids.Contains((int) t.TargetID) && t.TargetType==TestpaperTargetType.ToDepartment));
            var testpaperIds = from t in targets select t.TestPaperID;
            var testpapers = BllFactory.Current.TestPaperService.LoadEntities(t => testpaperIds.Contains(t.ID) &&t.PaperType!=PaperType.Private).ToArray();
            var studentPapers =
                BllFactory.Current.StudentPaperService.LoadEntities(
                    s => testpaperIds.Contains(s.TestPaperID) && s.UserID == userId).ToArray();
            var testpaperHasDone = from t in testpapers
                                           join s in studentPapers 
                                           on t.ID equals s.TestPaperID
                                           select new StudyStudent
                                            {
                                                Id = t.ID,
                                                Name = t.PaperName,
                                                Publisher = t.Publisher.UserName,
                                                PaperType = t.PaperType,
                                                TestDate = t.StartTime,
                                                TotalScore = t.PaperScore,
                                                GetScore = s.PaperScore,
                                            } ;
            var studyStudents = testpaperHasDone as StudyStudent[] ?? testpaperHasDone.ToArray();
            var hasDoneIds = from t in studyStudents select t.Id;
            var testpaperToDo = from t in testpapers 
                                where !hasDoneIds.Contains(t.ID)
                                select new StudyStudent
                                {
                                    Id = t.ID,
                                    Name = t.PaperName,
                                    Publisher = t.Publisher.UserName,
                                    PaperType = t.PaperType,
                                    TestDate = t.StartTime,
                                    TotalScore = t.PaperScore,
                                    GetScore = -1,
                                };

            var testpaperInfo = new List<StudyStudent>();
            testpaperInfo.AddRange(studyStudents);
            testpaperInfo.AddRange(testpaperToDo);
            var homework = from m in testpaperInfo where m.PaperType == PaperType.HomeWork select m;
            var fortest = from m in testpaperInfo where m.PaperType == PaperType.ForTest select m;
            var topublic = from m in testpaperInfo where m.PaperType == PaperType.Public select m;

            return View(new StudentPaperInfo
            {
                HomeWork = homework,
                UndoneHomeWorkCount = homework.Where(h=>h.GetScore==-1).Count(),
                ForTest = fortest,
                UndoneForTestCount = fortest.Where(h => h.GetScore == -1).Count(),
                ToPublic = topublic,
                UndoneToPublicCount = topublic.Where(h => h.GetScore == -1).Count(),

            });
        }
    }
}
