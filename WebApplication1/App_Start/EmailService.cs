using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;

namespace WebApplication1
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Подключите здесь службу электронной почты для отправки сообщения электронной почты.
            return Task.FromResult(0);
        }
    }

    // Настройка диспетчера пользователей приложения. UserManager определяется в ASP.NET Identity и используется приложением.

    // Настройка диспетчера входа для приложения.
}
