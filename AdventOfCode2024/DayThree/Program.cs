using FileReader;
using System.Text.RegularExpressions;

namespace DayThree;

public class Program
{
    public static void Main(string[] args)
    {
        var filePath = "C:\\Users\\andre\\Desktop\\estudos C#\\AdventOfCode2024\\AdventOfCode2024\\DayThree\\input.txt";
        var fileReader = new FileReaderTool();
        var lines = fileReader.ReadFile(filePath);

        var input = "";
        foreach (var line in lines)
        {
            input += line;
        }

        string instructionsPattern = @"don't\(\).*?do\(\)";
        string withoutInstructions = Regex.Replace(input, instructionsPattern, "");

        string multiplyPattern = @"mul\((\d{1,3}),(\d{1,3})\)";
        var multiplyRegex = new Regex(multiplyPattern);
        var matches = multiplyRegex.Matches(withoutInstructions);

        int result = 0;
        foreach (Match match in matches)
        {
            var firstNumber = int.Parse(match.Groups[1].Value);
            var secondNumber = int.Parse(match.Groups[2].Value);
            result += firstNumber * secondNumber;
        }
        Console.WriteLine(result);
    }
}