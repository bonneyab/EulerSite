using Contract;
using System.Threading.Tasks;

namespace EuelerSite.Services
{
    public interface ISmsSender : IDependency
    {
        Task SendSmsAsync(string number, string message);
    }
}
