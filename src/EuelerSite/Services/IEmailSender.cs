using Contract;
using System.Threading.Tasks;

namespace EuelerSite.Services
{
    public interface IEmailSender : IDependency
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
