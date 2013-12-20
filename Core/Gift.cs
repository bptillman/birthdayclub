namespace Core
{
    using System;

    public class Gift
    {
        public Gift(Person receiver, Person gifter)
        {
            if (receiver == gifter)
                throw new ArgumentException("receiver and gifter cannot be the same person");

            Receiver = receiver;
            Gifter = gifter;
        }

        public Person Receiver { get; private set; }
        public Person Gifter { get; private set; }

        public override string ToString()
        {
            return string.Format("{0} giving to {1}", Gifter, Receiver);
        }
    }
}