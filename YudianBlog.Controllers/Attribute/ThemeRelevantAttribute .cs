using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using YudianBlog.Infrastructure.Config;
using YudianBlog.Infrastructure.Themes;

namespace YudianBlog.Controllers.Attribute
{
    /// <summary>
    /// 主题相关
    /// </summary>
    public sealed class ThemesRelevantAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var viewResult = filterContext.Result as ViewResult;
            if (viewResult != null)
            {
                var currentUserTheme = ThemeConfigs.GetConfig().ConfigList.FirstOrDefault(t => t.ThemeEnabled == "1") ??
                                       ThemeConfigs.GetConfig().FindConfigById("1");
                var controller = filterContext.RequestContext.RouteData.Values["Controller"].ToString();
                var action = filterContext.RequestContext.RouteData.Values["Action"].ToString();

                if (string.IsNullOrWhiteSpace(viewResult.ViewName))
                {
                    viewResult.ViewName = string.Format(
                        "~/Views/Themes/{0}/{1}/{2}.cshtml",
                        currentUserTheme.ThemeName,
                        controller,
                        action);
                    return;
                }
            }

            base.OnResultExecuting(filterContext);
        }
    }
}
