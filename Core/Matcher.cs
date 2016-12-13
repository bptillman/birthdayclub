using Headspring;

namespace Core
{
    public class Matcher
    {
        private readonly Person[] _people;
        private readonly Givers _givers;

        public Matcher(Person[] people, Person[] offLimitsPeople)
        {
            _people = people;
            _givers = new Givers(people, offLimitsPeople);
        }

        public Gift Next()
        {
            var receiver = Receivers.NextRecipient(SystemClock.UtcNow, _people);
            return new Gift(receiver, _givers.Next(receiver));
        }

        public Person[] GetOffLimits()
        {
            return _givers.OffLimits;
        }
    }
}