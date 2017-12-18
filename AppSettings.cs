using System.Collections.Generic;

public class AppSettings
{
    public string PostTextUrl { get; set; }

    public List<SlackPerson> Persons { get; set; }

    public List<MessageText> Messages { get; set; }
}