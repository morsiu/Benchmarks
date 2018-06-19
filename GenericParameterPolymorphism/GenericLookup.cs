namespace GenericParameterPolymorphism
{
    public static class GenericLookup<T>
    {
        private static object _value;

        public static object Current() => _value;
        public static void Current(object value) => _value = value;
    }
}