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

            decimal MCUs = Malt.CalculateMcu(lbsGrain, degLovibond, totalVolume);

		    System.Console.WriteLine(String.Format("MCUs = {0}", MCUs));
		}

		public static void SrmTest()
		{
			decimal lbsGrain = PromptDecimal("Pounds of grain");
        		decimal degLovibond = PromptDecimal("Degrees Lovibond");
        		decimal totalVolume = PromptDecimal("Total volume");

            decimal SRM = Malt.CalculateSrm(lbsGrain, degLovibond, totalVolume);

		    System.Console.WriteLine(String.Format("SRM = {0}", SRM));
		}

		public static void EbcTest()
		{
			decimal lbsGrain = PromptDecimal("Pounds of grain");
        		decimal degLovibond = PromptDecimal("Degrees Lovibond");
        		decimal totalVolume = PromptDecimal("Total volume");

            decimal EBC = Malt.CalculateEbc(lbsGrain, degLovibond, totalVolume);

		    System.Console.WriteLine(String.Format("EBC = {0}", EBC));
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
