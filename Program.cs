namespace advent_of_code_2023;
using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        Day3.Run2();
    }
}

class Day3
{
    public static void Run1()
    {
        List<string> input = TextParser.ReadLines("./resources/day-3.txt");
        int result = 0;
        
        int numRows = input.Count();
        int numCols = input[0].Count();

        int i = 0;
        int j = 0;

        while (i < numRows)
        {
            while (j < numCols)
            {
                string digitString = "";
                bool isAdjacentToSymbol = false;
                while (j <numCols && char.IsDigit(input[i][j]))
                {
                    digitString += input[i][j];
                    isAdjacentToSymbol |= IsAdjacentToSymbol(input, i, j);
                    j += 1;
                }

                if (digitString.Count() > 0 && int.TryParse(digitString, out int digit))
                {
                    if (isAdjacentToSymbol)
                    {
                        result += digit;
                    }
                }

                j += 1;
            }

            i += 1;
            j = 0;
        }

        Console.WriteLine(result);
    }

    public static void Run2()
    {
        List<string> input = TextParser.ReadLines("./resources/day-3.txt");
        int result = 0;
        
        int numRows = input.Count();
        int numCols = input[0].Count();

        for (int i = 0; i < numRows; i++)
        {
            for (int j = 0; j < numCols; j++)
            {
                char character = input[i][j];
                if (IsSymbol(character))
                {
                    result += GearRatio(input, i, j);
                }
            }
        }

        Console.WriteLine("Result: " + result);
    }

    private static int GearRatio(List<string> input, int row, int col)
    {
        int numRows = input.Count();
        int numCols = input[0].Count();
       
        int i = row - 1;
        int j = col - 1;

        int ratio = 1;
        int numberOfAdjacentIntegers = 0;

        while (i < numRows && i <= row + 1)
        {
            j = col - 1;
            while (j < numCols && j <= col + 1)
            {
                char character = input[i][j];
                if (char.IsDigit(character))
                {
                    // Get full number 
                    if (TryGetInteger(input, i, j, out int value, out j))
                    {
                        // Console.WriteLine("Here: " + value);
                        ratio *= value;
                        numberOfAdjacentIntegers += 1;
                        if (numberOfAdjacentIntegers == 2) 
                        {
                            return ratio;
                        }
                    }
                }

                j++;
            }
            i++;
        }

        return 0;
    }

    private static bool TryGetInteger(List<string> input, int row, int col, out int result, out int endIndex)
    {   
        string digitString = "";
        int numCols = input[row].Count();

        // Get start 
        int i = col;
        while (i > 0 && char.IsDigit(input[row][i - 1]))
        {
            i--; 
        }

        while (i < numCols && char.IsDigit(input[row][i]))
        {
            digitString += input[row][i];
            i++;
        }

        
        if (int.TryParse(digitString, out result))
        {
            endIndex = i;
            return true;
        }
        else {
            endIndex = col;
            return false;
        }
    }

    private static bool IsSymbol(char character)
    {
        return !char.IsDigit(character) && character != '.';
    }

    private static bool IsAdjacentToSymbol(List<string> input, int row, int col)
    {
        int numRows = input.Count();
        int numCols = input[0].Count();

        for (int i = row - 1; i <= row + 1; i++)
        {
            for (int j = col - 1; j <= col + 1; j++)
            {
                if (i >= 0 && i < numRows && j >= 0 && j < numCols)
                {
                    if (IsSymbol(input[i][j]))
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }
}