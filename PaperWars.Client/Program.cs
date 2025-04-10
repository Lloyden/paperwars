using PaperWards.DataObjects;
using PaperWars.Client;

const string baseUrl = "https://localhost:5001";

//Vänta in uppstart
bool goodTogo = false;
while(!goodTogo)
{
    try
    { 
        var ping = await RestHelper.CallAsync<bool>(HttpMethod.Get, baseUrl+"/ping");
        if (ping)
            goodTogo = true;
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        await Task.Delay(100);
    }
}

//Start a one-player game
var game = new Game{
    Players = new List<Player>{ new Player{Name = "Lloyd"}}
};
game = await RestHelper.CallAsync<Game>(HttpMethod.Post, baseUrl+"/start", game);