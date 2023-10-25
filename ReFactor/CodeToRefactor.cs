using ReFactor;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingAssessment.Refactor
{
    public class BirthingUnit
    {
        private List<People> _people;
        private const int MINIMUM_AGE = 18;
        private const int MAXIMUM_AGE = 85;
        private const int DAYS_IN_A_YEAR = 365;

        public BirthingUnit()
        {
            _people = new List<People>();
        }

        /// <summary>
        /// Generates people randomly
        /// </summary>
        /// <param name="noOfPeopleToBeCreated"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<People> GeneratePeople(int noOfPeopleToBeCreated)
        {
            for (int j = 0; j < noOfPeopleToBeCreated; j++)
            {
                try
                {
                    // Creates a random Name
                    string name = string.Empty;
                    var random = new Random();
                    if (random.Next(0, 1) == 0)
                    {
                        name = "Bob";
                    }
                    else
                    {
                        name = "Betty";
                    }
                    _people.Add(CreatePerson(name, random));
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
        public People CreatePerson(string name, Random random)
        {
            return new People(name, DateTime.UtcNow.Subtract(new TimeSpan(random.Next(MINIMUM_AGE, MAXIMUM_AGE) * DAYS_IN_A_YEAR, 0, 0, 0)));
        }

        private IEnumerable<People> GetBobs(bool olderThan30)
        {
            return olderThan30 ? _people.Where(x => x.Name == "Bob" && x.DOB >= DateTime.Now.Subtract(new TimeSpan(30 * 356, 0, 0, 0))) : _people.Where(x => x.Name == "Bob");
        }

        public string GetMarried(People p, string lastName)
        {
            if (lastName.Contains("test"))
                return p.Name;
            if ((p.Name.Length + lastName).Length > 255)
            {
                (p.Name + " " + lastName).Substring(0, 255);
            }

            return p.Name + " " + lastName;
        }
    }
}