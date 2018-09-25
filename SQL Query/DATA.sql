USE [master]
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([PID], [Name], [Description], [Supplier], [Price]) VALUES (1, N'Iphone X', N'Supplier', N'1', 30000000)
INSERT [dbo].[Product] ([PID], [Name], [Description], [Supplier], [Price]) VALUES (2, N'Samsung Note 9', N'Samsung Note 9', N'2', 25000000)
INSERT [dbo].[Product] ([PID], [Name], [Description], [Supplier], [Price]) VALUES (3, N'Xiaomi Mi 6', N'Xiaomi Mi 6', N'3', 10000000)
INSERT [dbo].[Product] ([PID], [Name], [Description], [Supplier], [Price]) VALUES (4, N'Nokia 8800', N'Nokia 8800', N'4', 50000000)
SET IDENTITY_INSERT [dbo].[Product] OFF
SET IDENTITY_INSERT [dbo].[Supplier] ON 

INSERT [dbo].[Supplier] ([SID], [Name]) VALUES (1, N'Iphone')
INSERT [dbo].[Supplier] ([SID], [Name]) VALUES (2, N'Samsung')
INSERT [dbo].[Supplier] ([SID], [Name]) VALUES (3, N'Xiaomi')
INSERT [dbo].[Supplier] ([SID], [Name]) VALUES (4, N'Nokia')
SET IDENTITY_INSERT [dbo].[Supplier] OFF
