using System.Runtime.InteropServices;
using PaperWards.DataObjects;

namespace PaperWards.GameEngine;

public interface IEngine
{
    void StartGame(Game game);
}
public class Engine : IEngine
{
    public Engine()
    {
        // Initialize any necessary components or services here
    }
    
    public void StartGame(Game game)
    {
        game.ReporterDeck = Reporter.CreateDeck();
        game.NewsDeck = NewsCard.CreateDeck();
        //throw new NotImplementedException();
    }
}