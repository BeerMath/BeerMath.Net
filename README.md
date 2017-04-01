# Getting Started with BeerMath.net

So you want to do beer calculations in your .Net project?  You've come to the right place!

## A couple of design notes
BeerMath is designed around decimal values for two reasons.  One, casting to decimal is a widening conversion (that is, anything the other numeric types can store, decimal can store with at least as much precision).  Thus it's always an implicit conversion, which helps make using BeerMath quite easy.  Two, using decimal internally reduces the loss of precision after multiple stages of calculation, and there's no obvious reason why the API itself should be in a different scheme.  The downside is the tradeoff in space and time, with decimal requiring more of both.  However, the computations in BeerMath are not time-critical, and the amount of memory in use is expected to be trivial.

Another design goal of BeerMath is to be as easy to use for developers as possible.  For instance, most operations return a strongly-typed value such as "Bitterness".  Bitterness has both a magnitude and a unit (so, for example, 55 IBUs).  However, in most use cases of the various calculation routines, I expect that your code will already be in a "I'm calculating IBUs" context.  Thus, Bitterness has an implicit conversion to decimal, which allows you drop the units automatically and get at the numbers.

## Practical use of BeerMath.net
Version 0.2 of BeerMath.net has three types of calculations:
* Wort color
* Hop bitterness
* Alcohol content

I'll demonstrate the wort color APIs in this sample.  All BeerMath.net routines have XML documentation, so your IDE of choice should tell you how the other APIs work.  I'm still working on finding a Mono-friendly XML documentation generator (Sandcastle seems to require Windows, which isn't a showstopper but is less preferred).

At the moment, all of BeerMath is contained in one assembly - BeerMath.dll.  Step 1 is simply to add a reference to this file to your project.

All the interesting functionality is contained in the BeerMath namespace.  This documentation assumes you've added "using BeerMath;" to the top of each file where you want to use BeerMath.net functionality, but of course you can always use a fully-qualified name (instead of "Hops.CalculateIbus()", you can type "BeerMath.Hops.CalculateIbus()").

Suppose you're writing an app that needs to calculate the color of an American pale ale wort.  Our 5-gallon recipe will include 10lbs of American 2-row (1L, or 1 Lovibond), 1lb of Crystal 15L, and 0.25lb of Crystal 125L for complexity.  To calculate the color in SRM of this wort, we'll write:

```csharp
BeerColor color1 = Malt.CalculateSrm( 10,   1, 5);
BeerColor color2 = Malt.CalculateSrm(  1,  15, 5);
BeerColor color3 = Malt.CalculateSrm(.25, 125, 5);
Console.WriteLine("Color = {0} SRM", color1+color2+color3);
```

(Yes, this suggests an obvious improvement to BeerMath -- arithmetic operators on the strong types.)

If instead, we wanted the color in MCU, we could have written:

```csharp
BeerColor color1 = Malt.CalculateMcu( 10,   1, 5);
BeerColor color2 = Malt.CalculateMcu(  1,  15, 5);
BeerColor color3 = Malt.CalculateMcu(.25, 125, 5);
Console.WriteLine("Color = {0} MCU", color1+color2+color3);
```

## Handling exceptions
BeerMath normally throws only one type of exception, the BeerMathException.  When this exception is thrown, the calculation you were running cannot be completed.  However, BeerMath hasn't been put into a bad state, so you can correct the error and retry the calculation.  For instance, if you try to enter a negative boil time when doing hop bitterness calculations, you'll get a BeerMathException with a message that reads "Boil time cannot be negative".

BeerMath also makes liberal use of NotImplementedExceptions during development.  If you find these in released code, please file a bug at beermath.codeplex.com, as they should all be removed before release.