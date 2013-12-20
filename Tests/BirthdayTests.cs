namespace Tests
{
    using System;
    using Core;
    using Shouldly;

    public class BirthdayTests
    {
        public void should_be_a_valid_date()
        {
            Should.Throw<ArgumentOutOfRangeException>(() =>
                new Birthday(0, 0)
                );
            Should.Throw<ArgumentOutOfRangeException>(() =>
                new Birthday(13, 1)
                );
            Should.Throw<ArgumentOutOfRangeException>(() =>
                new Birthday(9, 31)
                );

            new Birthday(2, 29);
            new Birthday(1, 1);
            new Birthday(10, 31);
        }
    }
}