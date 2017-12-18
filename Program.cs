using System;
using System.Linq;
using System.Threading.Tasks;

namespace slackbot_test
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();
        }

        private static async Task RunAsync()
        {
            var settings = new AppSettingsManager().Get("AppSettings.json");

            var pair = settings.Persons.OrderBy(i => Guid.NewGuid()).Take(2).ToArray();
            var message = (pair.All(i => i.AllMessages) ? settings.Messages : settings.Messages.Where(i => i.Clean)).
                OrderBy(i => Guid.NewGuid()).First();

            var messageService = new SlackMessageService(settings.PostTextUrl);
            await messageService.SendAsync(string.Format(message.Text, pair.First().UserId, pair.Last().UserId));
        }
    }
}