namespace Core
{
    public class Matcher
    {
        private readonly Receivers _receivers;
        private readonly Givers _givers;

        public Matcher(Person[] people)
        {
            _receivers = new Receivers(people);
            _givers = new Givers(people);
        }

        public Gift Next()
        {
            var receiver = _receivers.Next();
            return new Gift(receiver, _givers.Next(receiver));
        }
    }
}