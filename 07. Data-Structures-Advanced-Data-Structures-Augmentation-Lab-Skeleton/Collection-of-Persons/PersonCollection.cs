namespace Collection_of_Persons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PersonCollection : IPersonCollection
    {
        Dictionary<string, SortedDictionary<string, Person>> peopleDomain;
        SortedDictionary<string, SortedDictionary<string, Person>> pplNameTown;
        SortedDictionary<string, Person> people;

        public PersonCollection()
        {
            peopleDomain = new Dictionary<string, SortedDictionary<string, Person>>();
            people = new SortedDictionary<string, Person>();
            pplNameTown = new SortedDictionary<string, SortedDictionary<string, Person>>();
        }

        public bool AddPerson(string email, string name, int age, string town)
        {
            var domain = email.Split('@')[1];
            var nameTown = name + town;

            if (!this.peopleDomain.ContainsKey(domain))
            {
                this.peopleDomain.Add(domain, new SortedDictionary<string, Person>());
            }

            if (!this.peopleDomain[domain].ContainsKey(email))
            {
                var person = new Person
                {
                    Age = age,
                    Email = email,
                    Name = name,
                    Town = town,
                };

                this.peopleDomain[domain].Add(email, person);
                this.people.Add(email, person);
                if (!this.pplNameTown.ContainsKey(nameTown))
                {
                    this.pplNameTown.Add(nameTown, new SortedDictionary<string, Person>());
                }

                this.pplNameTown[nameTown].Add(email, person);

                return true;
            }

            return false;
        }

        public int Count => this.people.Count;
        public Person FindPerson(string email)
        {
            if (this.people.ContainsKey(email))
            {
                return this.people[email];
            }

            return null;
        }

        public bool DeletePerson(string email)
        {
            var domain = email.Split('@')[1];

            if (this.peopleDomain.ContainsKey(domain))
            {
                if (this.peopleDomain[domain].ContainsKey(email))
                {
                    var nameTown = this.people[email].Name + this.people[email].Town;
                    this.peopleDomain[domain].Remove(email);
                    this.people.Remove(email);
                    if (this.pplNameTown.ContainsKey(nameTown))
                    {
                        this.pplNameTown[nameTown].Remove(email);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<Person> FindPersons(string emailDomain)
        {
            if (!this.peopleDomain.ContainsKey(emailDomain))
            {
                return new List<Person>();
            }

            var result = this.peopleDomain[emailDomain].Select(x => x.Value);

            return result;
        }

        public IEnumerable<Person> FindPersons(string name, string town)
        {
            var nameTown = name + town;

            if (!this.pplNameTown.ContainsKey(nameTown))
            {
                return new List<Person>();
            }

            var persons = this.pplNameTown[nameTown].Select(x => x.Value);

            return persons;

            //var persons = this.people.Values
            //    .Where(x => x.Name == name && x.Town == town);

            //if (persons.Count() == 0)
            //{
            //    return new List<Person>();
            //}

            //return persons;
        }

        public IEnumerable<Person> FindPersons(int startAge, int endAge)
        {
            var persons = this.people
                .Values
                .Where(x => x.Age >= startAge && x.Age <= endAge)
                .OrderBy(x => x.Age);

            if (persons.Count() == 0)
            {
                return new List<Person>();
            }

            return persons;
        }

        public IEnumerable<Person> FindPersons(int startAge, int endAge, string town)
        {
            var persons = this.people
                .Values
                .Where(x => x.Age >= startAge && x.Age <= endAge && x.Town == town)
                .OrderBy(x => x.Age);

            if (persons.Count() == 0)
            {
                return new List<Person>();
            }

            return persons;
        }
    }
}
