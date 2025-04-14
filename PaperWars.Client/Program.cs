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

foreach (var player in game.Players)
{
    if(!player.Passed)
        player.ClaimNews(game);
}
