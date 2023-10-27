﻿using System;

namespace ReFactor
{
    public class Person
    {
        private static readonly DateTimeOffset Under16 = DateTimeOffset.UtcNow.AddYears(-15);
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTimeOffset DOB { get; private set; }

        public int Age {
            get
            {
                int age = DateTimeOffset.UtcNow.Year - DOB.Year;
                return age;
            }
        }

        #region Constructors

        public Person(string firstName, string lastName) : this(firstName, lastName, Under16.Date)
        {
        }

        public Person(string firstName, string lastName, DateTime dob)
        {
            FirstName = firstName;
            LastName = lastName;
            DOB = dob;
        }

        #endregion
    }
}
