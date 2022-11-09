using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MimeKit;
using SupportRegister.Application.Interfaces;
using SupportRegister.Data.EF;
using SupportRegister.ViewModels.Requests.Mail;
using SupportRegister.ViewModels.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace SupportRegister.Application.Services
{
    public class MailService : IMailService
    {
        protected ProjectSupportRegisterContext _context;
        private readonly MailSettings _mailSettings;
        public MailService(ProjectSupportRegisterContext context, IOptions<MailSettings> mailSettings)
        {
            _context = context;
            _mailSettings = mailSettings.Value;
        }
        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            var mailfeedback = await _context.EmailAdmins
                .Where(x => x.Id == 2)
                .Select(app => new EmailAdminViewModel()
                {
                    Id = app.Id,
                    Name = app.Name,
                    EmailAdmin1 = app.EmailAdmin1,
                    Password = app.Password,
                }).FirstOrDefaultAsync();
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(mailfeedback.EmailAdmin1);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();
            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(mailfeedback.EmailAdmin1, mailfeedback.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }

        public async Task SendEmailAdminAsync(MailRequest mailRequest)
        {
            var mailfeedback = await _context.EmailAdmins
                .Where(x => x.Id == 1)
                .Select(app => new EmailAdminViewModel()
                {
                    Id = app.Id,
                    Name = app.Name,
                    EmailAdmin1 = app.EmailAdmin1,
                    Password = app.Password,
                }).FirstOrDefaultAsync();
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(mailfeedback.EmailAdmin1);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();
            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(mailfeedback.EmailAdmin1, mailfeedback.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }
}
