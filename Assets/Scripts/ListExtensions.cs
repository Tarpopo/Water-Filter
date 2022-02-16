using System.Collections.Generic;
public static class ListExtensions
{
    public static T GetNextItem<T>(this List<T> list,int currentIndex)
    {
        return currentIndex + 1 >= list.Count-1?list[currentIndex+1]:list[0];
    }
    public static int GetNextIndex<T>(this List<T> list,int currentIndex)
    {
        return currentIndex + 1 < list.Count?currentIndex+1:0;
    }
}
