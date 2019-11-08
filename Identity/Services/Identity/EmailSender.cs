using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Identity.Services.Identity
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {

            var message = new MailMessage("info@toplearnfile.ir", email, subject, htmlMessage)
            {
                IsBodyHtml = true,
                BodyEncoding = Encoding.UTF8,

            };

            var smtpClient = new SmtpClient("mail.toplearnfile.ir")
            {
                UseDefaultCredentials = false,
                Port = 587,
                Credentials = new NetworkCredential("info@toplearnfile.ir", "13667051"),
                DeliveryMethod = SmtpDeliveryMethod.Network
            };

            return smtpClient.SendMailAsync(message);
        }
    }
}