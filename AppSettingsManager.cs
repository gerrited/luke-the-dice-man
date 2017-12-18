using System.IO;
using Newtonsoft.Json;

public class AppSettingsManager{
    public AppSettings Get(string path) => JsonConvert.DeserializeObject<AppSettings>(File.ReadAllText(path));

    public void Set(string path, AppSettings settings){
        File.WriteAllText(path, JsonConvert.SerializeObject(settings));
    }
}