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
	[User_Password] [varchar](256) NULL, -- ������ ������������
	[User_IsAdmin] [bit] NULL -- ���� �������� �� ������������ ���������������
)
GO

CREATE TABLE [dbo].[Advert](
	[Advert_ID] [int] NOT NULL IDENTITY(1,1) PRIMARY KEY, -- ������������� ����������
	[Advert_Name] [varchar](40) NOT NULL, -- �������� ����������
	[Advert_AnimalAge] [int] NOT NULL, -- ������� ���������
	[Advert_AnimalWeight] [decimal](10,2) NOT NULL, -- ��� ���������
	[Advert_KindOfAnimal] [varchar](20) NULL, -- ��� ��������� � ���������
	[Advert_Description] [varchar](2000) NULL, -- �������� ����������
	[Advert_Image] [varchar](max) NULL, -- �������� ������������� � ����������
	[Advert_Creator] [int] NULL FOREIGN KEY ([Advert_Creator]) REFERENCES [User]([User_ID]), -- ��������� ����������
	[Advert_CreationDate] [DateTime] NULL, -- ���� �������� ����������
)
GO

CREATE TABLE [dbo].[Favorite](
	[Favorite_ID] [int] NOT NULL IDENTITY(1,1) PRIMARY KEY, -- ������������� ����������
	[Favorite_User_ID] [int] NOT NULL, -- ������������, ������� ������� ���������� � ���������
	[Favorite_Advert_ID] [int] NOT NULL, -- ���������� ���������� ������������� � ���������
)
GO