using System;
using TextFilter.Interfaces;

namespace TextFilter
{
    public class EntryPoint
    {
        private readonly ITextFileReader _fileReader;
        private readonly IStrategyFactory _strategyFactory;
        private readonly ITextProcessor _textProcessor;

        private const string path = "TextFiles\\TextInput.txt"; //config

        public EntryPoint(ITextFileReader fileReader, IStrategyFactory strategyFactory, ITextProcessor textProcessor)
        {
            _fileReader = fileReader;
            _strategyFactory = strategyFactory;
            _textProcessor = textProcessor;
        }

        public void Start()
        {
            var strategies = _strategyFactory.GetStrategies();
            var text = _fileReader.ConvertFileContents(path);

            var reformattedText = _textProcessor.ReformatText(text);

            var words = _textProcessor.Split(reformattedText);

            var calcOutput =_textProcessor.Process(words, strategies);

            Console.WriteLine(_textProcessor.ConvertToOutput(calcOutput));
            Console.ReadLine();
        }
    }
}
