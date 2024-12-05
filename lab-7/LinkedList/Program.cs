namespace LinkedList;

public static class Program
{
    public static void Main(string[] args)
    {
        const float a = 10.5f;
        const float b = 2.6f;
        
        var list = new LinkedList();
        list.Add(0f);
        list.Add(10.2f);
        list.Add(12.8f);
        list.Add(0.6f);
        list.Add(1.2f);
        list.Add(11.4f);
        list.Add(2.8f);
        list.Add(1.2f);
        
        LinkedList.Print(list);
        
        // Task 1
        var found = list.Find(x => x.Value > a);
        Console.WriteLine($"found: {found?.Value}");
       
        // Task 2
        var sum = list.Where(x => x.Value < found?.Value).Sum();
        Console.WriteLine($"sum: {sum}");
        
        // Task 3
        var newList = list.Where(x => x.Value > a);
        LinkedList.Print(newList);
        
        // Task 4
        list.RemoveAll(list.Where(x => x.Value < b));
        LinkedList.Print(list);
    }
}