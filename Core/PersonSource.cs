using System;
using System.Linq;

namespace Core
{
    public class PersonSource
    {
        private readonly Person[] _people;

        public PersonSource(Person[] people)
        {
            _people = people;
        }

        public Person[] GetAllPeople() => _people;

        public Person GetNextRecipient(DateTime startingFrom)
        {
            return BirthdayOrder.FromDate(startingFrom, _people).First();
        }
    }
}
