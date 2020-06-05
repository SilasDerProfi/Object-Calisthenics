namespace System
{
    /// <summary>
    /// A Container for primitive types and objects to make them constant.
    /// </summary>
    /// <typeparam name="T">Type that is not constant</typeparam>
    public readonly struct Const<T>
    {
        private readonly T _value;

        /// <summary>
        /// Creats the unchangeable Const type
        /// </summary>
        /// <param name="value">unchangeable Value of the const type</param>
        public Const(T value)
        {
            _value = value;
        }

        /// <summary>
        /// Converts the Const type implicit to the original type
        /// </summary>
        /// <param name="const">The const type to convert</param>
        public static implicit operator T(Const<T> @const) => @const._value;

        /// <summary>
        /// Returns the values ToString() Method
        /// </summary>
        /// <returns>ToString() Call of the Value</returns>
        public readonly override string ToString() => $"{_value}";
    }
}