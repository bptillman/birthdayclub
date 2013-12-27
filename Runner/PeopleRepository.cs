namespace Runner
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Core;

    class PeopleRepository
    {
        private readonly IEnumerable<string> _lines;
        private readonly string _fileName;

        public PeopleRepository(IEnumerable<string> lines, string fileName)
        {
            _lines = lines;
            _fileName = fileName;
        }

        // ugly code is ugly :)
        public Person[] GetPeople()
        {
            return _lines.Select(l => l.Split(new [] { ',', '/' }, StringSplitOptions.RemoveEmptyEntries))
                .Select(e => new Person { Name = e[0].Trim(), Birthday = new Birthday(int.Parse(e[1].Trim()), int.Parse(e[2].Trim()))})
                .ToArray();
        }

        public void Save(Person[] people)
        {
            var lines = from person in people
                        let line = string.Format("{0},{1}/{2}", person.Name, person.Birthday.Month, person.Birthday.Day)
                        select line;

            File.WriteAllLines(_fileName, lines);
        }
    }
}