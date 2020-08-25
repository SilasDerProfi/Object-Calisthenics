namespace TIE.Data
{
    public class PlateletValue
    {
        private readonly byte _value;

        private PlateletValue(byte value)
        {
            _value = value;
        }

        public static implicit operator byte(PlateletValue value) => value._value;

        public static implicit operator PlateletValue(byte value)
        {
            if (value > 9)
                value = 9;

            if (value < 1)
                value = 1;

            return new PlateletValue(value);
        }
    }
}
