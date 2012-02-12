IF NOT EXISTS (SELECT [Name] FROM [dashCommerce_Content_Provider] WHERE [Name] =N'Contact Us')
INSERT [dbo].[dashCommerce_Content_Provider] ([Name], [ViewControl], [EditControl], [StyleSheet], [CreatedBy], [ModifiedBy]) VALUES (N'Contact Us', N'~/controls/content/ContactUs.ascx', '~/admin/controls/content/EditContactUs.ascx', NULL, N'SYSTEM', N'SYSTEM')
GO
