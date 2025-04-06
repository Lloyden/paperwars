using PaperWards.DataObjects;
using PaperWars.Client;

const string startUrl = "https://localhost:5001/start";

//Start a one-player game
var game = new Game{
    Players = new List<Player>{ new Player{Name = "Lloyd"}}
};
game = await RestHelper.CallAsync<Game>(HttpMethod.Post, startUrl, game);