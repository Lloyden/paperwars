using System.Net.Http.Headers;
using System.Text;
using PaperWars.Utils;

namespace PaperWars.Client;

public class RestHelper
{
    public static async Task<T> CallAsync<T>(HttpMethod method, string url, object request = null)
    {
        var body = request != null ? SerializationHelper.SerializeToCamelCaseJson(request) : null;
        return await ResponseCheckAsync<T>(await MakeCallAsync(url, method, body));
    }
    
    private static bool Fail(string reason)
    {
        Console.WriteLine($"FAIL: {reason}");
        return false;
    }

    private static async Task<HttpResponseMessage> MakeCallAsync(string url, HttpMethod method, string body = null)
    {
        HttpClientHandler clientHandler = new HttpClientHandler();
        clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

        // Pass the handler to httpclient(from you are calling api)
        HttpClient client = new HttpClient(clientHandler);
        client.DefaultRequestHeaders
            .Accept
            .Add(new MediaTypeWithQualityHeaderValue("application/json")); //ACCEPT header
        
        var request = new HttpRequestMessage
        {
            Method = method,
            RequestUri = new Uri(url),
            Headers = { 
                { "Accept", "*/*" },
                { "Connection", "keep-alive" },
                { "User-Agent", "Rider" },
                { "Accept-Encoding", "gzip,deflate,br" }
            }
        };
        
        if (body != null)
            request.Content = new StringContent(body, Encoding.UTF8, "application/json"); //CONTENT-TYPE header
        
        return await client.SendAsync(request);
    }
    
    private static async Task<T> ResponseCheckAsync<T>(HttpResponseMessage response)
    {
        if (response == null)
            Fail("Inget responseobjekt från tjänsten");
        // else if (response.StatusCode != HttpStatusCode.OK)
        //     Fail($"HttpStatus = {response.StatusCode}: {response.ReasonPhrase}");
        //osv...
        else
        {
            var responseObject = SerializationHelper.DeserializeJsonWeb<T>(await response.Content.ReadAsStringAsync());
            if (responseObject == null)
                Fail("Inget svarsobjekt kunde deserializeras från tjänsten");
            else 
                return responseObject;   
        }

#pragma warning disable CS8603 // Possible null reference return.
        return default(T);
#pragma warning restore CS8603 // Possible null reference return.
    }
}