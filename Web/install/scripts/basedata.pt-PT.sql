/****** Object:  Table [dbo].[dashCommerce_Store_Notification]    Script Date: 02/11/2008 09:46:50 ******/
DELETE FROM [dbo].[dashCommerce_Store_Notification]
GO
/****** Object:  Table [dbo].[dashCommerce_Store_Currency]    Script Date: 02/11/2008 09:46:50 ******/
DELETE FROM [dbo].[dashCommerce_Store_Currency]
GO
/****** Object:  Table [dbo].[dashCommerce_Store_OrderStatusDescriptor]    Script Date: 02/11/2008 09:46:50 ******/
DELETE FROM [dbo].[dashCommerce_Store_OrderStatusDescriptor]
GO
/****** Object:  Table [dbo].[dashCommerce_Store_TransactionTypeDescriptor]    Script Date: 02/11/2008 09:46:50 ******/
DELETE FROM [dbo].[dashCommerce_Store_TransactionTypeDescriptor]
GO
/****** Object:  Table [dbo].[dashCommerce_Store_Provider]    Script Date: 02/11/2008 09:46:50 ******/
DELETE FROM [dbo].[dashCommerce_Store_Provider]
GO
/****** Object:  Table [dbo].[dashCommerce_Core_Country]    Script Date: 02/11/2008 09:46:50 ******/
DELETE FROM [dbo].[dashCommerce_Core_Country]
GO
/****** Object:  Table [dbo].[dashCommerce_Core_StateOrRegion]    Script Date: 02/11/2008 09:46:50 ******/
DELETE FROM [dbo].[dashCommerce_Core_StateOrRegion]
GO
/****** Object:  Table [dbo].[dashCommerce_Store_ProductStatusDescriptor]    Script Date: 02/11/2008 09:46:50 ******/
DELETE FROM [dbo].[dashCommerce_Store_ProductStatusDescriptor]
GO
/****** Object:  Table [dbo].[dashCommerce_Store_AttributeType]    Script Date: 02/11/2008 09:46:50 ******/
DELETE FROM [dbo].[dashCommerce_Store_AttributeType]
GO
/****** Object:  Table [dbo].[dashCommerce_Store_ProductType]    Script Date: 02/11/2008 09:46:50 ******/
DELETE FROM [dbo].[dashCommerce_Store_ProductType]
GO
/****** Object:  Table [dbo].[dashCommerce_Store_ShippingEstimate]    Script Date: 02/11/2008 09:46:50 ******/
DELETE FROM [dbo].[dashCommerce_Store_ShippingEstimate]
GO
/****** Object:  Table [dbo].[dashCommerce_Core_ConfigurationData]    Script Date: 02/11/2008 12:14:16 ******/
DELETE FROM [dbo].[dashCommerce_Core_ConfigurationData]
GO
/****** Object:  Table [dbo].[dashCommerce_Content_Template_TemplateRegion_Map]    Script Date: 03/19/2008 15:11:49 ******/
DELETE FROM [dbo].[dashCommerce_Content_Template_TemplateRegion_Map]
GO
/****** Object:  Table [dbo].[dashCommerce_Content_Page_Region_Map]    Script Date: 03/19/2008 15:11:49 ******/
DELETE FROM [dbo].[dashCommerce_Content_Page_Region_Map]
GO
/****** Object:  Table [dbo].[dashCommerce_Content_Region]    Script Date: 03/19/2008 15:11:49 ******/
DELETE FROM [dbo].[dashCommerce_Content_Region]
GO
/****** Object:  Table [dbo].[dashCommerce_Content_Provider]    Script Date: 03/19/2008 15:11:49 ******/
DELETE FROM [dbo].[dashCommerce_Content_Provider]
GO
/****** Object:  Table [dbo].[dashCommerce_Content_SimpleHtml]    Script Date: 03/19/2008 15:11:49 ******/
DELETE FROM [dbo].[dashCommerce_Content_SimpleHtml]
GO
/****** Object:  Table [dbo].[dashCommerce_Content_Page]    Script Date: 03/19/2008 15:11:49 ******/
DELETE FROM [dbo].[dashCommerce_Content_Page]
GO
/****** Object:  Table [dbo].[dashCommerce_Content_TemplateRegion]    Script Date: 03/19/2008 15:11:49 ******/
DELETE FROM [dbo].[dashCommerce_Content_TemplateRegion]
GO
/****** Object:  Table [dbo].[dashCommerce_Content_Template]    Script Date: 03/19/2008 15:11:49 ******/
DELETE FROM [dbo].[dashCommerce_Content_Template]
GO

/****** Object:  Table [dbo].[dashCommerce_Store_ShippingEstimate]    Script Date: 02/11/2008 09:46:50 ******/
SET IDENTITY_INSERT [dbo].[dashCommerce_Store_ShippingEstimate] ON
INSERT [dbo].[dashCommerce_Store_ShippingEstimate] ([ShippingEstimateId], [Name], [CreatedBy], [ModifiedBy]) VALUES (1, N'1-2 Dias', N'SYSTEM', N'SYSTEM')
INSERT [dbo].[dashCommerce_Store_ShippingEstimate] ([ShippingEstimateId], [Name], [CreatedBy], [ModifiedBy]) VALUES (2, N'3-5 Dias', N'SYSTEM', N'SYSTEM')
INSERT [dbo].[dashCommerce_Store_ShippingEstimate] ([ShippingEstimateId], [Name], [CreatedBy], [ModifiedBy]) VALUES (3, N'1-2 Semanas', N'SYSTEM', N'SYSTEM')
SET IDENTITY_INSERT [dbo].[dashCommerce_Store_ShippingEstimate] OFF
GO

/****** Object:  Table [dbo].[dashCommerce_Store_ProductType]    Script Date: 02/11/2008 09:46:50 ******/
SET IDENTITY_INSERT [dbo].[dashCommerce_Store_ProductType] ON
INSERT [dbo].[dashCommerce_Store_ProductType] ([ProductTypeId], [Name], [CreatedBy], [ModifiedBy]) VALUES (1, N'Bens de Consumo (Tangiveis)', N'SYSTEM', N'SYSTEM')
INSERT [dbo].[dashCommerce_Store_ProductType] ([ProductTypeId], [Name], [CreatedBy], [ModifiedBy]) VALUES (2, N'Servio', N'SYSTEM', N'SYSTEM')
SET IDENTITY_INSERT [dbo].[dashCommerce_Store_ProductType] OFF
GO

/****** Object:  Table [dbo].[dashCommerce_Store_AttributeType]    Script Date: 02/11/2008 09:46:50 ******/
SET IDENTITY_INSERT [dbo].[dashCommerce_Store_AttributeType] ON
INSERT [dbo].[dashCommerce_Store_AttributeType] ([AttributeTypeId], [Name], [CreatedBy], [ModifiedBy]) VALUES (1, N'Seleco Simples', N'SYSTEM', N'SYSTEM')
INSERT [dbo].[dashCommerce_Store_AttributeType] ([AttributeTypeId], [Name], [CreatedBy], [ModifiedBy]) VALUES (2, N'Singleline Input', N'SYSTEM', N'SYSTEM')
INSERT [dbo].[dashCommerce_Store_AttributeType] ([AttributeTypeId], [Name], [CreatedBy], [ModifiedBy]) VALUES (3, N'Introduo Utilizador', N'SYSTEM', N'SYSTEM')
SET IDENTITY_INSERT [dbo].[dashCommerce_Store_AttributeType] OFF
GO

/****** Object:  Table [dbo].[dashCommerce_Store_ProductStatusDescriptor]    Script Date: 02/11/2008 09:46:50 ******/
SET IDENTITY_INSERT [dbo].[dashCommerce_Store_ProductStatusDescriptor] ON
INSERT [dbo].[dashCommerce_Store_ProductStatusDescriptor] ([ProductStatusDescriptorId], [Name], [CreatedBy], [ModifiedBy]) VALUES (1, N'Activo', N'SYSTEM', N'SYSTEM')
INSERT [dbo].[dashCommerce_Store_ProductStatusDescriptor] ([ProductStatusDescriptorId], [Name], [CreatedBy], [ModifiedBy]) VALUES (99, N'Inactivo (No mostrar)', N'SYSTEM', N'SYSTEM')
SET IDENTITY_INSERT [dbo].[dashCommerce_Store_ProductStatusDescriptor] OFF
GO

