/****** Object:  Table [dbo].[log]    Script Date: 02/18/2015 11:15:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[log](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[timestamp] [datetime] NOT NULL,
	[application] [varchar](50) NOT NULL,
	[ip] [varchar](50) NOT NULL,
	[user] [varchar](50) NOT NULL,
	[action] [varchar](max) NOT NULL,
	[data] [varchar](max) NULL,
 CONSTRAINT [PK_log] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
