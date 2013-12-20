namespace Core
{
    using System.Collections.Generic;
    using System.Linq;

    public class Givers
    {
        private readonly Shuffler _shuffler = new Shuffler();
        private readonly IList<Person> _inPlay;
        private readonly Queue<Person> _offLimits;
        private readonly int _maxNotInPlay;
 
        public Givers(IEnumerable<Person> people)
        {
            _inPlay = new List<Person>(people);
            _offLimits = new Queue<Person>();

            _maxNotInPlay = _inPlay.Count / 4;
        }

        public Person Next(Person receiver)
        {
            // shuffle the people in play
            _shuffler.Shuffle(_inPlay);

            // grab the first person that's not the receiver to be the
            // gift giver this time.
            var person = _inPlay.First(x => x.Name != receiver.Name);

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
    }
}