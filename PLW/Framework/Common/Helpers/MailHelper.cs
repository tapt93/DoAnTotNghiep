using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

namespace Framework.Common.Helpers
{
    public static class MailHelper
    {
        /// <summary>
        /// Send a mail message from full informations
        /// </summary>
        /// <param name="to"></param>
        /// <param name="cc"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        public static void SendMail(string to, string cc, string subject, string body)
        {
            SendMail("aaa.com.vn", to, cc, subject, body);
        }

        /// <summary>
        /// Send a short mail message
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="cc"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        public static void SendMail(string from, string to, string cc, string subject, string body)
        {
            MailMessage message = new MailMessage();

            if (from != null) message.From = new MailAddress(from);
            if (to != null)
            {
                foreach (string address in to.Split(';'))
                    message.To.Add(address);
            }
            if (cc != string.Empty)
            {
                foreach (string address in cc.Split(';'))
                    message.CC.Add(address);
            }

            message.Body = body;

            message.Subject = subject;

            SendMail(message);
        }

        /// <summary>
        /// Send a mail message from MailMessage class
        /// </summary>
        /// <param name="message"></param>
        public static void SendMail(MailMessage message)
        {
            SmtpClient smtpClient = new SmtpClient();

            message.IsBodyHtml = true;

            smtpClient.Send(message);
        }

        public static bool IsValidEmail(string email)
        {
            string pattern = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            //Regular expression object
            Regex check = new Regex(pattern, RegexOptions.IgnorePatternWhitespace);
            if (check.IsMatch(email))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
