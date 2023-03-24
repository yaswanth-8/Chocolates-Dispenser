using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Drawing;

class Program
{
    public static Dictionary<string, int> chocolates = new Dictionary<string, int> {
        {"green", 0},
        {"blue", 0},
        {"red", 0},
        {"pink", 0}
    };
    public static int chocolateCount=0;
    public static Stack<String> dispenserStack = new Stack<String>();   //to maintain pushing order
    public void addChocolates(string color, int count)
    {
        chocolates[color] += count;
        chocolateCount = count + chocolateCount;
        for(int i = 0; i < count; i++)
        {
            dispenserStack.Push(color);   //adding in order to stack
        }
       
    }
    public void removeChocolates(int count)
    {
        Console.WriteLine("remove items from top---------");
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(dispenserStack.Pop());   
        }
        Console.WriteLine("-------------------------------");
        Console.WriteLine("");
    }

    static void dispenseChocolatesOfColor(string color)
    {
        int colorCOunt = chocolates[color];
        for(int i=0;i<colorCOunt; i++)
        {
            Console.WriteLine(color);
        }
    }

    public static void display()
    {
        Console.WriteLine("chocolate in dispenser ------------");
        foreach (string i in dispenserStack)
        {
            Console.WriteLine(i);
        }
        Console.WriteLine("---------------------------------");
        Console.WriteLine("");
    }

    public static void dispenseChocolates(int num)
    {
        Console.WriteLine("chocolates at bottom based on count -----");
        int start = chocolateCount - num;
        int ctne = 0;
        foreach (string i in dispenserStack)
        {
            ctne++;
            if (ctne > start)
            {
                Console.WriteLine(i);
            }
        }
        Console.WriteLine("------------------------------------");
        Console.WriteLine("");
    }
    public static void Main(string[] args)
    {
        Program dispenser = new Program();

        dispenser.addChocolates("green", 2);
        dispenser.addChocolates("red", 2);
        dispenseChocolates(3);
        //dispenseChocolatesOfColor("green");
    }
}