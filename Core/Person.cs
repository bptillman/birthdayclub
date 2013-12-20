namespace Core
{
    using System;

    public class Person
    {
        public string Name { get; set; }
        public Birthday Birthday { get; set; }

        public override string ToString()
        {
            return string.Format("{0} ({1:MMM} {1:dd})", Name, new DateTime(2000, Birthday.Month, Birthday.Day));
        }
    }
}