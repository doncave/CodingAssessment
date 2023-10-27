using CodingAssessment.Refactor;
using ReFactor;
using System.Text;
using Xunit;

namespace Tests
{
    public class PeopleTests
    {
        private readonly BirthingUnit birthingUnit;

        public PeopleTests()
        {
            birthingUnit = new BirthingUnit();
        }

        [Theory]
        [InlineData(5, 5)]
        [InlineData(50, 50)]
        [InlineData(100, 100)]
        public void GeneratePeople_ReturnsListOfPeople(int noOfPeopleToBeCreated, int expectedResult)
        {
            var result = birthingUnit.GeneratePeople(noOfPeopleToBeCreated);
            Assert.IsType<List<Person>>(result);
            Assert.Equal(expectedResult, result.Count);
        }

        [Fact]
        public void GeneratePeople_ReturnsPeopleWithValidAges()
        {
            var result = birthingUnit.GeneratePeople(100000);
            foreach (var person in result)
            {
                Assert.InRange(person.Age, 18, 85);
            }
        }

        [Theory]
        [InlineData("Bob", 30)]
        [InlineData("Don", 43)]
        [InlineData("Heart", 38)]
        public void GetSpecificPerson_ReturnASpecificNameAndAge(string name, int age)
        {
            var people = birthingUnit.GeneratePeople(1000);
            var bobs = birthingUnit.GetPeopleWithSpecificName(people, name);
            var result = birthingUnit.GetPeopleOlderThan(bobs, age);

            Assert.NotNull(result);
            Assert.All(result, person => Assert.True(person.FirstName == name));
            Assert.All(result, person => Assert.True(person.Age >= age));
        }

        [Fact]
        public void GetMarried_ReturnTheFullNameIfMarried()
        {
            string expectedReturnValue; 
            var people = birthingUnit.GeneratePeople(1000);
            foreach (var person in people)
            {
                int getFullNameLength = GetFullNameLength(person.FirstName, person.LastName);
                if (getFullNameLength > 10)
                {
                    expectedReturnValue = $"{person.FirstName} {person.LastName}";
                }
                else
                {
                    expectedReturnValue = "";
                }

                string result = birthingUnit.GetMarried(person);
                Assert.Equal(expectedReturnValue, result);
            }
        }

        #region Private Methods

        private int GetFullNameLength(params string[] strings)
        {
            var fullName = new StringBuilder();
            for (int i = 0; i < strings.Length; i++)
            {
                fullName.Append($"{strings[i]} ");
            }

            return fullName.ToString().Trim().Length;
        }

        #endregion
    }
}
