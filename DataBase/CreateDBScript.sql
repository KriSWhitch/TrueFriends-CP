USE [master]
GO

DROP DATABASE [MAV_TrueFriends_CP];
GO

CREATE DATABASE [MAV_TrueFriends_CP];
GO

USE [MAV_TrueFriends_CP]
GO

CREATE TABLE [dbo].[User](
	[User_ID] [int] NOT NULL IDENTITY(1,1) PRIMARY KEY, -- идентификатор пользовател€
	[User_Login] [varchar](20) NULL, -- логин пользовател€
	[User_Password] [varchar](256) NULL, -- пароль пользовател€
	[User_IsAdmin] [bit] NULL -- флаг €вл€етс€ ли пользователь администратором
)
GO

CREATE TABLE [dbo].[Advert](
	[Advert_ID] [int] NOT NULL IDENTITY(1,1) PRIMARY KEY, -- идентификатор объ€влени€
	[Advert_Name] [varchar](40) NOT NULL, -- название объ€влени€
	[Advert_AnimalAge] [int] NOT NULL, -- возраст животного
	[Advert_AnimalWeight] [decimal](10,2) NOT NULL, -- вес животного
	[Advert_KindOfAnimal] [varchar](20) NULL, -- вид животного в объ€лении
	[Advert_Description] [varchar](2000) NULL, -- описание объ€влени€
	[Advert_Image] [varchar](max) NULL, -- картинки прикрепленные к объ€влению
	[Advert_Creator] [int] NULL FOREIGN KEY ([Advert_Creator]) REFERENCES [User]([User_ID]), -- создатель объ€влени€
	[Advert_CreationDate] [DateTime] NULL, -- дата создани€ объ€влени€
)
GO

CREATE TABLE [dbo].[Comment](
	[Comment_ID] [int] NOT NULL IDENTITY(1,1) PRIMARY KEY, -- идентификатор комментари€
	[Comment_Text] [varchar](500) NULL, -- описание комментари€
	[Comment_Creator] [int] NULL FOREIGN KEY ([Comment_Creator]) REFERENCES [User]([User_ID]), -- создатель комментари€
	[Comment_CreationDate] [DateTime] NULL, -- дата создани€ комментари€
)
GO