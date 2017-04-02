# Getting Started with BeerMath.net

So you want to do beer calculations in your .Net project?  You've come to the right place!

Version 0.4 of BeerMath.net has several types of calculations:
* Wort color
* Hop bitterness
* Alcohol content
* Gravity

The current API basically sucks, so version 0.5 will refactor that pretty severely.

## Why decimal everywhere?
*Note: I'm currently re-thinking this, as we're not dealing with the kind of precision which would make decimals necessary. System.Math is pushing calculations through doubles anyhow.*
BeerMath is designed around decimal values for two reasons.
One, casting to decimal is a widening conversion.
That is, anything the other numeric types can store, decimal can store with at least as much precision.
Thus it's always an implicit conversion, which helps make using BeerMath quite easy.

Two, using decimal internally reduces the loss of precision after multiple stages of calculation.
There's no obvious reason why the API itself should be in a different scheme.
The downside is the tradeoff in space and time, with decimal requiring more of both.
However, the computations in BeerMath are not time-critical, and the amount of memory in use is expected to be trivial.

## Practical use of BeerMath.net
I'll demonstrate the wort color APIs in this sample.
<strike>All BeerMath.net routines have XML documentation, so your IDE of choice should tell you how the other APIs work.</strike>
Other APIs need to be documented.

Suppose you're writing an app that needs to calculate the color of an American pale ale wort.
Our 5-gallon recipe will include 10lbs of American 2-row (1L, or 1 Lovibond), 1lb of Crystal 15L, and 0.25lb of Crystal 125L for complexity.
First we get the malt color units for the recipe:

```csharp
using BeerMath;

// TODO: decide whether to support this syntax
var color1 = Mcu.FromGrainBill(10.lbs(), 1.lovibond(), 5.gallons());
var color2 = Mcu.FromGrainBill(Lbs: 1, Lovibond: 15, Gallons: 5);
var color3 = Mcu.FromGrainBill(.25, 125, 5);
var sumColor = color1 + color2 + color3;
```

Then we can estimate the SRM of the final beer:

```csharp
var beerColor = Srm.EstimateMorey(sumColor);
```

## Handling exceptions
BeerMath normally throws only one type of exception, the BeerMathException.
When this exception is thrown, the calculation you were running cannot be completed.
However, BeerMath hasn't been put into a bad state, so you can correct the error and retry the calculation.
For instance, if you try to enter a negative boil time when doing hop bitterness calculations, you'll get a BeerMathException with a message that reads "Boil time cannot be negative".
