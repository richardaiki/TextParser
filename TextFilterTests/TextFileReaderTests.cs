using FluentAssertions;
using TextFilter;
using Xunit;

namespace TextFilterTests
{
    public class TextFileReaderTests
    {
        [Fact]
        public void TextFileReader_GivenTestFile_ReturnsCorrectArrayWords()
        {
            var reader = new TextFileReader();
            var path = "TestFile.txt";

            var result = reader.ConvertFileContents(path);

            result.Should().Be("This is a Test");
        }
    }
}
