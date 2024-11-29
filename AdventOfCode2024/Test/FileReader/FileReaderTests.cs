using FileReader;
using FluentAssertions;
using Xunit;

namespace Test.FileReader;

public class FileReaderTests
{
    private readonly FileReaderTool reader = new();
    private const string filePath = "C:\\Users\\andre\\Desktop\\estudos C#\\AdventOfCode2024\\" +
            "AdventOfCode2024\\Test\\FileReader\\TestFile.txt";
    private const string emptyFilePath = "C:\\Users\\andre\\Desktop\\estudos C#\\AdventOfCode2024\\" +
        "AdventOfCode2024\\Test\\FileReader\\TestEmptyFile.txt";

    [Fact]
    public void ReadFile_WithExistingFullFilledTextFile_ShouldReadLineByLineCorrectly()
    {
        var result = reader.ReadFile(filePath);

        result.Should().NotBeNull();
        result.Should().NotBeEmpty();
        result.Count.Should().Be(7);
        var expectedResult = File.ReadLines(filePath);
        result.Should().BeEquivalentTo(expectedResult);
    }

    [Fact]
    public void ReadFile_WithExistingEmptyTextFile_ShouldThrowException()
    {
        reader.Invoking(r => r.ReadFile(emptyFilePath))
            .Should()
            .ThrowExactly<Exception>()
            .WithMessage("The current file is empty.");
    }
}
