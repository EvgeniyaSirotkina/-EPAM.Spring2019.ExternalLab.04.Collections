using System;

namespace Task1
{
    public class CsvException : Exception
    {
        public string CsvString { get; set; }

        public CsvException(string csvString, string message) : base(message)
        {
            CsvString = csvString;
        }
    }
}
