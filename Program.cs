namespace advent_of_code_2023;
using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        Day2.Run2();
    }
}


class Day2
{
    public static void Run1()
    {
        List<string> input = TextParser.ReadLines("./resources/day-2.txt");

        int result = 0;
        int index = 1;
        foreach (string line in input)
        {
            if (isGameValid(line))
            {
                result += index;
            }

            index += 1;
        }

        Console.WriteLine("Result: " + result);
    }

    private static bool isGameValid(string line)
    {
        Dictionary<string, int> colors = new Dictionary<string, int>
        {
            { "red", 12 },
            { "green", 13 },
            { "blue", 14 }
        };

        string game = line.Split(": ")[1];
        string[] draws = game.Split("; ");

        foreach (string draw in draws)
        {
            string[] cubes = draw.Split(", ");
            foreach (string cube in cubes)
            {
                string[] splitCube = cube.Split(" ");
                string color = splitCube[1];
                int value = Int32.Parse(splitCube[0]);

                if (colors.TryGetValue(color, out int result))
                {
                    if (value > result)
                    {
                        return false;
                    }
                }
                else 
                {
                    Console.WriteLine("Value not in dictionary");
                }
            }
        }

        return true;
    }

    public static void Run2()
    {
        List<string> input = TextParser.ReadLines("./resources/day-2.txt");
        int result = 0;
        foreach (string line in input)
        {
            result += Power(line);
        }

        Console.WriteLine("Result: " + result);
    }

    private static int Power(string line)
    {
        Dictionary<string, int> minDictionary = new Dictionary<string, int>
        {
            { "red", 0 },
            { "green", 0 },
            { "blue", 0 }
        };

        string game = line.Split(": ")[1];
        string[] draws = game.Split("; ");

        foreach (string draw in draws)
        {
            string[] cubes = draw.Split(", ");
            foreach (string cube in cubes)
            {
                string[] splitCube = cube.Split(" ");
                string color = splitCube[1];
                int value = Int32.Parse(splitCube[0]);

                if (minDictionary.TryGetValue(color, out int result))
                {
                    minDictionary[color] = Math.Max(value, result);
                }
                else 
                {
                    Console.WriteLine("Value not in dictionary");
                }
            }
        }

        return minDictionary.Values.Aggregate(1, (acc, value) => acc * value);
    }
}