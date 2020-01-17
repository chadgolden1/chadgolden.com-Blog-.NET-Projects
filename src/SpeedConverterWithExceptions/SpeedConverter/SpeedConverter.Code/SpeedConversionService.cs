using System;

namespace SpeedConverter.Code
{
    public class SpeedConversionService
    {
        public int ConvertToMilesPerHour(int kilometersPerHour)
        {
            if (kilometersPerHour <= -1)
            {
                throw new ArgumentOutOfRangeException($"{nameof(kilometersPerHour)} must be greater than or equal to zero.");
            }

            return (int)Math.Round(kilometersPerHour * 0.62137);
        }
    }
}