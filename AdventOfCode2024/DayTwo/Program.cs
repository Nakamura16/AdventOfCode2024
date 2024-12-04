using FileReader;
using System.Runtime.CompilerServices;

namespace DayTwo;

public class Program
{
    public static void Main(string[] args)
    {
        var filePath = "C:\\Users\\andre\\Desktop\\estudos C#\\AdventOfCode2024\\AdventOfCode2024\\DayTwo\\Input.txt";
        var fileReader = new FileReaderTool();
        var lines = fileReader.ReadFile(filePath);
        var result = 0;

        foreach (var line in lines)
        {
            var numbers = line.Split(" ")
                .Select(n => int.Parse(n))
                .ToList();

            var resport = new Report(numbers);
            resport.CheckIsSafe();

            if (resport.IsSafe)
            {
                result ++;
            }
            else
            {
                for (var i = 0; i < resport.Numbers.Count; i++)
                {
                    var dampenedReport = new Report(new List<int>(resport.Numbers));
                    dampenedReport.Numbers.RemoveAt(i);

                    dampenedReport.CheckIsSafe();
                    if (dampenedReport.IsSafe)
                    {
                        result++;
                        break;
                    }
                }
            }
        }
        Console.WriteLine(result);
    } 
}