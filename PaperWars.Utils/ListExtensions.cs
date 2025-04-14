namespace PaperWars.Utils;

public static class ListExtensions
{
    public static void Shuffle<T>(this IList<T> list)  
    {  
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
            (list[k], list[n]) = (list[n], list[k]);
        }
    }
    
    public static List<T> Draw<T>(this IList<T> list, int count)
    {
        var drawnItems = new List<T>();
        for (int i = 0; i < count; i++)
        {
            if (list.Count == 0) break;
            drawnItems.Add(list[0]);
            list.RemoveAt(0);
        }
        return drawnItems;
    }
}
