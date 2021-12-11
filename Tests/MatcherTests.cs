using Headspring;

namespace Tests
{
    using System;
    using Core;

    public class MatcherTests
    {
        public void should_run()
        {
            var personSource = new PersonSource(SampleData.People);
            var matcher = new Matcher(personSource, new OffLimitsSource(new Person[0], SampleData.People.Length), new ResultsSource(new Result[0]));

            for (int i = 0; i < 250; i++)
            {
                using (SystemClock.Stub(DateTime.Now.AddMonths(i)))
                {
                    Console.WriteLine(matcher.Next());
                }
            }
        }
    }
}
