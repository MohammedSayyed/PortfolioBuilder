USE [portfolio]
GO
/****** Object:  Table [dbo].[bachelor_degree]    Script Date: 08-12-2020 7.02.49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bachelor_degree](
	[email] [varchar](50) NULL,
	[bdegree] [varchar](50) NULL,
	[duration] [varchar](50) NULL,
	[college] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[junior_college]    Script Date: 08-12-2020 7.02.49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[junior_college](
	[email] [varchar](50) NULL,
	[stream] [varchar](50) NULL,
	[duration] [varchar](50) NULL,
	[college] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[master_degree]    Script Date: 08-12-2020 7.02.49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[master_degree](
	[email] [varchar](50) NULL,
	[mdegree] [varchar](50) NULL,
	[duration] [varchar](50) NULL,
	[college] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persons]    Script Date: 08-12-2020 7.02.49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[email] [varchar](50) NOT NULL,
	[name] [varchar](50) NULL,
	[gender] [varchar](50) NULL,
	[DOB] [varchar](50) NULL,
	[job_role] [varchar](50) NULL,
	[password] [varchar](50) NULL,
	[about] [varchar](max) NULL,
	[website] [varchar](50) NULL,
	[skills] [varchar](50) NULL,
	[profile_pic] [varchar](50) NULL,
	[resume] [varchar](50) NULL,
	[address] [varchar](100) NULL,
	[phone] [varchar](50) NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[work_exp]    Script Date: 08-12-2020 7.02.49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[work_exp](
	[email] [varchar](50) NULL,
	[role] [varchar](50) NULL,
	[company] [varchar](50) NULL,
	[job_info] [varchar](100) NULL,
	[duration] [varchar](50) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[bachelor_degree] ([email], [bdegree], [duration], [college]) VALUES (N'mohammedsayyed1010@gmail.com', N'Bachelor in Computer Application', N'Jun 2017- Nov 2020', N'Abeda Inamdar')
GO
INSERT [dbo].[junior_college] ([email], [stream], [duration], [college]) VALUES (N'mohammedsayyed1010@gmail.com', N'Science', N'Jun 2015 - march 2017', N'City International School')
GO
INSERT [dbo].[master_degree] ([email], [mdegree], [duration], [college]) VALUES (N'mohammedsayyed1010@gmail.com', N'Master in Computer Application', N'Aug 2020 - Dec 2020', N'MIT World Peace University Kothrud')
GO
INSERT [dbo].[Persons] ([email], [name], [gender], [DOB], [job_role], [password], [about], [website], [skills], [profile_pic], [resume], [address], [phone]) VALUES (N'mohammedsayyed1010@gmail.com', N'Mohammed Farooque Sayyed', N'Male', N'1999-10-10', N'Front-End Developer', N'momo', N'I am a Freelancer and I have good knowledge about programming and programming concepts', N'http://www.mohammed.com', N'HTML 5,Python,CSS3,PHP,JAVA,', N'20201208163509DSC_0076-01.jpeg', N'20201208011441mohammed-resume.pdf', N'503 Avishkar Progressive Primero Society Undri Pune', N'9860264614')
GO
INSERT [dbo].[work_exp] ([email], [role], [company], [job_info], [duration]) VALUES (N'mohammedsayyed1010@gmail.com', N'UI UX Developer', N'Google', N'I had to do UI UX designing for both mobile application and web application ', N'4 years')
INSERT [dbo].[work_exp] ([email], [role], [company], [job_info], [duration]) VALUES (N'mohammedsayyed1010@gmail.com', N'Database Analyst', N'Facebook', N'I had to handle the backend services and web apis and to improve user interface', N'2 Years')
INSERT [dbo].[work_exp] ([email], [role], [company], [job_info], [duration]) VALUES (N'mohammedsayyed1010@gmail.com', N'Digital marketer', N'Azure Private Limited', N'I had an opportunity to work in AI and ML.
', N'1 year ')
GO
ALTER TABLE [dbo].[bachelor_degree]  WITH NOCHECK ADD  CONSTRAINT [FK_bachelor_degree_Persons] FOREIGN KEY([email])
REFERENCES [dbo].[Persons] ([email])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[bachelor_degree] CHECK CONSTRAINT [FK_bachelor_degree_Persons]
GO
ALTER TABLE [dbo].[junior_college]  WITH CHECK ADD  CONSTRAINT [FK_junior_college_Persons] FOREIGN KEY([email])
REFERENCES [dbo].[Persons] ([email])
GO
ALTER TABLE [dbo].[junior_college] CHECK CONSTRAINT [FK_junior_college_Persons]
GO
ALTER TABLE [dbo].[master_degree]  WITH CHECK ADD  CONSTRAINT [FK_master_degree_Persons] FOREIGN KEY([email])
REFERENCES [dbo].[Persons] ([email])
GO
ALTER TABLE [dbo].[master_degree] CHECK CONSTRAINT [FK_master_degree_Persons]
GO
ALTER TABLE [dbo].[work_exp]  WITH CHECK ADD  CONSTRAINT [FK_work_exp_Persons] FOREIGN KEY([email])
REFERENCES [dbo].[Persons] ([email])
GO
ALTER TABLE [dbo].[work_exp] CHECK CONSTRAINT [FK_work_exp_Persons]
GO
