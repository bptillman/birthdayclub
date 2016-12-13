namespace Tests
{
    using Shouldly;
    using System;
    using Core;

    public class PersonSourceTests
    {
        public void given_a_start_date_Source_should_know_Next()
        {
            var today = new DateTime(2000, 8, 10);
            var source = new PersonSource(SampleData.People);

            source.GetNextRecipient(today).Name.ShouldBe("Iris");
        }
    }
}
