using PaperWards.API;
using PaperWards.GameEngine;

CancellationTokenSource cts = new();
var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddScoped<IEngine, Engine>();

var webApp = new RequestHandler();
var app = builder.Build();

app.MapPost("/start",ctx => { return webApp.StartGame(ctx); });

app.Run();

await Task.Delay(Timeout.Infinite, cts.Token).ConfigureAwait(false);