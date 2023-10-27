using CodingAssessment.Refactor;
using ReFactor;
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

        [Fact]
        public void GetSpecificPerson_ReturnWhoseNameIsBobAndOlderThan30()
        {
            var people = birthingUnit.GeneratePeople(1000);
            var bobs = birthingUnit.GetPeopleWithSpecificName(people, "Bob");
            var result = birthingUnit.GetPeopleOlderThan(bobs, 30);

            Assert.NotNull(result);
            Assert.All(result, person => Assert.True(person.FirstName == "Bob"));
            Assert.All(result, person => Assert.True(person.Age >= 30));
        }

        [Fact]
        public void GetMarried_ReturnTheFullNameIfMarried()
        {

        }
    }
}
