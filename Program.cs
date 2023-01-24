var sample = new Link(new Dictionary<string, string> {} );

MassTransit.Serialization.SystemTextJsonMessageSerializer.Options.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;

var sendContext = new MassTransit.InMemoryTransport.InMemorySendContext<Link>(sample);

sendContext.Serializer = MassTransit.Serialization.SystemTextJsonMessageSerializer.Instance;

var body = sendContext.Body.GetString();

var message = System.Text.Json.JsonDocument.Parse(body).RootElement.GetProperty("message").ToString();

Console.WriteLine(typeof(MassTransit.Serialization.SystemTextJsonMessageSerializer).AssemblyQualifiedName);

Console.WriteLine(message);

public class Link
{
    private ICollection<KeyValuePair<string, string>> headers;

    [System.Text.Json.Serialization.JsonConstructor]
    public Link(ICollection<KeyValuePair<string, string>> headers = null)
    {
        this.headers = headers ?? new List<KeyValuePair<string, string>>();
    }
    public ICollection<KeyValuePair<string, string>> Headers
    {
        get
        {
            return headers;
        }
        set { headers = value; }
    }
}