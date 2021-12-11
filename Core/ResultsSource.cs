using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class ResultsSource
    {
        private readonly Result[] _results;

        public ResultsSource(Result[] results)
        {
            _results = results;
        }

        public Result[] GetAllResults() => _results;
    }

    public class Result
    {
        public Result(Birthday birthday, string gifter, string receiver)
        {
            Birthday = birthday;
            Gifter = gifter;
            Receiver = receiver;
        }

        public Birthday Birthday { get; set; }
        public string Gifter { get; set; }
        public string Receiver { get; set; }
    }
}
