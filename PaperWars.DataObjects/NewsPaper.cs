namespace PaperWards.DataObjects;

public class NewsPaper
{
    public string Name { get; set; }
    public PaperLevel PaperLevel { get; set; }

    public int NewsSlots
    {
        get
        {
            switch (PaperLevel)
            {
                case PaperLevel.Local: return 3;
                case PaperLevel.City: return 6;
                case PaperLevel.National: return 8;
                case PaperLevel.International: return 9;
                case PaperLevel.Empire: return 10;
                default: throw new NotImplementedException();
            }
        }
    }

    public int RequiredEdition { get; set; }
    public int MaxAdvertisements { get; set; }
    public int MaxInserts { get; set; }
    public int MinNews { get; set; }
    public int RequiredReporterLevel { get; set; }
}

public enum PaperLevel
{
    Local,
    City,
    National,
    International,
    Empire
}

public enum PaperTemplate
{
    WashingtonPost,
    TheSun,
    TheNewYorker,
    AlJazeera,
    LeMonde,
    TheGuardian,
}