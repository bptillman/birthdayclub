using Headspring;

namespace Core
{
    public class Matcher
    {
        private readonly PersonSource _personSource;
        private readonly OffLimitsSource _offLimits;

        private readonly Givers _givers;

        public Matcher(PersonSource personSource, Person[] offLimitsPeople)
        {
            _personSource = personSource;
            var offLimitsSource = new OffLimitsSource(offLimitsPeople, personSource.GetAllPeople().Length);
            _givers = new Givers(personSource.GetAllPeople(), offLimitsSource);
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