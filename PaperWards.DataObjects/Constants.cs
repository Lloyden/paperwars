namespace PaperWards.DataObjects;

public static class Constants
{
    public const int NumRookies = 27;
    public const int NumNewsCardPerCategory = 20;

    public static readonly List<List<int>> NewsValues = new List<List<int>>{
        new List<int> { 0, 2, 4, 6, 7, 9, 10, 12, 13, 14, 15, 16, 17, 18, 18, 19, 19, 20, 20, 20 }, // Politics
        new List<int> { 0, 2, 4, 6, 7, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 19, 20, 20, 20 }, // Sports
        new List<int> { 0, 0, 1, 1, 1, 1, 2, 2, 3, 4, 5, 6, 7, 8, 10, 11, 13, 14, 18, 20 }, // Culture
        new List<int> { 0, 1, 2, 2, 3, 3, 4, 4, 4, 5, 5, 5, 6, 6, 6, 7, 8, 9, 9, 10 }, // Local
        new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 }, // Economy
        new List<int> { 0, 0, 0, 2, 3, 4, 5, 6, 7, 8, 10, 11, 12, 13, 14, 15, 16, 17, 19, 20 }, // Foreign
    };
    
    public static readonly List<List<int>> RequiredReporterLevel = new List<List<int>>{
        new List<int> { 2, 2, 2, 2, 4, 4, 4, 4, 6, 6, 8, 8, 10, 10, 12, 12, 14, 16, 18, 20 }, // Politics
        new List<int> { 0, 0, 1, 1, 3, 3, 5, 5, 7, 7, 8, 8, 10, 12, 14, 16, 18, 18, 20, 20 }, // Sports
        new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 20 }, // Culture
        new List<int> { 0, 0, 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 5, 5, 5 }, // Local
        new List<int> { 2, 2, 2, 2, 4, 4, 4, 4, 6, 6, 6, 8, 8, 10, 10, 12, 14, 16, 18, 20 }, // Economy
        new List<int> { 4, 4, 6, 6, 8, 8, 10, 10, 10, 12, 12, 12, 14, 14, 16, 16, 18, 18, 20, 20 }, // Foreign
    };
    
    public static readonly List<List<int>> ReputationAjustment = new List<List<int>>{
        new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 1, -1, 1, 2, 2 }, // Politics
        new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, -1, 1 }, // Sports
        new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, -1, 1, -1, 1 }, // Culture
        new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // Local
        new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1 }, // Economy
        new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, -1, 1 }, // Foreign
    };
}