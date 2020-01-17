using SpeedConverter.Code;
using System;
using Xunit;

namespace SpeedConverter.Tests
{
    public class SpeedConversionServiceTests : IDisposable
    {
        private readonly SpeedConversionService speedConverter;

        public SpeedConversionServiceTests()
        {
            speedConverter = new SpeedConversionService();
        }

        [Theory]
        [InlineData(0,0)]
        [InlineData(10,6)]
        [InlineData(11,7)]
        [InlineData(20,12)]
        public void ConvertToMilesPerHour_Input_Expected(int input, int expected)
        {
            var milesPerHour = speedConverter.ConvertToMilesPerHour(input);

            Assert.Equal(expected, milesPerHour);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-2)]
        public void ConvertToMilesPerHour_InputNegative_ThrowsArgumentOutOfRangeException(int input)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => speedConverter.ConvertToMilesPerHour(input));

            Assert.Contains("must be greater than or equal to zero.", ex.Message);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-2)]
        public void FrameworkAgnostic_ConvertToMilesPerHour_InputNegative_ThrowsArgumentOutOfRangeException(int input)
        {
            try
            {
                speedConverter.ConvertToMilesPerHour(input);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.Contains("must be greater than or equal to zero.", ex.Message);
                return;
            }

            throw new InvalidOperationException($"Expected {nameof(ArgumentOutOfRangeException)} but no exception was thrown.");
        }

        public void Dispose()
        {
            // no-op
        }
    }
}
