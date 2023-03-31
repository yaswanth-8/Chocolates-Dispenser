using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Net.NetworkInformation;

class Program
{
    public static Dictionary<string, int> chocolates = new Dictionary<string, int> {
        {"green", 0},
        {"blue", 0},
        {"red", 0},
        {"pink", 0},
        {"crimson",0 },
        {"purple",0 },
        {"silver",0 }
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
        string removedChocolate;
        for (int i = 0; i < count; i++)
        {
           removedChocolate = dispenserStack.Pop();
            chocolates[removedChocolate]--;
        }
        Console.WriteLine("-------------------------------");
        Console.WriteLine("");
    }

    static void dispenseChocolatesOfColor(string color,int num)
    {
        //int colorCOunt = chocolates[color];
        chocolates[color] -= num;
        Stack<String> duplicateStack = new Stack<String>();
      
        foreach(string i in dispenserStack)
        {
            duplicateStack.Push(i);
        }
        dispenserStack.Clear(); 
        foreach(string i in duplicateStack)
        {
            if(i==color && num>0)
            {
                num--;
                continue;
            }
            
            dispenserStack.Push(i);
            
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
        //Console.WriteLine("chocolates at bottom based on count -----");
        int start = chocolateCount - num;
        int ctne = 0;
        Stack<String> duplicateStack = new Stack<String>();
        foreach (string i in dispenserStack)
        {
           
            ctne++;
            if (ctne > start)
            {
                //Console.WriteLine(i);
                chocolates[i]--;
            }
            else
            {
                duplicateStack.Push(i);
            }
        }
        
       // Console.WriteLine("step 2 completed");
        dispenserStack.Clear();
        foreach (string i in duplicateStack)
        {
            dispenserStack.Push(i);
            //Console.WriteLine(i);
        }
        
        duplicateStack.Clear();
        Console.WriteLine("------------------------------------");
        Console.WriteLine("");
    }

    public void noOfChocolates()
    {
        Console.WriteLine(chocolates["green"]);
        Console.WriteLine(chocolates["silver"]);
        Console.WriteLine(chocolates["blue"]);
        Console.WriteLine(chocolates["crimson"]);
        Console.WriteLine(chocolates["purple"]);
        Console.WriteLine(chocolates["red"]);
        Console.WriteLine(chocolates["pink"]);
    }

    public void sortChocolateBasedOnCount()
    {
        var sortedDict = from entry in chocolates orderby entry.Value descending select entry;

        foreach (var item in sortedDict)
        {
            Console.WriteLine("{0}: {1}", item.Key, item.Value);
        }

    }
    public void changeChocolateColorAllOfxCount(string oldColor,string newColor)
    {
        if (chocolates.ContainsKey(oldColor))
        {
            int value = chocolates[oldColor];  // get the value associated with "apple"
            chocolates.Remove(oldColor);  // remove the original key-value pair
            chocolates.Add(newColor, value);  // add a new key-value pair with the new key name and the same value
        }
        Stack<string> newStack = new Stack<string>();
        foreach (string color in dispenserStack)
        {
            if (color == oldColor)
            {
                newStack.Push(newColor);
            }
            else
            {
                newStack.Push(color);
            }
        }
        dispenserStack.Clear();
        foreach(string color in newStack)
        {
            dispenserStack.Push(color);
        }
        newStack.Clear();
    }

    public void removeChocolateOfColor(string chocolate)
    {
        if (chocolates[chocolate]>1)
        chocolates[chocolate]--;
        string outChocolate;
        Stack<string> newStack = new Stack<string>();
        while(dispenserStack.Count > 0)
        {
            outChocolate = dispenserStack.Pop();
            if ( outChocolate== chocolate)
            {
                break;
            }
            newStack.Push(outChocolate);
        }
        while(newStack.Count > 0)
        {
            dispenserStack.Push(newStack.Pop());
        }
    }

    public int dispenseRainbowChocolates()
    {
        int count = 0;
        foreach(KeyValuePair<string,int> pair in chocolates)
        {
            if(pair.Value >= 3)
            {
                count = count + (pair.Value) / 3;
            }
            
        }
        return count;
    }
    public static void Main(string[] args)
    {
        Program dispenser = new Program();

        dispenser.addChocolates("green", 3);
        dispenser.addChocolates("red", 2);
        dispenser.addChocolates("green", 1);
        dispenser.addChocolates("blue", 2);
        display();
        //dispenser.noOfChocolates();
        //dispenseChocolates(3);
       // dispenser.noOfChocolates();
        //dispenseChocolatesOfColor("green",2);

        //dispenser.noOfChocolates();
        //dispenser.removeChocolates(2);
        //dispenser.changeChocolateColorAllOfxCount("green", "white");
        //dispenser.removeChocolateOfColor("green");
        //dispenser.sortChocolateBasedOnCount();
        //Console.WriteLine(dispenser.dispenseRainbowChocolates());
        //display();

    }
}