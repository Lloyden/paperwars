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
}

public static class ThreadSafeRandom
{
    [ThreadStatic] private static Random Local;

    public static Random ThisThreadsRandom
    {
        get { return Local ?? (Local = new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId))); }
    }
}
