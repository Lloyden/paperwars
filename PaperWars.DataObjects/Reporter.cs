using Microsoft.Extensions.Configuration;
using PaperWars.Utils;

namespace PaperWards.DataObjects;

public class Reporter
{
    public ReporterLevel ReporterLevel { get; set; }
    public int Experience { get; set; }
    public NewsCategory Speciality { get; set; }

    public static List<Reporter> CreateDeck()
    {
        var reporters = new List<Reporter>();
        for(int i = 0; i < Constants.NumRookies; i++)
        {
            var reporter = new Reporter
            {
                ReporterLevel = ReporterLevel.Rookie,
                Experience = 0,
                Speciality = NewsCategory.None
            };
            reporters.Add(reporter);
        }

        reporters.Shuffle();

        return reporters;
    }
}

public enum ReporterLevel
{
    Rookie = 1,
    Journalist = 5,
    Reporter = 10,
    Veteran = 15,
    StarReporter = 20
}