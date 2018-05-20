using LibraryProject.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Services
{
    public class PersonRepository : IPersonRepository
    {
        private string FilePath { get; set; }

        public PersonRepository()
        {
            FilePath=(Path.Combine(Environment.CurrentDirectory) + "People.json");
            if(File.Exists(FilePath))
            {
                return;
            }
            using (FileStream fs = File.Create(FilePath)) ;
        }

        public IEnumerable<Person> GetAllPeople()
        {
            var people = new List<Person>();

            using (StreamReader sr = new StreamReader(FilePath))
            {
                foreach (var line in File.ReadLines(FilePath))
                {
                    if (!string.IsNullOrWhiteSpace(line))
                        people.Add(JsonConvert.DeserializeObject<Person>(line));
                }
            }

            return people;
        }
        public Person AddPersonToList(string firstName,string lastName,List<Person> peopleList)
        {
            var person = new Person(peopleList.Count(), firstName, lastName);

            string jsonData = JsonConvert.SerializeObject(person);

            File.AppendAllText(FilePath, "\n" + jsonData);

            return person;
        }
        public void UpdatePersonList(Person person)
        {
            var peopleList = GetAllPeople().ToList();
            peopleList.RemoveAll(x => x.PersonID == person.PersonID);
            peopleList.Add(person);
            peopleList.OrderBy(x => x.PersonID).ToList();
            SavePeopleListToFile(peopleList);
        }



        private void SavePeopleListToFile(List<Person> peopleList)
        {
            List<string> jsonObjects = new List<string>();
            foreach (var item in peopleList)
            {
                jsonObjects.Add(JsonConvert.SerializeObject(item));
            }
            File.WriteAllLines(FilePath, jsonObjects);
        }
    }
}
