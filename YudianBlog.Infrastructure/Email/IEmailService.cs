using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YudianBlog.Infrastructure.Email
{
    #region 邮件收发代码接口

    public interface IEmailService
    {
        /// <summary>
        /// 发送
        /// </summary>
        /// <returns></returns>
        bool Send(SmtpMail smtpMail);

    }

    #endregion
}
