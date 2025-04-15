using Konsole;
using PaperWards.DataObjects;
using PaperWards.GameEngine;

//Start a one-player game
var game = new Game{
    Players = new List<Player>{ new Player{ Name = "Lloyd" }}
};

var engine = new Engine();
game.Players = engine.SetTurnOrder(game.Players);
engine.StartGame(game);

//Game loop

var width = 40 * game.Players.Count;
var gameWindow = Window.OpenBox("Paper Wars");
var newsWindow = gameWindow.OpenBox("News Cards", 1, 1, width,7, LineThickNess.Double);
var newsAgencyWindow = gameWindow.OpenBox("NewsAgency Cards", 1, 11, width,7, LineThickNess.Double);
var reporterWindow = gameWindow.OpenBox("Reporter Pool", 1, 21, width,7, LineThickNess.Double);

foreach (var player in game.Players)
{
    showNewsCards();


    // showNewsAgencyCards();
    // showReporterPool();
    
    if(!player.Passed)
        player.ClaimNews(game);
}


void showNewsCards()
{
    var splits = new List<Split>();
    var i = 1;
    foreach (var card in game.NewsPool)
    {
        splits.Add(new Split(17,"("+ i++.ToString()+ ") " + card.NewsCategory.ToString()));
    }
    var cols = newsWindow.SplitColumns(splits.ToArray());

    for (int c = 0; c < cols.Length; c++)
    {
        var col = cols[c];
        col.WriteLine("News value: " + game.NewsPool[c].NewsValue);
        col.WriteLine("Reporter:   " + game.NewsPool[c].RequiredReporterLevel);
        col.WriteLine("Reputation: " + game.NewsPool[c].ReputationAjustment);
    }
}