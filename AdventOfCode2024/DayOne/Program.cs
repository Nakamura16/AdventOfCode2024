using FileReader;

namespace DayOne;

public class Program
{
    public static void Main(string[] args)
    {
        var fileReader = new FileReaderTool();
        var filepath = "C:\\Users\\andre\\Desktop\\estudos C#\\AdventOfCode2024\\AdventOfCode2024\\DayOne\\input.txt";
        var lines = fileReader.ReadFile(filepath);

        var rightNumbers = new List<int>();
        var leftNumbers = new List<int>();

        foreach (var line in lines) 
        {
            var columns = line.Split("   ");
            leftNumbers.Add(int.Parse(columns[0]));
            rightNumbers.Add(int.Parse(columns[1]));
        }

        int result = 0;
        foreach (var number in leftNumbers) 
        {
            var quantityOfAppears = rightNumbers.Count(n => n == number);
            var similarity = number * quantityOfAppears;
            result += similarity;
        }

        Console.WriteLine(result);
    }
}
