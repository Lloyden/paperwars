using PaperWars.Utils;

namespace PaperWards.DataObjects;

public class NewsCard
{
    private static readonly List<List<int>> NewsValues =
    [
        new List<int> { 0, 2, 4, 6, 7, 9, 10, 12, 13, 14, 15, 16, 17, 18, 18, 19, 19, 20, 20, 20 }, // Politics
        new List<int> { 0, 2, 4, 6, 7, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 19, 20, 20, 20 }, // Sports
        new List<int> { 0, 0, 1, 1, 1, 1, 2, 2, 3, 4, 5, 6, 7, 8, 10, 11, 13, 14, 18, 20 }, // Culture
        new List<int> { 0, 1, 2, 2, 3, 3, 4, 4, 4, 5, 5, 5, 6, 6, 6, 7, 8, 9, 9, 10 }, // Local
        new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 }, // Economy
        new List<int> { 0, 0, 0, 2, 3, 4, 5, 6, 7, 8, 10, 11, 12, 13, 14, 15, 16, 17, 19, 20 } // Foreign
    ];
    
    private static readonly List<List<int>> RequiredReporterLevels =
    [
        new List<int> { 2, 2, 2, 2, 4, 4, 4, 4, 6, 6, 8, 8, 10, 10, 12, 12, 14, 16, 18, 20 }, // Politics
        new List<int> { 0, 0, 1, 1, 3, 3, 5, 5, 7, 7, 8, 8, 10, 12, 14, 16, 18, 18, 20, 20 }, // Sports
        new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 20 }, // Culture
        new List<int> { 0, 0, 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 5, 5, 5 }, // Local
        new List<int> { 2, 2, 2, 2, 4, 4, 4, 4, 6, 6, 6, 8, 8, 10, 10, 12, 14, 16, 18, 20 }, // Economy
        new List<int> { 4, 4, 6, 6, 8, 8, 10, 10, 10, 12, 12, 12, 14, 14, 16, 16, 18, 18, 20, 20 } // Foreign
    ];
    
    private static readonly List<List<int>> ReputationAjustments =
    [
        new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 1, -1, 1, 2, 2 }, // Politics
        new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, -1, 1 }, // Sports
        new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, -1, 1, -1, 1 }, // Culture
        new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // Local
        new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1 }, // Economy
        new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, -1, 1 } // Foreign
    ];
    
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
                    NewsValue = NewsValues[c][i],
                    RequiredReporterLevel = RequiredReporterLevels[c][i],
                    ReputationAjustment = ReputationAjustments[c][i]
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