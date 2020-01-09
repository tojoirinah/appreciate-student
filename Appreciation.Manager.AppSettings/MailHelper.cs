using System;
using System.Net;
using System.Net.Mail;

namespace Appreciation.Manager.Utils
{
    public class MailHelper
    {
        public static void SendMailSuccess(MailRequest request)
        {
            try
            {
                var smtp = new SmtpClient(Settings.MailSmtp, 587)
                {
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = true,
                    Credentials = new NetworkCredential(Settings.MailSender, Settings.MailPassword)
                };

                using (var message = new MailMessage(Settings.MailSender, request.Recipient)
                {
                    Subject = request.Subject,
                    Body = request.Body,
                    IsBodyHtml = true
                })
                {
                    smtp.Send(message);
                }
            }
            catch (Exception ex)
            {
                string err = $"{ex.Message} - {ex.InnerException} - {ex.StackTrace}";
                throw ex;
            }
        }
    }

    public class MailRequest
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Recipient { get; set; }
    }
}
