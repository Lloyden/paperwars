using System.Net.Http.Headers;
using System.Text;
using PaperWars.Utils;

namespace PaperWars.Client;

public class RestHelper
{
    public static async Task<T> CallAsync<T>(HttpMethod method, string url, object request)
    {
        return await ResponseCheckAsync<T>(await MakeCallAsync(url, method, SerializationHelper.SerializeToCamelCaseJson(request)));
    }
    
    private static bool Fail(string reason)
    {
        Console.WriteLine($"FAIL: {reason}");
        return false;
    }

    private static async Task<HttpResponseMessage> MakeCallAsync(string url, HttpMethod method, string body = null, string cookie = null)
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
                { "Accept-Encoding", "gzip,deflate,br" },
                { "Host", "svenskaspel.se" }
            }
        };
        
        if(string.IsNullOrEmpty(cookie))
            request.Headers.Add("Cookie", "svssid=bc2e7159-7217-4e70-b654-2c8c49aa62c9; Path=/; Domain=retail.test3.svenskaspel.se; HttpOnly;");
        else
            request.Headers.Add("Cookie", cookie);
        
        if (body != null)
            request.Content = new StringContent(body, Encoding.UTF8, "application/json"); //CONTENT-TYPE header
        
        var response = await client.SendAsync(request);
        return response;
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