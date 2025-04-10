using PaperWars.Utils;

namespace PaperWards.DataObjects;

public class NewsCard
{
    public NewsCategory NewsCategory { get; set; }
    public int NewsValue { get; set; }
    public int RequiredReporterLevel { get; set; }
    public int ReputationAjustment { get; set; }
    
    public static List<NewsCard> CreateDeck()
    {
        var cards = new List<NewsCard>();
        for (int c = 0; c < Enum.GetNames(typeof(NewsCategory)).Length-2; c++)
        {
            for(int i = 0; i < Constants.NumNewsCardPerCategory; i++)
            {
                var card = new NewsCard()
                {
                    NewsCategory = (NewsCategory)c,
                    NewsValue = Constants.NewsValues[c][i],
                    RequiredReporterLevel = Constants.RequiredReporterLevel[c][i],
                    ReputationAjustment = Constants.ReputationAjustment[c][i]
                };
                cards.Add(card);
            }   
        }

        cards.Shuffle();

        return cards;
    }
}

public enum NewsCategory
{
    Politics = 0,
    Sports = 1,
    Culture = 2,
    Local = 3,
    Economy = 4,
    Foreign = 5, 
    None = 99
}