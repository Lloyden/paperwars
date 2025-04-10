using PaperWards.DataObjects;
using PaperWards.GameEngine;

//Start a one-player game
var game = new Game{
    Players = new List<Player>{ new Player{Name = "Lloyd"}}
};
var engine = new Engine();

engine.StartGame(game);
