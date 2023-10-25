using System;
using CodingAssessment.Refactor;
using FluentAssertions;
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

        [Fact]
        public void GeneratePeople_ReturnsListOfPeople()
        {
            var result = birthingUnit.GeneratePeople(5);
            Assert.IsType<List<Person>>(result);
            Assert.Equal(5, result.Count);
        }

        [Fact]
        public void GeneratePeople_ReturnsPeopleWithValidAges()
        {
            var result = birthingUnit.GeneratePeople(5);
            foreach (var person in result)
            {
                Assert.InRange(person.Age, 18, 85);
            }
        }
    }
}
