namespace Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Givers
    {
        private readonly Shuffler _shuffler = new Shuffler();
        private readonly IList<Person> _inPlay;
        private readonly Queue<Person> _offLimits;
        private readonly int _maxNotInPlay;
 
        public Givers(IEnumerable<Person> people, IEnumerable<Person> offLimits)
        {
            _inPlay = new List<Person>(people);
            _offLimits = new Queue<Person>(offLimits ?? new Person[0]);

            _maxNotInPlay = _inPlay.Count / 2;
        }

        public Person Next(Person receiver)
        {
            // shuffle the people in play
            _shuffler.Shuffle(_inPlay);

            // grab the first person that's not in the off limits list and
            // is not the receiver to be the gift giver this time.
            var person = _inPlay
                .Where(x => !_offLimits.Contains(x, new PersonComparer()))
                .First(x => x.Name != receiver.Name);

            if (_offLimits.Select(x => x.Name).Contains(person.Name))
                throw new InvalidOperationException(string.Format("{0} is in the offlimits list!", person.Name));

            // that chosen person is no longer in play as a gifter
            // for awhile, so add them to the "off limits" queue
            _inPlay.Remove(person);
            _offLimits.Enqueue(person);

            // if the number of people that are off limits is more than
            // allowed, pop them off the queue and put them back in play
            // to be shuffled and entered back into the mix.
            if (_offLimits.Count > _maxNotInPlay)
            {
                var backInTheGame = _offLimits.Dequeue();
                _inPlay.Add(backInTheGame);
            }

            return person;
        }

        public Person[] OffLimits
        {
            get { return _offLimits.ToArray(); }
        }
    }
}