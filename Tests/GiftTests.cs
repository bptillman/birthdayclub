namespace Tests
{
    using System;
    using Core;
    using Shouldly;

    public class GiftTests
    {
        public void gift_cannot_be_given_and_received_by_same_person()
        {
            var person = new Person { Name = "Chris Missal" };
            Should.Throw<ArgumentException>(() =>
                new Gift(person, person)
                );
        }
    }
}
