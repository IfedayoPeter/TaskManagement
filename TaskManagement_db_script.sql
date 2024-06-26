USE [TaskManagement]
GO
/****** Object:  Table [dbo].[task]    Script Date: 5/20/2024 11:32:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[task](
	[TaskId] [bigint] IDENTITY(1,1) NOT NULL,
	[TaskCode] [varchar](50) NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[Status] [varchar](50) NOT NULL,
	[Priority] [varchar](50) NOT NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[DueDate] [datetime] NOT NULL,
	[AssignedTo] [varchar](50) NULL,
	[Comments] [varchar](50) NULL,
	[LastModifiedOn] [datetime] NULL,
 CONSTRAINT [PK_task] PRIMARY KEY CLUSTERED 
(
	[TaskCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user]    Script Date: 5/20/2024 11:32:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[UserId] [bigint] IDENTITY(1,1) NOT NULL,
	[UserCode] [varchar](50) NOT NULL,
	[FullName] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Password] [varchar](500) NOT NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[UserCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[task] ON 

INSERT [dbo].[task] ([TaskId], [TaskCode], [Title], [Description], [Status], [Priority], [CreatedOn], [CreatedBy], [DueDate], [AssignedTo], [Comments], [LastModifiedOn]) VALUES (3, N'JPXLS', N'Update Database', N'Weekly database update', N'ongoing', N'medium', CAST(N'2024-05-18T21:46:00.560' AS DateTime), N'Taiwo', CAST(N'2024-05-18T21:46:00.560' AS DateTime), N'Michael', N'Databased must be updated weekly', CAST(N'2024-05-18T22:52:19.613' AS DateTime))
INSERT [dbo].[task] ([TaskId], [TaskCode], [Title], [Description], [Status], [Priority], [CreatedOn], [CreatedBy], [DueDate], [AssignedTo], [Comments], [LastModifiedOn]) VALUES (2, N'LRVWJ', N'Update code', N'Bi-Weekly code update', N'ongoing', N'low', CAST(N'2024-05-18T21:46:00.560' AS DateTime), N'Taiwo', CAST(N'2024-05-18T21:46:00.560' AS DateTime), N'John', N'HMS code must be updated weekly', CAST(N'2024-05-18T22:50:28.013' AS DateTime))
SET IDENTITY_INSERT [dbo].[task] OFF
GO
SET IDENTITY_INSERT [dbo].[user] ON 

INSERT [dbo].[user] ([UserId], [UserCode], [FullName], [Email], [Password]) VALUES (2, N'KZXZL', N'Tolu Olawale', N'olatee@email.com', N'AQAAAAIAAYagAAAAEMz5FipkNG8n9gW7+9or5i2FWJHrpwO5j/QgozLeIt8RulYXOdgW5jpm2WaSMVbF9A==')
INSERT [dbo].[user] ([UserId], [UserCode], [FullName], [Email], [Password]) VALUES (1, N'RS7ZR', N'James Aina', N'aina05@email.com', N'AQAAAAIAAYagAAAAEBeOr0Ek/QNdxKfmIws3IHzhaom2ksfTpSKAa457wSQoURfwbhTgArDjLT7xFIQ8lw==')
SET IDENTITY_INSERT [dbo].[user] OFF
GO
