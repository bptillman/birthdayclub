using System;
using System.Linq;

namespace Core
{
    using System.Collections.Generic;

    public class Receivers
    {
        public static Person NextRecipient(DateTime today, IEnumerable<Person> people)
        {
            return BirthdayOrder.FromDate(today, people).First();
        }
    }
}
