using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using SupportRegister.Application.Interfaces;
using SupportRegister.ViewModels.Requests.Mail;
using System.Threading.Tasks;

namespace SupportRegister.Application.Services
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }
        public async Task SendEmailAsync(MailRequest mailRequest)
        {

            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse("hype.hotro@gmail.com");

            //email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();
            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("hype.hotro@gmail.com", "wsnvkoddenhhawvc");
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }
}
