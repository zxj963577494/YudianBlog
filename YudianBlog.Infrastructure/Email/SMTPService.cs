using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace YudianBlog.Infrastructure.Email
{
    public class SMTPService:IEmailService
    {
        public bool Send(SmtpMail smtpMail)
        {
            var smtpClient = new SmtpClient {DeliveryMethod = SmtpDeliveryMethod.Network, Host = smtpMail.STMPHost};
            ;//指定SMTP服务器
            smtpClient.Credentials = new System.Net.NetworkCredential(smtpMail.STMPAccount, smtpMail.STMPPwd);//用户名和密码
            var mailMessage = new MailMessage(smtpMail.From, smtpMail.To)
            {
                Subject = smtpMail.Subject,
                Body = smtpMail.Body,
                BodyEncoding = System.Text.Encoding.UTF8,
                IsBodyHtml = smtpMail.Html,
                Priority = MailPriority.High
            };
            try
            {
                smtpClient.Send(mailMessage);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
