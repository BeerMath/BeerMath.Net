namespace BeerMath.Sample.Console
{
    using BeerMath;
    using System;

    public class Calcs
    {
        private static decimal PromptDecimal(string text)
        {
            System.Console.Write(text);
            System.Console.Write(" >");
            return decimal.Parse(System.Console.ReadLine());
        }

        private static int PromptInt(string text)
        {
            System.Console.Write(text);
            System.Console.Write(" >");
            return int.Parse(System.Console.ReadLine());
        }

        public static void McuTest()
        {
            decimal lbsGrain = PromptDecimal("Pounds of grain");
            decimal degLovibond = PromptDecimal("Degrees Lovibond");
            decimal totalVolumeRaw = PromptDecimal("Total volume");

            Gallon totalVolume = new Gallon(totalVolumeRaw);

            var MCUs = Mcu.FromGrainBill(lbsGrain, degLovibond, totalVolume);

            System.Console.WriteLine($"MCUs = {MCUs.Value}");
        }

        public static void SrmTest()
        {
            decimal lbsGrain = PromptDecimal("Pounds of grain");
            decimal degLovibond = PromptDecimal("Degrees Lovibond");
            decimal totalVolumeRaw = PromptDecimal("Total volume");

            Gallon totalVolume = new Gallon(totalVolumeRaw);

            var SRM = Srm.EstimateMorey(Mcu.FromGrainBill(lbsGrain, degLovibond, totalVolume));

            System.Console.WriteLine($"SRM = {SRM.Value}");
        }

        public static void EbcTest()
        {
            decimal lbsGrain = PromptDecimal("Pounds of grain");
            decimal degLovibond = PromptDecimal("Degrees Lovibond");
            decimal totalVolumeRaw = PromptDecimal("Total volume");

            Gallon totalVolume = new Gallon(totalVolumeRaw);

            var EBC = Ebc.FromSrm(Srm.EstimateMorey(Mcu.FromGrainBill(lbsGrain, degLovibond, totalVolume)));

            System.Console.WriteLine($"EBC = {EBC.Value}");
        }

        public static void IbuTest()
        {
            decimal alphaAcidRaw = PromptDecimal("Alpha acid %");
            decimal hopsOzsRaw = PromptDecimal("Ounces of hops");
            int boilMinutesRaw = PromptInt("Minutes of boil time");

            AlphaAcid alphaAcid = AlphaAcid.FromPercent(alphaAcidRaw);
            Ounce hopsOzs = new Ounce(hopsOzsRaw);
            TimeSpan boilMinutes = new TimeSpan(0, boilMinutesRaw, 0);

            var IBU = StandardBitterness.CalculateIbus(alphaAcid, hopsOzs, boilMinutes);

            System.Console.WriteLine($"IBUs = {IBU.Value}");
        }

        public static void TinsethTest()
        {
            decimal alphaAcidRaw = PromptDecimal("Alpha acid %");
            decimal hopsOzsRaw = PromptDecimal("Ounces of hops");
            int boilMinutesRaw = PromptInt("Minutes of boil time");
            decimal gravityRaw = PromptDecimal("Gravity points of wort");
            decimal gallonsRaw = PromptDecimal("Gallons of wort");

            AlphaAcid alphaAcid = AlphaAcid.FromPercent(alphaAcidRaw);
            Ounce hopsOzs = new Ounce(hopsOzsRaw);
            TimeSpan boilMinutes = new TimeSpan(0, boilMinutesRaw, 0);
            SpecificGravity gravity = SpecificGravity.FromPoints(gravityRaw);
            Gallon gallons = new Gallon(gallonsRaw);

            var IBU = Tinseth.CalculateIbus(alphaAcid, hopsOzs, boilMinutes, gravity, gallons);

            System.Console.WriteLine($"IBUs = {IBU.Value}");
        }
    }
}
