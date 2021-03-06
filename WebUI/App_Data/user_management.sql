USE [master]
GO
/****** Object:  Database [user_management]    Script Date: 12/31/2014 14:56:30 ******/
CREATE DATABASE [user_management] ON  PRIMARY 
( NAME = N'user_management', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\template.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'user_management_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\template_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [user_management] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [user_management].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [user_management] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [user_management] SET ANSI_NULLS OFF
GO
ALTER DATABASE [user_management] SET ANSI_PADDING OFF
GO
ALTER DATABASE [user_management] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [user_management] SET ARITHABORT OFF
GO
ALTER DATABASE [user_management] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [user_management] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [user_management] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [user_management] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [user_management] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [user_management] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [user_management] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [user_management] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [user_management] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [user_management] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [user_management] SET  DISABLE_BROKER
GO
ALTER DATABASE [user_management] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [user_management] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [user_management] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [user_management] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [user_management] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [user_management] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [user_management] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [user_management] SET  READ_WRITE
GO
ALTER DATABASE [user_management] SET RECOVERY FULL
GO
ALTER DATABASE [user_management] SET  MULTI_USER
GO
ALTER DATABASE [user_management] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [user_management] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'user_management', N'ON'
GO
USE [user_management]
GO
/****** Object:  Table [dbo].[Actions]    Script Date: 12/31/2014 14:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Actions](
	[Id] [uniqueidentifier] NOT NULL,
	[ActionName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_Actions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Applications]    Script Date: 12/31/2014 14:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Applications](
	[ApplicationName] [nvarchar](235) NOT NULL,
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](256) NULL,
PRIMARY KEY CLUSTERED 
(
	[ApplicationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Applications] ([ApplicationName], [ApplicationId], [Description]) VALUES (N'UserManagement', N'495d2e92-85fd-4b5b-b21e-5d1908011b68', NULL)
INSERT [dbo].[Applications] ([ApplicationName], [ApplicationId], [Description]) VALUES (N'/', N'1ba67c97-fcd6-4ead-b34a-83653b36db2c', NULL)
/****** Object:  Table [dbo].[Modules]    Script Date: 12/31/2014 14:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Modules](
	[Id] [uniqueidentifier] NOT NULL,
	[ModuleName] [nvarchar](256) NOT NULL,
	[ParentModule] [nvarchar](50) NULL,
 CONSTRAINT [PK_Modules] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/31/2014 14:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[IsAnonymous] [bit] NOT NULL,
	[LastActivityDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_UserName] ON [dbo].[Users] 
(
	[UserName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
INSERT [dbo].[Users] ([ApplicationId], [UserId], [UserName], [IsAnonymous], [LastActivityDate]) VALUES (N'1ba67c97-fcd6-4ead-b34a-83653b36db2c', N'6e5d8b31-7a9f-4863-b135-04d1de5423dc', N'chandra', 0, CAST(0x0000A41100FAB599 AS DateTime))
INSERT [dbo].[Users] ([ApplicationId], [UserId], [UserName], [IsAnonymous], [LastActivityDate]) VALUES (N'495d2e92-85fd-4b5b-b21e-5d1908011b68', N'b930fda0-262a-4d71-8c0c-12b6e05e635b', N'superadmin', 0, CAST(0x0000A41100FC501B AS DateTime))
INSERT [dbo].[Users] ([ApplicationId], [UserId], [UserName], [IsAnonymous], [LastActivityDate]) VALUES (N'1ba67c97-fcd6-4ead-b34a-83653b36db2c', N'b3ec4a46-3500-470b-b8db-cd54a34459d7', N'admin', 0, CAST(0x0000A41100FC158E AS DateTime))
/****** Object:  Table [dbo].[Roles]    Script Date: 12/31/2014 14:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
	[RoleName] [nvarchar](256) NOT NULL,
	[Description] [nvarchar](256) NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Roles] ([ApplicationId], [RoleId], [RoleName], [Description]) VALUES (N'495d2e92-85fd-4b5b-b21e-5d1908011b68', N'f9dfbc89-6423-4c7c-9390-36d240a3f875', N'SecurityGuard', NULL)
/****** Object:  Table [dbo].[ActionsInModules]    Script Date: 12/31/2014 14:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActionsInModules](
	[ActionId] [uniqueidentifier] NOT NULL,
	[ModuleId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_ActionsInModules] PRIMARY KEY CLUSTERED 
(
	[ActionId] ASC,
	[ModuleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsersInRoles]    Script Date: 12/31/2014 14:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersInRoles](
	[UserId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[UsersInRoles] ([UserId], [RoleId]) VALUES (N'b930fda0-262a-4d71-8c0c-12b6e05e635b', N'f9dfbc89-6423-4c7c-9390-36d240a3f875')
INSERT [dbo].[UsersInRoles] ([UserId], [RoleId]) VALUES (N'b3ec4a46-3500-470b-b8db-cd54a34459d7', N'f9dfbc89-6423-4c7c-9390-36d240a3f875')
/****** Object:  Table [dbo].[Profiles]    Script Date: 12/31/2014 14:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profiles](
	[UserId] [uniqueidentifier] NOT NULL,
	[PropertyNames] [nvarchar](4000) NOT NULL,
	[PropertyValueStrings] [nvarchar](4000) NOT NULL,
	[PropertyValueBinary] [image] NOT NULL,
	[LastUpdatedDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ModulesInRoles]    Script Date: 12/31/2014 14:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModulesInRoles](
	[Id] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
	[ModuleId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_ModulesInRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Memberships]    Script Date: 12/31/2014 14:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Memberships](
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[Password] [nvarchar](128) NOT NULL,
	[PasswordFormat] [int] NOT NULL,
	[PasswordSalt] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[PasswordQuestion] [nvarchar](256) NULL,
	[PasswordAnswer] [nvarchar](128) NULL,
	[IsApproved] [bit] NOT NULL,
	[IsLockedOut] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastLoginDate] [datetime] NOT NULL,
	[LastPasswordChangedDate] [datetime] NOT NULL,
	[LastLockoutDate] [datetime] NOT NULL,
	[FailedPasswordAttemptCount] [int] NOT NULL,
	[FailedPasswordAttemptWindowStart] [datetime] NOT NULL,
	[FailedPasswordAnswerAttemptCount] [int] NOT NULL,
	[FailedPasswordAnswerAttemptWindowsStart] [datetime] NOT NULL,
	[Comment] [nvarchar](256) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Memberships] ([ApplicationId], [UserId], [Password], [PasswordFormat], [PasswordSalt], [Email], [PasswordQuestion], [PasswordAnswer], [IsApproved], [IsLockedOut], [CreateDate], [LastLoginDate], [LastPasswordChangedDate], [LastLockoutDate], [FailedPasswordAttemptCount], [FailedPasswordAttemptWindowStart], [FailedPasswordAnswerAttemptCount], [FailedPasswordAnswerAttemptWindowsStart], [Comment]) VALUES (N'1ba67c97-fcd6-4ead-b34a-83653b36db2c', N'6e5d8b31-7a9f-4863-b135-04d1de5423dc', N'pw+miVoqNSYZU97VzkMBqDV9K8VvrmhZkkS0oruaubY=', 1, N'K0zlQ8Cqa9jrMp0DSTkOUg==', N'chandra@rekadia.co.id', NULL, NULL, 1, 0, CAST(0x0000A41100FA9B32 AS DateTime), CAST(0x0000A41100FAB599 AS DateTime), CAST(0x0000A41100FA9B32 AS DateTime), CAST(0xFFFF2FB300000000 AS DateTime), 0, CAST(0xFFFF2FB300000000 AS DateTime), 0, CAST(0xFFFF2FB300000000 AS DateTime), NULL)
INSERT [dbo].[Memberships] ([ApplicationId], [UserId], [Password], [PasswordFormat], [PasswordSalt], [Email], [PasswordQuestion], [PasswordAnswer], [IsApproved], [IsLockedOut], [CreateDate], [LastLoginDate], [LastPasswordChangedDate], [LastLockoutDate], [FailedPasswordAttemptCount], [FailedPasswordAttemptWindowStart], [FailedPasswordAnswerAttemptCount], [FailedPasswordAnswerAttemptWindowsStart], [Comment]) VALUES (N'495d2e92-85fd-4b5b-b21e-5d1908011b68', N'b930fda0-262a-4d71-8c0c-12b6e05e635b', N'jndIeuOTb1fyc1hlQmXFzlZ2+wk77/JSOEYlMKfCTeI=', 1, N'yOBiyhp4tcfG5qiSi/Pw+A==', N'contact@rekadia.co.id', NULL, NULL, 1, 0, CAST(0x0000A411004924D4 AS DateTime), CAST(0x0000A41100FC501B AS DateTime), CAST(0x0000A411004924D4 AS DateTime), CAST(0xFFFF2FB300000000 AS DateTime), 0, CAST(0xFFFF2FB300000000 AS DateTime), 0, CAST(0xFFFF2FB300000000 AS DateTime), NULL)
INSERT [dbo].[Memberships] ([ApplicationId], [UserId], [Password], [PasswordFormat], [PasswordSalt], [Email], [PasswordQuestion], [PasswordAnswer], [IsApproved], [IsLockedOut], [CreateDate], [LastLoginDate], [LastPasswordChangedDate], [LastLockoutDate], [FailedPasswordAttemptCount], [FailedPasswordAttemptWindowStart], [FailedPasswordAnswerAttemptCount], [FailedPasswordAnswerAttemptWindowsStart], [Comment]) VALUES (N'1ba67c97-fcd6-4ead-b34a-83653b36db2c', N'b3ec4a46-3500-470b-b8db-cd54a34459d7', N'Wgw4kGwjR59MrTggnSTEgAF46c7BfyCbMFCvkMRu3cc=', 1, N'wsNvNAfDX7jM6xfwcBbk0w==', N'contact@rekadia.co.id', NULL, NULL, 1, 0, CAST(0x0000A41100FAF0A8 AS DateTime), CAST(0x0000A41100FC158E AS DateTime), CAST(0x0000A41100FAF0A8 AS DateTime), CAST(0xFFFF2FB300000000 AS DateTime), 0, CAST(0xFFFF2FB300000000 AS DateTime), 0, CAST(0xFFFF2FB300000000 AS DateTime), NULL)
/****** Object:  Table [dbo].[ActionsInModulesChosen]    Script Date: 12/31/2014 14:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActionsInModulesChosen](
	[ModuleInRoleId] [uniqueidentifier] NOT NULL,
	[ActionId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_ActionsInModulesChosen] PRIMARY KEY CLUSTERED 
(
	[ModuleInRoleId] ASC,
	[ActionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [UserApplication]    Script Date: 12/31/2014 14:56:32 ******/
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [UserApplication] FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[Applications] ([ApplicationId])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [UserApplication]
GO
/****** Object:  ForeignKey [RoleApplication]    Script Date: 12/31/2014 14:56:32 ******/
ALTER TABLE [dbo].[Roles]  WITH CHECK ADD  CONSTRAINT [RoleApplication] FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[Applications] ([ApplicationId])
GO
ALTER TABLE [dbo].[Roles] CHECK CONSTRAINT [RoleApplication]
GO
/****** Object:  ForeignKey [ActionsInModulesActions]    Script Date: 12/31/2014 14:56:32 ******/
ALTER TABLE [dbo].[ActionsInModules]  WITH CHECK ADD  CONSTRAINT [ActionsInModulesActions] FOREIGN KEY([ActionId])
REFERENCES [dbo].[Actions] ([Id])
GO
ALTER TABLE [dbo].[ActionsInModules] CHECK CONSTRAINT [ActionsInModulesActions]
GO
/****** Object:  ForeignKey [ActionsInModulesModules]    Script Date: 12/31/2014 14:56:32 ******/
ALTER TABLE [dbo].[ActionsInModules]  WITH CHECK ADD  CONSTRAINT [ActionsInModulesModules] FOREIGN KEY([ModuleId])
REFERENCES [dbo].[Modules] ([Id])
GO
ALTER TABLE [dbo].[ActionsInModules] CHECK CONSTRAINT [ActionsInModulesModules]
GO
/****** Object:  ForeignKey [UsersInRoleRole]    Script Date: 12/31/2014 14:56:32 ******/
ALTER TABLE [dbo].[UsersInRoles]  WITH CHECK ADD  CONSTRAINT [UsersInRoleRole] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
GO
ALTER TABLE [dbo].[UsersInRoles] CHECK CONSTRAINT [UsersInRoleRole]
GO
/****** Object:  ForeignKey [UsersInRoleUser]    Script Date: 12/31/2014 14:56:32 ******/
ALTER TABLE [dbo].[UsersInRoles]  WITH CHECK ADD  CONSTRAINT [UsersInRoleUser] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[UsersInRoles] CHECK CONSTRAINT [UsersInRoleUser]
GO
/****** Object:  ForeignKey [UserProfile]    Script Date: 12/31/2014 14:56:32 ******/
ALTER TABLE [dbo].[Profiles]  WITH CHECK ADD  CONSTRAINT [UserProfile] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Profiles] CHECK CONSTRAINT [UserProfile]
GO
/****** Object:  ForeignKey [ModulesInRolesModules]    Script Date: 12/31/2014 14:56:32 ******/
ALTER TABLE [dbo].[ModulesInRoles]  WITH CHECK ADD  CONSTRAINT [ModulesInRolesModules] FOREIGN KEY([ModuleId])
REFERENCES [dbo].[Modules] ([Id])
GO
ALTER TABLE [dbo].[ModulesInRoles] CHECK CONSTRAINT [ModulesInRolesModules]
GO
/****** Object:  ForeignKey [ModulesInRolesRoles]    Script Date: 12/31/2014 14:56:32 ******/
ALTER TABLE [dbo].[ModulesInRoles]  WITH CHECK ADD  CONSTRAINT [ModulesInRolesRoles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
GO
ALTER TABLE [dbo].[ModulesInRoles] CHECK CONSTRAINT [ModulesInRolesRoles]
GO
/****** Object:  ForeignKey [MembershipApplication]    Script Date: 12/31/2014 14:56:32 ******/
ALTER TABLE [dbo].[Memberships]  WITH CHECK ADD  CONSTRAINT [MembershipApplication] FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[Applications] ([ApplicationId])
GO
ALTER TABLE [dbo].[Memberships] CHECK CONSTRAINT [MembershipApplication]
GO
/****** Object:  ForeignKey [MembershipUser]    Script Date: 12/31/2014 14:56:32 ******/
ALTER TABLE [dbo].[Memberships]  WITH CHECK ADD  CONSTRAINT [MembershipUser] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Memberships] CHECK CONSTRAINT [MembershipUser]
GO
/****** Object:  ForeignKey [ActionsInModulesChosenActions]    Script Date: 12/31/2014 14:56:32 ******/
ALTER TABLE [dbo].[ActionsInModulesChosen]  WITH CHECK ADD  CONSTRAINT [ActionsInModulesChosenActions] FOREIGN KEY([ActionId])
REFERENCES [dbo].[Actions] ([Id])
GO
ALTER TABLE [dbo].[ActionsInModulesChosen] CHECK CONSTRAINT [ActionsInModulesChosenActions]
GO
/****** Object:  ForeignKey [ActionsInModulesChosenModulesInRoles]    Script Date: 12/31/2014 14:56:32 ******/
ALTER TABLE [dbo].[ActionsInModulesChosen]  WITH CHECK ADD  CONSTRAINT [ActionsInModulesChosenModulesInRoles] FOREIGN KEY([ModuleInRoleId])
REFERENCES [dbo].[ModulesInRoles] ([Id])
GO
ALTER TABLE [dbo].[ActionsInModulesChosen] CHECK CONSTRAINT [ActionsInModulesChosenModulesInRoles]
GO
