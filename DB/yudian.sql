if exists (select * from sysobjects where id = OBJECT_ID('[yd_Category]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [yd_Category]

CREATE TABLE [yd_Category] (
[Category_id] [int]  IDENTITY (1, 1)  NOT NULL,
[Category_name] [nvarchar]  (64) NULL,
[Category_slug] [nvarchar]  (64) NULL,
[Category_group] [int]  NULL,
[Category_description] [nvarchar]  (MAX) NULL,
[Category_addtime] [datetime]  NULL,
[Category_count] [int]  NULL,
[Category_parent] [int]  NULL DEFAULT (0),
[Category_type] [nvarchar]  (32) NULL)

ALTER TABLE [yd_Category] WITH NOCHECK ADD  CONSTRAINT [PK_yd_Category] PRIMARY KEY  NONCLUSTERED ( [Category_id] )
SET IDENTITY_INSERT [yd_Category] ON

INSERT [yd_Category] ([Category_id],[Category_name],[Category_slug],[Category_group],[Category_description],[Category_addtime],[Category_count],[Category_parent],[Category_type]) VALUES ( 1,N'�������',N'biancheng',0,N'C#��.NET����ı�����ϱ�̽�����վ,���д�����C#��.NET������ĵ�,�ṩ���һ����ѧϰ��',N'2014/1/6 15:12:26',1,0,N'post')
INSERT [yd_Category] ([Category_id],[Category_name],[Category_slug],[Category_group],[Category_description],[Category_addtime],[Category_count],[Category_parent],[Category_type]) VALUES ( 2,N'IT��Ѷ',N'itzixun',0,N'IT��ѶƵ�����ṩ���¡����ȡ���ȫ���ITҵ��������¡���Ȥ�º����Ž��㡣',N'2014/1/6 15:13:08',8,0,N'post')
INSERT [yd_Category] ([Category_id],[Category_name],[Category_slug],[Category_group],[Category_description],[Category_addtime],[Category_count],[Category_parent],[Category_type]) VALUES ( 3,N'�������',N'ruanjian',0,N'�����������ƽ�棬��ɫ�棬��ʽ������ʵ�õ�������أ�ӵ���ƽ��Ѹ�ף��ƽ��PPS��������������...',N'2014/1/6 15:13:40',1,0,N'post')

SET IDENTITY_INSERT [yd_Category] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[yd_CategoryPostLink]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [yd_CategoryPostLink]

CREATE TABLE [yd_CategoryPostLink] (
[Object_id] [int]  NOT NULL,
[Categorys_id] [int]  NOT NULL)

ALTER TABLE [yd_CategoryPostLink] WITH NOCHECK ADD  CONSTRAINT [PK_yd_CategoryPostLink] PRIMARY KEY  NONCLUSTERED ( [Object_id],[Categorys_id] )
INSERT [yd_CategoryPostLink] ([Object_id],[Categorys_id]) VALUES ( 1,1)
INSERT [yd_CategoryPostLink] ([Object_id],[Categorys_id]) VALUES ( 2,2)
INSERT [yd_CategoryPostLink] ([Object_id],[Categorys_id]) VALUES ( 3,2)
INSERT [yd_CategoryPostLink] ([Object_id],[Categorys_id]) VALUES ( 4,2)
INSERT [yd_CategoryPostLink] ([Object_id],[Categorys_id]) VALUES ( 5,2)
INSERT [yd_CategoryPostLink] ([Object_id],[Categorys_id]) VALUES ( 6,2)
INSERT [yd_CategoryPostLink] ([Object_id],[Categorys_id]) VALUES ( 7,2)
INSERT [yd_CategoryPostLink] ([Object_id],[Categorys_id]) VALUES ( 8,2)
INSERT [yd_CategoryPostLink] ([Object_id],[Categorys_id]) VALUES ( 9,2)
INSERT [yd_CategoryPostLink] ([Object_id],[Categorys_id]) VALUES ( 10,3)
if exists (select * from sysobjects where id = OBJECT_ID('[yd_Comment]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [yd_Comment]

CREATE TABLE [yd_Comment] (
[Comment_id] [int]  IDENTITY (1, 1)  NOT NULL,
[Comment_user_id] [int]  NOT NULL DEFAULT (0),
[Comment_agent] [nvarchar]  (256) NULL,
[Comment_approved] [nvarchar]  (32) NULL,
[Comment_content] [nvarchar]  (MAX) NULL,
[Comment_date] [datetime]  NULL DEFAULT (getdate()),
[Comment_author_ip] [nvarchar]  (64) NULL,
[Comment_author_url] [nvarchar]  (64) NULL,
[Comment_post_id] [int]  NULL,
[Comment_parent] [int]  NULL DEFAULT (0),
[Comment_author] [nvarchar]  (64) NULL,
[Comment_author_email] [nvarchar]  (64) NULL)

ALTER TABLE [yd_Comment] WITH NOCHECK ADD  CONSTRAINT [PK_yd_Comment] PRIMARY KEY  NONCLUSTERED ( [Comment_id] )
SET IDENTITY_INSERT [yd_Comment] ON


SET IDENTITY_INSERT [yd_Comment] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[yd_CommentMeta]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [yd_CommentMeta]

CREATE TABLE [yd_CommentMeta] (
[CommentMeta_id] [int]  IDENTITY (1, 1)  NOT NULL,
[CommentMeta_key] [nvarchar]  (MAX) NULL,
[CommentMeta_value] [nvarchar]  (MAX) NULL,
[Comments_id] [int]  NOT NULL)

ALTER TABLE [yd_CommentMeta] WITH NOCHECK ADD  CONSTRAINT [PK_yd_CommentMeta] PRIMARY KEY  NONCLUSTERED ( [CommentMeta_id] )
SET IDENTITY_INSERT [yd_CommentMeta] ON


SET IDENTITY_INSERT [yd_CommentMeta] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[yd_Link]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [yd_Link]

CREATE TABLE [yd_Link] (
[Link_id] [int]  IDENTITY (1, 1)  NOT NULL,
[Link_url] [nvarchar]  (256) NULL,
[Link_name] [nvarchar]  (256) NULL,
[Link_image] [nvarchar]  (256) NULL,
[Link_target] [nvarchar]  (16) NULL,
[Link_description] [nvarchar]  (MAX) NULL,
[Link_visible] [int]  NULL DEFAULT (1),
[Link_owner] [int]  NULL DEFAULT (1),
[Link_rating] [int]  NULL,
[Link_updated] [datetime]  NULL,
[Link_rel] [nvarchar]  (256) NULL,
[Link_notes] [nvarchar]  (MAX) NULL,
[Link_rss] [nvarchar]  (256) NULL)

ALTER TABLE [yd_Link] WITH NOCHECK ADD  CONSTRAINT [PK_yd_Link] PRIMARY KEY  NONCLUSTERED ( [Link_id] )
SET IDENTITY_INSERT [yd_Link] ON


SET IDENTITY_INSERT [yd_Link] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[yd_Option]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [yd_Option]

CREATE TABLE [yd_Option] (
[Option_id] [int]  IDENTITY (1, 1)  NOT NULL,
[Option_name] [nvarchar]  (MAX) NULL,
[Option_value] [nvarchar]  (MAX) NULL,
[Option_autoload] [int]  NULL DEFAULT (1))

ALTER TABLE [yd_Option] WITH NOCHECK ADD  CONSTRAINT [PK_yd_Option] PRIMARY KEY  NONCLUSTERED ( [Option_id] )
SET IDENTITY_INSERT [yd_Option] ON


SET IDENTITY_INSERT [yd_Option] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[yd_Post]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [yd_Post]

CREATE TABLE [yd_Post] (
[Post_id] [int]  IDENTITY (1, 1)  NOT NULL,
[Post_user_id] [int]  NULL DEFAULT (0),
[Post_date] [datetime]  NULL,
[Post_title] [nvarchar]  (MAX) NULL,
[Post_content] [nvarchar]  (MAX) NULL,
[Post_excerpt] [nvarchar]  (MAX) NULL,
[Post_status] [nvarchar]  (16) NULL,
[Post_comment_status] [nvarchar]  (16) NULL,
[Post_password] [nvarchar]  (64) NULL,
[Post_modified] [datetime]  NULL,
[Post_parent] [int]  NULL,
[Post_address] [nvarchar]  (256) NULL,
[Post_type] [nvarchar]  (16) NULL,
[Post_viewcount] [int]  NULL DEFAULT (0),
[Post_comment_count] [int]  NULL DEFAULT (0),
[Post_name] [nvarchar]  (256) NULL)

ALTER TABLE [yd_Post] WITH NOCHECK ADD  CONSTRAINT [PK_yd_Post] PRIMARY KEY  NONCLUSTERED ( [Post_id] )
SET IDENTITY_INSERT [yd_Post] ON

INSERT [yd_Post] ([Post_id],[Post_user_id],[Post_date],[Post_title],[Post_content],[Post_status],[Post_comment_status],[Post_modified],[Post_parent],[Post_address],[Post_type],[Post_viewcount],[Post_comment_count],[Post_name]) VALUES ( 1,1,N'2014/1/6 15:17:18',N'Ӣ�ض���һ����������ɱ��ͨ����800',N'һֱ�������ƶ������豸�������ṩ���������ͨ�����ǡ�Ӣΰ����������ȼ��ҹ�˾���������˸�֮ͨ�⣬�������ҹ�˾�ڽ�Щ��������������·�������ϵĸ߶��豸Ŀǰ�Ѿ��ʼ�������˾��Ʒ�����ø�ͨ�������ƺ�����ͳ��<a href="http://digi.ithome.com/phone/" target="_blank">�����ֻ�</a>�豸SOC�����ƣ����������Լ��콢Galaxy S4���ֵ���ס��ͨ���������ջ�����Ƴ���Snapdragon 600��800�Ĵ������汾��\r\n\r\n<img alt="" src="http://img.ithome.com/newsuploadfiles/2013/7/20130704_075707_430.png" />\r\n\r\n<img alt="" src="http://img.ithome.com/newsuploadfiles/2013/7/20130704_075707_481.png" />\r\n\r\n��������ΪPC���ϴ��λ��оƬ������Ӣ�ض��ƺ�������ʾ�����ھ���ǰ�����ƶ����������ܲ���ʮ������֮�󣬽��գ�Ӣ�ض���һ��Bay Trail-T��������������ͻȻ���������ֲܷ�����������ã����н���ͨ��ƷSnapdragon 800ϵ�д�����նɱ�����εĿ��ܡ�\r\n\r\n��Ϥ����ͨ��ƷSnapdragon 800��ʵҲ�շ������ã���ͨ�������ܷ�ά����31000�����ң�����������Ӣ�ض���һ��Bay Trail-T�����������ع����������ܷ־��ߴ�43416�֣������ȶ��ֶ��1���֡�\r\n\r\n���⣬�����ع����Ϣ��ʾ��Ӣ�ض����Bay Trail-T�����������ĺ��ļܹ���ƣ���������22nm������Ƶ�ʽ�Ϊ1.1GHz���Ӳ������ƺ���δ�����ر�����֮��������ȴֱ�ӽ�����2.2GHzƵ�ʵ�Snapdragon 800��ɱ������֤��Ӣ�ض�������ʵ�����Լ������ʱ�ڼܹ��ϵ���Խ�ԡ�\r\n\r\n���˾��ȵ��ǣ��˴β��Բ���Ӣ�ض�Bay Trail-T��������ȫ�����ܣ�����Ӣ�ض��ڲ���Ա͸¶����Ϣ��Bay Trail-T�������ڲ�����Ϊbyt_t_ffrd10����һ��רΪ<a href="http://digi.ithome.com/pingban/" target="_blank">ƽ�����</a>���Ƴ��ĵ͹��Ĵ������������Ƶ�ʿ�֧�ֵ�2.1GHz���ӽ�Ŀǰ����������Ϣ�ƣ�Ӣ�ض���������������9�·��Ƴ������������м۸�Ļ�������δ�����',N'open',N'open',N'2014/1/6 15:17:18',0,N'http://blog.winmono.com/?p=1',N'post',30,2,N'ying-te-er-xin-yi-dai-chu-li-qi-miao-sha-gao-tong-xiao-long-800')
INSERT [yd_Post] ([Post_id],[Post_user_id],[Post_date],[Post_title],[Post_content],[Post_status],[Post_comment_status],[Post_modified],[Post_parent],[Post_address],[Post_type],[Post_viewcount],[Post_comment_count],[Post_name]) VALUES ( 2,1,N'2014/1/6 15:17:19',N'Ӣ�ض���һ����������ɱ��ͨ����800',N'һֱ�������ƶ������豸�������ṩ���������ͨ�����ǡ�Ӣΰ����������ȼ��ҹ�˾���������˸�֮ͨ�⣬�������ҹ�˾�ڽ�Щ��������������·�������ϵĸ߶��豸Ŀǰ�Ѿ��ʼ�������˾��Ʒ�����ø�ͨ�������ƺ�����ͳ��<a href="http://digi.ithome.com/phone/" target="_blank">�����ֻ�</a>�豸SOC�����ƣ����������Լ��콢Galaxy S4���ֵ���ס��ͨ���������ջ�����Ƴ���Snapdragon 600��800�Ĵ������汾��\r\n\r\n<img alt="" src="http://img.ithome.com/newsuploadfiles/2013/7/20130704_075707_430.png" />\r\n\r\n<img alt="" src="http://img.ithome.com/newsuploadfiles/2013/7/20130704_075707_481.png" />\r\n\r\n��������ΪPC���ϴ��λ��оƬ������Ӣ�ض��ƺ�������ʾ�����ھ���ǰ�����ƶ����������ܲ���ʮ������֮�󣬽��գ�Ӣ�ض���һ��Bay Trail-T��������������ͻȻ���������ֲܷ�����������ã����н���ͨ��ƷSnapdragon 800ϵ�д�����նɱ�����εĿ��ܡ�\r\n\r\n��Ϥ����ͨ��ƷSnapdragon 800��ʵҲ�շ������ã���ͨ�������ܷ�ά����31000�����ң�����������Ӣ�ض���һ��Bay Trail-T�����������ع����������ܷ־��ߴ�43416�֣������ȶ��ֶ��1���֡�\r\n\r\n���⣬�����ع����Ϣ��ʾ��Ӣ�ض����Bay Trail-T�����������ĺ��ļܹ���ƣ���������22nm������Ƶ�ʽ�Ϊ1.1GHz���Ӳ������ƺ���δ�����ر�����֮��������ȴֱ�ӽ�����2.2GHzƵ�ʵ�Snapdragon 800��ɱ������֤��Ӣ�ض�������ʵ�����Լ������ʱ�ڼܹ��ϵ���Խ�ԡ�\r\n\r\n���˾��ȵ��ǣ��˴β��Բ���Ӣ�ض�Bay Trail-T��������ȫ�����ܣ�����Ӣ�ض��ڲ���Ա͸¶����Ϣ��Bay Trail-T�������ڲ�����Ϊbyt_t_ffrd10����һ��רΪ<a href="http://digi.ithome.com/pingban/" target="_blank">ƽ�����</a>���Ƴ��ĵ͹��Ĵ������������Ƶ�ʿ�֧�ֵ�2.1GHz���ӽ�Ŀǰ����������Ϣ�ƣ�Ӣ�ض���������������9�·��Ƴ������������м۸�Ļ�������δ�����',N'open',N'open',N'2014/1/6 15:17:19',0,N'http://blog.winmono.com/?p=1',N'post',30,2,N'ying-te-er-xin-yi-dai-chu-li-qi-miao-sha-gao-tong-xiao-long-800')
INSERT [yd_Post] ([Post_id],[Post_user_id],[Post_date],[Post_title],[Post_content],[Post_status],[Post_comment_status],[Post_modified],[Post_parent],[Post_address],[Post_type],[Post_viewcount],[Post_comment_count],[Post_name]) VALUES ( 3,1,N'2014/1/6 15:17:20',N'Ӣ�ض���һ����������ɱ��ͨ����800',N'һֱ�������ƶ������豸�������ṩ���������ͨ�����ǡ�Ӣΰ����������ȼ��ҹ�˾���������˸�֮ͨ�⣬�������ҹ�˾�ڽ�Щ��������������·�������ϵĸ߶��豸Ŀǰ�Ѿ��ʼ�������˾��Ʒ�����ø�ͨ�������ƺ�����ͳ��<a href="http://digi.ithome.com/phone/" target="_blank">�����ֻ�</a>�豸SOC�����ƣ����������Լ��콢Galaxy S4���ֵ���ס��ͨ���������ջ�����Ƴ���Snapdragon 600��800�Ĵ������汾��\r\n\r\n<img alt="" src="http://img.ithome.com/newsuploadfiles/2013/7/20130704_075707_430.png" />\r\n\r\n<img alt="" src="http://img.ithome.com/newsuploadfiles/2013/7/20130704_075707_481.png" />\r\n\r\n��������ΪPC���ϴ��λ��оƬ������Ӣ�ض��ƺ�������ʾ�����ھ���ǰ�����ƶ����������ܲ���ʮ������֮�󣬽��գ�Ӣ�ض���һ��Bay Trail-T��������������ͻȻ���������ֲܷ�����������ã����н���ͨ��ƷSnapdragon 800ϵ�д�����նɱ�����εĿ��ܡ�\r\n\r\n��Ϥ����ͨ��ƷSnapdragon 800��ʵҲ�շ������ã���ͨ�������ܷ�ά����31000�����ң�����������Ӣ�ض���һ��Bay Trail-T�����������ع����������ܷ־��ߴ�43416�֣������ȶ��ֶ��1���֡�\r\n\r\n���⣬�����ع����Ϣ��ʾ��Ӣ�ض����Bay Trail-T�����������ĺ��ļܹ���ƣ���������22nm������Ƶ�ʽ�Ϊ1.1GHz���Ӳ������ƺ���δ�����ر�����֮��������ȴֱ�ӽ�����2.2GHzƵ�ʵ�Snapdragon 800��ɱ������֤��Ӣ�ض�������ʵ�����Լ������ʱ�ڼܹ��ϵ���Խ�ԡ�\r\n\r\n���˾��ȵ��ǣ��˴β��Բ���Ӣ�ض�Bay Trail-T��������ȫ�����ܣ�����Ӣ�ض��ڲ���Ա͸¶����Ϣ��Bay Trail-T�������ڲ�����Ϊbyt_t_ffrd10����һ��רΪ<a href="http://digi.ithome.com/pingban/" target="_blank">ƽ�����</a>���Ƴ��ĵ͹��Ĵ������������Ƶ�ʿ�֧�ֵ�2.1GHz���ӽ�Ŀǰ����������Ϣ�ƣ�Ӣ�ض���������������9�·��Ƴ������������м۸�Ļ�������δ�����',N'open',N'open',N'2014/1/6 15:17:20',0,N'http://blog.winmono.com/?p=1',N'post',30,2,N'ying-te-er-xin-yi-dai-chu-li-qi-miao-sha-gao-tong-xiao-long-800')
INSERT [yd_Post] ([Post_id],[Post_user_id],[Post_date],[Post_title],[Post_content],[Post_status],[Post_comment_status],[Post_modified],[Post_parent],[Post_address],[Post_type],[Post_viewcount],[Post_comment_count],[Post_name]) VALUES ( 4,1,N'2014/1/6 15:17:20',N'Ӣ�ض���һ����������ɱ��ͨ����800',N'һֱ�������ƶ������豸�������ṩ���������ͨ�����ǡ�Ӣΰ����������ȼ��ҹ�˾���������˸�֮ͨ�⣬�������ҹ�˾�ڽ�Щ��������������·�������ϵĸ߶��豸Ŀǰ�Ѿ��ʼ�������˾��Ʒ�����ø�ͨ�������ƺ�����ͳ��<a href="http://digi.ithome.com/phone/" target="_blank">�����ֻ�</a>�豸SOC�����ƣ����������Լ��콢Galaxy S4���ֵ���ס��ͨ���������ջ�����Ƴ���Snapdragon 600��800�Ĵ������汾��\r\n\r\n<img alt="" src="http://img.ithome.com/newsuploadfiles/2013/7/20130704_075707_430.png" />\r\n\r\n<img alt="" src="http://img.ithome.com/newsuploadfiles/2013/7/20130704_075707_481.png" />\r\n\r\n��������ΪPC���ϴ��λ��оƬ������Ӣ�ض��ƺ�������ʾ�����ھ���ǰ�����ƶ����������ܲ���ʮ������֮�󣬽��գ�Ӣ�ض���һ��Bay Trail-T��������������ͻȻ���������ֲܷ�����������ã����н���ͨ��ƷSnapdragon 800ϵ�д�����նɱ�����εĿ��ܡ�\r\n\r\n��Ϥ����ͨ��ƷSnapdragon 800��ʵҲ�շ������ã���ͨ�������ܷ�ά����31000�����ң�����������Ӣ�ض���һ��Bay Trail-T�����������ع����������ܷ־��ߴ�43416�֣������ȶ��ֶ��1���֡�\r\n\r\n���⣬�����ع����Ϣ��ʾ��Ӣ�ض����Bay Trail-T�����������ĺ��ļܹ���ƣ���������22nm������Ƶ�ʽ�Ϊ1.1GHz���Ӳ������ƺ���δ�����ر�����֮��������ȴֱ�ӽ�����2.2GHzƵ�ʵ�Snapdragon 800��ɱ������֤��Ӣ�ض�������ʵ�����Լ������ʱ�ڼܹ��ϵ���Խ�ԡ�\r\n\r\n���˾��ȵ��ǣ��˴β��Բ���Ӣ�ض�Bay Trail-T��������ȫ�����ܣ�����Ӣ�ض��ڲ���Ա͸¶����Ϣ��Bay Trail-T�������ڲ�����Ϊbyt_t_ffrd10����һ��רΪ<a href="http://digi.ithome.com/pingban/" target="_blank">ƽ�����</a>���Ƴ��ĵ͹��Ĵ������������Ƶ�ʿ�֧�ֵ�2.1GHz���ӽ�Ŀǰ����������Ϣ�ƣ�Ӣ�ض���������������9�·��Ƴ������������м۸�Ļ�������δ�����',N'open',N'open',N'2014/1/6 15:17:20',0,N'http://blog.winmono.com/?p=1',N'post',30,2,N'ying-te-er-xin-yi-dai-chu-li-qi-miao-sha-gao-tong-xiao-long-800')
INSERT [yd_Post] ([Post_id],[Post_user_id],[Post_date],[Post_title],[Post_content],[Post_status],[Post_comment_status],[Post_modified],[Post_parent],[Post_address],[Post_type],[Post_viewcount],[Post_comment_count],[Post_name]) VALUES ( 5,1,N'2014/1/6 15:17:21',N'Ӣ�ض���һ����������ɱ��ͨ����800',N'һֱ�������ƶ������豸�������ṩ���������ͨ�����ǡ�Ӣΰ����������ȼ��ҹ�˾���������˸�֮ͨ�⣬�������ҹ�˾�ڽ�Щ��������������·�������ϵĸ߶��豸Ŀǰ�Ѿ��ʼ�������˾��Ʒ�����ø�ͨ�������ƺ�����ͳ��<a href="http://digi.ithome.com/phone/" target="_blank">�����ֻ�</a>�豸SOC�����ƣ����������Լ��콢Galaxy S4���ֵ���ס��ͨ���������ջ�����Ƴ���Snapdragon 600��800�Ĵ������汾��\r\n\r\n<img alt="" src="http://img.ithome.com/newsuploadfiles/2013/7/20130704_075707_430.png" />\r\n\r\n<img alt="" src="http://img.ithome.com/newsuploadfiles/2013/7/20130704_075707_481.png" />\r\n\r\n��������ΪPC���ϴ��λ��оƬ������Ӣ�ض��ƺ�������ʾ�����ھ���ǰ�����ƶ����������ܲ���ʮ������֮�󣬽��գ�Ӣ�ض���һ��Bay Trail-T��������������ͻȻ���������ֲܷ�����������ã����н���ͨ��ƷSnapdragon 800ϵ�д�����նɱ�����εĿ��ܡ�\r\n\r\n��Ϥ����ͨ��ƷSnapdragon 800��ʵҲ�շ������ã���ͨ�������ܷ�ά����31000�����ң�����������Ӣ�ض���һ��Bay Trail-T�����������ع����������ܷ־��ߴ�43416�֣������ȶ��ֶ��1���֡�\r\n\r\n���⣬�����ع����Ϣ��ʾ��Ӣ�ض����Bay Trail-T�����������ĺ��ļܹ���ƣ���������22nm������Ƶ�ʽ�Ϊ1.1GHz���Ӳ������ƺ���δ�����ر�����֮��������ȴֱ�ӽ�����2.2GHzƵ�ʵ�Snapdragon 800��ɱ������֤��Ӣ�ض�������ʵ�����Լ������ʱ�ڼܹ��ϵ���Խ�ԡ�\r\n\r\n���˾��ȵ��ǣ��˴β��Բ���Ӣ�ض�Bay Trail-T��������ȫ�����ܣ�����Ӣ�ض��ڲ���Ա͸¶����Ϣ��Bay Trail-T�������ڲ�����Ϊbyt_t_ffrd10����һ��רΪ<a href="http://digi.ithome.com/pingban/" target="_blank">ƽ�����</a>���Ƴ��ĵ͹��Ĵ������������Ƶ�ʿ�֧�ֵ�2.1GHz���ӽ�Ŀǰ����������Ϣ�ƣ�Ӣ�ض���������������9�·��Ƴ������������м۸�Ļ�������δ�����',N'open',N'open',N'2014/1/6 15:17:21',0,N'http://blog.winmono.com/?p=1',N'post',30,2,N'ying-te-er-xin-yi-dai-chu-li-qi-miao-sha-gao-tong-xiao-long-800')
INSERT [yd_Post] ([Post_id],[Post_user_id],[Post_date],[Post_title],[Post_content],[Post_status],[Post_comment_status],[Post_modified],[Post_parent],[Post_address],[Post_type],[Post_viewcount],[Post_comment_count],[Post_name]) VALUES ( 6,1,N'2014/1/6 15:17:21',N'Ӣ�ض���һ����������ɱ��ͨ����800',N'һֱ�������ƶ������豸�������ṩ���������ͨ�����ǡ�Ӣΰ����������ȼ��ҹ�˾���������˸�֮ͨ�⣬�������ҹ�˾�ڽ�Щ��������������·�������ϵĸ߶��豸Ŀǰ�Ѿ��ʼ�������˾��Ʒ�����ø�ͨ�������ƺ�����ͳ��<a href="http://digi.ithome.com/phone/" target="_blank">�����ֻ�</a>�豸SOC�����ƣ����������Լ��콢Galaxy S4���ֵ���ס��ͨ���������ջ�����Ƴ���Snapdragon 600��800�Ĵ������汾��\r\n\r\n<img alt="" src="http://img.ithome.com/newsuploadfiles/2013/7/20130704_075707_430.png" />\r\n\r\n<img alt="" src="http://img.ithome.com/newsuploadfiles/2013/7/20130704_075707_481.png" />\r\n\r\n��������ΪPC���ϴ��λ��оƬ������Ӣ�ض��ƺ�������ʾ�����ھ���ǰ�����ƶ����������ܲ���ʮ������֮�󣬽��գ�Ӣ�ض���һ��Bay Trail-T��������������ͻȻ���������ֲܷ�����������ã����н���ͨ��ƷSnapdragon 800ϵ�д�����նɱ�����εĿ��ܡ�\r\n\r\n��Ϥ����ͨ��ƷSnapdragon 800��ʵҲ�շ������ã���ͨ�������ܷ�ά����31000�����ң�����������Ӣ�ض���һ��Bay Trail-T�����������ع����������ܷ־��ߴ�43416�֣������ȶ��ֶ��1���֡�\r\n\r\n���⣬�����ع����Ϣ��ʾ��Ӣ�ض����Bay Trail-T�����������ĺ��ļܹ���ƣ���������22nm������Ƶ�ʽ�Ϊ1.1GHz���Ӳ������ƺ���δ�����ر�����֮��������ȴֱ�ӽ�����2.2GHzƵ�ʵ�Snapdragon 800��ɱ������֤��Ӣ�ض�������ʵ�����Լ������ʱ�ڼܹ��ϵ���Խ�ԡ�\r\n\r\n���˾��ȵ��ǣ��˴β��Բ���Ӣ�ض�Bay Trail-T��������ȫ�����ܣ�����Ӣ�ض��ڲ���Ա͸¶����Ϣ��Bay Trail-T�������ڲ�����Ϊbyt_t_ffrd10����һ��רΪ<a href="http://digi.ithome.com/pingban/" target="_blank">ƽ�����</a>���Ƴ��ĵ͹��Ĵ������������Ƶ�ʿ�֧�ֵ�2.1GHz���ӽ�Ŀǰ����������Ϣ�ƣ�Ӣ�ض���������������9�·��Ƴ������������м۸�Ļ�������δ�����',N'open',N'open',N'2014/1/6 15:17:21',0,N'http://blog.winmono.com/?p=1',N'post',30,2,N'ying-te-er-xin-yi-dai-chu-li-qi-miao-sha-gao-tong-xiao-long-800')
INSERT [yd_Post] ([Post_id],[Post_user_id],[Post_date],[Post_title],[Post_content],[Post_status],[Post_comment_status],[Post_modified],[Post_parent],[Post_address],[Post_type],[Post_viewcount],[Post_comment_count],[Post_name]) VALUES ( 7,1,N'2014/1/6 15:17:22',N'Ӣ�ض���һ����������ɱ��ͨ����800',N'һֱ�������ƶ������豸�������ṩ���������ͨ�����ǡ�Ӣΰ����������ȼ��ҹ�˾���������˸�֮ͨ�⣬�������ҹ�˾�ڽ�Щ��������������·�������ϵĸ߶��豸Ŀǰ�Ѿ��ʼ�������˾��Ʒ�����ø�ͨ�������ƺ�����ͳ��<a href="http://digi.ithome.com/phone/" target="_blank">�����ֻ�</a>�豸SOC�����ƣ����������Լ��콢Galaxy S4���ֵ���ס��ͨ���������ջ�����Ƴ���Snapdragon 600��800�Ĵ������汾��\r\n\r\n<img alt="" src="http://img.ithome.com/newsuploadfiles/2013/7/20130704_075707_430.png" />\r\n\r\n<img alt="" src="http://img.ithome.com/newsuploadfiles/2013/7/20130704_075707_481.png" />\r\n\r\n��������ΪPC���ϴ��λ��оƬ������Ӣ�ض��ƺ�������ʾ�����ھ���ǰ�����ƶ����������ܲ���ʮ������֮�󣬽��գ�Ӣ�ض���һ��Bay Trail-T��������������ͻȻ���������ֲܷ�����������ã����н���ͨ��ƷSnapdragon 800ϵ�д�����նɱ�����εĿ��ܡ�\r\n\r\n��Ϥ����ͨ��ƷSnapdragon 800��ʵҲ�շ������ã���ͨ�������ܷ�ά����31000�����ң�����������Ӣ�ض���һ��Bay Trail-T�����������ع����������ܷ־��ߴ�43416�֣������ȶ��ֶ��1���֡�\r\n\r\n���⣬�����ع����Ϣ��ʾ��Ӣ�ض����Bay Trail-T�����������ĺ��ļܹ���ƣ���������22nm������Ƶ�ʽ�Ϊ1.1GHz���Ӳ������ƺ���δ�����ر�����֮��������ȴֱ�ӽ�����2.2GHzƵ�ʵ�Snapdragon 800��ɱ������֤��Ӣ�ض�������ʵ�����Լ������ʱ�ڼܹ��ϵ���Խ�ԡ�\r\n\r\n���˾��ȵ��ǣ��˴β��Բ���Ӣ�ض�Bay Trail-T��������ȫ�����ܣ�����Ӣ�ض��ڲ���Ա͸¶����Ϣ��Bay Trail-T�������ڲ�����Ϊbyt_t_ffrd10����һ��רΪ<a href="http://digi.ithome.com/pingban/" target="_blank">ƽ�����</a>���Ƴ��ĵ͹��Ĵ������������Ƶ�ʿ�֧�ֵ�2.1GHz���ӽ�Ŀǰ����������Ϣ�ƣ�Ӣ�ض���������������9�·��Ƴ������������м۸�Ļ�������δ�����',N'open',N'open',N'2014/1/6 15:17:22',0,N'http://blog.winmono.com/?p=1',N'post',30,2,N'ying-te-er-xin-yi-dai-chu-li-qi-miao-sha-gao-tong-xiao-long-800')
INSERT [yd_Post] ([Post_id],[Post_user_id],[Post_date],[Post_title],[Post_content],[Post_status],[Post_comment_status],[Post_modified],[Post_parent],[Post_address],[Post_type],[Post_viewcount],[Post_comment_count],[Post_name]) VALUES ( 8,1,N'2014/1/6 15:17:22',N'Ӣ�ض���һ����������ɱ��ͨ����800',N'һֱ�������ƶ������豸�������ṩ���������ͨ�����ǡ�Ӣΰ����������ȼ��ҹ�˾���������˸�֮ͨ�⣬�������ҹ�˾�ڽ�Щ��������������·�������ϵĸ߶��豸Ŀǰ�Ѿ��ʼ�������˾��Ʒ�����ø�ͨ�������ƺ�����ͳ��<a href="http://digi.ithome.com/phone/" target="_blank">�����ֻ�</a>�豸SOC�����ƣ����������Լ��콢Galaxy S4���ֵ���ס��ͨ���������ջ�����Ƴ���Snapdragon 600��800�Ĵ������汾��\r\n\r\n<img alt="" src="http://img.ithome.com/newsuploadfiles/2013/7/20130704_075707_430.png" />\r\n\r\n<img alt="" src="http://img.ithome.com/newsuploadfiles/2013/7/20130704_075707_481.png" />\r\n\r\n��������ΪPC���ϴ��λ��оƬ������Ӣ�ض��ƺ�������ʾ�����ھ���ǰ�����ƶ����������ܲ���ʮ������֮�󣬽��գ�Ӣ�ض���һ��Bay Trail-T��������������ͻȻ���������ֲܷ�����������ã����н���ͨ��ƷSnapdragon 800ϵ�д�����նɱ�����εĿ��ܡ�\r\n\r\n��Ϥ����ͨ��ƷSnapdragon 800��ʵҲ�շ������ã���ͨ�������ܷ�ά����31000�����ң�����������Ӣ�ض���һ��Bay Trail-T�����������ع����������ܷ־��ߴ�43416�֣������ȶ��ֶ��1���֡�\r\n\r\n���⣬�����ع����Ϣ��ʾ��Ӣ�ض����Bay Trail-T�����������ĺ��ļܹ���ƣ���������22nm������Ƶ�ʽ�Ϊ1.1GHz���Ӳ������ƺ���δ�����ر�����֮��������ȴֱ�ӽ�����2.2GHzƵ�ʵ�Snapdragon 800��ɱ������֤��Ӣ�ض�������ʵ�����Լ������ʱ�ڼܹ��ϵ���Խ�ԡ�\r\n\r\n���˾��ȵ��ǣ��˴β��Բ���Ӣ�ض�Bay Trail-T��������ȫ�����ܣ�����Ӣ�ض��ڲ���Ա͸¶����Ϣ��Bay Trail-T�������ڲ�����Ϊbyt_t_ffrd10����һ��רΪ<a href="http://digi.ithome.com/pingban/" target="_blank">ƽ�����</a>���Ƴ��ĵ͹��Ĵ������������Ƶ�ʿ�֧�ֵ�2.1GHz���ӽ�Ŀǰ����������Ϣ�ƣ�Ӣ�ض���������������9�·��Ƴ������������м۸�Ļ�������δ�����',N'open',N'open',N'2014/1/6 15:17:22',0,N'http://blog.winmono.com/?p=1',N'post',30,2,N'ying-te-er-xin-yi-dai-chu-li-qi-miao-sha-gao-tong-xiao-long-800')
INSERT [yd_Post] ([Post_id],[Post_user_id],[Post_date],[Post_title],[Post_content],[Post_status],[Post_comment_status],[Post_modified],[Post_parent],[Post_address],[Post_type],[Post_viewcount],[Post_comment_count],[Post_name]) VALUES ( 9,1,N'2014/1/6 15:17:23',N'Ӣ�ض���һ����������ɱ��ͨ����800',N'һֱ�������ƶ������豸�������ṩ���������ͨ�����ǡ�Ӣΰ����������ȼ��ҹ�˾���������˸�֮ͨ�⣬�������ҹ�˾�ڽ�Щ��������������·�������ϵĸ߶��豸Ŀǰ�Ѿ��ʼ�������˾��Ʒ�����ø�ͨ�������ƺ�����ͳ��<a href="http://digi.ithome.com/phone/" target="_blank">�����ֻ�</a>�豸SOC�����ƣ����������Լ��콢Galaxy S4���ֵ���ס��ͨ���������ջ�����Ƴ���Snapdragon 600��800�Ĵ������汾��\r\n\r\n<img alt="" src="http://img.ithome.com/newsuploadfiles/2013/7/20130704_075707_430.png" />\r\n\r\n<img alt="" src="http://img.ithome.com/newsuploadfiles/2013/7/20130704_075707_481.png" />\r\n\r\n��������ΪPC���ϴ��λ��оƬ������Ӣ�ض��ƺ�������ʾ�����ھ���ǰ�����ƶ����������ܲ���ʮ������֮�󣬽��գ�Ӣ�ض���һ��Bay Trail-T��������������ͻȻ���������ֲܷ�����������ã����н���ͨ��ƷSnapdragon 800ϵ�д�����նɱ�����εĿ��ܡ�\r\n\r\n��Ϥ����ͨ��ƷSnapdragon 800��ʵҲ�շ������ã���ͨ�������ܷ�ά����31000�����ң�����������Ӣ�ض���һ��Bay Trail-T�����������ع����������ܷ־��ߴ�43416�֣������ȶ��ֶ��1���֡�\r\n\r\n���⣬�����ع����Ϣ��ʾ��Ӣ�ض����Bay Trail-T�����������ĺ��ļܹ���ƣ���������22nm������Ƶ�ʽ�Ϊ1.1GHz���Ӳ������ƺ���δ�����ر�����֮��������ȴֱ�ӽ�����2.2GHzƵ�ʵ�Snapdragon 800��ɱ������֤��Ӣ�ض�������ʵ�����Լ������ʱ�ڼܹ��ϵ���Խ�ԡ�\r\n\r\n���˾��ȵ��ǣ��˴β��Բ���Ӣ�ض�Bay Trail-T��������ȫ�����ܣ�����Ӣ�ض��ڲ���Ա͸¶����Ϣ��Bay Trail-T�������ڲ�����Ϊbyt_t_ffrd10����һ��רΪ<a href="http://digi.ithome.com/pingban/" target="_blank">ƽ�����</a>���Ƴ��ĵ͹��Ĵ������������Ƶ�ʿ�֧�ֵ�2.1GHz���ӽ�Ŀǰ����������Ϣ�ƣ�Ӣ�ض���������������9�·��Ƴ������������м۸�Ļ�������δ�����',N'open',N'open',N'2014/1/6 15:17:23',0,N'http://blog.winmono.com/?p=1',N'post',30,2,N'ying-te-er-xin-yi-dai-chu-li-qi-miao-sha-gao-tong-xiao-long-800')
INSERT [yd_Post] ([Post_id],[Post_user_id],[Post_date],[Post_title],[Post_content],[Post_status],[Post_comment_status],[Post_modified],[Post_parent],[Post_address],[Post_type],[Post_viewcount],[Post_comment_count],[Post_name]) VALUES ( 10,1,N'2014/1/6 15:17:24',N'Ӣ�ض���һ����������ɱ��ͨ����800',N'һֱ�������ƶ������豸�������ṩ���������ͨ�����ǡ�Ӣΰ����������ȼ��ҹ�˾���������˸�֮ͨ�⣬�������ҹ�˾�ڽ�Щ��������������·�������ϵĸ߶��豸Ŀǰ�Ѿ��ʼ�������˾��Ʒ�����ø�ͨ�������ƺ�����ͳ��<a href="http://digi.ithome.com/phone/" target="_blank">�����ֻ�</a>�豸SOC�����ƣ����������Լ��콢Galaxy S4���ֵ���ס��ͨ���������ջ�����Ƴ���Snapdragon 600��800�Ĵ������汾��\r\n\r\n<img alt="" src="http://img.ithome.com/newsuploadfiles/2013/7/20130704_075707_430.png" />\r\n\r\n<img alt="" src="http://img.ithome.com/newsuploadfiles/2013/7/20130704_075707_481.png" />\r\n\r\n��������ΪPC���ϴ��λ��оƬ������Ӣ�ض��ƺ�������ʾ�����ھ���ǰ�����ƶ����������ܲ���ʮ������֮�󣬽��գ�Ӣ�ض���һ��Bay Trail-T��������������ͻȻ���������ֲܷ�����������ã����н���ͨ��ƷSnapdragon 800ϵ�д�����նɱ�����εĿ��ܡ�\r\n\r\n��Ϥ����ͨ��ƷSnapdragon 800��ʵҲ�շ������ã���ͨ�������ܷ�ά����31000�����ң�����������Ӣ�ض���һ��Bay Trail-T�����������ع����������ܷ־��ߴ�43416�֣������ȶ��ֶ��1���֡�\r\n\r\n���⣬�����ع����Ϣ��ʾ��Ӣ�ض����Bay Trail-T�����������ĺ��ļܹ���ƣ���������22nm������Ƶ�ʽ�Ϊ1.1GHz���Ӳ������ƺ���δ�����ر�����֮��������ȴֱ�ӽ�����2.2GHzƵ�ʵ�Snapdragon 800��ɱ������֤��Ӣ�ض�������ʵ�����Լ������ʱ�ڼܹ��ϵ���Խ�ԡ�\r\n\r\n���˾��ȵ��ǣ��˴β��Բ���Ӣ�ض�Bay Trail-T��������ȫ�����ܣ�����Ӣ�ض��ڲ���Ա͸¶����Ϣ��Bay Trail-T�������ڲ�����Ϊbyt_t_ffrd10����һ��רΪ<a href="http://digi.ithome.com/pingban/" target="_blank">ƽ�����</a>���Ƴ��ĵ͹��Ĵ������������Ƶ�ʿ�֧�ֵ�2.1GHz���ӽ�Ŀǰ����������Ϣ�ƣ�Ӣ�ض���������������9�·��Ƴ������������м۸�Ļ�������δ�����',N'open',N'open',N'2014/1/6 15:17:24',0,N'http://blog.winmono.com/?p=1',N'post',30,2,N'ying-te-er-xin-yi-dai-chu-li-qi-miao-sha-gao-tong-xiao-long-800')

SET IDENTITY_INSERT [yd_Post] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[yd_PostMeta]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [yd_PostMeta]

CREATE TABLE [yd_PostMeta] (
[PostMeta_id] [int]  IDENTITY (1, 1)  NOT NULL,
[Posts_id] [int]  NOT NULL,
[PostMeta_key] [nvarchar]  (MAX) NULL,
[PostMeta_value] [nvarchar]  (MAX) NULL)

ALTER TABLE [yd_PostMeta] WITH NOCHECK ADD  CONSTRAINT [PK_yd_PostMeta] PRIMARY KEY  NONCLUSTERED ( [PostMeta_id] )
SET IDENTITY_INSERT [yd_PostMeta] ON

INSERT [yd_PostMeta] ([PostMeta_id],[Posts_id],[PostMeta_key],[PostMeta_value]) VALUES ( 1,1,N'top',N'1')
INSERT [yd_PostMeta] ([PostMeta_id],[Posts_id],[PostMeta_key],[PostMeta_value]) VALUES ( 2,2,N'top',N'1')
INSERT [yd_PostMeta] ([PostMeta_id],[Posts_id],[PostMeta_key],[PostMeta_value]) VALUES ( 3,3,N'top',N'0')

SET IDENTITY_INSERT [yd_PostMeta] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[yd_User]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [yd_User]

CREATE TABLE [yd_User] (
[User_id] [int]  IDENTITY (1, 1)  NOT NULL,
[User_email] [nvarchar]  (64) NULL,
[User_nicename] [nvarchar]  (64) NULL,
[User_salt] [nvarchar]  (64) NULL,
[User_pass] [nvarchar]  (64) NULL,
[User_login] [nvarchar]  (MAX) NULL,
[User_status] [int]  NULL DEFAULT (1),
[User_url] [nvarchar]  (64) NULL,
[User_registeredtime] [datetime]  NULL)

ALTER TABLE [yd_User] WITH NOCHECK ADD  CONSTRAINT [PK_yd_User] PRIMARY KEY  NONCLUSTERED ( [User_id] )
SET IDENTITY_INSERT [yd_User] ON

INSERT [yd_User] ([User_id],[User_email],[User_nicename],[User_salt],[User_pass],[User_login],[User_status],[User_url],[User_registeredtime]) VALUES ( 1,N'admin@qq.com',N'admin',N'PUoRG58soD2Rgb3YJQG/TA==',N'FfAftwmFrDiIjOMtdWy2w1nMEQY=',N'admin',1,N'www.yudianblog.com',N'2014/1/6 15:06:44')

SET IDENTITY_INSERT [yd_User] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[yd_UserMeta]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [yd_UserMeta]

CREATE TABLE [yd_UserMeta] (
[UserMeta_id] [int]  IDENTITY (1, 1)  NOT NULL,
[Users_id] [int]  NOT NULL,
[UserMeta_key] [nvarchar]  (MAX) NULL,
[UserMeta_value] [nvarchar]  (MAX) NULL)

ALTER TABLE [yd_UserMeta] WITH NOCHECK ADD  CONSTRAINT [PK_yd_UserMeta] PRIMARY KEY  NONCLUSTERED ( [UserMeta_id] )
SET IDENTITY_INSERT [yd_UserMeta] ON

INSERT [yd_UserMeta] ([UserMeta_id],[Users_id],[UserMeta_key],[UserMeta_value]) VALUES ( 1,1,N'phone',N'13666123456')
INSERT [yd_UserMeta] ([UserMeta_id],[Users_id],[UserMeta_key],[UserMeta_value]) VALUES ( 3,1,N'job',N'����Գ')

SET IDENTITY_INSERT [yd_UserMeta] OFF
