namespace PaperWards.DataObjects;

public class Player
{
    public string Name { get; set; }
    public bool Passed { get; set; }

    public void ClaimNews(Game game)
    {
        throw new NotImplementedException();
    }
}