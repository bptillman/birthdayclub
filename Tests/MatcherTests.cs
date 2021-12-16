using Headspring;
using Shouldly;

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
                    Should.NotThrow(() => matcher.Next());
                }
            }
        }

        public void should_not_pick_previous_gift_giver()
        {
            var people = new[]
            {
                new Person {Name = "Anita", Birthday = new Birthday(1, 1)},
                new Person {Name = "Brendan", Birthday = new Birthday(2, 1)},
                new Person {Name = "Charles", Birthday = new Birthday(3, 1)},
                new Person {Name = "Damien", Birthday = new Birthday(4, 1)},
                new Person { Name = "Iris", Birthday = new Birthday(9, 1) },
            };
            var results = new[]
            {
                new Result(new Birthday(2,1),"Anita","Brendan"),
                new Result(new Birthday(2,1),"Iris","Brendan"),
            };
            var personSource = new PersonSource(people);
            var offLimitsSource = new OffLimitsSource(new[] {people[0]}, people.Length);
            var resultsSource = new ResultsSource(results);
            var matcher = new Matcher(personSource, offLimitsSource,resultsSource);
            using (SystemClock.Stub(new DateTime(DateTime.Now.Year,1,15)))
            {
                var result = matcher.Next();
                result.Gifter.Name.ShouldNotBe("Anita");
                result.Gifter.Name.ShouldNotBe("Iris");
                result.Gifter.Name.ShouldBeOneOf("Charles", "Damien");
            }
            
        }
    }
}
