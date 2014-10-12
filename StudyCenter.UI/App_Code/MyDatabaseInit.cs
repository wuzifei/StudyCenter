using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using StudyCenter.Model;

namespace StudyCenter.UI.App_Code
{
    public class MyDatabaseInit<TContext> :DropCreateDatabaseIfModelChanges<TContext> where TContext :DbContext 
    {
		public new void Seed(TContext context) 
        {
            context.Set<PaperCategory>().Add(new PaperCategory()
            {
                Name = "IT",
                ParentID = 0,
            });
            context.Set<PaperCategory>().Add(new PaperCategory()
            {
                Name = "管理",
                ParentID = 0,
            });
            context.Set<PaperCategory>().Add(new PaperCategory()
            {
                Name = "asp.net",
                ParentID = 1,
            });
            context.Set<PaperCategory>().Add(new PaperCategory()
            {
                Name = "jsp",
                ParentID = 1,
            });
            context.Set<PaperCategory>().Add(new PaperCategory()
            {
                Name = "php",
                ParentID = 1,
            });
            context.Set<PaperCategory>().Add(new PaperCategory()
            {
                Name = "金融管理",
                ParentID = 2,
            });

            context.SaveChanges();

            #region 添加用户信息 班级 学院 个人详细信息
            context.Set<Academy>().Add(new Academy
            {
                Description = "First",
                Name = "数计学院",
                Population = 1000,
                President = "wuzifei",
                Phone = "13065187972",
                SiteUrl = "t.qq.com",
                IconUrl = "me.com",
                Remark = "我是学院院长，我怕谁",
            });

            context.Set<Academy>().Add(new Academy
            {
               Description = "Second",
               Name = "外国语学院",
               Population = 1000,
               Phone = "13065187972",
               SiteUrl = "t.qq.com",
               IconUrl = "me.com",
               Remark = "我是学院院长，我怕谁",
           });

            context.SaveChanges();

            context.Set<ClassInfo>().Add(new ClassInfo
            {
                ClassName = "11计算机科学与技术师范班",
                Population = 55,
                SiteUrl = "computer.com",
                ClassIcon = "computer.com",
                SubTime = DateTime.Now,
                Remark = "班级信息",
                AcademyID = context.Set<Academy>().ToArray().FirstOrDefault().ID,
            });
            context.Set<ClassInfo>().Add(new ClassInfo
            {
                ClassName = "12计算机科学与技术师范班",
                Population = 55,
                SiteUrl = "computer.com",
                ClassIcon = "computer.com",
                SubTime = DateTime.Now,
                Remark = "班级信息",
                AcademyID = context.Set<Academy>().ToArray().FirstOrDefault().ID,
            });
            context.Set<ClassInfo>().Add(new ClassInfo
            {
                ClassName = "13计算机科学与技术师范班",
                Population = 55,
                SiteUrl = "computer.com",
                ClassIcon = "computer.com",
                SubTime = DateTime.Now,
                Remark = "班级信息",
                AcademyID = context.Set<Academy>().ToArray().FirstOrDefault().ID,
            });

            context.SaveChanges();

            context.Set<User>().Add(new User
                {
                    UserNumber = "20111931",
                    UserName = "吴自飞",
                    NickName = "SimpleCoder",
                    UserPwd = "wuzifei",
                    Experiences = 9999,
                    Golds = 9999,
                    LastLoginTime = DateTime.Now,
                    Email = "wuzifei@hotmail.com",
                    SafeQuestion = "你是谁？",
                    SafeAnswer = "吴自飞",
                    Remark = "吴自飞是一个好学生",
                    SubTime = DateTime.Now,
                    ClassInfoID = context.Set<ClassInfo>().ToArray().FirstOrDefault().ID,
                    AcademyID = context.Set<Academy>().ToArray().FirstOrDefault().ID,
                });
            context.SaveChanges();

            context.Set<UserInfo>().Add(new UserInfo
            {
                Gender = "男",
                Birthday = DateTime.Now,
                Interest = "code",
                Height = 170,
                Weight = 55,
                BlogUrl = "www.cnblogs.com/wuzifei",
                MicroBlogUrl = "t.qq.com/greatcoder",
                WeChatAccount = "SimpleCoder",
                LivePlace = "南昌",
                GovFace = "团员",
                IdNumber = "362330199405153072",
                TelNumber = "13065187972",
                QqNumber = 274110020,
                SubTime = DateTime.Now,
                Remark = "吴自飞的个人信息",
                Address = "江西省南昌市",
                User = context.Set<User>().ToArray().FirstOrDefault(),
            });
            context.SaveChanges();

            #endregion	
		
             context.Set(typeof(Article)).Add(new Article
			{
				Title = "Unity3D入门",
				Content = "Unity3D入门Unity3D入门",
				EndTime = DateTime.Now,
				PublishTime = DateTime.Now,
				ArticleType = ArticleType.IsArticle,
				LikePoint = 2,
				RecommendPoint = 1,
				DislikePoint = 2,
				ReadTimes = 1,
				Tips = "Unity3D,C#,游戏",
				Publisher = context.Set<User>().ToArray().FirstOrDefault(),

			});

			context.Set(typeof(Article)).Add(new Article
			{
				Title = "c#入门",
				Content = "c#入门c#入门c#入门c#入门",
				EndTime = DateTime.Now,
				PublishTime = DateTime.Now,
				ArticleType = ArticleType.IsNews,
				LikePoint = 2,
				RecommendPoint = 1,
				DislikePoint = 2,
				ReadTimes = 1,
				Tips = "Unity3D,C#,游戏",
                Publisher = context.Set<User>().ToArray().FirstOrDefault(),

			});

            context.Set<ChoiceQuestion>().Add(new ChoiceQuestion 
            {
                Content = "你最喜欢的人是谁？",
                SelectA = "吴自飞",
                SelectB = "吴自飞",
                SelectC = "吴自飞",
                SelectD = "吴自飞",
                Answers = "A|B|C|D",
                IsMultiSelect = true,
                IsPublic = true,
                Difficulty = 1,
                Publisher = context.Set<User>().ToArray().FirstOrDefault()
            });


            context.Set<Course>().Add(new Course() {
                CourseName = "数据库原理",
                Description = "数据库原理是一门很重要的课程",
                Remark = "这是一门课",
                SubTime = DateTime.Now,
                
            });

            context.Set<Department>().Add(new Department
            {
                Name = "组织部门",
                Population = 111,
                Boss = "李映刚",
                Phone = "19779160998",
                SiteUrl = "computer.com",
                IconUrl = "me.com",
                Number = "zuozhi001",
                Remark = "组织部门描述信息",
                ParentId = 0,
                IsLeaf = true,
                Level = 1
            });

				context.Set<File>().Add(new File
                {
					 Remark = "文章附件",
					 SubTime = DateTime.Now,	
					 FileName="图片1",
					 FileSize	= 1024,
					 FileType = "jpg",//后缀名
					 FileUrl = "./Content/Images/1.jpg",
					 DownloadTimes = 1,
                     Article = context.Set<Article>().ToArray().FirstOrDefault(),
                     User = context.Set<User>().ToArray().FirstOrDefault()
				});

				context.Set<File>().Add(new File
				{
					Remark = "新闻附件",
					SubTime = DateTime.Now,
					FileName = "图片222",
					FileSize = 1024,
					FileType = "jpg",//后缀名
					FileUrl = "./Content/Images/2.jpg",
					DownloadTimes = 1,
                    Article = context.Set<Article>().ToArray().FirstOrDefault(),
                    User = context.Set<User>().ToArray().FirstOrDefault()
                });

            context.Set<FillingQuestion>().Add(new FillingQuestion
            {
                Content = "你最喜欢的人是____,你喜欢他的____？",
                Answers = "吴自飞|一切",
                IsMultiFilling = true,
                IsPublic = true,
                Difficulty = 3,
                Remark = "这是填空题" ,
                SubTime = DateTime.Now,
                Publisher = context.Set<User>().ToArray().FirstOrDefault()   
            });

				context.Set<Friend>().Add(new Friend
				{
					Remark = "好友1",
					SubTime = DateTime.Now,
					UserId = context.Set<User>().ToArray().FirstOrDefault().ID,
					FriendId = context.Set<User>().ToArray().FirstOrDefault().ID,
					AddTime = DateTime.Now
				});


				context.Set<Item>().Add(new Item
				{
					Name = "道具转让",
					Effect = "使用该道具可以将自己已有的道具转让给好友,一次消耗一个",
					Target =ItemTargetType.ToOtherUser,
					ItemEffectType = ItemEffectType.IsOneTime,
					Price = 20,
					EffectDays = 0,//默认为0,表示是一次性的
					SubTime = DateTime.Now
				});

				context.SaveChanges();

				context.Set<UserItem>().Add(new UserItem
				{
					Count = 10,
					UsedCount = 1,
					StartUseTime = DateTime.Now,//可以不设置
					EndUseTime = DateTime.Now,//两个时间一样说明是一次性的
					User = context.Set<User>().FirstOrDefault(),
					Item = context.Set<Item>().FirstOrDefault(),
				});

			 context.SaveChanges();

            context.Set<Permission>().Add(new Permission
            {
                Url = "/index/home",
                HttpMethod = "all",
                Action = "home",
                Controoller = "index",
                Area = "admin",
                SubTime = DateTime.Now,
                Remark = "用户首页,需登录才可进入",
            });

            var newRoles = new HashSet<Role>
            {
                new Role
                {
                    RoleName = "学生",
                    SubTime = DateTime.Now,
                    Remark = "学生权限比较少"
                },
                new Role
                {
                    RoleName = "管理员",
                    SubTime = DateTime.Now,
                    Remark = "管理角色"
                },
                new Role
                {
                    RoleName = "教师",
                    SubTime = DateTime.Now,
                    Remark = "管理学生"
                },
                new Role
                {
                    RoleName = "超级管理员",
                    SubTime = DateTime.Now,
                    Remark = "管理管理员及教师及学生"
                },
                new Role
                {
                    RoleName = "黑客",
                    SubTime = DateTime.Now,
                    Remark = "后门"
                }
            };


            //角色已存在则不增加新角色
            //IEnumerable role;
            //role = (
            //    from oldRole in oldRoles
            //    from newRole in newRoles
            //    where newRole.RoleName != oldRole.RoleName
            //    select newRole
            //       ).AsEnumerable();
            foreach(var newRole in newRoles)
            {
                if (!(from r in context.Set<Role>().ToArray()
                        where r.RoleName==newRole.RoleName
                        select r).Any())
                    context.Set<Role>().Add(newRole);
            }

            //if(role!=null)
            //    foreach (var r in role)
            //    {
            //        context.Set<Role>().Add(r as Role);
            //    }
            context.SaveChanges();
 

            context.Set<ShortQuestion>().Add(new ShortQuestion
            {
                Content = "说说你最喜欢的人是怎么样的一个人？",
                Answers = "我最喜欢的人是吴自飞，喜欢他，没理由",
                IsPublic = true,
                Difficulty = 4,
                Remark = "这是填空题" ,
                SubTime = DateTime.Now,
                Publisher = context.Set<User>().ToArray().FirstOrDefault(),
                Course = context.Set<Course>().ToArray().FirstOrDefault()
            });


				//特殊权限：User - SpecialPermission - Permission
				//对应关系：	1,0			*	*					1,0
            context.Set<SpecialPermission>().Add(new SpecialPermission
            {
                IsPass = true,
                SubTime = DateTime.Now,
                Remark = "开启特权模式",
				User = context.Set<User>().ToArray().FirstOrDefault(),
				Permission = context.Set<Permission>().ToArray().FirstOrDefault()
            });

			 context.SaveChanges();



            context.Set<TestPaper>().Add(new TestPaper
            {
                SubTime = DateTime.Now,
                Remark = "数据库作业",
                PaperName = "数据库期中考试作业练习",
                PaperDate = DateTime.Now,
                StartTime = DateTime.Now.AddDays(10),
                EndTime = DateTime.Now.AddDays(10).AddHours(2),
                //ShortTitle = "简答题",
                //ShortDes = "每小题10分，共三小题",
                //ShortScore = 30,
                //TrueFalseTitle = "判断题",
                //TrueFalseDes = "没小题1分，共10小题",
                //TrueFalseScore = 10,
                //SelectQuestionTItle = "选择题",
                //SelectQuestionDes = "没小题3分，共10题，多选的请多选，漏选1分，错选0分",
                //SelectQuestionScore = 30,
                //FillingTitle = "填空题",
                //FillingDes = "每空2分，共15空",
                //FillingScore = 30,
                PaperScore = 100,
                PaperDescription = "数据库其中考试试卷",
                PaperType = PaperType.HomeWork,
                Publisher = context.Set<User>().ToArray().FirstOrDefault(),
                Course = context.Set<Course>().ToArray().FirstOrDefault()

            });


		     context.SaveChanges();

            context.Set<StudentPaper>().Add(new StudentPaper
            {
                SubmitTime = DateTime.Now.AddDays(10).AddHours(2),
                StartTime = DateTime.Now.AddDays(10),
                PaperScore = 50,
                Remark = "考的不咋地，加油",
                TeacherWords = "又退步了，下次不及格来我办公室！",
                TestPaper = context.Set<TestPaper>().ToArray().FirstOrDefault(),
                User = context.Set<User>().ToArray().FirstOrDefault()
            });
            context.Set<StudentPaper>().Add(new StudentPaper
            {
                SubmitTime = DateTime.Now.AddDays(10).AddHours(2),
                StartTime = DateTime.Now.AddDays(10),
                PaperScore = 50,
                Remark = "考的不咋地，加油",
                TeacherWords = "又退步了，下次不及格来我办公室！",
                TestPaper = context.Set<TestPaper>().ToArray().FirstOrDefault(),
                User = context.Set<User>().ToArray().FirstOrDefault()
            });

            context.Set<StudentPaper>().Add(new StudentPaper
            {
                SubmitTime = DateTime.Now.AddDays(10).AddHours(2),
                StartTime = DateTime.Now.AddDays(10),
                PaperScore = 50,
                Remark = "考的不咋地，加油",
                TeacherWords = "又退步了，下次不及格来我办公室！",
                TestPaper = context.Set<TestPaper>().ToArray().FirstOrDefault(),
                User = context.Set<User>().ToArray().FirstOrDefault()
            });

            context.Set<TrueFalseQuestion>().Add(new TrueFalseQuestion
            {

                Content = "你喜欢吴自飞吗？",
                Answers = true,
                Remark = "大家都喜欢",
                Difficulty = 5,
                Publisher = context.Set<User>().ToArray().FirstOrDefault(),
                Course = context.Set<Course>().ToArray().FirstOrDefault()                
            });
				context.SaveChanges();

			 context.Set<Vote>().Add(new Vote
			 {
				 VoteTitle = "大一新生是否应该晚自习",
				 ClassName = "学习",
				 VoteContent = "投票的相关信息",
				 MoreInfo = "投票的说明信息木有了",
				 Option1 ="应该晚自习",
				 Option2 ="不应该晚自习",
				 Option3 = "中立",
				 Option4 = "非常不赞同",
				 Option5 = "非常赞同",
				 IsMutilSelect = false,
				 MutilSelectCount = 1,
				 VoteImageUrl = "/content/images/1.jpg",
				 ParentId = 0,
                 PublisherID = context.Set<User>().ToArray().FirstOrDefault().ID,
				 StartTime = DateTime.Now,
				 EndTime = DateTime.Now.AddDays(100)
			 });

			 context.SaveChanges();
			 context.Set<Voted>().Add(new Voted
			 {
                UserID = context.Set<User>().ToArray().FirstOrDefault().ID,
		        Reason = "都大学生了还上晚自习强烈反对",
		        SelectOptions = "4",
		        PostTime = DateTime.Now.AddDays(1),
			 });
			 context.Set<Vote>().Find(1).Voted.Add(context.Set<Voted>().FirstOrDefault());
             context.SaveChanges();


        }
    }
}