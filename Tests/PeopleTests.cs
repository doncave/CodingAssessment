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
        public void GetPeople_ReturnsListOfPeople()
        {
            var result = birthingUnit.GetPeople(5);
            Assert.IsType<List<People>>(result);
            Assert.Equal(5, result.Count);
        }

        [Fact]
        public void GetPeople_ReturnsPeopleWithValidAges()
        {
            var result = birthingUnit.GetPeople(5);
            foreach (var person in result)
            {
                Assert.InRange(person.Age, 18, 85);
            }
        }
    }
}
