using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YudianBlog.Infrastructure.Email
{
    [Serializable]
    public class SmtpMail
    {
        /// <summary>
        /// STMP服务器地址
        /// </summary>
        public string STMPHost { get; set; }

        /// <summary>
        /// STMP服务帐号
        /// </summary>
        public string STMPAccount { get; set; }

        /// <summary>
        /// STMP服务密码
        /// </summary>
        public string STMPPwd { get; set; }

        /// <summary>
        /// 发件人地址
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// 邮件标题
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// 邮件内容
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// 接收人邮件地址
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// 是否Html邮件
        /// </summary>
        public bool Html { get; set; }

    }
}
