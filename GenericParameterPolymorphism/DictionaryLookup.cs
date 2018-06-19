using System;
using System.Collections.Generic;

namespace GenericParameterPolymorphism
{
    public static class DictionaryLookup
    {
        private static readonly Dictionary<Type, object> _values = new Dictionary<Type, object>();

        public static object Current<T>() => _values[typeof(T)];
        public static void Current<T>(object value) => _values[typeof(T)] = value;
    }
}