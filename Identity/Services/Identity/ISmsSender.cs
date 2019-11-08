using System.Threading.Tasks;

namespace Identity.Services.Identity
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string phoneNumber, string message);
    }
}