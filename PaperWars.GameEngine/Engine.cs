using System.Runtime.InteropServices;
using PaperWards.DataObjects;
using PaperWars.Utils;

namespace PaperWards.GameEngine;

public interface IEngine
{
    void StartGame(Game game);
}
public class Engine : IEngine
{
    public Engine()
    {
    }
    
    public void StartGame(Game game)
    {
        game.ReporterDeck = Reporter.CreateDeck();
        game.NewsDeck = NewsCard.CreateDeck();
        game.NewsAgencyDeck = NewsAgencyCard.CreateDeck();

        game.ReporterPool = game.ReporterDeck.Draw(game.Players.Count);
        game.NewsPool = game.NewsDeck.Draw(game.Players.Count+1);
        game.NewsAgencyPool = game.NewsAgencyDeck.Draw(game.Players.Count+1);
    }

    public List<Player> SetTurnOrder(List<Player> players)
    {
        players.Shuffle();
        return players;
    }
}