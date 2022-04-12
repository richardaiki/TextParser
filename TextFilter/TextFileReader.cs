using System;
using System.IO;
using TextFilter.Interfaces;

namespace TextFilter
{
    public class TextFileReader : ITextFileReader 
    {
        public string ConvertFileContents(string path)
        {
            var fullPath = Path.Combine(Environment.CurrentDirectory, path); 

            return File.ReadAllText(fullPath);
        }
    }
}
