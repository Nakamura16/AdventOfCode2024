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

        string pattern = @"mul\((\d{1,3}),(\d{1,3})\)";

        int result = 0;
        var regex = new Regex(pattern);
        foreach (var line in lines) 
        {
            var matches = regex.Matches(line);
            foreach (Match match in matches) 
            {
                var firstNumber = int.Parse(match.Groups[1].Value);
                var secondNumber = int.Parse(match.Groups[2].Value);
                result += firstNumber * secondNumber;
            }
        }
        Console.WriteLine(result);
    }
}