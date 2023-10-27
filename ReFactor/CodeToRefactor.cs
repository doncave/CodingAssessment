using ReFactor;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingAssessment.Refactor
{
    public class BirthingUnit
    {
        private const int MINIMUM_AGE = 18;
        private const int MAXIMUM_AGE = 85;
        private const int NAME_LIMIT = 10;
        private Random random = new();

        /// <summary>
        /// Generates people randomly
        /// </summary>
        /// <param name="noOfPeopleToBeCreated"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<Person> GeneratePeople(int noOfPeopleToBeCreated)
        {
            List<Person> people = new();
            for (int j = 0; j < noOfPeopleToBeCreated; j++)
            {
                try
                {
                    string firstName = GenerateRandomFirstName();
                    string lastName = GenerateRandomLastName();
                    people.Add(CreatePerson(firstName, lastName, null, null));
                }
                catch (Exception e)
                {
                    // Log the error in the console or use ILogger or maybe log it in Azure Appinsights or AWS Cloudwatch
                    Console.WriteLine($"Something failed in user creation: {e.Message}");
                }
            }
            return people;
        }

        /// <summary>
        /// Create a person with optional minimum and maximum age, if left out, it will use the default MINIMUM_AGE = 18 and MAXIMUM_AGE = 85
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="minimumAge"></param>
        /// <param name="maximumAge"></param>
        /// <returns></returns>
        public Person CreatePerson(string firstName, string lastName, int? minimumAge, int? maximumAge)
        {
            int minAge = minimumAge.HasValue ? minimumAge.Value : MINIMUM_AGE;
            int maxAge = maximumAge.HasValue ? maximumAge.Value : MAXIMUM_AGE;
            int randomAge = random.Next(minAge + 1, maxAge);
            DateTime birthdate = DateTime.UtcNow.AddYears(-randomAge);
            return new Person(firstName, lastName, birthdate);
        }

        /// <summary>
        /// Get people with specific name ex. "Bob"
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IEnumerable<Person> GetPeopleWithSpecificName(IEnumerable<Person> people, string name)
        {
            return people.Where(x => x.FirstName == name);
        }

        /// <summary>
        /// Get people older than a specific age
        /// </summary>
        /// <param name="people"></param>
        /// <param name="age"></param>
        /// <returns></returns>
        public IEnumerable<Person> GetPeopleOlderThan(IEnumerable<Person> people, int age)
        {
            return people.Where(x => x.Age >= age);
        }

        /// <summary>
        /// Gets the name of a married person
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public string GetMarried(Person person)
        {
            if (person.LastName.ToUpper().Contains("TEST"))
            {
                return person.FirstName;
            }

            if ($"{person.FirstName} {person.LastName}".Length > NAME_LIMIT)
            {
                return $"{person.FirstName} {person.LastName}";
            }

            return string.Empty;
        }

        #region Private Methods

        /// <summary>
        /// Create a random first name
        /// </summary>
        /// <returns></returns>
        private string GenerateRandomFirstName()
        {
            string[] maleNames = new string[] { "Alucard", "Leon", "Dave", "Don", "Bob" };
            string[] femaleNames = new string[] { "Bella", "Chien", "Catriona", "Heart", "Betty" };
            List<string> allNames = maleNames.Concat(femaleNames).ToList();

            string firstName = allNames[random.Next(0, allNames.Count - 1)];

            return firstName;
        }

        /// <summary>
        /// Create a random last name
        /// </summary>
        /// <returns></returns>
        private string GenerateRandomLastName()
        {
            string[] lastNames = new string[] { "Gates", "Jobs", "Cave", "Jordan", "Sins", "Test" };
            string lastName = lastNames[random.Next(0, lastNames.Length - 1)];

            return lastName;
        }

        #endregion
    }
}