namespace Tests
{
    using Core;

    public static class SampleData
    {
        private static readonly Person[] _people = new[]
            {
                new Person { Name = "Anita", Birthday = new Birthday(1, 1) },
                new Person { Name = "Brendan", Birthday = new Birthday(2, 1) },
                new Person { Name = "Charles", Birthday = new Birthday(3, 1) },
                new Person { Name = "Derek", Birthday = new Birthday(4, 1) },
                new Person { Name = "Ecleamus", Birthday = new Birthday(5, 1) },
                new Person { Name = "Frank", Birthday = new Birthday(6, 1) },
                new Person { Name = "Gerald", Birthday = new Birthday(7, 1) },
                new Person { Name = "Henry", Birthday = new Birthday(8, 1) },
                new Person { Name = "Iris", Birthday = new Birthday(9, 1) },
                new Person { Name = "Jack", Birthday = new Birthday(10, 1) },
                new Person { Name = "Kelly", Birthday = new Birthday(11, 1) },
                new Person { Name = "Larry", Birthday = new Birthday(12, 1) },
            };

        public static Person[] People
        {
            get { return _people; }
        }
    }
}