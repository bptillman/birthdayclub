using System.Linq;
using Headspring;

namespace Core
{
    public class Matcher
    {
        private readonly PersonSource _personSource;
        private readonly OffLimitsSource _offLimits;

        public Matcher(PersonSource personSource, OffLimitsSource offLimits)
        {
            _personSource = personSource;
            _offLimits = offLimits;
        }

        public Gift Next()
        {
            var receiver = _personSource.GetNextRecipient(SystemClock.UtcNow);

            // grab people not on the off limits list
            var possibleGivers = _personSource.GetAllPeople()
                .Where(x => !_offLimits.IsPersonInList(x))
                .ToList();

            // shuffle them
            Shuffler.Shuffle(possibleGivers);

            //the first person that is not the receiver is the gift giver.
            var giver = possibleGivers.First(x => x.Name != receiver.Name);

            // chosen person is no longer in play as a gifter,
            // so add them to the "off limits" queue
            _offLimits.Add(giver);

            return new Gift(receiver, giver);
        }

        public Person[] GetOffLimits() => _offLimits.GetOffLimitsPeople.ToArray();
    }
}
