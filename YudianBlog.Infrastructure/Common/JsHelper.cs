using System.Web;
using System.Web.UI;

namespace YudianBlog.Infrastructure.Common
{
	public class JsHelper
	{
		#region  弹出消息提示小窗口(非Page页面 如：用户控件)
		/// <summary>
		/// 弹出消息提示小窗口(非Page页面 如：用户控件)
		/// </summary>
		/// <param name="js">窗口信息</param>
		public static void Alert(string message)
		{

			string js = @"<Script language='JavaScript'>
					alert('" + message + "');</Script>";
			HttpContext.Current.Response.Write(js);

		}
		#endregion

		#region  弹出消息提示小窗口(Page页面使用，背景不变黑)
		/// <summary>
		/// 弹出消息提示小窗口
		/// </summary>
		/// <param name="message">窗口信息</param>
		/// <param name="_page">this</param>
		public static void Alert(string message, Page _page)
		{
			_page.ClientScript.RegisterStartupScript(_page.GetType(), "MsgBox", "<script type='text/javascript'>alert('" + message + "')</script>");
		}
		#endregion

		#region 弹出消息框并且转向到新的URL（只刷新本个frame框架）
		/// <summary>
		/// 弹出消息框并且转向到新的URL（只刷新本个frame框架）
		/// </summary>
		/// <param name="message">消息内容</param>
		/// <param name="toURL">连接地址</param>
		public static void AlertAndSelf(string message, string toURL)
		{
			string js = "<script type='text/javascript'>var search = this.location.href;alert('{0}');window.location.replace('{1}')</script>";
			HttpContext.Current.Response.Write(string.Format(js, message, toURL));
		}
		#endregion

		#region 弹出消息框并且转向到新的URL(刷新顶级框架)
		/// <summary>
		/// 弹出消息框并且转向到新的URL(刷新顶级框架)
		/// </summary>
		/// <param name="message">消息内容</param>
		/// <param name="toURL">连接地址</param>
		public static void AlertAndTop(string message, string toURL)
		{

			string js = "<script type=\"text/javascript\">alert(\"{0}\");top.location.replace(\"{1}\")</script>";
			HttpContext.Current.Response.Write(string.Format(js, message, toURL));

		}
		#endregion

		#region 弹出消息框并且转向到原来url(jS)
		/// <summary>
		/// 弹出消息框并且转向到原来url(jS)
		/// </summary>
		/// <param name="message">消息内容</param>
		public static void AlertAndHistory(string message)
		{
			string js = "<script type='text/javascript'>alert('{0}');window.history.back(-1)</script>";
			HttpContext.Current.Response.Write(string.Format(js, message));
		}
		#endregion

		#region 转向到新的URL(刷新顶级框架)
		/// <summary>
		/// 跳转新页面，覆盖旧页面(刷新顶级框架)
		/// </summary>
		/// <param name="toURL">新的网址</param>
		public static void RedirectTop(string toURL)
		{

			string js = "<script type='text/javascript'>top.location.replace('{0}')</script>";
			HttpContext.Current.Response.Write(string.Format(js, toURL));

		}
		#endregion



		#region 转向到新的URL
		/// <summary>
		/// 跳转新页面
		/// </summary>
		/// <param name="toURL">新的网址</param>
		public static void Redirectblank(string toURL)
		{

			string js = "<script type='text/javascript'>window.open('{0}')</script>";
			HttpContext.Current.Response.Write(string.Format(js, toURL));

		}
		#endregion

		#region 转向到新的URL（只刷新本框架）
		/// <summary>
		/// 转向到新的URL（只刷新本框架）
		/// </summary>
		///  <param name="toURL">连接地址</param>
		public static void AlertAndSelf(string toURL)
		{
			string js = "<script type='text/javascript'>window.location.replace('{0}')</script>";
			HttpContext.Current.Response.Write(string.Format(js, toURL));
		}
		#endregion

		#region 回到历史页面
		/// <summary>
		/// 回到历史页面
		/// </summary>
		/// <param name="value">-1/1</param>
		public static void GoHistory(int value)
		{

			string js = @"<Script type='text/javascript'>
					history.go({0});  
				  </Script>";
			HttpContext.Current.Response.Write(string.Format(js, value));

		}
		#endregion

		#region 弹出对话款后关闭当前窗口
		/// <summary>
		/// 弹出对话款后关闭当前窗口
		/// </summary>
		/// <param name="str"></param>
		public static void ShowClose(string str)
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			sb.Append("<script type='text/javascript'>\n");
			sb.Append("alert(\"" + str.Trim() + "\"); \n");
			sb.Append("   window.close();\n");
			sb.Append("</script>\n");
			System.Web.HttpContext.Current.Response.Write(sb.ToString());
		}
		#endregion

		#region 关闭当前窗口
		/// <summary>
		/// 关闭当前窗口
		/// </summary>
		public static void CloseWindow()
		{
			#region
			string js = @"<Script type='text/javascript'>
					parent.opener=null;window.close();  
				  </Script>";
			HttpContext.Current.Response.Write(js);
			HttpContext.Current.Response.End();
			#endregion
		}
		#endregion


		#region 刷新父窗口
		/// <summary>
		/// 刷新父窗口
		/// </summary>
		public static void RefreshParent(string url)
		{
			#region
			string js = @"<script>try{top.location=""" + url + @"""}catch(e){location=""" + url + @"""}</script>";
			HttpContext.Current.Response.Write(js);
			#endregion
		}
		/// <summary>
		/// 刷新父窗口
		/// </summary>
		public static void RefreshOpener()
		{
			#region
			string js = @"<Script language='JavaScript'>
					opener.location.reload();
				  </Script>";
			HttpContext.Current.Response.Write(js);
			#endregion
		}

		#endregion

		/// <summary>
		/// 回调函数
		/// </summary>
		/// <param name="_str">回传内容</param>
		public static void CallBack(string _str)
		{
			string js = @"<script type='text/javascript'>
							var fileName = '" + _str + "';" +
							"window.top.callBack(fileName);" +
						"</script>";
			HttpContext.Current.Response.Write(js);
		}
	}
}
