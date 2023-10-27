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
        private const int DAYS_IN_A_YEAR = 365;
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
            return new Person(firstName, lastName, DateTime.UtcNow.Subtract(new TimeSpan(random.Next(minAge, maxAge) * DAYS_IN_A_YEAR, 0, 0, 0)));
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

        public string GetMarried(Person p, string lastName)
        {
            if (lastName.Contains("test"))
                return p.FirstName;
            if ((p.FirstName.Length + lastName).Length > 255)
            {
                (p.FirstName + " " + lastName).Substring(0, 255);
            }

            return p.FirstName + " " + lastName;
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
            string[] lastNames = new string[] { "Gates", "Jobs", "Cave", "Jordan", "Sins" };
            string lastName = lastNames[random.Next(0, lastNames.Length - 1)];

            return lastName;
        }

        #endregion
    }
}