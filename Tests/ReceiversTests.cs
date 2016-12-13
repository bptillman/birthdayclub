namespace Tests
{
    using Shouldly;
    using System;
    using Core;

    public class ReceiversTests
    {
        public void given_a_start_date_Receivers_should_know_Next()
        {
            var today = new DateTime(2000, 8, 10);
            var people = SampleData.People;

            Receivers.NextRecipient(today, people).Name.ShouldBe("Iris");
        }
    }
}
