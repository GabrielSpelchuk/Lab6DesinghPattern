using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

delegate List<string> Strategy(List<string> data);

class Program
{
    static List<string> NormalSort(List<string> data)
    {
        var sorted = new List<string>(data);
        sorted.Sort();
        return sorted;
    }

    static List<string> ReverseSort(List<string> data)
    {
        var sorted = new List<string>(data);
        sorted.Sort();
        sorted.Reverse();
        return sorted;
    }

    static void doBusinessLogic(Strategy strategy)
    {
        Console.WriteLine("Context: Sorting data using the strategy (functional style)");
        var result = strategy(new List<string> { "a", "b", "c", "d", "e" });
        Console.WriteLine(string.Join(",", result));
    }

    static void Main()
    {
        Console.WriteLine("Client: Strategy is set to normal sorting.");
        doBusinessLogic(NormalSort);

        Console.WriteLine();

        Console.WriteLine("Client: Strategy is set to reverse sorting.");
        doBusinessLogic(ReverseSort);
    }
}