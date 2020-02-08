IF OBJECT_ID('dbo.PAMS_USER', 'U') IS NOT NULL 
    DROP TABLE dbo.PAMS_USER;
GO
CREATE TABLE PAMS_USER
(
[UserID] [uniqueidentifier] NOT NULL,
[UserName] [nvarchar] (256) COLLATE Chinese_PRC_CI_AS NOT NULL,
[LogonPassword] [nvarchar] (256) COLLATE Chinese_PRC_CI_AS NOT NULL DEFAULT (''),
[LogonName] [nvarchar] (256) COLLATE Chinese_PRC_CI_AS NOT NULL DEFAULT (''),
[UserURL] [nvarchar] (38) COLLATE Chinese_PRC_CI_AS NOT NULL DEFAULT (''),
[PicturePath] [nvarchar] (200) COLLATE Chinese_PRC_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].PAMS_USER ADD CONSTRAINT [PK_PAMS_USER] PRIMARY KEY CLUSTERED ([UserID]) ON [PRIMARY]
GO
