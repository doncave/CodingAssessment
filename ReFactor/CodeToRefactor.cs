using ReFactor;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingAssessment.Refactor
{
    public class BirthingUnit
    {
        private List<Person> _people = new();
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
            for (int j = 0; j < noOfPeopleToBeCreated; j++)
            {
                try
                {
                    string name = CreateRandomPersonName();
                    _people.Add(CreatePerson(name));
                }
                catch (Exception e)
                {
                    // Log the error in the console or use ILogger or maybe log it in Azure Appinsights or AWS Cloudwatch
                    Console.WriteLine($"Something failed in user creation: {e.Message}");
                }
            }
            return _people;
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="name"></param>
        /// <param name="random"></param>
        /// <returns></returns>
        public Person CreatePerson(string name)
        {
            return new Person(name, DateTime.UtcNow.Subtract(new TimeSpan(random.Next(MINIMUM_AGE, MAXIMUM_AGE) * DAYS_IN_A_YEAR, 0, 0, 0)));
        }

        /// <summary>
        /// Get people with specific name ex. "Bob" either older than 30 or not 
        /// </summary>
        /// <param name="olderThan30"></param>
        /// <returns></returns>
        public IEnumerable<Person> GetSpecificPerson(string name, bool olderThan30)
        {
            return olderThan30 
                ? _people.Where(x => x.Name == name && x.DOB >= DateTime.Now.Subtract(new TimeSpan(30 * DAYS_IN_A_YEAR, 0, 0, 0))) 
                : _people.Where(x => x.Name == name);
        }

        public string GetMarried(Person p, string lastName)
        {
            if (lastName.Contains("test"))
                return p.Name;
            if ((p.Name.Length + lastName).Length > 255)
            {
                (p.Name + " " + lastName).Substring(0, 255);
            }

            return p.Name + " " + lastName;
        }

        #region Private Methods

        /// <summary>
        /// Create a random person name
        /// </summary>
        /// <returns></returns>
        private string CreateRandomPersonName()
        {
            // Creates a random Name
            string name;
            var random = new Random();
            if (random.Next(0, 1) == 0)
            {
                name = "Bob";
            }
            else
            {
                name = "Betty";
            }

            return name;
        }

        #endregion
    }
}