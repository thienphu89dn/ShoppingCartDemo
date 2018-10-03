USE [DB_Oauth_API]  
GO  
/****** Object:  StoredProcedure [dbo].[LoginByUsernamePassword]    Script Date: 5/10/2018 2:37:02 PM ******/  
DROP PROCEDURE [dbo].[LoginByUsernamePassword]  
GO  
/****** Object:  Table [dbo].[Login]    Script Date: 5/10/2018 2:37:02 PM ******/  
DROP TABLE [dbo].[Login]  
GO  
/****** Object:  Table [dbo].[Login]    Script Date: 5/10/2018 2:37:02 PM ******/  
SET ANSI_NULLS ON  
GO  
SET QUOTED_IDENTIFIER ON  
GO  
SET ANSI_PADDING ON  
GO  
CREATE TABLE [dbo].[Login](  
    [id] [int] IDENTITY(1,1) NOT NULL,  
    [username] [varchar](50) NOT NULL,  
    [password] [varchar](50) NOT NULL,  
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED   
(  
    [id] ASC  
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]  
) ON [PRIMARY]  
  
GO  
SET ANSI_PADDING OFF  
GO  
SET IDENTITY_INSERT [dbo].[Login] ON   
  
INSERT [dbo].[Login] ([id], [username], [password]) VALUES (1, N'admin', N'adminpass')  
SET IDENTITY_INSERT [dbo].[Login] OFF  
/****** Object:  StoredProcedure [dbo].[LoginByUsernamePassword]    Script Date: 5/10/2018 2:37:02 PM ******/  
SET ANSI_NULLS ON  
GO  
SET QUOTED_IDENTIFIER ON  
GO  
-- =============================================  
-- Author:      <Author,,Asma Khalid>  
-- Create date: <Create Date,,15-Mar-2016>  
-- Description: <Description,,You are Allow to Distribute this Code>  
-- =============================================  
CREATE PROCEDURE [dbo].[LoginByUsernamePassword]   
    @username varchar(50),  
    @password varchar(50)  
AS  
BEGIN  
    SELECT id, username, password  
    FROM Login  
    WHERE username = @username  
    AND password = @password  
END  
  
GO  