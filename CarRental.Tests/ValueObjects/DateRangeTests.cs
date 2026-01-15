using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Domain.Exceptions;
using CarRental.Domain.ValueObjects;
using Xunit;
using FluentAssertions;

namespace CarRental.Tests.ValueObjects
{
    public class DateRangeTests
    {
        [Fact]
        public void Create_ShouldThrowException_WhenStartIsAfterEnd()
        {
            // Arrange
            var start = DateTime.Now;
            var end = DateTime.Now.AddHours(-1);

            Assert.Throws<ValidationException>(() => DateRange.Create(start, end));
        }

        [Fact]
        public void Create_ShouldCreateRange_WhenDatesAreValid()
        {
            // Arrange
            var start = DateTime.Now;
            var end = DateTime.Now.AddHours(2);

            // Act
            var range = DateRange.Create(start, end);

            // Assert

            range.Start.Should().Be(start);
            range.End.Should().Be(end);
        }

        [Theory]
        // (Overlap)
        [InlineData("2024-01-01 10:00", "2024-01-01 12:00", "2024-01-01 11:00", "2024-01-01 13:00", true)]
        // (Overlap)
        [InlineData("2024-01-01 10:00", "2024-01-01 14:00", "2024-01-01 11:00", "2024-01-01 12:00", true)]
        // (End Exclusive)
        [InlineData("2024-01-01 10:00", "2024-01-01 12:00", "2024-01-01 12:00", "2024-01-01 14:00", false)]
        // (Separated)
        [InlineData("2024-01-01 10:00", "2024-01-01 12:00", "2024-01-01 13:00", "2024-01-01 14:00", false)]

        public void Overlaps_ShouldReturnCorrectResult(string startA, string endA, string startB, string endB, bool expected)
        {
            // Arrange
            var range1 = DateRange.Create(DateTime.Parse(startA), DateTime.Parse(endA));
            var range2 = DateRange.Create(DateTime.Parse(startB), DateTime.Parse(endB));

            // Act
            var result =  range1.Overlaps(range2);

            // Assert
            result.Should().Be(expected);
        }

    }
}
