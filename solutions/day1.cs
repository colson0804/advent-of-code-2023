namespace advent_of_code_2023;

class Day1
{
    private static string ExtractTwoDigitNumber(string line)
    {
        string twoDigitNumber = "";
        int i = 0;
        for (i = 0; i < line.Length; i++)
        {
            if (int.TryParse(line[i].ToString(), out int resultTryParse))
            {
                twoDigitNumber += line[i];
                break;
            }
        }

        for (int j = line.Length - 1; j >= 0; j--)
        {
            if (int.TryParse(line[j].ToString(), out int resultTryParse))
            {
                twoDigitNumber += line[j];
                break;
            }
        }

        return twoDigitNumber;
    }
    
    public static void Part1()
    {
        List<string> input = TextParser.ReadLines("./resources/day-1.txt");
        int sum = 0;
        foreach (string line in input)
        {
            string twoDigitNumber = ExtractTwoDigitNumber(line);
            if (int.TryParse(twoDigitNumber, out int value))
            {
                sum += value;
            }
        }

        Console.WriteLine(sum);
    }

    public static void Part2() 
    {
        Dictionary<string, int> words = new Dictionary<string, int>()
        {
            ["one"] = 1,
            ["two"] = 2,
            ["three"] = 3,
            ["four"] = 4,
            ["five"] = 5,
            ["six"] = 6,
            ["seven"] = 7,
            ["eight"] = 8,
            ["nine"] = 9
        };

        List<string> input = TextParser.ReadLines("./resources/day-1.txt");
        int sum = 0;
        foreach (string line in input)
        {
            string twoDigitNumber = "";

            int i = 0;
            for (i = 0; i < line.Length; i++)
            {
                if (int.TryParse(line[i].ToString(), out int resultTryParse))
                {
                    twoDigitNumber += line[i];
                    break;
                }
                else
                {
                    string substring = line.Substring(i);
                    bool isInDict = false;
                    foreach (var kvp in words)
                    {
                        if (substring.StartsWith(kvp.Key))
                        {
                            twoDigitNumber += kvp.Value.ToString();
                            isInDict = true;
                            break;
                        }
                    }

                    if (isInDict) 
                    {
                        break;
                    }
                }
            }

            for (int j = line.Length - 1; j >= 0; j--)
            {
                if (int.TryParse(line[j].ToString(), out int resultTryParse))
                {
                    twoDigitNumber += line[j];
                    break;
                }
                else
                {
                    string substring = line.Substring(j);
                    bool isInDict = false;
                    foreach (var kvp in words)
                    {
                        if (substring.StartsWith(kvp.Key))
                        {
                            twoDigitNumber += kvp.Value.ToString();
                            isInDict = true;
                            break;
                        }
                    }

                    if (isInDict) 
                    {
                        break;
                    }
                }
            }

            if (int.TryParse(twoDigitNumber, out int value))
            {
                sum += value;
            }
        }

        Console.WriteLine(sum);
    }
}
