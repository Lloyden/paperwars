using PaperWards.API;
using PaperWards.GameEngine;

CancellationTokenSource cts = new();
var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddScoped<IEngine, Engine>();

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

var webApp = new RequestHandler();
var app = builder.Build();

app.MapGet("/ping", webApp.Ping); 
app.MapPost("/start",ctx => webApp.StartGame(ctx));

app.Run();

await Task.Delay(Timeout.Infinite, cts.Token).ConfigureAwait(false);