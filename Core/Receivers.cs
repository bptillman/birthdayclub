namespace Core
{
    using System.Collections.Generic;
    using Headspring;

    public class Receivers
    {
        private readonly Queue<Person> _people;

        public Receivers(IEnumerable<Person> people)
        {
            var orderedFromToday = BirthdayOrder.FromDate(SystemClock.UtcNow, people);
            _people = new Queue<Person>(orderedFromToday);
        }

        public Person Next()
        {
            var person = _people.Dequeue();
            _people.Enqueue(person);
            return person;
        }
    }
}