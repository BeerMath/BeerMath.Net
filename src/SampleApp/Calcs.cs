using System;
using BeerMath;

namespace BeerMath.Sample.Console
{


	public class Calcs
	{

		public Calcs ()
		{
		}

		private static decimal PromptDecimal(string text)
		{
			System.Console.Write(text);
			System.Console.Write(" >");
			return decimal.Parse(System.Console.ReadLine());
		}

		public static void McuTest()
		{
			decimal lbsGrain = PromptDecimal("Pounds of grain");
			decimal degLovibond = PromptDecimal("Degrees Lovibond");
			decimal totalVolume = PromptDecimal("Total volume");

            var MCUs = Mcu.FromGrainBill(lbsGrain, degLovibond, totalVolume);

		    System.Console.WriteLine($"MCUs = {MCUs.Value}");
		}

		public static void SrmTest()
		{
			decimal lbsGrain = PromptDecimal("Pounds of grain");
			decimal degLovibond = PromptDecimal("Degrees Lovibond");
			decimal totalVolume = PromptDecimal("Total volume");

            var SRM = Srm.EstimateMorey(Mcu.FromGrainBill(lbsGrain, degLovibond, totalVolume));

		    System.Console.WriteLine($"SRM = {SRM.Value}");
		}

		public static void EbcTest()
		{
			decimal lbsGrain = PromptDecimal("Pounds of grain");
			decimal degLovibond = PromptDecimal("Degrees Lovibond");
			decimal totalVolume = PromptDecimal("Total volume");

            var EBC = Ebc.FromSrm(Srm.EstimateMorey(Mcu.FromGrainBill(lbsGrain, degLovibond, totalVolume)));

		    System.Console.WriteLine($"EBC = {EBC.Value}");
		}

		public static void IbuTest()
		{
			decimal alphaAcid = PromptDecimal("Alpha acid %");
			decimal hopsOzs = PromptDecimal("Ounces of hops");
			decimal boilMinutes = PromptDecimal("Minutes of boil time");

			decimal IBU = Hops.CalculateIbus(alphaAcid, hopsOzs, boilMinutes);

			System.Console.WriteLine(String.Format("IBUs = {0}", IBU));
		}

		public static void TinsethTest()
		{
			decimal alphaAcid = PromptDecimal("Alpha acid %");
			decimal hopsOzs = PromptDecimal("Ounces of hops");
			decimal boilMinutes = PromptDecimal("Minutes of boil time");
			Gravity gravity = new Gravity(PromptDecimal("Gravity points of wort"));
			decimal gallons = PromptDecimal("Gallons of wort");

			decimal IBU = Hops.CalculateIbusTinseth(alphaAcid, hopsOzs, boilMinutes, gravity, gallons);

			System.Console.WriteLine(String.Format("IBUs = {0}", IBU));
		}
	}
}
