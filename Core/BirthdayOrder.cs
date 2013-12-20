namespace Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class BirthdayOrder
    {
        public static IEnumerable<Person> FromDate(DateTime dateTime, IEnumerable<Person> people)
        {
            var ordered = people.OrderBy(x => x.Birthday.Month).ThenBy(x => x.Birthday.Day);

            return ordered.Where(x => x.Birthday >= dateTime)
                .Concat(ordered.Where(x => x.Birthday < dateTime));
        }
    }
}
