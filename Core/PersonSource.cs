using System;
using System.Linq;

namespace Core
{
    public class PersonSource
    {
        private readonly Person[] _people;
        private readonly Result[] _results;

        public PersonSource(Person[] people)
        {
            _people = people;
        }

        public PersonSource(Person[] people, Result[] results)
        {
            _people = people;
            _results = results;
        }

        public Person[] GetAllPeople() => _people;

        public Person GetNextRecipient(DateTime startingFrom)
        {
            return BirthdayOrder.FromDate(startingFrom, _people).First();
        }

        public Person GetNextRecipient2(DateTime startingFrom)
        {
            return BirthdayOrder.FromDate(startingFrom, _people).First(x => x.Name != _results.Last().Receiver);
        }
    }
}
