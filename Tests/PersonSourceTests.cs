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

        public void given_a_duplicate_birthday_should_not_skip_the_duplicate()
        {
            var source = new PersonSource(SampleData.PeopleWithDupeBirthday,
                new[] {new Result(new Birthday(8, 1), "Anita", "Henry")});
            var next = source.GetNextRecipient2(new DateTime(2000, 8, 10));
            next.Name.ShouldBe("Iris");

            source = new PersonSource(SampleData.PeopleWithDupeBirthday,
                new[]
                {
                    new Result(new Birthday(8, 1), "Anita", "Henry"),
                    new Result(new Birthday(9, 1), "Larry", "Iris")
                });
            var nextNext = source.GetNextRecipient2(new DateTime(2000, 8, 10));
            nextNext.Name.ShouldBe("Chris");
        }
    }
}
