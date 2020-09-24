using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace WebForumTestTask.Models
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // настройка логина, пароля отправителя
            var from = "WebForumTestTask@gmail.com";
            var pass = "W3bF0rumT3stTask";

            var client = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(from, pass),
                Timeout = 20000
            };

            // адрес и порт smtp-сервера, с которого мы и будем отправлять письмо
            //SmtpClient client = new SmtpClient("smtp.gmail.com", 587);

            //client.DeliveryMethod = SmtpDeliveryMethod.Network;
            //client.UseDefaultCredentials = false;
            //client.Credentials = new System.Net.NetworkCredential(from, pass);
            //client.EnableSsl = true;

            // создаем письмо: message.Destination - адрес получателя
            var mail = new MailMessage(from, message.Destination);
            mail.Subject = message.Subject;
            mail.Body = message.Body;
            mail.IsBodyHtml = true;

            return client.SendMailAsync(mail);
        }
    }
    public class UserManager : UserManager<User>
    {
        public UserManager(IUserStore<User> store) : base(store)
        {

        }
        public static UserManager Create(IdentityFactoryOptions<UserManager> options,
            IOwinContext context)
        {
            ForumContext db = context.Get<ForumContext>();
            UserManager manager = new UserManager(new UserStore<User>(db));
            manager.EmailService = new EmailService();
            manager.UserValidator = new UserValidator<User>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            return manager;
        }
    }
}