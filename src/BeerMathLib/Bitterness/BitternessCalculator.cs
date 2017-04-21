using System;

namespace BeerMath.Fluent
{
    public class BitternessCalculator
    {
        private enum BitternessCalculation
        {
            Standard,
            Garetz,
            Rager,
            Tinseth,
        }

        private BitternessCalculator() { }

        private BitternessCalculation _CalcType;
        private AlphaAcid _Acid;
        private Ounce _Amount;
        private TimeSpan _BoilTime;
        private Gallon _FinalVolume;
        private Gallon _BoilVolume;
        private SpecificGravity _Gravity;
        private Ibu _DesiredIbus;
        private decimal _Elevation;

        public static BitternessCalculator Standard
        {
            get => new BitternessCalculator() { _CalcType = BitternessCalculation.Standard };
        }

        public static BitternessCalculator Garetz
        {
            get => new BitternessCalculator() { _CalcType = BitternessCalculation.Garetz };
        }

        public static BitternessCalculator Rager
        {
            get => new BitternessCalculator() { _CalcType = BitternessCalculation.Rager };
        }

        public static BitternessCalculator Tinseth
        {
            get => new BitternessCalculator() { _CalcType = BitternessCalculation.Tinseth };
        }

        public BitternessCalculator AlphaAcid(AlphaAcid acid)
        {
            _Acid = acid;
            return this;
        }

        public BitternessCalculator Amount(Ounce hops)
        {
            _Amount = hops;
            return this;
        }

        public BitternessCalculator BoilTime(TimeSpan boilTime)
        {
            _BoilTime = boilTime;
            return this;
        }

        public BitternessCalculator FinalVolume(Gallon finalVolume)
        {
            _FinalVolume = finalVolume;
            return this;
        }

        public BitternessCalculator BoilVolume(Gallon boilVolume)
        {
            _BoilVolume = boilVolume;
            return this;
        }

        public BitternessCalculator WortGravity(SpecificGravity wortGravity)
        {
            _Gravity = wortGravity;
            return this;
        }

        public BitternessCalculator DesiredIbus(Ibu desiredIbus)
        {
            _DesiredIbus = desiredIbus;
            return this;
        }

        public BitternessCalculator Elevation(decimal elevationFeet)
        {
            _Elevation = elevationFeet;
            return this;
        }

        public Ibu Calculate()
        {
            switch (_CalcType)
            {
                case BitternessCalculation.Standard:
                    this.Require<AlphaAcid>(_Acid);
                    this.Require<Ounce>(_Amount);
                    this.Require(_BoilTime);
                    return BeerMath.StandardBitterness.CalculateIbus(_Acid, _Amount, _BoilTime);
                case BitternessCalculation.Garetz:
                    this.Require<AlphaAcid>(_Acid);
                    this.Require<Ounce>(_Amount);
                    this.Require<Gallon>(_FinalVolume);
                    this.Require<Gallon>(_BoilVolume);
                    this.Require<SpecificGravity>(_Gravity);
                    this.Require(_BoilTime);
                    this.Require<Ibu>(_DesiredIbus);
                    // elevation defaults to 0 and can be negative
                    return BeerMath.Garetz.CalculateIbus(
                        _Acid,
                        _Amount,
                        _FinalVolume,
                        _BoilVolume,
                        _Gravity,
                        _BoilTime,
                        _DesiredIbus,
                        _Elevation);
                case BitternessCalculation.Rager:
                    this.Require<AlphaAcid>(_Acid);
                    this.Require<Ounce>(_Amount);
                    this.Require<Gallon>(_BoilVolume);
                    this.Require<SpecificGravity>(_Gravity);
                    this.Require(_BoilTime);
                    return BeerMath.Rager.CalculateIbus(
                        _Acid,
                        _Amount,
                        _BoilVolume,
                        _Gravity,
                        _BoilTime);
                case BitternessCalculation.Tinseth:
                    this.Require<AlphaAcid>(_Acid);
                    this.Require<Ounce>(_Amount);
                    this.Require<Gallon>(_BoilVolume);
                    this.Require<SpecificGravity>(_Gravity);
                    this.Require(_BoilTime);
                    return BeerMath.Tinseth.CalculateIbus(
                        _Acid,
                        _Amount,
                        _BoilVolume,
                        _Gravity,
                        _BoilTime);
                default:
                    throw new NotImplementedException("bitterness calculation not found");
            }
        }

        private void Require<T>(BeerValue value)
            where T : BeerValue
        {
            if (value == null)
            {
                throw new ArgumentNullException($"expected non-null {typeof(T)}");
            }
        }

        private void Require(TimeSpan value)
        {
            if (value.Equals(TimeSpan.Zero))
            {
                throw new ArgumentNullException($"expected non-zero {value.GetType()}");
            }
        }
    }
}
