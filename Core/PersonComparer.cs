namespace Core
{
    using System.Collections.Generic;

    public class PersonComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person x, Person y)
        {
            return x.ToString().Equals(y.ToString());
        }

        public int GetHashCode(Person obj)
        {
            return obj.GetHashCode();
        }
    }
}