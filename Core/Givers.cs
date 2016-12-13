namespace Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Givers
    {
        private readonly Shuffler _shuffler = new Shuffler();
        private readonly IList<Person> _inPlay;
        private readonly OffLimitsSource _offLimitsSource;

        public Givers(IEnumerable<Person> people, OffLimitsSource offLimitsSource)
        {
            _offLimitsSource = offLimitsSource;
            _inPlay = new List<Person>(people);
        }

        public Person Next(Person receiver)
        {
            // shuffle the people in play
            _shuffler.Shuffle(_inPlay);

            // grab the first person that's not in the off limits list and
            // is not the receiver to be the gift giver this time.
            var person = _inPlay
                .Where(x => !_offLimitsSource.IsPersonInList(x))
                .First(x => x.Name != receiver.Name);

            _offLimitsSource.Add(person);

            return person;
        }

        public Person[] OffLimits
        {
            get { return _offLimitsSource.GetOffLimitsPeople.ToArray(); }
        }
    }
}