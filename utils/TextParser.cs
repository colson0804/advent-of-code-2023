namespace advent_of_code_2023;

class TextParser
{
    public static List<string> ReadLines(string filePath)
    {
        List<string> result = new List<string>();

        try
        {
            result.AddRange(File.ReadAllLines(filePath));
        }
        catch (Exception e)
        {
            Console.WriteLine("An error occurred: " + e.Message);
        }

        return result;
    }
}