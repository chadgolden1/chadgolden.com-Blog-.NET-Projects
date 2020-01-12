using System;

namespace SpeedConverter.Code
{
    public class SpeedConversionService
    {
        public int ConvertToMilesPerHour(int kilometersPerHour)
        {
            return (int)Math.Round(kilometersPerHour * 0.62137);
        }
    }
}