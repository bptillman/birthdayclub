namespace Runner
{
    using System;
    using System.IO;
    using Core;
    using Headspring;
    using NDesk.Options;

    class Program
    {
        static void Main(string[] args)
        {
            PeopleRepository allPeople = null;
            PeopleRepository offLimitsPeople = null;
            ResultsRepository results = null;

            new OptionSet {
                { "allpeople=", s => {
                        allPeople = new PeopleRepository(File.ReadLines(s), s);
                    }
                }, { "offlimits=", s => {
                        offLimitsPeople = new PeopleRepository(File.ReadLines(s), s);
                    }
                }, { "results=", s => {
                        results = new ResultsRepository(s);
                    }
                }
            }.Parse(args);

            var nextBirthday = results.NextBirthday();
            var checkDate = new DateTime(DateTime.Now.Year, nextBirthday.Month, nextBirthday.Day).AddDays(1).AddSeconds(-1); // meh

            using (SystemClock.Stub(checkDate))
            {
                var persons = allPeople.GetPeople();
                var limitsPeople = offLimitsPeople.GetPeople();
                var matcher = new Matcher(persons, limitsPeople);

                results.Save(matcher.Next());

                offLimitsPeople.Save(matcher.GetOffLimits());
            }
        }
    }
}
