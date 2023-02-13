﻿namespace Runner
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

            var lastBirthday = results.LastBirthday();
            var checkDate = new DateTime(DateTime.Now.Year, lastBirthday.Month, lastBirthday.Day).AddDays(1).AddSeconds(-1); // meh

            using (SystemClock.Stub(checkDate))
            {
                var personSource = new PersonSource(allPeople.GetPeople());
                var offLimitSource = new OffLimitsSource(offLimitsPeople.GetPeople(),
                    personSource.GetAllPeople().Length);
                var resultsSource = new ResultsSource(results.GetResults());

                var matcher = new Matcher(personSource, offLimitSource, resultsSource);

                results.Save(matcher.Next());
                offLimitsPeople.Save(matcher.GetOffLimits());
            }
        }
    }
}
