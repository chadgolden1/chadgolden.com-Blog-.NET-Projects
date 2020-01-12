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

        public void Dispose()
        {
            // no-op
        }
    }
}
