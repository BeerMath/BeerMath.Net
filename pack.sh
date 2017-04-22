#!/usr/bin/env bash
BEERMATH_ROOT=`git rev-parse --show-toplevel`
if [ -d "$BEERMATH_ROOT" ]; then
  pushd ${BEERMATH_ROOT}/src/BeerMathLib
  dotnet pack -c Release
  popd
else
  echo Could not locate BeerMathLib directory to build NuGet package.
fi