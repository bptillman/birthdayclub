namespace Tests
{
    using System;
    using Core;

    public class MatcherTests
    {
        public void should_run()
        {
            var personSource = new PersonSource(SampleData.People);
            var matcher = new Matcher(personSource, new Person[0]);

            for (int i = 0; i < 250; i++)
            {
                Console.WriteLine(matcher.Next());
            }
        }
    }
}
