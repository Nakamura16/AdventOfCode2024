namespace DayTwo;

internal class Report
{
    public List<int> Numbers{ get; set; }
    public bool IsSafe { get; private set; }

    public Report(List<int> numbers)
    {
        Numbers = numbers;
        IsSafe = false;
    }

    public void CheckIsSafe()
    {
        var IsDecreasing = Numbers[0] > Numbers[1];
        for (var i = 0; i < Numbers.Count; i++)
        {
            if (i == Numbers.Count - 1)
            {
                bool isLastOrderEqual = Numbers[i - 1] > Numbers[i] == IsDecreasing;
                var lastLevel = Math.Abs(Numbers[i - 1] - Numbers[i]);
                var isLastLevelSafe = lastLevel == 1 | lastLevel == 2 || lastLevel == 3;
                if (isLastOrderEqual && isLastLevelSafe)
                {
                    IsSafe = true;
                    break;
                }
            }
            bool isOrderEqual = Numbers[i] > Numbers[i + 1] == IsDecreasing;
            var level = Math.Abs(Numbers[i] - Numbers[i + 1]);
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
}
