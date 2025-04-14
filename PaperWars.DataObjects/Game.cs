namespace PaperWards.DataObjects;

public class Game
{
    public List<Player> Players { get; set; } = new();
    
    public List<Reporter> ReporterDeck { get; set; } = new();
    public List<NewsCard> NewsDeck { get; set; } = new();
    public List<NewsAgencyCard> NewsAgencyDeck { get; set; } = new();
    
    public List<Reporter> ReporterPool { get; set; }
    public List<NewsCard> NewsPool { get; set; }
    public List<NewsAgencyCard> NewsAgencyPool { get; set; }
}