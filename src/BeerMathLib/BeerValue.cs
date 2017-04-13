namespace BeerMath
{
    internal interface IBeerValue
    {
        decimal Value { get; }
    }

    public abstract class BeerValue : IBeerValue
    {
        public decimal Value { get; protected set; }

        // override object.Equals
        public override bool Equals (object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }

            IBeerValue other = obj as IBeerValue;
            return this.Value.Equals(other.Value);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }
    }
}
