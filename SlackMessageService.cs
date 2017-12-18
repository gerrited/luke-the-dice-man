using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class SlackMessageService{
    private string Url { get; }

    public SlackMessageService(string url)
    {
        Url = url;
        //Url = "https://hooks.slack.com/services/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";
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