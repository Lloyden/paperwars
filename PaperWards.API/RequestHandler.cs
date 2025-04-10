namespace PaperWards.API;

public class RequestHandler
{
    public bool Ping()
    {
        return true;
    }
    
    public Task StartGame(HttpContext ctx)
    {
        /*
         *  AccountRequest request;
                  using (var sr = new StreamReader(ctx.Request.Body))
                  {
                      //om man vill använda requestet
                      request = JsonSerializerHelper.DeserializeJsonWeb<AccountRequest>(await sr.ReadToEndAsync());
                  }
                  
                  await ctx.Response.WriteAsync(JsonSerializer.Serialize(GetAccountResponse(Tenant.SVS_LB)));
         */
        
        return ctx.Response.WriteAsync("Hello World!");
    }
}