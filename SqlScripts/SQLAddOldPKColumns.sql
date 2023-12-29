USE [CrtsTranscript_2024]
GO

--SELECT 'ALTER TABLE ' + QUOTENAME(ss.name) + '.' + QUOTENAME(st.name) + ' ADD old' + st.name +'ID int NOT NULL;'
--FROM sys.tables st
--INNER JOIN sys.schemas ss on st.[schema_id] = ss.[schema_id]
--WHERE st.is_ms_shipped = 0
--;


ALTER TABLE [dbo].[CourseNames] ADD oldCourseNamesID int NOT NULL;
ALTER TABLE [dbo].[Courses] ADD oldCoursesID int NOT NULL;
ALTER TABLE [dbo].[CourseTerms] ADD oldCourseTermsID int NOT NULL;
ALTER TABLE [dbo].[CourseTermSection] ADD oldCourseTermSectionID int NOT NULL;
ALTER TABLE [dbo].[DegreeLevel] ADD oldDegreeLevelID int NOT NULL;
ALTER TABLE [dbo].[Degrees] ADD oldDegreesID int NOT NULL;
ALTER TABLE [dbo].[DeliveryMethod] ADD oldDeliveryMethodID int NOT NULL;
ALTER TABLE [dbo].[Departments] ADD oldDepartmentsID int NOT NULL;
ALTER TABLE [dbo].[Faculty] ADD oldFacultyID int NOT NULL;
ALTER TABLE [dbo].[Grades] ADD oldGradesID int NOT NULL;
ALTER TABLE [dbo].[GradeStatus] ADD oldGradeStatusID int NOT NULL;
ALTER TABLE [dbo].[GradRequirements] ADD oldGradRequirementsID int NOT NULL;
ALTER TABLE [dbo].[GradRequirementType] ADD oldGradRequirementTypeID int NOT NULL;
ALTER TABLE [dbo].[Handbooks] ADD oldHandbooksID int NOT NULL;
ALTER TABLE [dbo].[RequirementName] ADD oldRequirementNameID int NOT NULL;
ALTER TABLE [dbo].[Section] ADD oldSectionID int NOT NULL;
ALTER TABLE [dbo].[StudentDegrees] ADD oldStudentDegreesID int NOT NULL;
ALTER TABLE [dbo].[Students] ADD oldStudentsID int NOT NULL;
ALTER TABLE [dbo].[Terms] ADD oldTermsID int NOT NULL;
ALTER TABLE [dbo].[Transcript] ADD oldTranscriptID int NOT NULL;
ALTER TABLE [dbo].[TransferCredits] ADD oldTransferCreditsID int NOT NULL;
GO

