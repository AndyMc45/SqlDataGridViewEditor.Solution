USE [CrtsTranscript_2024]
GO
/****** Object:  User [Academic]    Script Date: 12/27/2023 12:40:51 PM ******/
CREATE USER [Academic] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[db_datawriter]
GO
/****** Object:  User [admin]    Script Date: 12/27/2023 12:40:51 PM ******/
CREATE USER [admin] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [andymc]    Script Date: 12/27/2023 12:40:51 PM ******/
CREATE USER [andymc] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[db_owner]
GO
ALTER ROLE [db_owner] ADD MEMBER [admin]
GO
ALTER ROLE [db_owner] ADD MEMBER [andymc]
GO
/****** Object:  Table [dbo].[CourseNames]    Script Date: 12/27/2023 12:40:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseNames](
	[courseNameID] [int] IDENTITY(1,1) NOT NULL,
	[courseName] [nvarchar](50) NOT NULL,
	[eCourseName] [nvarchar](100) NULL,
	[departmentID] [int] NOT NULL,
	[note] [nvarchar](200) NULL,
 CONSTRAINT [PK_CourseName] PRIMARY KEY CLUSTERED 
(
	[courseNameID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 12/27/2023 12:40:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[courseID] [int] IDENTITY(1,1) NOT NULL,
	[courseNameID] [int] NULL,
	[requirementNameID] [int] NOT NULL,
	[degreeLevelID] [int] NOT NULL,
	[repeatsPermitted] [int] NOT NULL,
	[note] [nvarchar](50) NULL,
 CONSTRAINT [Courses$PrimaryKey] PRIMARY KEY CLUSTERED 
(
	[courseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourseTerms]    Script Date: 12/27/2023 12:40:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseTerms](
	[courseTermID] [int] IDENTITY(1,1) NOT NULL,
	[termID] [int] NOT NULL,
	[courseID] [int] NOT NULL,
	[facultyID] [int] NOT NULL,
	[note] [nvarchar](50) NULL,
 CONSTRAINT [CourseTerms$PrimaryKey] PRIMARY KEY CLUSTERED 
(
	[courseTermID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourseTermSection]    Script Date: 12/27/2023 12:40:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseTermSection](
	[courseTermSectionID] [int] IDENTITY(1,1) NOT NULL,
	[courseTermID] [int] NOT NULL,
	[sectionID] [int] NOT NULL,
 CONSTRAINT [PK_CourseTermSection] PRIMARY KEY CLUSTERED 
(
	[courseTermSectionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DegreeLevel]    Script Date: 12/27/2023 12:40:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DegreeLevel](
	[degreeLevelID] [int] IDENTITY(1,1) NOT NULL,
	[degreeLevelName] [nvarchar](50) NOT NULL,
	[degreeLevel] [int] NOT NULL,
 CONSTRAINT [PK_DegreeLevel] PRIMARY KEY CLUSTERED 
(
	[degreeLevelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Degrees]    Script Date: 12/27/2023 12:40:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Degrees](
	[degreeID] [int] IDENTITY(1,1) NOT NULL,
	[degreeName] [nvarchar](50) NOT NULL,
	[deliveryMethodID] [int] NOT NULL,
	[degreeNameLong] [nvarchar](50) NULL,
	[eDegreeName] [nvarchar](50) NULL,
	[eDegreeNameLong] [nvarchar](50) NULL,
	[degreeLevelID] [int] NOT NULL,
	[note] [nvarchar](50) NULL,
 CONSTRAINT [PK_Degrees] PRIMARY KEY CLUSTERED 
(
	[degreeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeliveryMethod]    Script Date: 12/27/2023 12:40:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeliveryMethod](
	[deliveryMethodID] [int] IDENTITY(1,1) NOT NULL,
	[delMethDK] [nvarchar](70) NULL,
	[delMethName] [nvarchar](70) NULL,
	[eDelMethName] [nvarchar](70) NULL,
	[deliveryLevel] [int] NOT NULL,
 CONSTRAINT [PK_DeliveryMethod] PRIMARY KEY CLUSTERED 
(
	[deliveryMethodID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 12/27/2023 12:40:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[departmentID] [int] IDENTITY(1,1) NOT NULL,
	[depName] [nvarchar](50) NOT NULL,
	[cDepName] [nvarchar](50) NULL,
	[eDepName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[departmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Faculty]    Script Date: 12/27/2023 12:40:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Faculty](
	[facultyID] [int] IDENTITY(1,1) NOT NULL,
	[facultyName] [nvarchar](50) NULL,
	[eFacultyName] [nvarchar](50) NULL,
	[facultyUnique] [nvarchar](50) NULL,
	[note] [nvarchar](50) NULL,
 CONSTRAINT [老師$PrimaryKey] PRIMARY KEY CLUSTERED 
(
	[facultyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Grades]    Script Date: 12/27/2023 12:40:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grades](
	[gradesID] [int] IDENTITY(1,1) NOT NULL,
	[grade] [nvarchar](50) NULL,
	[QP] [real] NULL,
	[earnedCredits] [bit] NULL,
	[creditsInQPA] [bit] NULL,
	[note] [nvarchar](255) NULL,
 CONSTRAINT [成績$PrimaryKey] PRIMARY KEY CLUSTERED 
(
	[gradesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GradeStatus]    Script Date: 12/27/2023 12:40:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GradeStatus](
	[gradeStatusID] [int] IDENTITY(1,1) NOT NULL,
	[statusKey] [nvarchar](100) NOT NULL,
	[statusName] [nvarchar](100) NULL,
	[eStatusName] [nvarchar](100) NULL,
	[note] [nvarchar](200) NULL,
	[forCredit] [bit] NOT NULL,
 CONSTRAINT [PK_GradeStatus] PRIMARY KEY CLUSTERED 
(
	[gradeStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GradRequirements]    Script Date: 12/27/2023 12:40:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GradRequirements](
	[gradRequirementID] [int] IDENTITY(1,1) NOT NULL,
	[handbookID] [int] NOT NULL,
	[degreeID] [int] NOT NULL,
	[gradReqTypeID] [int] NOT NULL,
	[reqNameID] [int] NOT NULL,
	[rDeliveryMethodID] [int] NOT NULL,
	[reqUnits] [real] NOT NULL,
	[creditLimit] [real] NOT NULL,
	[note] [nvarchar](200) NULL,
 CONSTRAINT [PK_GradRequirements] PRIMARY KEY CLUSTERED 
(
	[gradRequirementID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GradRequirementType]    Script Date: 12/27/2023 12:40:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GradRequirementType](
	[gradReqTypeID] [int] IDENTITY(1,1) NOT NULL,
	[typeDK] [nvarchar](50) NOT NULL,
	[typeName] [nvarchar](50) NULL,
	[eTypeName] [nvarchar](50) NULL,
 CONSTRAINT [PK_GradRequirementType] PRIMARY KEY CLUSTERED 
(
	[gradReqTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Handbooks]    Script Date: 12/27/2023 12:40:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Handbooks](
	[handbookID] [int] IDENTITY(1,1) NOT NULL,
	[handbook] [nvarchar](70) NOT NULL,
	[note] [nvarchar](200) NULL,
 CONSTRAINT [PK_Handbooks] PRIMARY KEY CLUSTERED 
(
	[handbookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RequirementName]    Script Date: 12/27/2023 12:40:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequirementName](
	[requirementNameID] [int] IDENTITY(1,1) NOT NULL,
	[reqNameDK] [nvarchar](50) NOT NULL,
	[reqName] [nvarchar](50) NULL,
	[eReqName] [nvarchar](50) NULL,
	[Ancestors] [nvarchar](300) NULL,
 CONSTRAINT [PK_RequirementName] PRIMARY KEY CLUSTERED 
(
	[requirementNameID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Section]    Script Date: 12/27/2023 12:40:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Section](
	[sectionID] [int] IDENTITY(1,1) NOT NULL,
	[deliveryMethodID] [int] NOT NULL,
	[credits] [real] NOT NULL,
 CONSTRAINT [PK_Section] PRIMARY KEY CLUSTERED 
(
	[sectionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentDegrees]    Script Date: 12/27/2023 12:40:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentDegrees](
	[studentDegreeID] [int] IDENTITY(1,1) NOT NULL,
	[studentID] [int] NOT NULL,
	[studentUnique] [nvarchar](50) NULL,
	[degreeID] [int] NOT NULL,
	[handbookID] [int] NOT NULL,
	[startDate] [datetime] NOT NULL,
	[endDate] [datetime] NULL,
	[graduated] [bit] NOT NULL,
	[creditsEarned] [real] NOT NULL,
	[QPA] [real] NULL,
	[lastUpdatedQPA] [date] NOT NULL,
	[note] [nvarchar](50) NULL,
 CONSTRAINT [StudentDegrees$PrimaryKey] PRIMARY KEY CLUSTERED 
(
	[studentDegreeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 12/27/2023 12:40:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[studentID] [int] IDENTITY(1,1) NOT NULL,
	[studentName] [nvarchar](50) NULL,
	[eStudentName] [nvarchar](50) NULL,
	[note] [nvarchar](50) NULL,
 CONSTRAINT [學生$PrimaryKey] PRIMARY KEY CLUSTERED 
(
	[studentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Terms]    Script Date: 12/27/2023 12:40:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Terms](
	[termID] [int] IDENTITY(1,1) NOT NULL,
	[term] [smallint] NULL,
	[termName] [nvarchar](50) NULL,
	[eTermName] [nvarchar](50) NULL,
	[startYear] [smallint] NULL,
	[startMonth] [smallint] NULL,
	[endYear] [smallint] NULL,
	[endMonth] [smallint] NULL,
	[note] [nvarchar](50) NULL,
 CONSTRAINT [學季$PrimaryKey] PRIMARY KEY CLUSTERED 
(
	[termID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transcript]    Script Date: 12/27/2023 12:40:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transcript](
	[transcriptID] [int] IDENTITY(1,1) NOT NULL,
	[studentDegreeID] [int] NOT NULL,
	[courseTermSectionID] [int] NOT NULL,
	[gradeStatusID] [int] NOT NULL,
	[gradeID] [int] NOT NULL,
	[auditing] [bit] NULL,
	[selfStudyCourse] [bit] NULL,
	[note] [nvarchar](255) NULL,
 CONSTRAINT [PK_Transcript] PRIMARY KEY CLUSTERED 
(
	[transcriptID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransferCredits]    Script Date: 12/27/2023 12:40:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransferCredits](
	[transferCreditID] [int] IDENTITY(1,1) NOT NULL,
	[studentDegreeID] [int] NOT NULL,
	[creditSource] [nvarchar](50) NULL,
	[eCreditSource] [nvarchar](50) NULL,
	[credits] [real] NOT NULL,
	[requirementNameID] [int] NOT NULL,
	[degreeLevelID] [int] NOT NULL,
	[deliveryMethodID] [int] NOT NULL,
	[fulfillRequirementNoCredit] [bit] NOT NULL,
	[note] [nvarchar](50) NULL,
 CONSTRAINT [PK_TransferCredits] PRIMARY KEY CLUSTERED 
(
	[transferCreditID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Courses] ADD  CONSTRAINT [DF_Courses_repeatable]  DEFAULT ((1)) FOR [repeatsPermitted]
GO
ALTER TABLE [dbo].[CourseTerms] ADD  CONSTRAINT [DF__課程學季__課程ID__2C3393D0]  DEFAULT ((0)) FOR [courseID]
GO
ALTER TABLE [dbo].[CourseTerms] ADD  CONSTRAINT [DF__課程學季__老師ID__2E1BDC42]  DEFAULT ((0)) FOR [facultyID]
GO
ALTER TABLE [dbo].[DegreeLevel] ADD  CONSTRAINT [DF_DegreeLevel_intLevel]  DEFAULT ((0)) FOR [degreeLevel]
GO
ALTER TABLE [dbo].[Degrees] ADD  CONSTRAINT [DF_Degrees_deliveryMethodID]  DEFAULT ((1)) FOR [deliveryMethodID]
GO
ALTER TABLE [dbo].[DeliveryMethod] ADD  CONSTRAINT [DF_RequirementStatus_statusLevel]  DEFAULT ((0)) FOR [deliveryLevel]
GO
ALTER TABLE [dbo].[Grades] ADD  DEFAULT ((0)) FOR [QP]
GO
ALTER TABLE [dbo].[Grades] ADD  DEFAULT ((0)) FOR [earnedCredits]
GO
ALTER TABLE [dbo].[Grades] ADD  DEFAULT ((0)) FOR [creditsInQPA]
GO
ALTER TABLE [dbo].[GradeStatus] ADD  CONSTRAINT [DF_GradeStatus_forCredit]  DEFAULT ((0)) FOR [forCredit]
GO
ALTER TABLE [dbo].[GradRequirements] ADD  CONSTRAINT [DF_GradRequirements_handbookID]  DEFAULT ((1)) FOR [handbookID]
GO
ALTER TABLE [dbo].[GradRequirements] ADD  CONSTRAINT [DF__畢業要求__學科ID__30F848ED]  DEFAULT ((0)) FOR [degreeID]
GO
ALTER TABLE [dbo].[GradRequirements] ADD  CONSTRAINT [DF_GradRequirements_gradReqTypeID]  DEFAULT ((1)) FOR [gradReqTypeID]
GO
ALTER TABLE [dbo].[GradRequirements] ADD  CONSTRAINT [DF_GradRequirements_rDeliveryMethodID]  DEFAULT ((6)) FOR [rDeliveryMethodID]
GO
ALTER TABLE [dbo].[GradRequirements] ADD  CONSTRAINT [DF__畢業要求__必須修學分__33D4B598]  DEFAULT ((0)) FOR [reqUnits]
GO
ALTER TABLE [dbo].[GradRequirements] ADD  CONSTRAINT [DF__畢業要求__學分限制__34C8D9D1]  DEFAULT ((-1)) FOR [creditLimit]
GO
ALTER TABLE [dbo].[Section] ADD  CONSTRAINT [DF_Section_credits]  DEFAULT ((0)) FOR [credits]
GO
ALTER TABLE [dbo].[StudentDegrees] ADD  CONSTRAINT [DF__學生學科__學生ID__276EDEB3]  DEFAULT ((0)) FOR [studentID]
GO
ALTER TABLE [dbo].[StudentDegrees] ADD  CONSTRAINT [DF__學生學科__學科ID__286302EC]  DEFAULT ((0)) FOR [degreeID]
GO
ALTER TABLE [dbo].[StudentDegrees] ADD  CONSTRAINT [DF_StudentDegrees_handbookID]  DEFAULT ((1)) FOR [handbookID]
GO
ALTER TABLE [dbo].[StudentDegrees] ADD  CONSTRAINT [DF_StudentDegrees_startDate]  DEFAULT (CONVERT([date],getdate(),(0))) FOR [startDate]
GO
ALTER TABLE [dbo].[StudentDegrees] ADD  CONSTRAINT [DF__學生學科__結束本科__2A4B4B5E]  DEFAULT ((0)) FOR [graduated]
GO
ALTER TABLE [dbo].[StudentDegrees] ADD  CONSTRAINT [DF_StudentDegrees_creditsEarned]  DEFAULT ((0)) FOR [creditsEarned]
GO
ALTER TABLE [dbo].[StudentDegrees] ADD  CONSTRAINT [DF_StudentDegrees_QPA]  DEFAULT ((0)) FOR [QPA]
GO
ALTER TABLE [dbo].[StudentDegrees] ADD  CONSTRAINT [DF_StudentDegrees_lastUpdated]  DEFAULT (CONVERT([date],dateadd(day,(-10000),getdate()),(0))) FOR [lastUpdatedQPA]
GO
ALTER TABLE [dbo].[Terms] ADD  DEFAULT ((0)) FOR [term]
GO
ALTER TABLE [dbo].[Terms] ADD  DEFAULT ((0)) FOR [startYear]
GO
ALTER TABLE [dbo].[Terms] ADD  DEFAULT ((0)) FOR [startMonth]
GO
ALTER TABLE [dbo].[Terms] ADD  DEFAULT ((0)) FOR [endYear]
GO
ALTER TABLE [dbo].[Terms] ADD  DEFAULT ((0)) FOR [endMonth]
GO
ALTER TABLE [dbo].[Transcript] ADD  CONSTRAINT [DF__transcrip__學生學科I__398D8EEE]  DEFAULT ((0)) FOR [studentDegreeID]
GO
ALTER TABLE [dbo].[Transcript] ADD  CONSTRAINT [DF_transcript_enrollStatusIS]  DEFAULT ((1)) FOR [gradeStatusID]
GO
ALTER TABLE [dbo].[Transcript] ADD  CONSTRAINT [DF__transcript__成績ID__3B75D760]  DEFAULT ((0)) FOR [gradeID]
GO
ALTER TABLE [dbo].[Transcript] ADD  CONSTRAINT [DF__transcript__旁聽__3C69FB99]  DEFAULT ((0)) FOR [auditing]
GO
ALTER TABLE [dbo].[Transcript] ADD  CONSTRAINT [DF__transcript__自修課程__3D5E1FD2]  DEFAULT ((0)) FOR [selfStudyCourse]
GO
ALTER TABLE [dbo].[TransferCredits] ADD  CONSTRAINT [DF__轉學分__學生學科ID__1DE57479]  DEFAULT ((0)) FOR [studentDegreeID]
GO
ALTER TABLE [dbo].[TransferCredits] ADD  CONSTRAINT [DF__轉學分__轉學分__1ED998B2]  DEFAULT ((0)) FOR [credits]
GO
ALTER TABLE [dbo].[TransferCredits] ADD  CONSTRAINT [DF_TransferCredits_deliveryMethodID]  DEFAULT ((1)) FOR [deliveryMethodID]
GO
ALTER TABLE [dbo].[TransferCredits] ADD  CONSTRAINT [DF_TransferCredits_fulfillRequirementNoCredit]  DEFAULT ((0)) FOR [fulfillRequirementNoCredit]
GO
ALTER TABLE [dbo].[CourseNames]  WITH CHECK ADD  CONSTRAINT [FK_CourseName_Departments] FOREIGN KEY([departmentID])
REFERENCES [dbo].[Departments] ([departmentID])
GO
ALTER TABLE [dbo].[CourseNames] CHECK CONSTRAINT [FK_CourseName_Departments]
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_Courses_CourseNames] FOREIGN KEY([courseNameID])
REFERENCES [dbo].[CourseNames] ([courseNameID])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_Courses_CourseNames]
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_Courses_RequirementName] FOREIGN KEY([requirementNameID])
REFERENCES [dbo].[RequirementName] ([requirementNameID])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_Courses_RequirementName]
GO
ALTER TABLE [dbo].[CourseTerms]  WITH CHECK ADD  CONSTRAINT [FK_CoursesTerms_Courses] FOREIGN KEY([courseID])
REFERENCES [dbo].[Courses] ([courseID])
GO
ALTER TABLE [dbo].[CourseTerms] CHECK CONSTRAINT [FK_CoursesTerms_Courses]
GO
ALTER TABLE [dbo].[CourseTerms]  WITH CHECK ADD  CONSTRAINT [FK_CoursesTerms_Terms] FOREIGN KEY([termID])
REFERENCES [dbo].[Terms] ([termID])
GO
ALTER TABLE [dbo].[CourseTerms] CHECK CONSTRAINT [FK_CoursesTerms_Terms]
GO
ALTER TABLE [dbo].[CourseTerms]  WITH CHECK ADD  CONSTRAINT [FK_CourseTerms_Faculty] FOREIGN KEY([facultyID])
REFERENCES [dbo].[Faculty] ([facultyID])
GO
ALTER TABLE [dbo].[CourseTerms] CHECK CONSTRAINT [FK_CourseTerms_Faculty]
GO
ALTER TABLE [dbo].[CourseTermSection]  WITH CHECK ADD  CONSTRAINT [FK_CourseTermSection_CourseTerms] FOREIGN KEY([courseTermID])
REFERENCES [dbo].[CourseTerms] ([courseTermID])
GO
ALTER TABLE [dbo].[CourseTermSection] CHECK CONSTRAINT [FK_CourseTermSection_CourseTerms]
GO
ALTER TABLE [dbo].[CourseTermSection]  WITH CHECK ADD  CONSTRAINT [FK_CourseTermSection_Section] FOREIGN KEY([sectionID])
REFERENCES [dbo].[Section] ([sectionID])
GO
ALTER TABLE [dbo].[CourseTermSection] CHECK CONSTRAINT [FK_CourseTermSection_Section]
GO
ALTER TABLE [dbo].[Degrees]  WITH CHECK ADD  CONSTRAINT [FK_Degrees_DegreeLevel] FOREIGN KEY([degreeLevelID])
REFERENCES [dbo].[DegreeLevel] ([degreeLevelID])
GO
ALTER TABLE [dbo].[Degrees] CHECK CONSTRAINT [FK_Degrees_DegreeLevel]
GO
ALTER TABLE [dbo].[Degrees]  WITH CHECK ADD  CONSTRAINT [FK_Degrees_DeliveryMethod] FOREIGN KEY([deliveryMethodID])
REFERENCES [dbo].[DeliveryMethod] ([deliveryMethodID])
GO
ALTER TABLE [dbo].[Degrees] CHECK CONSTRAINT [FK_Degrees_DeliveryMethod]
GO
ALTER TABLE [dbo].[GradRequirements]  WITH CHECK ADD  CONSTRAINT [FK_GradRequirements_Degrees] FOREIGN KEY([degreeID])
REFERENCES [dbo].[Degrees] ([degreeID])
GO
ALTER TABLE [dbo].[GradRequirements] CHECK CONSTRAINT [FK_GradRequirements_Degrees]
GO
ALTER TABLE [dbo].[GradRequirements]  WITH CHECK ADD  CONSTRAINT [FK_GradRequirements_DeliveryMethod] FOREIGN KEY([rDeliveryMethodID])
REFERENCES [dbo].[DeliveryMethod] ([deliveryMethodID])
GO
ALTER TABLE [dbo].[GradRequirements] CHECK CONSTRAINT [FK_GradRequirements_DeliveryMethod]
GO
ALTER TABLE [dbo].[GradRequirements]  WITH CHECK ADD  CONSTRAINT [FK_GradRequirements_GradRequirementType] FOREIGN KEY([gradReqTypeID])
REFERENCES [dbo].[GradRequirementType] ([gradReqTypeID])
GO
ALTER TABLE [dbo].[GradRequirements] CHECK CONSTRAINT [FK_GradRequirements_GradRequirementType]
GO
ALTER TABLE [dbo].[GradRequirements]  WITH CHECK ADD  CONSTRAINT [FK_GradRequirements_Handbooks] FOREIGN KEY([handbookID])
REFERENCES [dbo].[Handbooks] ([handbookID])
GO
ALTER TABLE [dbo].[GradRequirements] CHECK CONSTRAINT [FK_GradRequirements_Handbooks]
GO
ALTER TABLE [dbo].[GradRequirements]  WITH CHECK ADD  CONSTRAINT [FK_GradRequirements_RequirementName] FOREIGN KEY([reqNameID])
REFERENCES [dbo].[RequirementName] ([requirementNameID])
GO
ALTER TABLE [dbo].[GradRequirements] CHECK CONSTRAINT [FK_GradRequirements_RequirementName]
GO
ALTER TABLE [dbo].[Section]  WITH CHECK ADD  CONSTRAINT [FK_Section_DeliveryMethod] FOREIGN KEY([deliveryMethodID])
REFERENCES [dbo].[DeliveryMethod] ([deliveryMethodID])
GO
ALTER TABLE [dbo].[Section] CHECK CONSTRAINT [FK_Section_DeliveryMethod]
GO
ALTER TABLE [dbo].[StudentDegrees]  WITH CHECK ADD  CONSTRAINT [FK_StudentDegrees_Degrees] FOREIGN KEY([degreeID])
REFERENCES [dbo].[Degrees] ([degreeID])
GO
ALTER TABLE [dbo].[StudentDegrees] CHECK CONSTRAINT [FK_StudentDegrees_Degrees]
GO
ALTER TABLE [dbo].[StudentDegrees]  WITH CHECK ADD  CONSTRAINT [FK_StudentDegrees_Handbooks] FOREIGN KEY([handbookID])
REFERENCES [dbo].[Handbooks] ([handbookID])
GO
ALTER TABLE [dbo].[StudentDegrees] CHECK CONSTRAINT [FK_StudentDegrees_Handbooks]
GO
ALTER TABLE [dbo].[StudentDegrees]  WITH CHECK ADD  CONSTRAINT [FK_StudentDegrees_Students] FOREIGN KEY([studentID])
REFERENCES [dbo].[Students] ([studentID])
GO
ALTER TABLE [dbo].[StudentDegrees] CHECK CONSTRAINT [FK_StudentDegrees_Students]
GO
ALTER TABLE [dbo].[Transcript]  WITH CHECK ADD  CONSTRAINT [FK_Transcript_CourseTermSection] FOREIGN KEY([courseTermSectionID])
REFERENCES [dbo].[CourseTermSection] ([courseTermSectionID])
GO
ALTER TABLE [dbo].[Transcript] CHECK CONSTRAINT [FK_Transcript_CourseTermSection]
GO
ALTER TABLE [dbo].[Transcript]  WITH CHECK ADD  CONSTRAINT [FK_Transcript_Grades] FOREIGN KEY([gradeID])
REFERENCES [dbo].[Grades] ([gradesID])
GO
ALTER TABLE [dbo].[Transcript] CHECK CONSTRAINT [FK_Transcript_Grades]
GO
ALTER TABLE [dbo].[Transcript]  WITH CHECK ADD  CONSTRAINT [FK_Transcript_GradeStatus] FOREIGN KEY([gradeStatusID])
REFERENCES [dbo].[GradeStatus] ([gradeStatusID])
GO
ALTER TABLE [dbo].[Transcript] CHECK CONSTRAINT [FK_Transcript_GradeStatus]
GO
ALTER TABLE [dbo].[Transcript]  WITH CHECK ADD  CONSTRAINT [FK_Transcript_StudentDegrees] FOREIGN KEY([studentDegreeID])
REFERENCES [dbo].[StudentDegrees] ([studentDegreeID])
GO
ALTER TABLE [dbo].[Transcript] CHECK CONSTRAINT [FK_Transcript_StudentDegrees]
GO
ALTER TABLE [dbo].[TransferCredits]  WITH CHECK ADD  CONSTRAINT [FK_TransferCredits_DegreeLevel] FOREIGN KEY([degreeLevelID])
REFERENCES [dbo].[DegreeLevel] ([degreeLevelID])
GO
ALTER TABLE [dbo].[TransferCredits] CHECK CONSTRAINT [FK_TransferCredits_DegreeLevel]
GO
ALTER TABLE [dbo].[TransferCredits]  WITH CHECK ADD  CONSTRAINT [FK_TransferCredits_DeliveryMethod] FOREIGN KEY([deliveryMethodID])
REFERENCES [dbo].[DeliveryMethod] ([deliveryMethodID])
GO
ALTER TABLE [dbo].[TransferCredits] CHECK CONSTRAINT [FK_TransferCredits_DeliveryMethod]
GO
ALTER TABLE [dbo].[TransferCredits]  WITH CHECK ADD  CONSTRAINT [FK_TransferCredits_RequirementName] FOREIGN KEY([requirementNameID])
REFERENCES [dbo].[RequirementName] ([requirementNameID])
GO
ALTER TABLE [dbo].[TransferCredits] CHECK CONSTRAINT [FK_TransferCredits_RequirementName]
GO
ALTER TABLE [dbo].[TransferCredits]  WITH CHECK ADD  CONSTRAINT [FK_TransferCredits_StudentDegrees] FOREIGN KEY([studentDegreeID])
REFERENCES [dbo].[StudentDegrees] ([studentDegreeID])
GO
ALTER TABLE [dbo].[TransferCredits] CHECK CONSTRAINT [FK_TransferCredits_StudentDegrees]
GO
ALTER TABLE [dbo].[Grades]  WITH NOCHECK ADD  CONSTRAINT [SSMA_CC$成績$grade$disallow_zero_length] CHECK  ((len([grade])>(0)))
GO
ALTER TABLE [dbo].[Grades] CHECK CONSTRAINT [SSMA_CC$成績$grade$disallow_zero_length]
GO
ALTER TABLE [dbo].[Grades]  WITH NOCHECK ADD  CONSTRAINT [SSMA_CC$成績$note$disallow_zero_length] CHECK  ((len([grade])>(0)))
GO
ALTER TABLE [dbo].[Grades] CHECK CONSTRAINT [SSMA_CC$成績$note$disallow_zero_length]
GO
