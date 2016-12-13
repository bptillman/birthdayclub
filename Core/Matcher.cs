using Headspring;

namespace Core
{
    public class Matcher
    {
        private readonly PersonSource _personSource;
        private readonly Givers _givers;

        public Matcher(PersonSource personSource, Person[] offLimitsPeople)
        {
            _personSource = personSource;
            _givers = new Givers(personSource.GetAllPeople(), offLimitsPeople);
        }

        public Gift Next()
        {
            var receiver = _personSource.GetNextRecipient(SystemClock.UtcNow);
            var giver = _givers.Next(receiver);
            return new Gift(receiver, giver);
        }

        public Person[] GetOffLimits()
        {
            return _givers.OffLimits;
        }
    }
}