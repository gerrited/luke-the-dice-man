using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class SlackMessageService{
    private string Url { get; }

    public SlackMessageService(string url)
    {
        Url = url;
    }

    public async Task SendAsync(string message){
        var slackMessage = new { 
            text = message
        };

        var content = new StringContent(JsonConvert.SerializeObject(slackMessage), Encoding.UTF8, "application/json");

        using (var client = new HttpClient())
            await client.PostAsync(Url, content);
    }
}