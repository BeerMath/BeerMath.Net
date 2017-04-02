# Beer Color

BeerMath.Net knows about 3 kinds of color systems:

* MCU - malt color units
* SRM - Standard Reference Method
* EBC - European Brewery Convention

MCUs are calculated directly from an addition of malt to a volume of wort.
`Mcu.FromGrainBill(decimal Lbs, decimal Lovibond, decimal Gallons)`

You can sum the MCUs of multiple malt additions.
`Mcu color1 + Mcu color2`

Then you can get the predicted color of the beer made from those malts.
`Srm.EstimateMorey(Mcu mcuColor)`

If you prefer to express that in EBC, you can convert.
`Ebc.FromSrm(Srm srmColor)`

And you can go back to SRM, too.
`Srm srm = ebc.ToSrm()`

TODO:
* `Ebc.EstimateMorey`
* `ToRgb` - get a screen-displayable color
* Table of common malt colors
