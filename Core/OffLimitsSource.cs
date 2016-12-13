using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public class OffLimitsSource
    {
        private readonly Queue<Person> _offLimitsPeople;
        private readonly int _maxOffLimits;

        public OffLimitsSource(Person[] offLimitsPeople, int totalPersonCount)
        {
            _offLimitsPeople = new Queue<Person>(offLimitsPeople ?? new Person[0]);

            _maxOffLimits = (int) (totalPersonCount/1.25m);
        }

        public bool IsPersonInList(Person other)
        {
            return _offLimitsPeople.Any(
                person => other.ToString().Equals(person.ToString()));
        }

        public void Add(Person person)
        {
            _offLimitsPeople.Enqueue(person);

            // if the number of people that are off limits is more than
            // allowed, pop someone off the queue and put them back in play
            if (_offLimitsPeople.Count > _maxOffLimits)
            {
                _offLimitsPeople.Dequeue();
            }
        }

        public IEnumerable<Person> GetOffLimitsPeople => _offLimitsPeople;
    }
}
