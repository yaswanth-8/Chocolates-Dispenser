using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
class Program
{
    public static Dictionary<string, int> chocolates = new Dictionary<string, int> {
        {"green", 0},
        {"blue", 0},
        {"red", 0},
        {"pink", 0}
    };
    public static Stack<String> dispenserStack = new Stack<String>();   //to maintain pushing order
    public void addChocolates(string color, int count)
    {
        chocolates[color] += count;
        for(int i = 0; i < count; i++)
        {
            dispenserStack.Push(color);
        }
       
    }
    
    public static void display()
    {
        while (dispenserStack.Count > 0)
            Console.Write(dispenserStack.Pop() + ",");
    }
    public static void Main(string[] args)
    {
        Program dispenser = new Program();

        dispenser.addChocolates("green", 2);
        dispenser.addChocolates("red", 2);

        display();
    }
}