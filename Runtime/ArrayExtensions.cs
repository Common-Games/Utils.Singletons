using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

public static class ArrayExtensions
{
    /// <summary>
    /// Adds a single item to an array, USE VERY SPARINGLY, you probably shouldn't be using an Array (if it's your own API).
    /// </summary>
    [PublicAPI]
    [MethodImpl(MethodImplOptions.Synchronized)]
    public static T[] Add<T>(this T[] array, in T item)
    {
        if (array == null) 
        {
            return new[] { item };
        }
        
        Array.Resize(ref array, newSize: array.Length + 1);
        array[array.Length - 1] = item;
 
        return array;
    }

    [PublicAPI]
    [MethodImpl(MethodImplOptions.Synchronized)]
    public static bool HasElements<T>(this T[] array) => (array.Length > 0);
}
