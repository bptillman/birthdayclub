namespace Tests
{
    using System;
    using Core;

    public class MatcherTests
    {
        public void should_run()
        {
            var matcher = new Matcher(SampleData.People);

            for (int i = 0; i < 250; i++)
            {
                Console.WriteLine(matcher.Next());
            }
        }
    }
}
