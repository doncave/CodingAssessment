﻿using ReFactor;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingAssessment.Refactor
{
    public class BirthingUnit
    {
        /// <summary>
        /// MaxItemsToRetrieve
        /// </summary>
        private List<People> _people;

        public BirthingUnit()
        {
            _people = new List<People>();
        }

        /// <summary>
        /// GetPeoples
        /// </summary>
        /// <param name="j"></param>
        /// <returns>List<object></returns>
        public List<People> GetPeople(int i)
        {
            for (int j = 0; j < i; j++)
            {
                try
                {
                    // Creates a dandon Name
                    string name = string.Empty;
                    var random = new Random();
                    if (random.Next(0, 1) == 0) {
                        name = "Bob";
                    }
                    else {
                        name = "Betty";
                    }
                    // Adds new people to the list
                    _people.Add(new People(name, DateTime.UtcNow.Subtract(new TimeSpan(random.Next(18, 85) * 356, 0, 0, 0))));
                }
                catch (Exception e)
                {
                    // Dont think this should ever happen
                    throw new Exception("Something failed in user creation");
                }
            }
            return _people;
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