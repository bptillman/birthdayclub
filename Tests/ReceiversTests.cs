namespace Tests
{
    using System.Linq;
    using Shouldly;
    using System;
    using System.Collections.Generic;
    using Core;
    using Headspring;

    public class ReceiversTests
    {
        public void given_a_start_date_Receivers_should_know_Next()
        {
            using (SystemClock.Stub(new DateTime(2000, 8, 10)))
            {
                var names = new List<string>();
                var people = SampleData.People;
                var receiver = new Receivers(people);
                names.AddRange(people.Select(person => receiver.Next().Name));
                names.ShouldBe(new List<string> { "Iris", "Jack", "Kelly", "Larry", "Anita", "Brendan", "Charles", "Derek", "Ecleamus", "Frank", "Gerald", "Henry" });
            }
        }

        public void Receivers_should_rotate_through_list()
        {
            var receiver = new Receivers(SampleData.People);

            Enumerable.Range(0, 200).Select(i => receiver.Next())
                .Count(x => x.Name == "Charles")
                .ShouldBe(17);
        }
    }
}
