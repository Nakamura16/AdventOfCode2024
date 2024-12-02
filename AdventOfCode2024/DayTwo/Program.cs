using FileReader;

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
            var numbers = line.Split(" ");

            bool isDecreasing = int.Parse(numbers[0]) > int.Parse(numbers[1]);
            
            for (var i = 0; i < numbers.Length; i++)
            {
                if (i == numbers.Length - 1)
                {
                    bool isLastOrderEqual = int.Parse(numbers[i-1]) > int.Parse(numbers[i]) == isDecreasing;
                    var lastLevel = Math.Abs(int.Parse(numbers[0]) - int.Parse(numbers[1]));
                    var isLastLevelSafe = lastLevel == 1 | lastLevel == 2 || lastLevel == 3;
                    if (isLastOrderEqual && isLastLevelSafe) 
                    {
                        result++; 
                        break;
                    }
                }
                bool isOrderEqual = int.Parse(numbers[i]) > int.Parse(numbers[i+1]) == isDecreasing;
                var level = Math.Abs(int.Parse(numbers[i]) - int.Parse(numbers[i+1]));
                var isLevelSafe = level == 1 | level == 2 || level == 3;
                if (isOrderEqual && isLevelSafe)
                {
                    continue;
                }
                else
                {
                    break;
                }
            }
        }
        Console.WriteLine(result);
    } 
}