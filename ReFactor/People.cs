using System;

namespace ReFactor
{
    public class People
    {
        private static readonly DateTimeOffset Under16 = DateTimeOffset.UtcNow.AddYears(-15);
        public string Name { get; private set; }
        public DateTimeOffset DOB { get; private set; }

        public int Age {
            get
            {
                // Calculate the difference in years
                int age = DateTimeOffset.UtcNow.Year - DOB.Year;

                // Check if the birthdate has occurred this year
                if (DateTimeOffset.UtcNow.Date > DateTimeOffset.UtcNow.Date.AddYears(-age))
                {
                    age--;
                }

                return age;
            }
        }

        #region Constructors

        public People(string name) : this(name, Under16.Date)
        {
        }

        public People(string name, DateTime dob)
        {
            Name = name;
            DOB = dob;
        }

        #endregion
    }
}
