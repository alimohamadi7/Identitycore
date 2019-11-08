using System.Threading.Tasks;
using Kavenegar;
using Microsoft.Extensions.Configuration;

namespace Identity.Services.Identity
{
    public class SmsSender : ISmsSender
    {
        private readonly IConfiguration _configuration;

        public SmsSender(IConfiguration configuration) => _configuration = configuration;

        public async Task SendSmsAsync(string phoneNumber, string message)
        {
            var sender = "1000596446";

            var apiKey = _configuration["SmsApiKey"];

            var kavnegarApi = new KavenegarApi(apiKey);

            var result = await kavnegarApi.Send(sender, phoneNumber, message);
        }
    }
}