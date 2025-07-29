using CORE_PintPoint.Abstraction.IService;
using CORE_PintPoint.Entities;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Net;

namespace CORE_PintPoint.Services
{
    public class MailService(IOptions<MailSettings> mailSettings) : IMailService
    {
        public async Task<bool> EmailData(string email, string code, int id, string subject, string textLink, string link)
        {
            MailData mailData = new()
            {
                ToName = email,
                ToId = email,
                Subject = subject,
                HTMLBody = "Bonjour, <br><br> <a href='" + link + WebUtility.UrlEncode(code) + "&id=" + id + "'>" + textLink + "</a> <br><br> La team Pintpoint.",
            };
            return await SendEmail(mailData);
        }

        public async Task<bool> SendEmail(MailData mailData)
        {
            try
            {
                //MimeMessage - a class from Mimekit
                MimeMessage email_Message = new();
                MailboxAddress email_From = new(mailSettings.Value.Name, "noreply@pintpoint.be");
                email_Message.From.Add(email_From);
                MailboxAddress email_To = new(mailData.ToName, mailData.ToId);
                email_Message.To.Add(email_To);
                email_Message.Subject = mailData.Subject;
                BodyBuilder emailBodyBuilder = new()
                {
                    HtmlBody = mailData.HTMLBody,
                    TextBody = mailData.TextBody
                };
                email_Message.Body = emailBodyBuilder.ToMessageBody();
                //this is the SmtpClient class from the Mailkit.Net.Smtp namespace, not the System.Net.Mail one
                SmtpClient MailClient = new();
                MailClient.CheckCertificateRevocation = false;
                await MailClient.ConnectAsync(mailSettings.Value.Host, mailSettings.Value.Port, mailSettings.Value.UseSSL).ConfigureAwait(false);
                await MailClient.AuthenticateAsync(mailSettings.Value.EmailId, mailSettings.Value.Password).ConfigureAwait(false);
                await MailClient.SendAsync(email_Message).ConfigureAwait(false);
                await MailClient.DisconnectAsync(true).ConfigureAwait(false);
                MailClient.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                // Exception Details
                return false;
            }
        }
    }
}
