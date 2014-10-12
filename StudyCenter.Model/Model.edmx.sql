
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/08/2014 02:01:43
-- Generated from EDMX file: D:\SourceCode\StudyCenter\StudyCenter.Model\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [StudyCenter];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AcademyUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_AcademyUser];
GO
IF OBJECT_ID(N'[dbo].[FK_AnswerUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer] DROP CONSTRAINT [FK_AnswerUser];
GO
IF OBJECT_ID(N'[dbo].[FK_ArticleUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Article] DROP CONSTRAINT [FK_ArticleUser];
GO
IF OBJECT_ID(N'[dbo].[FK_AttachmentArticle]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[File] DROP CONSTRAINT [FK_AttachmentArticle];
GO
IF OBJECT_ID(N'[dbo].[FK_ClassInfoAcademy]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClassInfo] DROP CONSTRAINT [FK_ClassInfoAcademy];
GO
IF OBJECT_ID(N'[dbo].[FK_CommentArticle]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comment] DROP CONSTRAINT [FK_CommentArticle];
GO
IF OBJECT_ID(N'[dbo].[FK_CourseAcademy_Academy]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourseAcademy] DROP CONSTRAINT [FK_CourseAcademy_Academy];
GO
IF OBJECT_ID(N'[dbo].[FK_CourseAcademy_Course]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourseAcademy] DROP CONSTRAINT [FK_CourseAcademy_Course];
GO
IF OBJECT_ID(N'[dbo].[FK_CourseChoiceQuestion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChoiceQuestion] DROP CONSTRAINT [FK_CourseChoiceQuestion];
GO
IF OBJECT_ID(N'[dbo].[FK_CourseFillingQuestion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FillingQuestion] DROP CONSTRAINT [FK_CourseFillingQuestion];
GO
IF OBJECT_ID(N'[dbo].[FK_CourseShortQuestion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ShortQuestion] DROP CONSTRAINT [FK_CourseShortQuestion];
GO
IF OBJECT_ID(N'[dbo].[FK_CourseTrueFalseQuestion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TrueFalseQuestion] DROP CONSTRAINT [FK_CourseTrueFalseQuestion];
GO
IF OBJECT_ID(N'[dbo].[FK_FileUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[File] DROP CONSTRAINT [FK_FileUser];
GO
IF OBJECT_ID(N'[dbo].[FK_FillingQuestionUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FillingQuestion] DROP CONSTRAINT [FK_FillingQuestionUser];
GO
IF OBJECT_ID(N'[dbo].[FK_ItemUserItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserItem] DROP CONSTRAINT [FK_ItemUserItem];
GO
IF OBJECT_ID(N'[dbo].[FK_PermissionRole_Permission]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PermissionRole] DROP CONSTRAINT [FK_PermissionRole_Permission];
GO
IF OBJECT_ID(N'[dbo].[FK_PermissionRole_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PermissionRole] DROP CONSTRAINT [FK_PermissionRole_Role];
GO
IF OBJECT_ID(N'[dbo].[FK_ShortQuestionUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ShortQuestion] DROP CONSTRAINT [FK_ShortQuestionUser];
GO
IF OBJECT_ID(N'[dbo].[FK_SpecialPermissionPermission]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SpecialPermission] DROP CONSTRAINT [FK_SpecialPermissionPermission];
GO
IF OBJECT_ID(N'[dbo].[FK_SpecialPermissionUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SpecialPermission] DROP CONSTRAINT [FK_SpecialPermissionUser];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentPaperTestPaper]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudentPaper] DROP CONSTRAINT [FK_StudentPaperTestPaper];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentPaperUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudentPaper] DROP CONSTRAINT [FK_StudentPaperUser];
GO
IF OBJECT_ID(N'[dbo].[FK_TeacherVerifyUserPaper_TestPaper]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TeacherVerifyUserPaper] DROP CONSTRAINT [FK_TeacherVerifyUserPaper_TestPaper];
GO
IF OBJECT_ID(N'[dbo].[FK_TeacherVerifyUserPaper_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TeacherVerifyUserPaper] DROP CONSTRAINT [FK_TeacherVerifyUserPaper_User];
GO
IF OBJECT_ID(N'[dbo].[FK_TestPaperBigQuestion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BigQuestion] DROP CONSTRAINT [FK_TestPaperBigQuestion];
GO
IF OBJECT_ID(N'[dbo].[FK_TestPaperCourse]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TestPaper] DROP CONSTRAINT [FK_TestPaperCourse];
GO
IF OBJECT_ID(N'[dbo].[FK_TestPaperUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TestPaper] DROP CONSTRAINT [FK_TestPaperUser];
GO
IF OBJECT_ID(N'[dbo].[FK_TestPaperUserCheck_TestPaper]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TestPaperUserCheck] DROP CONSTRAINT [FK_TestPaperUserCheck_TestPaper];
GO
IF OBJECT_ID(N'[dbo].[FK_TestPaperUserCheck_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TestPaperUserCheck] DROP CONSTRAINT [FK_TestPaperUserCheck_User];
GO
IF OBJECT_ID(N'[dbo].[FK_TrueFalseQuestionUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TrueFalseQuestion] DROP CONSTRAINT [FK_TrueFalseQuestionUser];
GO
IF OBJECT_ID(N'[dbo].[FK_UserChoiceQuestion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChoiceQuestion] DROP CONSTRAINT [FK_UserChoiceQuestion];
GO
IF OBJECT_ID(N'[dbo].[FK_UserClassInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_UserClassInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_UserDepartment_Department]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserDepartment] DROP CONSTRAINT [FK_UserDepartment_Department];
GO
IF OBJECT_ID(N'[dbo].[FK_UserDepartment_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserDepartment] DROP CONSTRAINT [FK_UserDepartment_User];
GO
IF OBJECT_ID(N'[dbo].[FK_UserFavoritesArticle_Article]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserFavoritesArticle] DROP CONSTRAINT [FK_UserFavoritesArticle_Article];
GO
IF OBJECT_ID(N'[dbo].[FK_UserFavoritesArticle_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserFavoritesArticle] DROP CONSTRAINT [FK_UserFavoritesArticle_User];
GO
IF OBJECT_ID(N'[dbo].[FK_UserInfoUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserInfo] DROP CONSTRAINT [FK_UserInfoUser];
GO
IF OBJECT_ID(N'[dbo].[FK_UserItemUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserItem] DROP CONSTRAINT [FK_UserItemUser];
GO
IF OBJECT_ID(N'[dbo].[FK_UserRole_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserRole] DROP CONSTRAINT [FK_UserRole_Role];
GO
IF OBJECT_ID(N'[dbo].[FK_UserRole_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserRole] DROP CONSTRAINT [FK_UserRole_User];
GO
IF OBJECT_ID(N'[dbo].[FK_VoteClassVote]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vote] DROP CONSTRAINT [FK_VoteClassVote];
GO
IF OBJECT_ID(N'[dbo].[FK_VotedUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Voted] DROP CONSTRAINT [FK_VotedUser];
GO
IF OBJECT_ID(N'[dbo].[FK_VotedVote]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Voted] DROP CONSTRAINT [FK_VotedVote];
GO
IF OBJECT_ID(N'[dbo].[FK_VoteUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vote] DROP CONSTRAINT [FK_VoteUser];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Academy]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Academy];
GO
IF OBJECT_ID(N'[dbo].[Answer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer];
GO
IF OBJECT_ID(N'[dbo].[Article]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Article];
GO
IF OBJECT_ID(N'[dbo].[BigQuestion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BigQuestion];
GO
IF OBJECT_ID(N'[dbo].[ChoiceQuestion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChoiceQuestion];
GO
IF OBJECT_ID(N'[dbo].[ClassInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClassInfo];
GO
IF OBJECT_ID(N'[dbo].[Comment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comment];
GO
IF OBJECT_ID(N'[dbo].[Course]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Course];
GO
IF OBJECT_ID(N'[dbo].[CourseAcademy]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CourseAcademy];
GO
IF OBJECT_ID(N'[dbo].[Department]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Department];
GO
IF OBJECT_ID(N'[dbo].[File]', 'U') IS NOT NULL
    DROP TABLE [dbo].[File];
GO
IF OBJECT_ID(N'[dbo].[FillingQuestion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FillingQuestion];
GO
IF OBJECT_ID(N'[dbo].[Friend]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Friend];
GO
IF OBJECT_ID(N'[dbo].[Item]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Item];
GO
IF OBJECT_ID(N'[dbo].[Log]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Log];
GO
IF OBJECT_ID(N'[dbo].[PaperCategory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PaperCategory];
GO
IF OBJECT_ID(N'[dbo].[Permission]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Permission];
GO
IF OBJECT_ID(N'[dbo].[PermissionRole]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PermissionRole];
GO
IF OBJECT_ID(N'[dbo].[Role]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Role];
GO
IF OBJECT_ID(N'[dbo].[ShortQuestion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ShortQuestion];
GO
IF OBJECT_ID(N'[dbo].[SmallQuestion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SmallQuestion];
GO
IF OBJECT_ID(N'[dbo].[SpecialPermission]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SpecialPermission];
GO
IF OBJECT_ID(N'[dbo].[StudentPaper]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StudentPaper];
GO
IF OBJECT_ID(N'[dbo].[TeacherVerifyUserPaper]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TeacherVerifyUserPaper];
GO
IF OBJECT_ID(N'[dbo].[TestPaper]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TestPaper];
GO
IF OBJECT_ID(N'[dbo].[TestpaperTarget]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TestpaperTarget];
GO
IF OBJECT_ID(N'[dbo].[TestPaperUserCheck]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TestPaperUserCheck];
GO
IF OBJECT_ID(N'[dbo].[TrueFalseQuestion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TrueFalseQuestion];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[UserDepartment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserDepartment];
GO
IF OBJECT_ID(N'[dbo].[UserFavoritesArticle]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserFavoritesArticle];
GO
IF OBJECT_ID(N'[dbo].[UserInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserInfo];
GO
IF OBJECT_ID(N'[dbo].[UserItem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserItem];
GO
IF OBJECT_ID(N'[dbo].[UserRole]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserRole];
GO
IF OBJECT_ID(N'[dbo].[Vote]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Vote];
GO
IF OBJECT_ID(N'[dbo].[VoteClass]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VoteClass];
GO
IF OBJECT_ID(N'[dbo].[Voted]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Voted];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UserNumber] nvarchar(max)  NOT NULL,
    [UserName] nvarchar(max)  NOT NULL,
    [NickName] nvarchar(max)  NOT NULL,
    [UserPwd] nvarchar(20)  NOT NULL,
    [Experiences] int  NOT NULL,
    [Golds] int  NOT NULL,
    [LastLoginTime] datetime  NULL,
    [Email] nvarchar(max)  NULL,
    [SafeQuestion] nvarchar(100)  NULL,
    [SafeAnswer] nvarchar(100)  NULL,
    [IsDeleted] smallint  NOT NULL,
    [Remark] nvarchar(max)  NOT NULL,
    [SubTime] datetime  NULL,
    [IsLocked] smallint  NOT NULL,
    [ClassInfoID] int  NOT NULL,
    [IsItemUsedToNickName] bit  NULL,
    [AcademyID] int  NOT NULL,
    [VoteID] int  NOT NULL
);
GO

-- Creating table 'UserInfo'
CREATE TABLE [dbo].[UserInfo] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Gender] nvarchar(max)  NULL,
    [Birthday] datetime  NULL,
    [Interest] nvarchar(max)  NULL,
    [Height] int  NULL,
    [Weight] int  NULL,
    [BlogUrl] nvarchar(max)  NULL,
    [MicroBlogUrl] nvarchar(max)  NULL,
    [WeChatAccount] nvarchar(max)  NULL,
    [LivePlace] nvarchar(max)  NULL,
    [GovFace] nvarchar(max)  NULL,
    [IdNumber] nvarchar(max)  NULL,
    [TelNumber] nvarchar(max)  NULL,
    [QqNumber] real  NULL,
    [IsDeleted] smallint  NOT NULL,
    [SubTime] datetime  NULL,
    [Remark] nvarchar(max)  NULL,
    [Address] nvarchar(max)  NULL,
    [HeadImageUrl] nvarchar(300)  NULL,
    [User_ID] int  NOT NULL
);
GO

-- Creating table 'ChoiceQuestion'
CREATE TABLE [dbo].[ChoiceQuestion] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [IsDeleted] smallint  NOT NULL,
    [Remark] nvarchar(max)  NULL,
    [SubTime] datetime  NULL,
    [Content] nvarchar(max)  NOT NULL,
    [SelectA] nvarchar(max)  NOT NULL,
    [SelectB] nvarchar(max)  NOT NULL,
    [SelectC] nvarchar(max)  NULL,
    [SelectD] nvarchar(max)  NULL,
    [SelectE] nvarchar(max)  NULL,
    [SelectF] nvarchar(max)  NULL,
    [Answers] nvarchar(max)  NOT NULL,
    [IsMultiSelect] bit  NULL,
    [IsPublic] bit  NULL,
    [Difficulty] smallint  NULL,
    [PublisherID] int  NOT NULL,
    [CourseID] int  NULL
);
GO

-- Creating table 'FillingQuestion'
CREATE TABLE [dbo].[FillingQuestion] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [IsDeleted] smallint  NOT NULL,
    [Remark] nvarchar(max)  NULL,
    [SubTime] datetime  NULL,
    [Content] nvarchar(max)  NOT NULL,
    [Answers] nvarchar(max)  NOT NULL,
    [IsPublic] bit  NULL,
    [IsMultiFilling] bit  NULL,
    [Difficulty] smallint  NULL,
    [CourseID] int  NOT NULL,
    [PublisherID] int  NOT NULL
);
GO

-- Creating table 'TrueFalseQuestion'
CREATE TABLE [dbo].[TrueFalseQuestion] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Difficulty] smallint  NULL,
    [IsPublic] bit  NULL,
    [Answers] bit  NULL,
    [Content] nvarchar(max)  NOT NULL,
    [SubTime] datetime  NULL,
    [Remark] nvarchar(max)  NULL,
    [IsDeleted] smallint  NOT NULL,
    [CourseID] int  NOT NULL,
    [PublisherID] int  NOT NULL
);
GO

-- Creating table 'TestPaper'
CREATE TABLE [dbo].[TestPaper] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [IsDeleted] smallint  NOT NULL,
    [SubTime] datetime  NULL,
    [Remark] nvarchar(max)  NULL,
    [PaperName] nvarchar(max)  NOT NULL,
    [PaperDescription] nvarchar(max)  NULL,
    [PaperDate] datetime  NOT NULL,
    [StartTime] datetime  NOT NULL,
    [EndTime] datetime  NOT NULL,
    [PaperScore] smallint  NOT NULL,
    [PaperType] smallint  NULL,
    [PublisherID] int  NOT NULL,
    [CourseID] int  NOT NULL,
    [CategoryID] int  NULL,
    [Knowledge] nvarchar(max)  NULL,
    [TestMinutes] int  NULL
);
GO

-- Creating table 'ShortQuestion'
CREATE TABLE [dbo].[ShortQuestion] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Difficulty] smallint  NULL,
    [IsPublic] bit  NULL,
    [Answers] nvarchar(max)  NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [SubTime] datetime  NULL,
    [Remark] nvarchar(max)  NULL,
    [IsDeleted] smallint  NOT NULL,
    [CourseID] int  NOT NULL,
    [PublisherID] int  NOT NULL
);
GO

-- Creating table 'StudentPaper'
CREATE TABLE [dbo].[StudentPaper] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [PaperScore] smallint  NOT NULL,
    [SubmitTime] datetime  NOT NULL,
    [StartTime] datetime  NOT NULL,
    [Remark] nvarchar(max)  NULL,
    [IsDeleted] smallint  NOT NULL,
    [TeacherWords] nvarchar(max)  NULL,
    [TestPaperID] int  NOT NULL,
    [UserID] int  NOT NULL
);
GO

-- Creating table 'Department'
CREATE TABLE [dbo].[Department] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Population] int  NULL,
    [SubTime] nvarchar(max)  NULL,
    [Boss] nvarchar(max)  NULL,
    [Phone] nvarchar(max)  NOT NULL,
    [SiteUrl] nvarchar(max)  NULL,
    [IconUrl] nvarchar(max)  NULL,
    [Remark] nvarchar(max)  NULL,
    [IsDeleted] smallint  NOT NULL,
    [Number] nvarchar(max)  NOT NULL,
    [ParentId] int  NULL,
    [IsLeaf] bit  NULL,
    [Level] smallint  NULL
);
GO

-- Creating table 'Course'
CREATE TABLE [dbo].[Course] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [IsDeleted] smallint  NOT NULL,
    [SubTime] datetime  NULL,
    [Remark] nvarchar(max)  NULL,
    [CourseName] nvarchar(max)  NULL,
    [Description] nvarchar(max)  NULL
);
GO

-- Creating table 'ClassInfo'
CREATE TABLE [dbo].[ClassInfo] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ClassName] nvarchar(max)  NOT NULL,
    [Population] smallint  NULL,
    [SiteUrl] nvarchar(max)  NULL,
    [ClassIcon] nvarchar(max)  NULL,
    [SubTime] datetime  NULL,
    [Remark] nvarchar(max)  NOT NULL,
    [IsDeleted] smallint  NOT NULL,
    [AcademyID] int  NOT NULL,
    [MonitorID] int  NULL,
    [TeacherID] int  NULL
);
GO

-- Creating table 'Academy'
CREATE TABLE [dbo].[Academy] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Population] int  NULL,
    [President] nvarchar(max)  NULL,
    [Phone] nvarchar(max)  NULL,
    [SiteUrl] nvarchar(max)  NULL,
    [IconUrl] nvarchar(max)  NULL,
    [Remark] nvarchar(max)  NULL,
    [IsDeleted] smallint  NULL,
    [SubTime] nvarchar(max)  NULL,
    [VicePresidentA] nvarchar(max)  NULL,
    [VicePresidentB] nvarchar(max)  NULL,
    [VicePresidentC] nvarchar(max)  NULL,
    [VicePresidentD] nvarchar(max)  NULL
);
GO

-- Creating table 'Permission'
CREATE TABLE [dbo].[Permission] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Url] nvarchar(512)  NOT NULL,
    [HttpMethod] varchar(32)  NOT NULL,
    [Action] nvarchar(32)  NOT NULL,
    [Remark] nvarchar(128)  NULL,
    [Controoller] nvarchar(128)  NOT NULL,
    [Area] nvarchar(max)  NULL,
    [SubTime] datetime  NULL,
    [IsDeleted] smallint  NOT NULL
);
GO

-- Creating table 'Role'
CREATE TABLE [dbo].[Role] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [RoleName] nvarchar(max)  NOT NULL,
    [IsDeleted] smallint  NOT NULL,
    [Remark] nvarchar(max)  NOT NULL,
    [SubTime] datetime  NULL
);
GO

-- Creating table 'SpecialPermission'
CREATE TABLE [dbo].[SpecialPermission] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [SubTime] datetime  NULL,
    [Remark] nvarchar(max)  NOT NULL,
    [IsDeleted] smallint  NOT NULL,
    [UserID] int  NOT NULL,
    [PermissionID] int  NOT NULL,
    [IsPass] bit  NOT NULL
);
GO

-- Creating table 'Friend'
CREATE TABLE [dbo].[Friend] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [IsDeleted] smallint  NOT NULL,
    [Remark] nvarchar(max)  NULL,
    [SubTime] datetime  NOT NULL,
    [UserId] int  NOT NULL,
    [FriendId] int  NOT NULL,
    [AddTime] datetime  NULL
);
GO

-- Creating table 'Article'
CREATE TABLE [dbo].[Article] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [IsDeleted] smallint  NOT NULL,
    [Remark] nvarchar(max)  NULL,
    [SubTime] datetime  NULL,
    [Title] nvarchar(max)  NULL,
    [Content] nvarchar(max)  NULL,
    [EndTime] datetime  NULL,
    [PublishTime] datetime  NULL,
    [ArticleType] smallint  NOT NULL,
    [LikePoint] int  NULL,
    [RecommendPoint] int  NOT NULL,
    [DislikePoint] int  NOT NULL,
    [ReadTimes] int  NOT NULL,
    [Tips] nvarchar(max)  NULL,
    [IsItemUseToTitle] bit  NOT NULL,
    [IsItemUseToContent] bit  NULL,
    [PublisherID] int  NOT NULL
);
GO

-- Creating table 'File'
CREATE TABLE [dbo].[File] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [IsDeleted] smallint  NOT NULL,
    [Remark] nvarchar(max)  NULL,
    [SubTime] datetime  NULL,
    [FileName] nvarchar(max)  NOT NULL,
    [FileType] nvarchar(max)  NOT NULL,
    [FileSize] int  NULL,
    [FileUrl] nvarchar(max)  NULL,
    [DownloadTimes] int  NULL,
    [UserID] int  NOT NULL,
    [ArticleID] int  NULL
);
GO

-- Creating table 'Voted'
CREATE TABLE [dbo].[Voted] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [IsDeleted] smallint  NOT NULL,
    [Remark] nvarchar(max)  NULL,
    [SubTime] datetime  NULL,
    [Reason] nvarchar(max)  NOT NULL,
    [SelectOptions] nvarchar(max)  NOT NULL,
    [PostTime] datetime  NULL,
    [VoteID] int  NOT NULL,
    [UserID] int  NOT NULL
);
GO

-- Creating table 'Vote'
CREATE TABLE [dbo].[Vote] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [IsDeleted] smallint  NOT NULL,
    [Remark] nvarchar(max)  NULL,
    [SubTime] datetime  NULL,
    [ClassName] nvarchar(max)  NOT NULL,
    [VoteTitle] nvarchar(max)  NOT NULL,
    [VoteContent] nvarchar(max)  NOT NULL,
    [Option1] nvarchar(max)  NOT NULL,
    [Option2] nvarchar(max)  NOT NULL,
    [Option3] nvarchar(max)  NULL,
    [Option4] nvarchar(max)  NULL,
    [Option5] nvarchar(max)  NULL,
    [Option6] nvarchar(max)  NULL,
    [Option7] nvarchar(max)  NULL,
    [Option8] nvarchar(max)  NULL,
    [Option9] nvarchar(max)  NULL,
    [Option10] nvarchar(max)  NULL,
    [ParentId] int  NULL,
    [MoreInfo] nvarchar(max)  NULL,
    [IsEnded] bit  NULL,
    [IsMutilSelect] bit  NOT NULL,
    [MutilSelectCount] smallint  NOT NULL,
    [StartTime] datetime  NULL,
    [EndTime] datetime  NULL,
    [VoteImageUrl] nvarchar(max)  NULL,
    [VoteClassID] int  NULL,
    [PublisherID] int  NOT NULL
);
GO

-- Creating table 'VoteClass'
CREATE TABLE [dbo].[VoteClass] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [IsDeleted] bit  NULL,
    [SubTime] datetime  NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Remark] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Item'
CREATE TABLE [dbo].[Item] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NULL,
    [Effect] nvarchar(max)  NULL,
    [Target] smallint  NULL,
    [Price] int  NOT NULL,
    [EffectDays] int  NOT NULL,
    [IsDeleted] smallint  NOT NULL,
    [Remark] nvarchar(max)  NULL,
    [SubTime] datetime  NULL,
    [ItemEffectType] smallint  NOT NULL,
    [ImageUrl] nvarchar(250)  NULL,
    [EntTIme] datetime  NULL
);
GO

-- Creating table 'UserItem'
CREATE TABLE [dbo].[UserItem] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Count] int  NULL,
    [StartUseTime] datetime  NULL,
    [UsedCount] int  NOT NULL,
    [EndUseTime] datetime  NULL,
    [IsDeleted] smallint  NOT NULL,
    [Remark] nvarchar(max)  NULL,
    [SubTime] datetime  NULL,
    [UserID] int  NOT NULL,
    [ItemID] int  NOT NULL
);
GO

-- Creating table 'Comment'
CREATE TABLE [dbo].[Comment] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [ImageUrl] nvarchar(max)  NOT NULL,
    [IsHidedByItem] bit  NULL,
    [IsDeleted] smallint  NOT NULL,
    [Remark] nvarchar(max)  NULL,
    [SubTime] datetime  NULL,
    [IsItemUsedToComent] bit  NULL,
    [ArticleID] int  NOT NULL
);
GO

-- Creating table 'BigQuestion'
CREATE TABLE [dbo].[BigQuestion] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Remark] nvarchar(max)  NOT NULL,
    [SubTime] datetime  NOT NULL,
    [Score] int  NOT NULL,
    [IsDeleted] bit  NOT NULL,
    [TestPaperID] int  NOT NULL
);
GO

-- Creating table 'Answer'
CREATE TABLE [dbo].[Answer] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UserID] int  NOT NULL,
    [QuestionID] int  NULL,
    [BigQuestionID] int  NOT NULL,
    [QuestionType] smallint  NOT NULL,
    [SubTime] datetime  NULL,
    [Score] smallint  NULL,
    [AnswerContent] nvarchar(max)  NULL
);
GO

-- Creating table 'SmallQuestion'
CREATE TABLE [dbo].[SmallQuestion] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [BigQuestionID] int  NOT NULL,
    [QuestionID] int  NOT NULL,
    [QuestionType] smallint  NOT NULL,
    [Score] smallint  NOT NULL
);
GO

-- Creating table 'Log'
CREATE TABLE [dbo].[Log] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NOT NULL,
    [Application] nvarchar(255)  NOT NULL,
    [Thread] nvarchar(255)  NOT NULL,
    [Level] nvarchar(50)  NOT NULL,
    [Logger] nvarchar(255)  NOT NULL,
    [Server] nvarchar(255)  NOT NULL,
    [Location] nvarchar(255)  NOT NULL,
    [Message] nvarchar(max)  NOT NULL,
    [Exception] nvarchar(max)  NULL
);
GO

-- Creating table 'PaperCategory'
CREATE TABLE [dbo].[PaperCategory] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Remark] nvarchar(max)  NULL,
    [ParentID] int  NULL,
    [SubTime] datetime  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'TestpaperTarget'
CREATE TABLE [dbo].[TestpaperTarget] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [TestPaperID] int  NULL,
    [TargetType] smallint  NULL,
    [TargetID] int  NULL
);
GO

-- Creating table 'UserDepartment'
CREATE TABLE [dbo].[UserDepartment] (
    [User_ID] int  NOT NULL,
    [Department_ID] int  NOT NULL
);
GO

-- Creating table 'UserRole'
CREATE TABLE [dbo].[UserRole] (
    [User_ID] int  NOT NULL,
    [Role_ID] int  NOT NULL
);
GO

-- Creating table 'PermissionRole'
CREATE TABLE [dbo].[PermissionRole] (
    [Permission_ID] int  NOT NULL,
    [Role_ID] int  NOT NULL
);
GO

-- Creating table 'TeacherVerifyUserPaper'
CREATE TABLE [dbo].[TeacherVerifyUserPaper] (
    [VerifyPaper_ID] int  NOT NULL,
    [VerifyBy_ID] int  NOT NULL
);
GO

-- Creating table 'TestPaperUserCheck'
CREATE TABLE [dbo].[TestPaperUserCheck] (
    [CheckPaper_ID] int  NOT NULL,
    [CheckBy_ID] int  NOT NULL
);
GO

-- Creating table 'UserFavoritesArticle'
CREATE TABLE [dbo].[UserFavoritesArticle] (
    [FavoriteArticle_ID] int  NOT NULL,
    [CollectUser_ID] int  NOT NULL
);
GO

-- Creating table 'CourseAcademy'
CREATE TABLE [dbo].[CourseAcademy] (
    [Course_ID] int  NOT NULL,
    [Academy_ID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'UserInfo'
ALTER TABLE [dbo].[UserInfo]
ADD CONSTRAINT [PK_UserInfo]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'ChoiceQuestion'
ALTER TABLE [dbo].[ChoiceQuestion]
ADD CONSTRAINT [PK_ChoiceQuestion]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'FillingQuestion'
ALTER TABLE [dbo].[FillingQuestion]
ADD CONSTRAINT [PK_FillingQuestion]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'TrueFalseQuestion'
ALTER TABLE [dbo].[TrueFalseQuestion]
ADD CONSTRAINT [PK_TrueFalseQuestion]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'TestPaper'
ALTER TABLE [dbo].[TestPaper]
ADD CONSTRAINT [PK_TestPaper]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'ShortQuestion'
ALTER TABLE [dbo].[ShortQuestion]
ADD CONSTRAINT [PK_ShortQuestion]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'StudentPaper'
ALTER TABLE [dbo].[StudentPaper]
ADD CONSTRAINT [PK_StudentPaper]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Department'
ALTER TABLE [dbo].[Department]
ADD CONSTRAINT [PK_Department]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Course'
ALTER TABLE [dbo].[Course]
ADD CONSTRAINT [PK_Course]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'ClassInfo'
ALTER TABLE [dbo].[ClassInfo]
ADD CONSTRAINT [PK_ClassInfo]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Academy'
ALTER TABLE [dbo].[Academy]
ADD CONSTRAINT [PK_Academy]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Permission'
ALTER TABLE [dbo].[Permission]
ADD CONSTRAINT [PK_Permission]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Role'
ALTER TABLE [dbo].[Role]
ADD CONSTRAINT [PK_Role]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'SpecialPermission'
ALTER TABLE [dbo].[SpecialPermission]
ADD CONSTRAINT [PK_SpecialPermission]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Friend'
ALTER TABLE [dbo].[Friend]
ADD CONSTRAINT [PK_Friend]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Article'
ALTER TABLE [dbo].[Article]
ADD CONSTRAINT [PK_Article]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'File'
ALTER TABLE [dbo].[File]
ADD CONSTRAINT [PK_File]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Voted'
ALTER TABLE [dbo].[Voted]
ADD CONSTRAINT [PK_Voted]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Vote'
ALTER TABLE [dbo].[Vote]
ADD CONSTRAINT [PK_Vote]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'VoteClass'
ALTER TABLE [dbo].[VoteClass]
ADD CONSTRAINT [PK_VoteClass]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [Id] in table 'Item'
ALTER TABLE [dbo].[Item]
ADD CONSTRAINT [PK_Item]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserItem'
ALTER TABLE [dbo].[UserItem]
ADD CONSTRAINT [PK_UserItem]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Comment'
ALTER TABLE [dbo].[Comment]
ADD CONSTRAINT [PK_Comment]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ID] in table 'BigQuestion'
ALTER TABLE [dbo].[BigQuestion]
ADD CONSTRAINT [PK_BigQuestion]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Answer'
ALTER TABLE [dbo].[Answer]
ADD CONSTRAINT [PK_Answer]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'SmallQuestion'
ALTER TABLE [dbo].[SmallQuestion]
ADD CONSTRAINT [PK_SmallQuestion]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [Id] in table 'Log'
ALTER TABLE [dbo].[Log]
ADD CONSTRAINT [PK_Log]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ID] in table 'PaperCategory'
ALTER TABLE [dbo].[PaperCategory]
ADD CONSTRAINT [PK_PaperCategory]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'TestpaperTarget'
ALTER TABLE [dbo].[TestpaperTarget]
ADD CONSTRAINT [PK_TestpaperTarget]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [User_ID], [Department_ID] in table 'UserDepartment'
ALTER TABLE [dbo].[UserDepartment]
ADD CONSTRAINT [PK_UserDepartment]
    PRIMARY KEY CLUSTERED ([User_ID], [Department_ID] ASC);
GO

-- Creating primary key on [User_ID], [Role_ID] in table 'UserRole'
ALTER TABLE [dbo].[UserRole]
ADD CONSTRAINT [PK_UserRole]
    PRIMARY KEY CLUSTERED ([User_ID], [Role_ID] ASC);
GO

-- Creating primary key on [Permission_ID], [Role_ID] in table 'PermissionRole'
ALTER TABLE [dbo].[PermissionRole]
ADD CONSTRAINT [PK_PermissionRole]
    PRIMARY KEY CLUSTERED ([Permission_ID], [Role_ID] ASC);
GO

-- Creating primary key on [VerifyPaper_ID], [VerifyBy_ID] in table 'TeacherVerifyUserPaper'
ALTER TABLE [dbo].[TeacherVerifyUserPaper]
ADD CONSTRAINT [PK_TeacherVerifyUserPaper]
    PRIMARY KEY CLUSTERED ([VerifyPaper_ID], [VerifyBy_ID] ASC);
GO

-- Creating primary key on [CheckPaper_ID], [CheckBy_ID] in table 'TestPaperUserCheck'
ALTER TABLE [dbo].[TestPaperUserCheck]
ADD CONSTRAINT [PK_TestPaperUserCheck]
    PRIMARY KEY CLUSTERED ([CheckPaper_ID], [CheckBy_ID] ASC);
GO

-- Creating primary key on [FavoriteArticle_ID], [CollectUser_ID] in table 'UserFavoritesArticle'
ALTER TABLE [dbo].[UserFavoritesArticle]
ADD CONSTRAINT [PK_UserFavoritesArticle]
    PRIMARY KEY CLUSTERED ([FavoriteArticle_ID], [CollectUser_ID] ASC);
GO

-- Creating primary key on [Course_ID], [Academy_ID] in table 'CourseAcademy'
ALTER TABLE [dbo].[CourseAcademy]
ADD CONSTRAINT [PK_CourseAcademy]
    PRIMARY KEY CLUSTERED ([Course_ID], [Academy_ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserID] in table 'StudentPaper'
ALTER TABLE [dbo].[StudentPaper]
ADD CONSTRAINT [FK_StudentPaperUser]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[User]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentPaperUser'
CREATE INDEX [IX_FK_StudentPaperUser]
ON [dbo].[StudentPaper]
    ([UserID]);
GO

-- Creating foreign key on [ClassInfoID] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [FK_UserClassInfo]
    FOREIGN KEY ([ClassInfoID])
    REFERENCES [dbo].[ClassInfo]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserClassInfo'
CREATE INDEX [IX_FK_UserClassInfo]
ON [dbo].[User]
    ([ClassInfoID]);
GO

-- Creating foreign key on [AcademyID] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [FK_AcademyUser]
    FOREIGN KEY ([AcademyID])
    REFERENCES [dbo].[Academy]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AcademyUser'
CREATE INDEX [IX_FK_AcademyUser]
ON [dbo].[User]
    ([AcademyID]);
GO

-- Creating foreign key on [User_ID] in table 'UserDepartment'
ALTER TABLE [dbo].[UserDepartment]
ADD CONSTRAINT [FK_UserDepartment_User]
    FOREIGN KEY ([User_ID])
    REFERENCES [dbo].[User]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Department_ID] in table 'UserDepartment'
ALTER TABLE [dbo].[UserDepartment]
ADD CONSTRAINT [FK_UserDepartment_Department]
    FOREIGN KEY ([Department_ID])
    REFERENCES [dbo].[Department]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserDepartment_Department'
CREATE INDEX [IX_FK_UserDepartment_Department]
ON [dbo].[UserDepartment]
    ([Department_ID]);
GO

-- Creating foreign key on [User_ID] in table 'UserRole'
ALTER TABLE [dbo].[UserRole]
ADD CONSTRAINT [FK_UserRole_User]
    FOREIGN KEY ([User_ID])
    REFERENCES [dbo].[User]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Role_ID] in table 'UserRole'
ALTER TABLE [dbo].[UserRole]
ADD CONSTRAINT [FK_UserRole_Role]
    FOREIGN KEY ([Role_ID])
    REFERENCES [dbo].[Role]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserRole_Role'
CREATE INDEX [IX_FK_UserRole_Role]
ON [dbo].[UserRole]
    ([Role_ID]);
GO

-- Creating foreign key on [Permission_ID] in table 'PermissionRole'
ALTER TABLE [dbo].[PermissionRole]
ADD CONSTRAINT [FK_PermissionRole_Permission]
    FOREIGN KEY ([Permission_ID])
    REFERENCES [dbo].[Permission]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Role_ID] in table 'PermissionRole'
ALTER TABLE [dbo].[PermissionRole]
ADD CONSTRAINT [FK_PermissionRole_Role]
    FOREIGN KEY ([Role_ID])
    REFERENCES [dbo].[Role]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PermissionRole_Role'
CREATE INDEX [IX_FK_PermissionRole_Role]
ON [dbo].[PermissionRole]
    ([Role_ID]);
GO

-- Creating foreign key on [VerifyPaper_ID] in table 'TeacherVerifyUserPaper'
ALTER TABLE [dbo].[TeacherVerifyUserPaper]
ADD CONSTRAINT [FK_TeacherVerifyUserPaper_TestPaper]
    FOREIGN KEY ([VerifyPaper_ID])
    REFERENCES [dbo].[TestPaper]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [VerifyBy_ID] in table 'TeacherVerifyUserPaper'
ALTER TABLE [dbo].[TeacherVerifyUserPaper]
ADD CONSTRAINT [FK_TeacherVerifyUserPaper_User]
    FOREIGN KEY ([VerifyBy_ID])
    REFERENCES [dbo].[User]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TeacherVerifyUserPaper_User'
CREATE INDEX [IX_FK_TeacherVerifyUserPaper_User]
ON [dbo].[TeacherVerifyUserPaper]
    ([VerifyBy_ID]);
GO

-- Creating foreign key on [CheckPaper_ID] in table 'TestPaperUserCheck'
ALTER TABLE [dbo].[TestPaperUserCheck]
ADD CONSTRAINT [FK_TestPaperUserCheck_TestPaper]
    FOREIGN KEY ([CheckPaper_ID])
    REFERENCES [dbo].[TestPaper]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [CheckBy_ID] in table 'TestPaperUserCheck'
ALTER TABLE [dbo].[TestPaperUserCheck]
ADD CONSTRAINT [FK_TestPaperUserCheck_User]
    FOREIGN KEY ([CheckBy_ID])
    REFERENCES [dbo].[User]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TestPaperUserCheck_User'
CREATE INDEX [IX_FK_TestPaperUserCheck_User]
ON [dbo].[TestPaperUserCheck]
    ([CheckBy_ID]);
GO

-- Creating foreign key on [PublisherID] in table 'FillingQuestion'
ALTER TABLE [dbo].[FillingQuestion]
ADD CONSTRAINT [FK_FillingQuestionUser]
    FOREIGN KEY ([PublisherID])
    REFERENCES [dbo].[User]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FillingQuestionUser'
CREATE INDEX [IX_FK_FillingQuestionUser]
ON [dbo].[FillingQuestion]
    ([PublisherID]);
GO

-- Creating foreign key on [PublisherID] in table 'ShortQuestion'
ALTER TABLE [dbo].[ShortQuestion]
ADD CONSTRAINT [FK_ShortQuestionUser]
    FOREIGN KEY ([PublisherID])
    REFERENCES [dbo].[User]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ShortQuestionUser'
CREATE INDEX [IX_FK_ShortQuestionUser]
ON [dbo].[ShortQuestion]
    ([PublisherID]);
GO

-- Creating foreign key on [PublisherID] in table 'TrueFalseQuestion'
ALTER TABLE [dbo].[TrueFalseQuestion]
ADD CONSTRAINT [FK_TrueFalseQuestionUser]
    FOREIGN KEY ([PublisherID])
    REFERENCES [dbo].[User]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TrueFalseQuestionUser'
CREATE INDEX [IX_FK_TrueFalseQuestionUser]
ON [dbo].[TrueFalseQuestion]
    ([PublisherID]);
GO

-- Creating foreign key on [AcademyID] in table 'ClassInfo'
ALTER TABLE [dbo].[ClassInfo]
ADD CONSTRAINT [FK_ClassInfoAcademy]
    FOREIGN KEY ([AcademyID])
    REFERENCES [dbo].[Academy]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClassInfoAcademy'
CREATE INDEX [IX_FK_ClassInfoAcademy]
ON [dbo].[ClassInfo]
    ([AcademyID]);
GO

-- Creating foreign key on [TestPaperID] in table 'StudentPaper'
ALTER TABLE [dbo].[StudentPaper]
ADD CONSTRAINT [FK_StudentPaperTestPaper]
    FOREIGN KEY ([TestPaperID])
    REFERENCES [dbo].[TestPaper]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentPaperTestPaper'
CREATE INDEX [IX_FK_StudentPaperTestPaper]
ON [dbo].[StudentPaper]
    ([TestPaperID]);
GO

-- Creating foreign key on [UserID] in table 'SpecialPermission'
ALTER TABLE [dbo].[SpecialPermission]
ADD CONSTRAINT [FK_SpecialPermissionUser]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[User]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SpecialPermissionUser'
CREATE INDEX [IX_FK_SpecialPermissionUser]
ON [dbo].[SpecialPermission]
    ([UserID]);
GO

-- Creating foreign key on [PermissionID] in table 'SpecialPermission'
ALTER TABLE [dbo].[SpecialPermission]
ADD CONSTRAINT [FK_SpecialPermissionPermission]
    FOREIGN KEY ([PermissionID])
    REFERENCES [dbo].[Permission]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SpecialPermissionPermission'
CREATE INDEX [IX_FK_SpecialPermissionPermission]
ON [dbo].[SpecialPermission]
    ([PermissionID]);
GO

-- Creating foreign key on [PublisherID] in table 'Article'
ALTER TABLE [dbo].[Article]
ADD CONSTRAINT [FK_ArticleUser]
    FOREIGN KEY ([PublisherID])
    REFERENCES [dbo].[User]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ArticleUser'
CREATE INDEX [IX_FK_ArticleUser]
ON [dbo].[Article]
    ([PublisherID]);
GO

-- Creating foreign key on [ArticleID] in table 'File'
ALTER TABLE [dbo].[File]
ADD CONSTRAINT [FK_AttachmentArticle]
    FOREIGN KEY ([ArticleID])
    REFERENCES [dbo].[Article]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AttachmentArticle'
CREATE INDEX [IX_FK_AttachmentArticle]
ON [dbo].[File]
    ([ArticleID]);
GO

-- Creating foreign key on [UserID] in table 'File'
ALTER TABLE [dbo].[File]
ADD CONSTRAINT [FK_FileUser]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[User]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FileUser'
CREATE INDEX [IX_FK_FileUser]
ON [dbo].[File]
    ([UserID]);
GO

-- Creating foreign key on [FavoriteArticle_ID] in table 'UserFavoritesArticle'
ALTER TABLE [dbo].[UserFavoritesArticle]
ADD CONSTRAINT [FK_UserFavoritesArticle_Article]
    FOREIGN KEY ([FavoriteArticle_ID])
    REFERENCES [dbo].[Article]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [CollectUser_ID] in table 'UserFavoritesArticle'
ALTER TABLE [dbo].[UserFavoritesArticle]
ADD CONSTRAINT [FK_UserFavoritesArticle_User]
    FOREIGN KEY ([CollectUser_ID])
    REFERENCES [dbo].[User]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserFavoritesArticle_User'
CREATE INDEX [IX_FK_UserFavoritesArticle_User]
ON [dbo].[UserFavoritesArticle]
    ([CollectUser_ID]);
GO

-- Creating foreign key on [VoteID] in table 'Voted'
ALTER TABLE [dbo].[Voted]
ADD CONSTRAINT [FK_VotedVote]
    FOREIGN KEY ([VoteID])
    REFERENCES [dbo].[Vote]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VotedVote'
CREATE INDEX [IX_FK_VotedVote]
ON [dbo].[Voted]
    ([VoteID]);
GO

-- Creating foreign key on [VoteClassID] in table 'Vote'
ALTER TABLE [dbo].[Vote]
ADD CONSTRAINT [FK_VoteClassVote]
    FOREIGN KEY ([VoteClassID])
    REFERENCES [dbo].[VoteClass]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VoteClassVote'
CREATE INDEX [IX_FK_VoteClassVote]
ON [dbo].[Vote]
    ([VoteClassID]);
GO

-- Creating foreign key on [UserID] in table 'UserItem'
ALTER TABLE [dbo].[UserItem]
ADD CONSTRAINT [FK_UserItemUser]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[User]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserItemUser'
CREATE INDEX [IX_FK_UserItemUser]
ON [dbo].[UserItem]
    ([UserID]);
GO

-- Creating foreign key on [ItemID] in table 'UserItem'
ALTER TABLE [dbo].[UserItem]
ADD CONSTRAINT [FK_ItemUserItem]
    FOREIGN KEY ([ItemID])
    REFERENCES [dbo].[Item]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ItemUserItem'
CREATE INDEX [IX_FK_ItemUserItem]
ON [dbo].[UserItem]
    ([ItemID]);
GO

-- Creating foreign key on [ArticleID] in table 'Comment'
ALTER TABLE [dbo].[Comment]
ADD CONSTRAINT [FK_CommentArticle]
    FOREIGN KEY ([ArticleID])
    REFERENCES [dbo].[Article]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CommentArticle'
CREATE INDEX [IX_FK_CommentArticle]
ON [dbo].[Comment]
    ([ArticleID]);
GO

-- Creating foreign key on [TestPaperID] in table 'BigQuestion'
ALTER TABLE [dbo].[BigQuestion]
ADD CONSTRAINT [FK_TestPaperBigQuestion]
    FOREIGN KEY ([TestPaperID])
    REFERENCES [dbo].[TestPaper]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TestPaperBigQuestion'
CREATE INDEX [IX_FK_TestPaperBigQuestion]
ON [dbo].[BigQuestion]
    ([TestPaperID]);
GO

-- Creating foreign key on [PublisherID] in table 'TestPaper'
ALTER TABLE [dbo].[TestPaper]
ADD CONSTRAINT [FK_TestPaperUser]
    FOREIGN KEY ([PublisherID])
    REFERENCES [dbo].[User]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TestPaperUser'
CREATE INDEX [IX_FK_TestPaperUser]
ON [dbo].[TestPaper]
    ([PublisherID]);
GO

-- Creating foreign key on [CourseID] in table 'TestPaper'
ALTER TABLE [dbo].[TestPaper]
ADD CONSTRAINT [FK_TestPaperCourse]
    FOREIGN KEY ([CourseID])
    REFERENCES [dbo].[Course]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TestPaperCourse'
CREATE INDEX [IX_FK_TestPaperCourse]
ON [dbo].[TestPaper]
    ([CourseID]);
GO

-- Creating foreign key on [PublisherID] in table 'ChoiceQuestion'
ALTER TABLE [dbo].[ChoiceQuestion]
ADD CONSTRAINT [FK_UserChoiceQuestion]
    FOREIGN KEY ([PublisherID])
    REFERENCES [dbo].[User]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserChoiceQuestion'
CREATE INDEX [IX_FK_UserChoiceQuestion]
ON [dbo].[ChoiceQuestion]
    ([PublisherID]);
GO

-- Creating foreign key on [CourseID] in table 'ChoiceQuestion'
ALTER TABLE [dbo].[ChoiceQuestion]
ADD CONSTRAINT [FK_CourseChoiceQuestion]
    FOREIGN KEY ([CourseID])
    REFERENCES [dbo].[Course]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CourseChoiceQuestion'
CREATE INDEX [IX_FK_CourseChoiceQuestion]
ON [dbo].[ChoiceQuestion]
    ([CourseID]);
GO

-- Creating foreign key on [CourseID] in table 'FillingQuestion'
ALTER TABLE [dbo].[FillingQuestion]
ADD CONSTRAINT [FK_CourseFillingQuestion]
    FOREIGN KEY ([CourseID])
    REFERENCES [dbo].[Course]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CourseFillingQuestion'
CREATE INDEX [IX_FK_CourseFillingQuestion]
ON [dbo].[FillingQuestion]
    ([CourseID]);
GO

-- Creating foreign key on [CourseID] in table 'ShortQuestion'
ALTER TABLE [dbo].[ShortQuestion]
ADD CONSTRAINT [FK_CourseShortQuestion]
    FOREIGN KEY ([CourseID])
    REFERENCES [dbo].[Course]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CourseShortQuestion'
CREATE INDEX [IX_FK_CourseShortQuestion]
ON [dbo].[ShortQuestion]
    ([CourseID]);
GO

-- Creating foreign key on [CourseID] in table 'TrueFalseQuestion'
ALTER TABLE [dbo].[TrueFalseQuestion]
ADD CONSTRAINT [FK_CourseTrueFalseQuestion]
    FOREIGN KEY ([CourseID])
    REFERENCES [dbo].[Course]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CourseTrueFalseQuestion'
CREATE INDEX [IX_FK_CourseTrueFalseQuestion]
ON [dbo].[TrueFalseQuestion]
    ([CourseID]);
GO

-- Creating foreign key on [Course_ID] in table 'CourseAcademy'
ALTER TABLE [dbo].[CourseAcademy]
ADD CONSTRAINT [FK_CourseAcademy_Course]
    FOREIGN KEY ([Course_ID])
    REFERENCES [dbo].[Course]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Academy_ID] in table 'CourseAcademy'
ALTER TABLE [dbo].[CourseAcademy]
ADD CONSTRAINT [FK_CourseAcademy_Academy]
    FOREIGN KEY ([Academy_ID])
    REFERENCES [dbo].[Academy]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CourseAcademy_Academy'
CREATE INDEX [IX_FK_CourseAcademy_Academy]
ON [dbo].[CourseAcademy]
    ([Academy_ID]);
GO

-- Creating foreign key on [User_ID] in table 'UserInfo'
ALTER TABLE [dbo].[UserInfo]
ADD CONSTRAINT [FK_UserInfoUser]
    FOREIGN KEY ([User_ID])
    REFERENCES [dbo].[User]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfoUser'
CREATE INDEX [IX_FK_UserInfoUser]
ON [dbo].[UserInfo]
    ([User_ID]);
GO

-- Creating foreign key on [UserID] in table 'Answer'
ALTER TABLE [dbo].[Answer]
ADD CONSTRAINT [FK_AnswerUser]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[User]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AnswerUser'
CREATE INDEX [IX_FK_AnswerUser]
ON [dbo].[Answer]
    ([UserID]);
GO

-- Creating foreign key on [UserID] in table 'Voted'
ALTER TABLE [dbo].[Voted]
ADD CONSTRAINT [FK_VotedUser]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[User]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VotedUser'
CREATE INDEX [IX_FK_VotedUser]
ON [dbo].[Voted]
    ([UserID]);
GO

-- Creating foreign key on [PublisherID] in table 'Vote'
ALTER TABLE [dbo].[Vote]
ADD CONSTRAINT [FK_VoteUser]
    FOREIGN KEY ([PublisherID])
    REFERENCES [dbo].[User]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VoteUser'
CREATE INDEX [IX_FK_VoteUser]
ON [dbo].[Vote]
    ([PublisherID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------