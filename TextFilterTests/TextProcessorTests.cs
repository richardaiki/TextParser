using System.Collections.Generic;
using FluentAssertions;
using Moq;
using TextFilter;
using TextFilter.Interfaces;
using TextFilter.Strategies;
using Xunit;

namespace TextFilterTests
{
    public class TextProcessorTests
    {
        [Fact]
        public void TextProcessor_Process_CallsAStrategy()
        {
            var textProcessor = new TextProcessor();

            var strategies = new Dictionary<string, IStrategyAction>
            {
                {"key", new WordsGivenLetterStrategy('t')}
            };

            var mockStrategy = new Mock<IStrategyAction>();
            mockStrategy.Setup(x => x.Process(It.IsAny<IList<string>>()));

            textProcessor.Process(new List<string>{ "a", "word" }, strategies);

            mockStrategy.Verify();
        }

        [Fact]
        public void TextProcessor_Split_SplitsStringByChar()
        {
            var textProcessor = new TextProcessor();

            var result = textProcessor.Split("raw string");

            result[0].Should().Be("raw");
            result[1].Should().Be("string");
        }

        [Fact]
        public void TextProcessor_ConvertToOutput_JoinsStrings()
        {
            var textProcessor = new TextProcessor();

            var result = textProcessor.ConvertToOutput(new List<string>{"raw", "string" });

            result.Should().Be("raw string");
        }

        [Fact]
        public void TextProcessor_ReformatText_MakesSureSpaceExistsAsNextCharAfterFullStop()
        {
            var textProcessor = new TextProcessor();

            var result = textProcessor.ReformatText("Once.Twice");

            result.Should().Be("Once. Twice");
        }
    }
}