/****** Object:  Table [dbo].[dashCommerce_Store_Provider]    Script Date: 02/11/2008 09:46:50 ******/
SET IDENTITY_INSERT [dbo].[dashCommerce_Store_Provider] ON
INSERT [dbo].[dashCommerce_Store_Provider] ([ProviderId], [ProviderTypeId], [Name], [Description], [ConfigurationControlPath], [CreatedBy], [ModifiedBy]) VALUES (1, 1, N'PayPalProPaymentProvider', N'&lt;div&gt;&lt;a target=&quot;_blank&quot; href=&quot;http://www.mettlesystems.com&quot;&gt;&lt;font size=&quot;2&quot;&gt;Mettle Systems LLC&lt;/font&gt;&lt;/a&gt;&lt;font size=&quot;2&quot;&gt;, the creators of dashCommerce, have partnered with PayPal to give you a complete e-commerce and all-in-one payment solution using PayPal Website Payments Pro with Express Checkout.&lt;/font&gt;&lt;/div&gt;
&lt;ul&gt;
    &lt;li&gt;&lt;font size=&quot;2&quot;&gt;Accept credit card payments without requiring the buyer to have a PayPal account. &lt;/font&gt;&lt;/li&gt;
    &lt;li&gt;&lt;font size=&quot;2&quot;&gt;Get PayPal''s industry-leading security fraud-prevention systems. &lt;/font&gt;&lt;/li&gt;
    &lt;li&gt;&lt;font size=&quot;2&quot;&gt;Take advantage of PayPal''s comprehensive online reports that help you measure sales and manage your business easily. &lt;/font&gt;&lt;/li&gt;
&lt;/ul&gt;
&lt;p&gt;&lt;strong&gt;&lt;font size=&quot;2&quot;&gt;Step 1: Set Up a Verified PayPal Business Account&lt;/font&gt;&lt;/strong&gt;&lt;/p&gt;
&lt;p&gt;&lt;font size=&quot;2&quot;&gt;If you don''t have an existing PayPal account:&lt;/font&gt;&lt;/p&gt;
&lt;ol&gt;
    &lt;li&gt;&lt;a target=&quot;_blank&quot; href=&quot;https://www.paypal.com/us/mrb/pal=NAG62FTSWGJ5W&quot;&gt;&lt;span class=&quot;payPalLink&quot;&gt;&lt;font size=&quot;2&quot;&gt;Go to Paypal&lt;/font&gt;&lt;/span&gt;&lt;/a&gt;&lt;font size=&quot;2&quot;&gt; &lt;/font&gt;&lt;/li&gt;
    &lt;li&gt;&lt;font size=&quot;2&quot;&gt;Click Sign Up Today. &lt;/font&gt;&lt;/li&gt;
    &lt;li&gt;&lt;font size=&quot;2&quot;&gt;Set up an account for Business Owners. &lt;/font&gt;&lt;/li&gt;
    &lt;li&gt;&lt;font size=&quot;2&quot;&gt;Follow the instructions on the PayPal site. &lt;/font&gt;&lt;/li&gt;
&lt;/ol&gt;
&lt;p&gt;&lt;font size=&quot;2&quot;&gt;If you already have a Personal or Premier account:&lt;/font&gt;&lt;/p&gt;
&lt;ol&gt;
    &lt;li&gt;&lt;a target=&quot;_blank&quot; href=&quot;https://www.paypal.com/us/mrb/pal=NAG62FTSWGJ5W&quot;&gt;&lt;span class=&quot;payPalLink&quot;&gt;&lt;font size=&quot;2&quot;&gt;Go to Paypal&lt;/font&gt;&lt;/span&gt;&lt;/a&gt;&lt;font size=&quot;2&quot;&gt; &lt;/font&gt;&lt;/li&gt;
    &lt;li&gt;&lt;font size=&quot;2&quot;&gt;Click the Upgrade your Account link. &lt;/font&gt;&lt;/li&gt;
    &lt;li&gt;&lt;font size=&quot;2&quot;&gt;Click the Upgrade Now button. &lt;/font&gt;&lt;/li&gt;
    &lt;li&gt;&lt;font size=&quot;2&quot;&gt;Choose to upgrade to a Business account and follow instructions to complete the upgrade. &lt;/font&gt;&lt;/li&gt;
    &lt;li&gt;&lt;font size=&quot;2&quot;&gt;If you haven''t already, add a bank account to become a Verified member. Follow the instructions on the PayPal site. (This process may take 2-3 business days.) &lt;/font&gt;&lt;/li&gt;
&lt;/ol&gt;
&lt;p&gt;&lt;strong&gt;&lt;font size=&quot;2&quot;&gt;Step 2: Apply for Website Payments Pro&lt;/font&gt;&lt;/strong&gt;&lt;/p&gt;
&lt;p&gt;&lt;font size=&quot;2&quot;&gt;Get the features of an internet merchant account and payment gateway with Website Payments Pro. Control your checkout from start to finish by integrating PayPal Website Payments Pro with dashCommerce.&lt;/font&gt;&lt;/p&gt;
&lt;ol&gt;
    &lt;li&gt;&lt;a target=&quot;_blank&quot; href=&quot;https://www.paypal.com/us/mrb/pal=NAG62FTSWGJ5W&quot;&gt;&lt;span class=&quot;payPalLink&quot;&gt;&lt;font size=&quot;2&quot;&gt;Go to Paypal&lt;/font&gt;&lt;/span&gt;&lt;/a&gt;&lt;font size=&quot;2&quot;&gt; &lt;/font&gt;&lt;/li&gt;
    &lt;li&gt;&lt;font size=&quot;2&quot;&gt;Login to your PayPal Business Account &lt;/font&gt;&lt;/li&gt;
    &lt;li&gt;&lt;font size=&quot;2&quot;&gt;Click the Merchant Services tab. &lt;/font&gt;&lt;/li&gt;
    &lt;li&gt;&lt;font size=&quot;2&quot;&gt;Click Website Payments Pro (U.S. Only). &lt;/font&gt;&lt;/li&gt;
    &lt;li&gt;&lt;font size=&quot;2&quot;&gt;Click Sign Up Now. &lt;/font&gt;&lt;/li&gt;
    &lt;li&gt;&lt;font size=&quot;2&quot;&gt;Fill in your information, and submit your application. Approval takes between 24 and 48 hours. &lt;/font&gt;&lt;/li&gt;
    &lt;li&gt;&lt;font size=&quot;2&quot;&gt;Once approved, accept the Pro billing agreement. Check the Getting Started section on the upper left of your account overview page. &lt;/font&gt;&lt;/li&gt;
&lt;/ol&gt;
&lt;p&gt;&lt;strong&gt;&lt;font size=&quot;2&quot;&gt;Step 3: Get your API Account Name, API Account Password, and the API Signature.&lt;/font&gt;&lt;/strong&gt;&lt;/p&gt;
&lt;p&gt;&lt;strong&gt;&lt;font size=&quot;2&quot;&gt;Step 4: Configure the Payment System.&lt;/font&gt;&lt;/strong&gt;&lt;/p&gt;', N'~/admin/controls/configuration/paymentproviders/paypalproconfiguration.ascx', N'SYSTEM', N'SYSTEM')
INSERT [dbo].[dashCommerce_Store_Provider] ([ProviderId], [ProviderTypeId], [Name], [Description], [ConfigurationControlPath], [CreatedBy], [ModifiedBy]) VALUES (2, 1, N'PayPalStandardPaymentProvider', N'&lt;strong&gt;PayPal Website Payments Standard. &lt;br /&gt;
&lt;/strong&gt;Now there''s a fast, affordable way to start accepting credit cards and PayPal payments online. Buyers pay by entering their credit card information on secure PayPal pages and promptly return to your site. Your buyers &lt;i&gt;do not&lt;/i&gt; need a PayPal account. Start selling immediately &amp;mdash; you don''t need to go through a lengthy approval process or pay any setup or monthly fees.&lt;br /&gt;
&lt;ul&gt;
    &lt;li&gt;&amp;nbsp;&lt;b&gt;Easy to manage&lt;/b&gt;
    &lt;ul&gt;
        &lt;li&gt;Automatic order confirmation email messages to both you and your customers.&lt;/li&gt;
        &lt;li&gt;Simple sales activity and accounting reports that you can export to QuickBooks or Microsoft Excel.&lt;/li&gt;
        &lt;li&gt;Sell internationally with automatic currency conversion.&lt;/li&gt;
    &lt;/ul&gt;
    &lt;/li&gt;
    &lt;li&gt;&lt;b&gt;Fraud protection&lt;/b&gt;
    &lt;ul&gt;
        &lt;li&gt;Includes some of the industry&amp;rsquo;s best automatic fraud screening technology.&lt;/li&gt;
        &lt;li&gt;Eligible transactions are covered against unauthorized payments, charge-backs, andreversals through PayPal&amp;rsquo;s Seller Protection Policy.&lt;/li&gt;
        &lt;li&gt;You don&amp;rsquo;t need to store or transmit sensitive payment data, because your customers pay on secure pages hosted by PayPal.&lt;/li&gt;
    &lt;/ul&gt;
    &lt;/li&gt;
    &lt;li&gt;&lt;b&gt;Affordable pricing&lt;/b&gt;
    &lt;ul&gt;
        &lt;li&gt;You don''t pay a thing until you get paid &amp;mdash; no setup fees, monthly fees, or cancellation fees.&lt;/li&gt;
        &lt;li&gt;Low per-transaction fees typically range from 1.9% to 2.9% plus $.30, depending on how&amp;nbsp;much money you take-in each month. The higher your volume, the lower your rate.&lt;/li&gt;
    &lt;/ul&gt;
    &lt;/li&gt;
&lt;/ul&gt;
&lt;b&gt;&lt;a target=&quot;_blank&quot; href=&quot;https://www.paypal-marketing.com/html/partner/portal/standard.html&quot;&gt;See a demo of PayPal Website Payments Standard&lt;/a&gt;&lt;br /&gt;
&lt;br /&gt;
PayPal Website Payments Standard&amp;nbsp;&lt;/b&gt;is the low-cost alternative. Your shopper is sent to PayPal where they complete the transaction; PayPal then sends your website (in this case, dashCommerce) information back about the transaction. dashCommerce logs this info when the buyer returns from PayPal and records the transaction.&lt;br /&gt;
&lt;br /&gt;
Standard is the easiest to setup, but is the most vulnerable to failure since the sale is not purely transactional. In other words, money changes hands at another site, and your site is told about it after the fact. This can cause issues with inventory if the sale is not immediate, as well as if your site goes down.&lt;br /&gt;
&lt;br /&gt;
&lt;strong&gt;To setup Payments Standard, you must:&lt;/strong&gt;&lt;br /&gt;
&lt;ol&gt;
    &lt;li&gt;&lt;a target=&quot;_blank&quot; href=&quot;http://www.paypal.com/&quot;&gt;Create a PayPal Account (it''s free)&lt;/a&gt;&lt;/li&gt;
    &lt;li&gt;Validate your email and Verify your account using a Bank Account or Credit Card&amp;nbsp;&lt;/li&gt;
    &lt;li&gt;&lt;a target=&quot;_blank&quot; href=&quot;https://www.paypal.com/cgi-bin/webscr?cmd=p/xcl/rec/pdt-techview-outside&quot;&gt;Setup your PDT&lt;/a&gt;&lt;/li&gt;
    &lt;li&gt;&lt;a target=&quot;_blank&quot; href=&quot;https://www.paypal.com/us/cgi-bin/webscr?cmd=p/xcl/rec/ipn-techview-outside&quot;&gt;Setup your IPN&lt;/a&gt;&lt;/li&gt;
    &lt;li&gt;Enter the configuration settings into dashCommerce.&lt;/li&gt;
&lt;/ol&gt;', N'~/admin/controls/configuration/paymentproviders/paypalstandardconfiguration.ascx', N'SYSTEM', N'SYSTEM')
INSERT [dbo].[dashCommerce_Store_Provider] ([ProviderId], [ProviderTypeId], [Name], [Description], [ConfigurationControlPath], [CreatedBy], [ModifiedBy]) VALUES (3, 3, N'SimpleWeightShippingProvider', N'&lt;p&gt;&lt;font size=&quot;2&quot;&gt;The SimpleWeightShippingProvider will multiply the weight of the item(s) by the AmountPerUnit for each Service specified.&lt;/font&gt;&lt;/p&gt;
&lt;p&gt;&lt;font size=&quot;2&quot;&gt;For example: If a television weights 50 pounds, and both Ground and Freight are specified services, then the resultant shipping options would look like:&lt;/font&gt;&lt;/p&gt;
&lt;p&gt;&lt;font size=&quot;2&quot;&gt;&amp;nbsp; &lt;/font&gt;
&lt;table cellspacing=&quot;1&quot; cellpadding=&quot;1&quot; width=&quot;300&quot; border=&quot;0&quot;&gt;
    &lt;tbody&gt;
        &lt;tr&gt;
            &lt;td&gt;&lt;strong&gt;&lt;font size=&quot;2&quot;&gt;Service&lt;/font&gt;&lt;/strong&gt;&lt;/td&gt;
            &lt;td&gt;&lt;strong&gt;&lt;font size=&quot;2&quot;&gt;AmountPerUnit&lt;/font&gt;&lt;/strong&gt;&lt;/td&gt;
            &lt;td&gt;&lt;strong&gt;&lt;font size=&quot;2&quot;&gt;Total Charge&lt;/font&gt;&lt;/strong&gt;&lt;/td&gt;
        &lt;/tr&gt;
        &lt;tr&gt;
            &lt;td&gt;&lt;font size=&quot;2&quot;&gt;Ground&lt;/font&gt;&lt;/td&gt;
            &lt;td&gt;&lt;font size=&quot;2&quot;&gt;$2.00&lt;/font&gt;&lt;/td&gt;
            &lt;td&gt;&lt;font size=&quot;2&quot;&gt;$100.00&lt;/font&gt;&lt;/td&gt;
        &lt;/tr&gt;
        &lt;tr&gt;
            &lt;td&gt;&lt;font size=&quot;2&quot;&gt;Freight&lt;/font&gt;&lt;/td&gt;
            &lt;td&gt;&lt;font size=&quot;2&quot;&gt;$1.00&lt;/font&gt;&lt;/td&gt;
            &lt;td&gt;&lt;font size=&quot;2&quot;&gt;$&amp;nbsp; 50.00&lt;/font&gt;&lt;/td&gt;
        &lt;/tr&gt;
    &lt;/tbody&gt;
&lt;/table&gt;
&lt;/p&gt;', N'~/admin/controls/configuration/shippingproviders/simpleweightconfiguration.ascx', N'SYSTEM', N'SYSTEM')
INSERT [dbo].[dashCommerce_Store_Provider] ([ProviderId], [ProviderTypeId], [Name], [Description], [ConfigurationControlPath], [CreatedBy], [ModifiedBy]) VALUES (4, 2, N'RegionCodeTaxProvider', N'&lt;div&gt;The RegionCodeTaxProvider will allow you to apply taxes to an order based on the a region code. By default, the RegionCodeTaxProvider will calculate the tax based on the PostalCode of the order.&lt;/div&gt;', N'~/admin/controls/configuration/taxproviders/regioncodeconfiguration.ascx', N'SYSTEM', N'SYSTEM')
INSERT [dbo].[dashCommerce_Store_Provider] ([ProviderId], [ProviderTypeId], [Name], [Description], [ConfigurationControlPath], [CreatedBy], [ModifiedBy]) VALUES (5, 4, N'PercentOffCouponProvider', N'&lt;p&gt;The PercentOffCouponProvider will apply a percentage discount to the order.&lt;/p&gt;', N'~/admin/controls/configuration/couponproviders/percentoffconfiguration.ascx', N'SYSTEM', N'SYSTEM')
SET IDENTITY_INSERT [dbo].[dashCommerce_Store_Provider] OFF
GO

/****** Object:  Table [dbo].[dashCommerce_Store_TransactionTypeDescriptor]    Script Date: 02/11/2008 09:46:50 ******/
SET IDENTITY_INSERT [dbo].[dashCommerce_Store_TransactionTypeDescriptor] ON
INSERT [dbo].[dashCommerce_Store_TransactionTypeDescriptor] ([TransactionTypeDescriptorId], [Name], [CreatedBy], [ModifiedBy]) VALUES (1, N'Autorizada', N'SYSTEM', N'SYSTEM')
INSERT [dbo].[dashCommerce_Store_TransactionTypeDescriptor] ([TransactionTypeDescriptorId], [Name], [CreatedBy], [ModifiedBy]) VALUES (2, N'Processada', N'SYSTEM', N'SYSTEM')
INSERT [dbo].[dashCommerce_Store_TransactionTypeDescriptor] ([TransactionTypeDescriptorId], [Name], [CreatedBy], [ModifiedBy]) VALUES (3, N'Reembolsada', N'SYSTEM', N'SYSTEM')
SET IDENTITY_INSERT [dbo].[dashCommerce_Store_TransactionTypeDescriptor] OFF
GO

/****** Object:  Table [dbo].[dashCommerce_Store_OrderStatusDescriptor]    Script Date: 02/11/2008 09:46:50 ******/
INSERT [dbo].[dashCommerce_Store_OrderStatusDescriptor] ([OrderStatusDescriptorId], [Name], [CreatedBy], [ModifiedBy]) VALUES (100, N'Pagamento Recebido, Encomenda em processamento', N'SYSTEM', N'SYSTEM')
INSERT [dbo].[dashCommerce_Store_OrderStatusDescriptor] ([OrderStatusDescriptorId], [Name], [CreatedBy], [ModifiedBy]) VALUES (200, N'Retirar produtos de stock', N'SYSTEM', N'SYSTEM')
INSERT [dbo].[dashCommerce_Store_OrderStatusDescriptor] ([OrderStatusDescriptorId], [Name], [CreatedBy], [ModifiedBy]) VALUES (300, N'Encomenda - Envio Parcial', N'SYSTEM', N'SYSTEM')
INSERT [dbo].[dashCommerce_Store_OrderStatusDescriptor] ([OrderStatusDescriptorId], [Name], [CreatedBy], [ModifiedBy]) VALUES (400, N'Encomenda - Envio Completo', N'SYSTEM', N'SYSTEM')
INSERT [dbo].[dashCommerce_Store_OrderStatusDescriptor] ([OrderStatusDescriptorId], [Name], [CreatedBy], [ModifiedBy]) VALUES (500, N'Encomenda completamente reembolsada', N'SYSTEM', N'SYSTEM')
INSERT [dbo].[dashCommerce_Store_OrderStatusDescriptor] ([OrderStatusDescriptorId], [Name], [CreatedBy], [ModifiedBy]) VALUES (600, N'Encomenda parcialmente reembolsada', N'SYSTEM', N'SYSTEM')
INSERT [dbo].[dashCommerce_Store_OrderStatusDescriptor] ([OrderStatusDescriptorId], [Name], [CreatedBy], [ModifiedBy]) VALUES (9999, N'No Processada', N'SYSTEM', N'SYSTEM')
GO

/****** Object:  Table [dbo].[dashCommerce_Store_Notification]    Script Date: 02/11/2008 09:46:50 ******/
SET IDENTITY_INSERT [dbo].[dashCommerce_Store_Notification] ON
INSERT [dbo].[dashCommerce_Store_Notification] ([NotificationId], [Name], [ToList], [CcList], [FromName], [FromEmail], [Subject], [NotificationBody], [IsHTML], [IsSystemNotification], [CreatedBy], [ModifiedBy]) VALUES (1, N'Confirmao de Encomenda - Fornecedor', N'merchant_mail_account@yourstore.com', N'', N'dashCommerce Site', N'merchant_mail_account@yourstore.com', N'Confirmao de Encomenda', N'<TABLE style="BORDER-RIGHT: gainsboro 1px solid; BORDER-TOP: gainsboro 1px solid; BORDER-LEFT: gainsboro 1px solid; BORDER-BOTTOM: gainsboro 1px solid" width="75%" align=center><TBODY><TR><TD height=50><IMG src="http://dashcommerce.org/smalllogo.gif"> </TD></TR><TR><TD style="HEIGHT: 50px" vAlign=top><STRONG>The following order nas been received:<BR></SPAN><BR></STRONG></TD></TR><TR><TD bgColor=lightsteelblue><B>Order Information</B></TD></TR><TR><TD>#ORDER# </TD></TR><TR><TD>"<B>#TAGLINE#</B>"</TD></TR></TBODY></TABLE>', 1, 1, N'SYSTEM', N'SYSTEM')
INSERT [dbo].[dashCommerce_Store_Notification] ([NotificationId], [Name], [ToList], [CcList], [FromName], [FromEmail], [Subject], [NotificationBody], [IsHTML], [IsSystemNotification], [CreatedBy], [ModifiedBy]) VALUES (2, N'Confirmao de Encomenda - Cliente', N'', N'merchant_mail_account@yourstore.com', N'dashCommerce Site', N'merchant_mail_account@yourstore.com', N'A sua encomenda foi confirmada!', N'&lt;table style=&quot;border-right: gainsboro 1px solid; border-top: gainsboro 1px solid; border-left: gainsboro 1px solid; border-bottom: gainsboro 1px solid&quot; width=&quot;75%&quot; align=&quot;center&quot;&gt;
    &lt;tbody&gt;
        &lt;tr&gt;
            &lt;td height=&quot;50&quot;&gt;&lt;img alt=&quot;&quot; src=&quot;http://dashcommerce.org/smalllogo.gif&quot; /&gt;&lt;/td&gt;
        &lt;/tr&gt;
        &lt;tr&gt;
            &lt;td style=&quot;height: 50px&quot; valign=&quot;top&quot;&gt;&lt;strong&gt;Thank you for your recent order #NAME#!&lt;br /&gt;
            &lt;/strong&gt;&lt;br /&gt;
            &lt;span style=&quot;font-size: 10pt&quot;&gt;If you want to know more about your order, you can visit us online at #SITELINK# and click on &amp;quot;My Orders&amp;quot; in the top area of the page.&lt;br /&gt;
            &lt;/span&gt;&lt;/td&gt;
        &lt;/tr&gt;
        &lt;tr&gt;
            &lt;td bgcolor=&quot;#b0c4de&quot;&gt;&lt;strong&gt;Order Information&lt;/strong&gt;&lt;/td&gt;
        &lt;/tr&gt;
        &lt;tr&gt;
            &lt;td&gt;#ORDER#&lt;/td&gt;
        &lt;/tr&gt;
        &lt;tr&gt;
            &lt;td&gt;Please note: If you have any questions, please email us at #STOREEMAIL#. &lt;br /&gt;
            &lt;br /&gt;
            Thanks again for shopping with us!&lt;/td&gt;
        &lt;/tr&gt;
        &lt;tr&gt;
            &lt;td&gt;&amp;quot;&lt;strong&gt;#TAGLINE#&lt;/strong&gt;&amp;quot;&lt;/td&gt;
        &lt;/tr&gt;
    &lt;/tbody&gt;
&lt;/table&gt;', 1, 1, N'SYSTEM', N'SYSTEM')
INSERT [dbo].[dashCommerce_Store_Notification] ([NotificationId], [Name], [ToList], [CcList], [FromName], [FromEmail], [Subject], [NotificationBody], [IsHTML], [IsSystemNotification], [CreatedBy], [ModifiedBy]) VALUES (3, N'Notificao de Envio - Cliente', N'', N'', N'dashCommerce Envio', N'merchant_mail_account@yourstore.com', N'A sua encomenda foi enviada!', N'<TABLE style="BORDER-RIGHT: gainsboro 1px solid; BORDER-TOP: gainsboro 1px solid; BORDER-LEFT: gainsboro 1px solid; BORDER-BOTTOM: gainsboro 1px solid" width="75%" align=center><TBODY><TR><TD height=50><IMG src="http://dashcommerce.org/smalllogo.gif"> </TD></TR><TR><TD style="HEIGHT: 50px" vAlign=top><STRONG>Thank you for your recent order #NAME#!<BR></STRONG><BR><SPAN style="FONT-SIZE: 10pt">Your order #ORDERNUMBER# was shipped on #DATE#.<BR><BR>You can use the following tracking number to track your shipment: #TRACKINGNUMBER#<BR <br>If you want to know more about your order, you can visit us online at #SITELINK# and click on "My Orders" in the top area of the page.<BR></SPAN><BR></TD></TR><TR><TD bgColor=lightsteelblue><B>Order Information</B></TD></TR><TR><TD>#ORDER# </TD></TR><TR><TD>Please note: If you have any questions, please email us at #STOREEMAIL#. <BR><BR>Thanks again for shopping with us! </TD></TR><TR><TD>"<B>#TAGLINE#</B>"</TD></TR></TBODY></TABLE>', 1, 1, N'SYSTEM', N'SYSTEM')
INSERT [dbo].[dashCommerce_Store_Notification] ([NotificationId], [Name], [ToList], [CcList], [FromName], [FromEmail], [Subject], [NotificationBody], [IsHTML], [IsSystemNotification], [CreatedBy], [ModifiedBy]) VALUES (4, N'Encomenda Cancelada - Cliente', N'', N'', N'dashCommerce Site', N'merchant_mail_account@yourstore.com', N'Encomenda cancelada', N'<TABLE style="BORDER-RIGHT: gainsboro 1px solid; BORDER-TOP: gainsboro 1px solid; BORDER-LEFT: gainsboro 1px solid; BORDER-BOTTOM: gainsboro 1px solid" width="75%" align=center><TBODY><TR><TD height=50><IMG src="http://dashcommerce.org/smalllogo.gif"> </TD></TR><TR><TD style="HEIGHT: 50px" vAlign=top><STRONG>The following order has been cancelled. Please shop with us again!<BR></SPAN><BR></STRONG></TD></TR><TR><TD bgColor=lightsteelblue><B>Order Information</B></TD></TR><TR><TD>#ORDER# </TD></TR><TR><TD>Please note: If you have any questions, please email us at #STOREEMAIL#. <BR><BR>Thanks again for shopping with us! </TD></TR><TR><TD>"<B>#TAGLINE#</B>"</TD></TR></TBODY></TABLE>', 1, 1, N'SYSTEM', N'SYSTEM')
INSERT [dbo].[dashCommerce_Store_Notification] ([NotificationId], [Name], [ToList], [CcList], [FromName], [FromEmail], [Subject], [NotificationBody], [IsHTML], [IsSystemNotification], [CreatedBy], [ModifiedBy]) VALUES (5, N'Encomenda Reembolsada - Cliente', N'', N'', N'dashCommerce Site', N'merchant_mail_account@yourstore.com', N'Encomenda reembolsada', N'<TABLE style="BORDER-RIGHT: gainsboro 1px solid; BORDER-TOP: gainsboro 1px solid; BORDER-LEFT: gainsboro 1px solid; BORDER-BOTTOM: gainsboro 1px solid" width="75%" align=center><TBODY><TR><TD height=50><IMG src="http://dashcommerce.org/smalllogo.gif"> </TD></TR><TR><TD style="HEIGHT: 50px" vAlign=top><STRONG>The following order has been refunded. Please shop with us again!<BR></SPAN><BR></STRONG></TD></TR><TR><TD bgColor=lightsteelblue><B>Order Information</B></TD></TR><TR><TD>#ORDER# </TD></TR><TR><TD>Please note: If you have any questions, please email us at #STOREEMAIL#. <BR><BR>Thanks again for shopping with us! </TD></TR><TR><TD>"<B>#TAGLINE#</B>"</TD></TR></TBODY></TABLE>', 1, 1, N'SYSTEM', N'SYSTEM')
SET IDENTITY_INSERT [dbo].[dashCommerce_Store_Notification] OFF
GO

/****** Object:  Table [dbo].[dashCommerce_Core_ConfigurationData]    Script Date: 02/11/2008 12:14:16 ******/
SET IDENTITY_INSERT [dbo].[dashCommerce_Core_ConfigurationData] ON
INSERT [dbo].[dashCommerce_Core_ConfigurationData] ([ConfigurationDataId], [Name], [Type], [Value], [CreatedBy], [ModifiedBy], [IsDeleted]) VALUES (1, N'siteSettings', N'MettleSystems.dashCommerce.Store.SiteSettings, MettleSystems.dashCommerce.Core, Version=1.0.0.21792, Culture=neutral, PublicKeyToken=null', N'<?xml version="1.0"?>
<SiteSettings xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <SiteLogo />
  <SiteName />
  <TagLine />
  <LoginRequirement>Checkout</LoginRequirement>
  <NewsFeedUrl />
  <RequireSsl>true</RequireSsl>
  <CollectBrowsingCategory>true</CollectBrowsingCategory>
  <CollectBrowsingProduct>true</CollectBrowsingProduct>
  <CollectSearchTerms>true</CollectSearchTerms>
  <CatalogItems>6</CatalogItems>
  <DisplayRetailPrice>true</DisplayRetailPrice>
  <DisplayNarrowByManufacturer>true</DisplayNarrowByManufacturer>
  <DisplayNarrowByPrice>true</DisplayNarrowByPrice>
  <Language>en-US</Language>
  <CurrencyCode>USD</CurrencyCode>
  <Theme>dashCommerce</Theme>
</SiteSettings>', N'SYSTEM', N'SYSTEM', 0)
SET IDENTITY_INSERT [dbo].[dashCommerce_Core_ConfigurationData] OFF
GO

/****** Object:  Table [dbo].[dashCommerce_Content_Template]    Script Date: 03/19/2008 15:11:49 ******/
SET IDENTITY_INSERT [dbo].[dashCommerce_Content_Template] ON
INSERT [dbo].[dashCommerce_Content_Template] ([TemplateId], [Name], [Description], [StyleSheet], [CreatedBy], [ModifiedBy]) VALUES (1, N'3 Column Template', N'3 Column Template', N'~/controls/content/styles/3col.css', N'SYSTEM', N'SYSTEM')
INSERT [dbo].[dashCommerce_Content_Template] ([TemplateId], [Name], [Description], [StyleSheet], [CreatedBy], [ModifiedBy]) VALUES (2, N'2 Column Template (Main Right)', N'2 Column Template', N'~/controls/content/styles/2colmainright.css', N'SYSTEM', N'SYSTEM')
INSERT [dbo].[dashCommerce_Content_Template] ([TemplateId], [Name], [Description], [StyleSheet], [CreatedBy], [ModifiedBy]) VALUES (3, N'2 Column Template (Main Left)', N'2 Column Template', N'~/controls/content/styles/2colmainleft.css', N'SYSTEM', N'SYSTEM')
SET IDENTITY_INSERT [dbo].[dashCommerce_Content_Template] OFF
GO

/****** Object:  Table [dbo].[dashCommerce_Content_TemplateRegion]    Script Date: 03/19/2008 15:11:49 ******/
SET IDENTITY_INSERT [dbo].[dashCommerce_Content_TemplateRegion] ON
INSERT [dbo].[dashCommerce_Content_TemplateRegion] ([TemplateRegionId], [Name], [Description], [CreatedBy], [ModifiedBy]) VALUES (1, N'Left Content', N'Left Content', N'SYSTEM', N'SYSTEM')
INSERT [dbo].[dashCommerce_Content_TemplateRegion] ([TemplateRegionId], [Name], [Description], [CreatedBy], [ModifiedBy]) VALUES (2, N'Right Content', N'Right Content', N'SYSTEM', N'SYSTEM')
INSERT [dbo].[dashCommerce_Content_TemplateRegion] ([TemplateRegionId], [Name], [Description], [CreatedBy], [ModifiedBy]) VALUES (3, N'Main Content', N'Main Content', N'SYSTEM', N'SYSTEM')
SET IDENTITY_INSERT [dbo].[dashCommerce_Content_TemplateRegion] OFF
GO

/****** Object:  Table [dbo].[dashCommerce_Content_Provider]    Script Date: 03/19/2008 15:11:49 ******/
SET IDENTITY_INSERT [dbo].[dashCommerce_Content_Provider] ON
INSERT [dbo].[dashCommerce_Content_Provider] ([ProviderId], [Name], [ViewControl], [EditControl], [StyleSheet], [CreatedBy], [ModifiedBy]) VALUES (1, N'Simple Html', N'~/controls/content/html/viewhtml.ascx', N'~/admin/controls/content/html/edithtml.ascx', NULL, N'SYSTEM', N'SYSTEM')
SET IDENTITY_INSERT [dbo].[dashCommerce_Content_Provider] OFF
GO

/****** Object:  Table [dbo].[dashCommerce_Content_Template_TemplateRegion_Map]    Script Date: 03/19/2008 15:11:49 ******/
INSERT [dbo].[dashCommerce_Content_Template_TemplateRegion_Map] ([TemplateId], [TemplateRegionId]) VALUES (1, 1)
INSERT [dbo].[dashCommerce_Content_Template_TemplateRegion_Map] ([TemplateId], [TemplateRegionId]) VALUES (1, 2)
INSERT [dbo].[dashCommerce_Content_Template_TemplateRegion_Map] ([TemplateId], [TemplateRegionId]) VALUES (1, 3)
--INSERT [dbo].[dashCommerce_Content_Template_TemplateRegion_Map] ([TemplateId], [TemplateRegionId]) VALUES (2, 1)
--INSERT [dbo].[dashCommerce_Content_Template_TemplateRegion_Map] ([TemplateId], [TemplateRegionId]) VALUES (2, 3)
--INSERT [dbo].[dashCommerce_Content_Template_TemplateRegion_Map] ([TemplateId], [TemplateRegionId]) VALUES (3, 2)
--INSERT [dbo].[dashCommerce_Content_Template_TemplateRegion_Map] ([TemplateId], [TemplateRegionId]) VALUES (3, 3)
INSERT [dbo].[dashCommerce_Content_Template_TemplateRegion_Map] ([TemplateId], [TemplateRegionId]) VALUES (2, 2)
INSERT [dbo].[dashCommerce_Content_Template_TemplateRegion_Map] ([TemplateId], [TemplateRegionId]) VALUES (2, 3)
INSERT [dbo].[dashCommerce_Content_Template_TemplateRegion_Map] ([TemplateId], [TemplateRegionId]) VALUES (3, 1)
INSERT [dbo].[dashCommerce_Content_Template_TemplateRegion_Map] ([TemplateId], [TemplateRegionId]) VALUES (3, 3)
GO

/****** Object:  Table [dbo].[dashCommerce_Content_Page]    Script Date: 04/06/2008 14:27:59 ******/
SET IDENTITY_INSERT [dbo].[dashCommerce_Content_Page] ON
INSERT [dbo].[dashCommerce_Content_Page] ([PageId], [PageGuid], [ParentId], [Title], [MenuTitle], [Keywords], [Description], [SortOrder], [TemplateId], [CreatedBy], [ModifiedBy]) VALUES (1, N'58ec67c1-e2d3-4adc-8ad3-297f52efcf62', 0, N'Home', N'Home', N'', N'', 1, 3, N'SYSTEM', N'SYSTEM')
SET IDENTITY_INSERT [dbo].[dashCommerce_Content_Page] OFF
GO

/****** Object:  Table [dbo].[dashCommerce_Content_SimpleHtml]    Script Date: 04/06/2008 14:27:59 ******/
SET IDENTITY_INSERT [dbo].[dashCommerce_Content_SimpleHtml] ON
INSERT [dbo].[dashCommerce_Content_SimpleHtml] ([SimpleHtmlId], [RegionId], [Html], [CreatedBy], [ModifiedBy]) VALUES (1, 1, N'&lt;div&gt;&lt;a target=&quot;_blank&quot; href=&quot;http://www.mettlesystems.com&quot;&gt;&lt;font size=&quot;2&quot;&gt;Mettle Systems LLC&lt;/font&gt;&lt;/a&gt;&lt;font size=&quot;2&quot;&gt;, the creators of dashCommerce, have partnered with PayPal to give you a complete e-commerce and all-in-one payment solution using PayPal Website Payments Pro with Express Checkout.&lt;/font&gt;&lt;/div&gt;
&lt;ul&gt;
    &lt;li&gt;&lt;font size=&quot;2&quot;&gt;Accept credit card payments without requiring the buyer to have a PayPal account. &lt;/font&gt;&lt;/li&gt;
    &lt;li&gt;&lt;font size=&quot;2&quot;&gt;Get PayPal''s industry-leading security fraud-prevention systems. &lt;/font&gt;&lt;/li&gt;
    &lt;li&gt;&lt;font size=&quot;2&quot;&gt;Take advantage of PayPal''s comprehensive online reports that help you measure sales and manage your business easily. &lt;/font&gt;&lt;/li&gt;
&lt;/ul&gt;
&lt;p&gt;&lt;strong&gt;&lt;font size=&quot;2&quot;&gt;Step 1: Set Up a Verified PayPal Business Account&lt;/font&gt;&lt;/strong&gt;&lt;/p&gt;
&lt;p&gt;&lt;font size=&quot;2&quot;&gt;If you don''t have an existing PayPal account:&lt;/font&gt;&lt;/p&gt;
&lt;ol&gt;
    &lt;li&gt;&lt;a target=&quot;_blank&quot; href=&quot;https://www.paypal.com/us/mrb/pal=NAG62FTSWGJ5W&quot;&gt;&lt;span class=&quot;payPalLink&quot;&gt;&lt;font size=&quot;2&quot;&gt;Go to Paypal&lt;/font&gt;&lt;/span&gt;&lt;/a&gt;&lt;font size=&quot;2&quot;&gt; &lt;/font&gt;&lt;/li&gt;
    &lt;li&gt;&lt;font size=&quot;2&quot;&gt;Click Sign Up Today. &lt;/font&gt;&lt;/li&gt;
    &lt;li&gt;&lt;font size=&quot;2&quot;&gt;Set up an account for Business Owners. &lt;/font&gt;&lt;/li&gt;
    &lt;li&gt;&lt;font size=&quot;2&quot;&gt;Follow the instructions on the PayPal site. &lt;/font&gt;&lt;/li&gt;
&lt;/ol&gt;
&lt;p&gt;&lt;font size=&quot;2&quot;&gt;If you already have a Personal or Premier account:&lt;/font&gt;&lt;/p&gt;
&lt;ol&gt;
    &lt;li&gt;&lt;a target=&quot;_blank&quot; href=&quot;https://www.paypal.com/us/mrb/pal=NAG62FTSWGJ5W&quot;&gt;&lt;span class=&quot;payPalLink&quot;&gt;&lt;font size=&quot;2&quot;&gt;Go to Paypal&lt;/font&gt;&lt;/span&gt;&lt;/a&gt;&lt;font size=&quot;2&quot;&gt; &lt;/font&gt;&lt;/li&gt;
    &lt;li&gt;&lt;font size=&quot;2&quot;&gt;Click the Upgrade your Account link. &lt;/font&gt;&lt;/li&gt;
    &lt;li&gt;&lt;font size=&quot;2&quot;&gt;Click the Upgrade Now button. &lt;/font&gt;&lt;/li&gt;
    &lt;li&gt;&lt;font size=&quot;2&quot;&gt;Choose to upgrade to a Business account and follow instructions to complete the upgrade. &lt;/font&gt;&lt;/li&gt;
    &lt;li&gt;&lt;font size=&quot;2&quot;&gt;If you haven''t already, add a bank account to become a Verified member. Follow the instructions on the PayPal site. (This process may take 2-3 business days.) &lt;/font&gt;&lt;/li&gt;
&lt;/ol&gt;
&lt;p&gt;&lt;strong&gt;&lt;font size=&quot;2&quot;&gt;Step 2: Apply for Website Payments Pro&lt;/font&gt;&lt;/strong&gt;&lt;/p&gt;
&lt;p&gt;&lt;font size=&quot;2&quot;&gt;Get the features of an internet merchant account and payment gateway with Website Payments Pro. Control your checkout from start to finish by integrating PayPal Website Payments Pro with dashCommerce.&lt;/font&gt;&lt;/p&gt;
&lt;ol&gt;
    &lt;li&gt;&lt;a target=&quot;_blank&quot; href=&quot;https://www.paypal.com/us/mrb/pal=NAG62FTSWGJ5W&quot;&gt;&lt;span class=&quot;payPalLink&quot;&gt;&lt;font size=&quot;2&quot;&gt;Go to Paypal&lt;/font&gt;&lt;/span&gt;&lt;/a&gt;&lt;font size=&quot;2&quot;&gt; &lt;/font&gt;&lt;/li&gt;
    &lt;li&gt;&lt;font size=&quot;2&quot;&gt;Login to your PayPal Business Account &lt;/font&gt;&lt;/li&gt;
    &lt;li&gt;&lt;font size=&quot;2&quot;&gt;Click the Merchant Services tab. &lt;/font&gt;&lt;/li&gt;
    &lt;li&gt;&lt;font size=&quot;2&quot;&gt;Click Website Payments Pro (U.S. Only). &lt;/font&gt;&lt;/li&gt;
    &lt;li&gt;&lt;font size=&quot;2&quot;&gt;Click Sign Up Now. &lt;/font&gt;&lt;/li&gt;
    &lt;li&gt;&lt;font size=&quot;2&quot;&gt;Fill in your information, and submit your application. Approval takes between 24 and 48 hours. &lt;/font&gt;&lt;/li&gt;
    &lt;li&gt;&lt;font size=&quot;2&quot;&gt;Once approved, accept the Pro billing agreement. Check the Getting Started section on the upper left of your account overview page. &lt;/font&gt;&lt;/li&gt;
&lt;/ol&gt;
&lt;p&gt;&lt;strong&gt;&lt;font size=&quot;2&quot;&gt;Step 3: Get your API Account Name, API Account Password, and the API Signature.&lt;/font&gt;&lt;/strong&gt;&lt;/p&gt;
&lt;p&gt;&lt;strong&gt;&lt;font size=&quot;2&quot;&gt;Step 4: Configure the Payment System.&lt;/font&gt;&lt;/strong&gt;&lt;/p&gt;', N'SYSTEM', N'SYSTEM')
SET IDENTITY_INSERT [dbo].[dashCommerce_Content_SimpleHtml] OFF
GO

/****** Object:  Table [dbo].[dashCommerce_Content_Region]    Script Date: 04/06/2008 14:27:59 ******/
SET IDENTITY_INSERT [dbo].[dashCommerce_Content_Region] ON
INSERT [dbo].[dashCommerce_Content_Region] ([RegionId], [RegionGuid], [ProviderId], [Title], [TemplateRegionId], [SortOrder], [ShowTitle], [CreatedBy], [ModifiedBy]) VALUES (1, N'e8a639de-50f9-4a21-bf1a-42a866dcb2be', 1, N'Welcome to dashCommerce', 3, 0, 1, N'SYSTEM', N'SYSTEM')
SET IDENTITY_INSERT [dbo].[dashCommerce_Content_Region] OFF
GO

/****** Object:  Table [dbo].[dashCommerce_Content_Page_Region_Map]    Script Date: 04/06/2008 14:27:59 ******/
INSERT [dbo].[dashCommerce_Content_Page_Region_Map] ([RegionId], [PageId]) VALUES (1, 1)
GO

/****** Object:  Table [dbo].[dashCommerce_Store_ToDo]    Script Date: 03/25/2008 12:06:22 ******/
SET IDENTITY_INSERT [dbo].[dashCommerce_Store_ToDo] ON
INSERT [dbo].[dashCommerce_Store_ToDo] ([ToDoId], [ToDo], [CreatedBy], [ModifiedBy]) VALUES (1, N'Configure Shipping Providers', N'SYSTEM', N'SYSTEM')
INSERT [dbo].[dashCommerce_Store_ToDo] ([ToDoId], [ToDo], [CreatedBy], [ModifiedBy]) VALUES (2, N'Configure Tax Providers', N'SYSTEM', N'SYSTEM')
INSERT [dbo].[dashCommerce_Store_ToDo] ([ToDoId], [ToDo], [CreatedBy], [ModifiedBy]) VALUES (3, N'Configure Payment Providers', N'SYSTEM', N'SYSTEM')
INSERT [dbo].[dashCommerce_Store_ToDo] ([ToDoId], [ToDo], [CreatedBy], [ModifiedBy]) VALUES (4, N'Configure Mail Settings', N'SYSTEM', N'SYSTEM')
INSERT [dbo].[dashCommerce_Store_ToDo] ([ToDoId], [ToDo], [CreatedBy], [ModifiedBy]) VALUES (5, N'Configure Notifications', N'SYSTEM', N'SYSTEM')
SET IDENTITY_INSERT [dbo].[dashCommerce_Store_ToDo] OFF
GO

/****** Object:  Table [dbo].[dashCommerce_Core_Country]    Script Date: 02/11/2008 09:46:50 ******/
SET IDENTITY_INSERT [dbo].[dashCommerce_Core_Country] ON
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (1, N'AF', N'Afghanistan')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (2, N'AL', N'Albania')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (3, N'DZ', N'Algeria')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (4, N'AS', N'American Samoa')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (5, N'AD', N'Andorra')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (6, N'AO', N'Angola')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (7, N'AI', N'Anguilla')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (8, N'AQ', N'Antarctica')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (9, N'AG', N'Antigua and Barbuda')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (10, N'AR', N'Argentina')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (11, N'AM', N'Armenia')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (12, N'AW', N'Aruba')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (13, N'AU', N'Australia')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (14, N'AT', N'Austria')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (15, N'AZ', N'Azerbaijan')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (16, N'BS', N'Bahamas')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (17, N'BH', N'Bahrain')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (18, N'BD', N'Bangladesh')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (19, N'BB', N'Barbados')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (20, N'BY', N'Belarus')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (21, N'BE', N'Belgium')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (22, N'BZ', N'Belize')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (23, N'BJ', N'Benin')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (24, N'BM', N'Bermuda')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (25, N'BT', N'Bhutan')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (26, N'BO', N'Bolivia')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (27, N'BA', N'Bosnia and Herzegovina')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (28, N'BW', N'Botswana')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (29, N'BV', N'Bouvet Island')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (30, N'BR', N'Brazil')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (31, N'IO', N'British Indian Ocean Territory')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (32, N'VG', N'British Virgin Islands')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (33, N'BN', N'Brunei Darussalam')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (34, N'BG', N'Bulgaria')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (35, N'BF', N'Burkina Faso')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (36, N'BI', N'Burundi')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (37, N'KH', N'Cambodia')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (38, N'CM', N'Cameroon')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (39, N'CA', N'Canada')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (40, N'CV', N'Cape Verde')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (41, N'KY', N'Cayman Islands')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (42, N'CF', N'Central African Republic')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (43, N'TD', N'Chad')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (44, N'CL', N'Chile')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (45, N'CN', N'China')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (46, N'CX', N'Christmas Island')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (47, N'CC', N'Cocos')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (48, N'CO', N'Colombia')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (49, N'KM', N'Comoros')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (50, N'CG', N'Congo')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (51, N'CK', N'Cook Islands')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (52, N'CR', N'Costa Rica')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (53, N'HR', N'Croatia')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (54, N'CU', N'Cuba')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (55, N'CY', N'Cyprus')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (56, N'CZ', N'Czech Republic')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (57, N'DK', N'Denmark')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (58, N'DJ', N'Djibouti')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (59, N'DM', N'Dominica')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (60, N'DO', N'Dominican Republic')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (61, N'TP', N'East Timor')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (62, N'EC', N'Ecuador')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (63, N'EG', N'Egypt')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (64, N'SV', N'El Salvador')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (65, N'GQ', N'Equatorial Guinea')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (66, N'ER', N'Eritrea')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (67, N'EE', N'Estonia')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (68, N'ET', N'Ethiopia')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (69, N'FK', N'Falkland Islands')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (70, N'FO', N'Faroe Islands')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (71, N'FJ', N'Fiji')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (72, N'FI', N'Finland')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (73, N'FR', N'France')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (74, N'GF', N'French Guiana')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (75, N'PF', N'French Polynesia')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (76, N'TF', N'French Southern Territories')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (77, N'GA', N'Gabon')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (78, N'GM', N'Gambia')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (79, N'GE', N'Georgia')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (80, N'DE', N'Germany')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (81, N'GH', N'Ghana')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (82, N'GI', N'Gibraltar')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (83, N'GR', N'Greece')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (84, N'GL', N'Greenland')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (85, N'GD', N'Grenada')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (86, N'GP', N'Guadeloupe')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (87, N'GU', N'Guam')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (88, N'GT', N'Guatemala')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (89, N'GN', N'Guinea')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (90, N'GW', N'Guinea-Bissau')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (91, N'GY', N'Guyana')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (92, N'HT', N'Haiti')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (93, N'HM', N'Heard and McDonald Islands')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (94, N'HN', N'Honduras')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (95, N'HK', N'Hong Kong')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (96, N'HU', N'Hungary')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (97, N'IS', N'Iceland')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (98, N'IN', N'India')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (99, N'ID', N'Indonesia')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (100, N'IR', N'Iran')
GO
print 'Processed 100 total records'
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (101, N'IQ', N'Iraq')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (102, N'IE', N'Ireland')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (103, N'IL', N'Israel')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (104, N'IT', N'Italy')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (105, N'CI', N'Ivory Coast')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (106, N'JM', N'Jamaica')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (107, N'JP', N'Japan')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (108, N'JO', N'Jordan')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (109, N'KZ', N'Kazakhstan')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (110, N'KE', N'Kenya')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (111, N'KI', N'Kiribati')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (112, N'KW', N'Kuwait')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (113, N'KG', N'Kyrgyzstan')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (114, N'LA', N'Laos')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (115, N'LV', N'Latvia')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (116, N'LB', N'Lebanon')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (117, N'LS', N'Lesotho')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (118, N'LR', N'Liberia')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (119, N'LY', N'Libya')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (120, N'LI', N'Liechtenstein')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (121, N'LT', N'Lithuania')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (122, N'LU', N'Luxembourg')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (123, N'MO', N'Macau')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (124, N'MK', N'Macedonia')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (125, N'MG', N'Madagascar')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (126, N'MW', N'Malawi')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (127, N'MY', N'Malaysia')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (128, N'MV', N'Maldives')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (129, N'ML', N'Mali')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (130, N'MT', N'Malta')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (131, N'MH', N'Marshall Islands')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (132, N'MQ', N'Martinique')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (133, N'MR', N'Mauritania')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (134, N'MU', N'Mauritius')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (135, N'YT', N'Mayotte')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (136, N'MX', N'Mexico')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (137, N'FM', N'Micronesia')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (138, N'MD', N'Moldova')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (139, N'MC', N'Monaco')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (140, N'MN', N'Mongolia')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (141, N'MS', N'Montserrat')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (142, N'MA', N'Morocco')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (143, N'MZ', N'Mozambique')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (144, N'MM', N'Myanmar')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (145, N'NA', N'Namibia')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (146, N'NR', N'Nauru')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (147, N'NP', N'Nepal')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (148, N'NL', N'Netherlands')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (149, N'AN', N'Netherlands Antilles')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (150, N'NC', N'New Caledonia')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (151, N'NZ', N'New Zealand')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (152, N'NI', N'Nicaragua')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (153, N'NE', N'Niger')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (154, N'NG', N'Nigeria')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (155, N'NU', N'Niue')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (156, N'NF', N'Norfolk Island')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (157, N'KP', N'North Korea')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (158, N'MP', N'Northern Mariana Islands')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (159, N'NO', N'Norway')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (160, N'OM', N'Oman')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (161, N'PK', N'Pakistan')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (162, N'PW', N'Palau')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (163, N'PA', N'Panama')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (164, N'PG', N'Papua New Guinea')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (165, N'PY', N'Paraguay')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (166, N'PE', N'Peru')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (167, N'PH', N'Philippines')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (168, N'PN', N'Pitcairn')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (169, N'PL', N'Poland')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (170, N'PT', N'Portugal')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (171, N'PR', N'Puerto Rico')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (172, N'QA', N'Qatar')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (173, N'RE', N'Reunion')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (174, N'RO', N'Romania')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (175, N'RU', N'Russian Federation')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (176, N'RW', N'Rwanda')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (177, N'GS', N'S. Georgia and S. Sandwich Islands')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (178, N'KN', N'Saint Kitts and Nevis')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (179, N'LC', N'Saint Lucia')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (180, N'VC', N'Saint Vincent and The Grenadines')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (181, N'WS', N'Samoa')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (182, N'SM', N'San Marino')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (183, N'ST', N'Sao Tome and Principe')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (184, N'SA', N'Saudi Arabia')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (185, N'SN', N'Senegal')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (186, N'SC', N'Seychelles')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (187, N'SL', N'Sierra Leone')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (188, N'SG', N'Singapore')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (189, N'SK', N'Slovakia')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (190, N'SI', N'Slovenia')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (191, N'SB', N'Solomon Islands')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (192, N'SO', N'Somalia')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (193, N'ZA', N'South Africa')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (194, N'KR', N'South Korea')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (195, N'SU', N'Soviet Union')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (196, N'ES', N'Spain')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (197, N'LK', N'Sri Lanka')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (198, N'SH', N'St. Helena')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (199, N'PM', N'St. Pierre and Miquelon')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (200, N'SD', N'Sudan')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (201, N'SR', N'Suriname')
GO
print 'Processed 200 total records'
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (202, N'SJ', N'Svalbard and Jan Mayen Islands')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (203, N'SZ', N'Swaziland')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (204, N'SE', N'Sweden')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (205, N'CH', N'Switzerland')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (206, N'SY', N'Syria')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (207, N'TW', N'Taiwan')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (208, N'TJ', N'Tajikistan')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (209, N'TZ', N'Tanzania')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (210, N'TH', N'Thailand')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (211, N'TG', N'Togo')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (212, N'TK', N'Tokelau')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (213, N'TO', N'Tonga')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (214, N'TT', N'Trinidad and Tobago')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (215, N'TN', N'Tunisia')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (216, N'TR', N'Turkey')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (217, N'TM', N'Turkmenistan')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (218, N'TC', N'Turks and Caicos Islands')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (219, N'TV', N'Tuvalu')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (220, N'UG', N'Uganda')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (221, N'UA', N'Ukraine')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (222, N'AE', N'United Arab Emirates')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (223, N'GB', N'United Kingdom')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (224, N'US', N'United States')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (225, N'UY', N'Uruguay')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (226, N'UM', N'US Minor Outlying Islands')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (227, N'VI', N'US Virgin Islands')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (228, N'UZ', N'Uzbekistan')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (229, N'VU', N'Vanuatu')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (230, N'VE', N'Venezuela')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (231, N'VN', N'Viet Nam')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (232, N'WF', N'Wallis and Futuna Islands')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (233, N'EH', N'Western Sahara')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (234, N'YE', N'Yemen')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (235, N'YU', N'Yugoslavia')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (236, N'ZR', N'Zaire')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (237, N'ZM', N'Zambia')
INSERT [dbo].[dashCommerce_Core_Country] ([CountryId], [Code], [Name]) VALUES (238, N'ZW', N'Zimbabwe')
SET IDENTITY_INSERT [dbo].[dashCommerce_Core_Country] OFF
GO

/****** Object:  Table [dbo].[dashCommerce_Store_Currency]    Script Date: 02/11/2008 09:46:50 ******/
SET IDENTITY_INSERT [dbo].[dashCommerce_Store_Currency] ON
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (1, N'AFA', N'Afghanistan afghani')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (2, N'ALL', N'Albanian lek')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (3, N'DZD', N'Algerian dinar')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (4, N'AOR', N'Angolan kwanza reajustado')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (5, N'ARS', N'Argentine peso')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (6, N'AMD', N'Armenian dram')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (7, N'AWG', N'Aruban guilder')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (8, N'AUD', N'Australian dollar')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (9, N'AZN', N'Azerbaijanian new manat')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (10, N'BSD', N'Bahamian dollar')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (11, N'BHD', N'Bahraini dinar')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (12, N'BDT', N'Bangladeshi taka')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (13, N'BBD', N'Barbados dollar')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (14, N'BYR', N'Belarusian ruble')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (15, N'BZD', N'Belize dollar')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (16, N'BMD', N'Bermudian dollar')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (17, N'BTN', N'Bhutan ngultrum')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (18, N'BOB', N'Bolivian boliviano')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (19, N'BWP', N'Botswana pula')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (20, N'BRL', N'Brazilian real')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (21, N'GBP', N'British pound')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (22, N'BND', N'Brunei dollar')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (23, N'BGN', N'Bulgarian lev')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (24, N'BIF', N'Burundi franc')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (25, N'KHR', N'Cambodian riel')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (26, N'CAD', N'Canadian dollar')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (27, N'CVE', N'Cape Verde escudo')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (28, N'KYD', N'Cayman Islands dollar')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (29, N'XOF', N'CFA franc BCEAO')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (30, N'XAF', N'CFA franc BEAC')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (31, N'XPF', N'CFP franc')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (32, N'CLP', N'Chilean peso')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (33, N'CNY', N'Chinese yuan renminbi')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (34, N'COP', N'Colombian peso')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (35, N'KMF', N'Comoros franc')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (36, N'CDF', N'Congolese franc')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (37, N'CRC', N'Costa Rican colon')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (38, N'HRK', N'Croatian kuna')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (39, N'CUP', N'Cuban peso')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (40, N'CYP', N'Cypriot pound')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (41, N'CZK', N'Czech koruna')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (42, N'DKK', N'Danish krone')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (43, N'DJF', N'Djibouti franc')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (44, N'DOP', N'Dominican peso')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (45, N'XCD', N'East Caribbean dollar')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (46, N'EGP', N'Egyptian pound')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (47, N'SVC', N'El Salvador colon')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (48, N'ERN', N'Eritrean nakfa')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (49, N'EEK', N'Estonian kroon')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (50, N'ETB', N'Ethiopian birr')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (51, N'EUR', N'EU euro')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (52, N'FKP', N'Falkland Islands pound')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (53, N'FJD', N'Fiji dollar')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (54, N'GMD', N'Gambian dalasi')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (55, N'GEL', N'Georgian lari')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (56, N'GHC', N'Ghanaian cedi')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (57, N'GIP', N'Gibraltar pound')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (58, N'XAU', N'Gold (ounce)')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (59, N'XFO', N'Gold franc')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (60, N'GTQ', N'Guatemalan quetzal')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (61, N'GNF', N'Guinean franc')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (62, N'GYD', N'Guyana dollar')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (63, N'HTG', N'Haitian gourde')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (64, N'HNL', N'Honduran lempira')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (65, N'HKD', N'Hong Kong SAR dollar')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (66, N'HUF', N'Hungarian forint')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (67, N'ISK', N'Icelandic krona')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (68, N'XDR', N'IMF special drawing right')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (69, N'INR', N'Indian rupee')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (70, N'IDR', N'Indonesian rupiah')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (71, N'IRR', N'Iranian rial')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (72, N'IQD', N'Iraqi dinar')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (73, N'ILS', N'Israeli new shekel')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (74, N'JMD', N'Jamaican dollar')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (75, N'JPY', N'Japanese yen')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (76, N'JOD', N'Jordanian dinar')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (77, N'KZT', N'Kazakh tenge')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (78, N'KES', N'Kenyan shilling')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (79, N'KWD', N'Kuwaiti dinar')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (80, N'KGS', N'Kyrgyz som')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (81, N'LAK', N'Lao kip')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (82, N'LVL', N'Latvian lats')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (83, N'LBP', N'Lebanese pound')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (84, N'LSL', N'Lesotho loti')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (85, N'LRD', N'Liberian dollar')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (86, N'LYD', N'Libyan dinar')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (87, N'LTL', N'Lithuanian litas')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (88, N'MOP', N'Macao SAR pataca')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (89, N'MKD', N'Macedonian denar')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (90, N'MGA', N'Malagasy ariary')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (91, N'MWK', N'Malawi kwacha')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (92, N'MYR', N'Malaysian ringgit')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (93, N'MVR', N'Maldivian rufiyaa')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (94, N'MTL', N'Maltese lira')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (95, N'MRO', N'Mauritanian ouguiya')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (96, N'MUR', N'Mauritius rupee')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (97, N'MXN', N'Mexican peso')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (98, N'MDL', N'Moldovan leu')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (99, N'MNT', N'Mongolian tugrik')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (100, N'MAD', N'Moroccan dirham')
GO
print 'Processed 100 total records'
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (101, N'MZN', N'Mozambique new metical')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (102, N'MMK', N'Myanmar kyat')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (103, N'NAD', N'Namibian dollar')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (104, N'NPR', N'Nepalese rupee')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (105, N'ANG', N'Netherlands Antillian guilder')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (106, N'NZD', N'New Zealand dollar')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (107, N'NIO', N'Nicaraguan cordoba oro')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (108, N'NGN', N'Nigerian naira')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (109, N'KPW', N'North Korean won')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (110, N'NOK', N'Norwegian krone')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (111, N'OMR', N'Omani rial')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (112, N'PKR', N'Pakistani rupee')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (113, N'XPD', N'Palladium (ounce)')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (114, N'PAB', N'Panamanian balboa')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (115, N'PGK', N'Papua New Guinea kina')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (116, N'PYG', N'Paraguayan guarani')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (117, N'PEN', N'Peruvian nuevo sol')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (118, N'PHP', N'Philippine peso')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (119, N'XPT', N'Platinum (ounce)')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (120, N'PLN', N'Polish zloty')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (121, N'QAR', N'Qatari rial')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (122, N'RON', N'Romanian new leu')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (123, N'RUB', N'Russian ruble')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (124, N'RWF', N'Rwandan franc')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (125, N'SHP', N'Saint Helena pound')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (126, N'WST', N'Samoan tala')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (127, N'STD', N'Sao Tome and Principe dobra')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (128, N'SAR', N'Saudi riyal')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (129, N'CSD', N'Serbian dinar')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (130, N'SCR', N'Seychelles rupee')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (131, N'SLL', N'Sierra Leone leone')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (132, N'XAG', N'Silver (ounce)')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (133, N'SGD', N'Singapore dollar')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (134, N'SKK', N'Slovak koruna')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (135, N'SIT', N'Slovenian tolar')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (136, N'SBD', N'Solomon Islands dollar')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (137, N'SOS', N'Somali shilling')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (138, N'ZAR', N'South African rand')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (139, N'KRW', N'South Korean won')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (140, N'LKR', N'Sri Lanka rupee')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (141, N'SDD', N'Sudanese dinar')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (142, N'SRD', N'Suriname dollar')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (143, N'SZL', N'Swaziland lilangeni')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (144, N'SEK', N'Swedish krona')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (145, N'CHF', N'Swiss franc')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (146, N'SYP', N'Syrian pound')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (147, N'TWD', N'Taiwan New dollar')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (148, N'TJS', N'Tajik somoni')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (149, N'TZS', N'Tanzanian shilling')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (150, N'THB', N'Thai baht')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (151, N'TOP', N'Tongan pa''anga')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (152, N'TTD', N'Trinidad and Tobago dollar')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (153, N'TND', N'Tunisian dinar')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (154, N'TRY', N'Turkish lira')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (155, N'TMM', N'Turkmen manat')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (156, N'AED', N'UAE dirham')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (157, N'UGX', N'Uganda new shilling')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (158, N'XFU', N'UIC franc')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (159, N'UAH', N'Ukrainian hryvnia')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (160, N'UYU', N'Uruguayan peso uruguayo')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (161, N'USD', N'US dollar')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (162, N'UZS', N'Uzbekistani sum')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (163, N'VUV', N'Vanuatu vatu')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (164, N'VEB', N'Venezuelan bolivar')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (165, N'VND', N'Vietnamese dong')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (166, N'YER', N'Yemeni rial')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (167, N'ZMK', N'Zambian kwacha')
INSERT [dbo].[dashCommerce_Store_Currency] ([codeID], [code], [description]) VALUES (168, N'ZWD', N'Zimbabwe dollar')
SET IDENTITY_INSERT [dbo].[dashCommerce_Store_Currency] OFF
GO

SET IDENTITY_INSERT [dbo].[dashCommerce_Core_StateOrRegion] ON
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (1, 224, N'ALABAMA', N'AL')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (2, 224, N'ALASKA', N'AK')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (3, 224, N'AMERICAN SAMOA', N'AS')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (4, 224, N'ARIZONA', N'AZ')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (5, 224, N'ARKANSAS', N'AR')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (6, 224, N'CALIFORNIA', N'CA')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (7, 224, N'COLORADO', N'CO')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (8, 224, N'CONNECTICUT', N'CT')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (9, 224, N'DELAWARE', N'DE')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (10, 224, N'DISTRICT OF COLUMBIA', N'DC')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (11, 224, N'FEDERATED STATES OF MICRONESIA', N'FM')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (12, 224, N'FLORIDA', N'FL')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (13, 224, N'GEORGIA', N'GA')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (14, 224, N'GUAM', N'GU')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (15, 224, N'HAWAII', N'HI')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (16, 224, N'IDAHO', N'ID')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (17, 224, N'ILLINOIS', N'IL')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (18, 224, N'INDIANA', N'IN')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (19, 224, N'IOWA', N'IA')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (20, 224, N'KANSAS', N'KS')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (21, 224, N'KENTUCKY', N'KY')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (22, 224, N'LOUISIANA', N'LA')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (23, 224, N'MAINE', N'ME')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (24, 224, N'MARSHALL ISLANDS', N'MH')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (25, 224, N'MARYLAND', N'MD')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (26, 224, N'MASSACHUSETTS', N'MA')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (27, 224, N'MICHIGAN', N'MI')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (28, 224, N'MINNESOTA', N'MN')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (29, 224, N'MISSISSIPPI', N'MS')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (30, 224, N'MISSOURI', N'MO')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (31, 224, N'MONTANA', N'MT')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (32, 224, N'NEBRASKA', N'NE')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (33, 224, N'NEVADA', N'NV')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (34, 224, N'NEW HAMPSHIRE', N'NH')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (35, 224, N'NEW JERSEY', N'NJ')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (36, 224, N'NEW MEXICO', N'NM')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (37, 224, N'NEW YORK', N'NY')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (38, 224, N'NORTH CAROLINA', N'NC')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (39, 224, N'NORTH DAKOTA', N'ND')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (40, 224, N'NORTHERN MARIANA ISLANDS', N'MP')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (41, 224, N'OHIO', N'OH')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (42, 224, N'OKLAHOMA', N'OK')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (43, 224, N'OREGON', N'OR')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (44, 224, N'PALAU', N'PW')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (45, 224, N'PENNSYLVANIA', N'PA')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (46, 224, N'PUERTO RICO', N'PR')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (47, 224, N'RHODE ISLAND', N'RI')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (48, 224, N'SOUTH CAROLINA', N'SC')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (49, 224, N'SOUTH DAKOTA', N'SD')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (50, 224, N'TENNESSEE', N'TN')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (51, 224, N'TEXAS', N'TX')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (52, 224, N'UTAH', N'UT')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (53, 224, N'VERMONT', N'VT')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (54, 224, N'VIRGIN ISLANDS', N'VI')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (55, 224, N'VIRGINIA', N'VA')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (56, 224, N'WASHINGTON', N'WA')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (57, 224, N'WEST VIRGINIA', N'WV')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (58, 224, N'WISCONSIN', N'WI')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (59, 224, N'WYOMING', N'WY')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (60, 39, N'ALBERTA', N'AB')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (61, 39, N'BRITISH COLUMBIA', N'BC')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (62, 39, N'MANITOBA', N'MB')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (63, 39, N'NEW BRUNSWICK', N'NB')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (64, 39, N'NEWFOUNDLAND AND LABRADOR', N'NL')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (65, 39, N'NOVA SCOTIA', N'NS')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (66, 39, N'NORTHWEST TERRITORIES', N'NT')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (67, 39, N'NUNAVUT', N'NU')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (68, 39, N'ONTARIO', N'ON')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (69, 39, N'PRINCE EDWARD ISLAND', N'PE')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (70, 39, N'QUEBEC', N'QC')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (71, 39, N'SASKATCHEWAN', N'SK')
INSERT [dbo].[dashCommerce_Core_StateOrRegion] ([StateOrRegionId], [CountryId], [Name], [Abbreviation]) VALUES (72, 39, N'YUKON', N'YT')
SET IDENTITY_INSERT [dbo].[dashCommerce_Core_StateOrRegion] OFF
GO
