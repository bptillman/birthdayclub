namespace Tests
{
    using System;
    using System.Linq;
    using Core;
    using Shouldly;

    public class BirthdayOrderTests
    {
        private readonly Person[] _people = new[]
            {
                new Person { Name = "a", Birthday = new Birthday(4, 5) },
                new Person { Name = "b", Birthday = new Birthday(4, 15) },
                new Person { Name = "c", Birthday = new Birthday(4, 25) },
                new Person { Name = "d", Birthday = new Birthday(5, 5) },
                new Person { Name = "e", Birthday = new Birthday(5, 15) },
                new Person { Name = "f", Birthday = new Birthday(5, 25) },
                new Person { Name = "g", Birthday = new Birthday(6, 5) },
            };

        public void should_order_from_a_given_date()
        {
            var testDateTime = new DateTime(2000, 5, 1);
            var ordered = BirthdayOrder.FromDate(testDateTime, _people);

            ordered.First().Name.ShouldBe("d");
            ordered.Last().Name.ShouldBe("c");
        }
    }
}
