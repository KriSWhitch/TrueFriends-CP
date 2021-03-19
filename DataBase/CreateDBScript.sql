USE [master]
GO

DROP DATABASE [MAV_TrueFriends_CP];
GO

CREATE DATABASE [MAV_TrueFriends_CP];
GO

USE [MAV_TrueFriends_CP]
GO

CREATE TABLE [dbo].[User](
	[User_ID] [int] NOT NULL IDENTITY(1,1) PRIMARY KEY, -- ������������� ������������
	[User_Login] [varchar](20) NULL, -- ����� ������������
	[User_Password] [varchar](30) NULL, -- ������ ������������
	[User_Name] [varchar](20) NULL, -- ��� ������������
	[User_Surname] [varchar](30) NULL, -- ������� ������������
	[User_IsAdmin] [bit] NULL -- ���� �������� �� ������������ ���������������
)
GO

CREATE TABLE [dbo].[Advert](
	[Advert_ID] [int] NOT NULL IDENTITY(1,1) PRIMARY KEY, -- ������������� ����������
	[Advert_FullName] [varchar](40) NULL, -- ������ �������� ����������
	[Advert_ShortName] [varchar](20) NULL, -- ����������� �������� ����������
	[Advert_Description] [varchar](2200) NULL, -- �������� ����������
	[Advert_Images] [varbinary](max) NULL, -- �������� ������������� � ����������
	[Advert_KindOfAnimal] [varchar](20) NULL, -- ��� ��������� � ���������
	[Advert_Creator] [int] NULL FOREIGN KEY ([Advert_Creator]) REFERENCES [User]([User_ID]), -- ��������� ����������
	[Advert_CreationDate] [DateTime] NULL, -- ���� �������� ����������
)
GO

CREATE TABLE [dbo].[Comment](
	[Comment_ID] [int] NOT NULL IDENTITY(1,1) PRIMARY KEY, -- ������������� �����������
	[Comment_Text] [varchar](500) NULL, -- �������� �����������
	[Comment_Creator] [int] NULL FOREIGN KEY ([Comment_Creator]) REFERENCES [User]([User_ID]), -- ��������� �����������
	[Comment_CreationDate] [DateTime] NULL, -- ���� �������� �����������
)
GO


