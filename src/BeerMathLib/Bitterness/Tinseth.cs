using System;

namespace BeerMath
{
    /// <summary>
    /// Constants related to Glenn Tinseth's IBU methods
    /// http://realbeer.com/hops/research.html
    /// </summary>
    internal static class Tinseth
    {
        public const decimal BignessCoefficient = 1.65m;
        public const decimal BignessBase = 0.000125m;
        public const decimal BoiltimeShape = -0.04m;
        public const decimal BoiltimeMaximumUtilization = 4.15m;
        public const decimal NonmetricMagicNumber = 74.9m;
    }
}