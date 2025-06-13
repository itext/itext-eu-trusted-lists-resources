using System;
using System.Collections.Generic;

namespace iText.Eutrustedlistsresources {
    /// <summary>
    /// Utility class for handling java conversion methods.
    /// </summary>
    internal class Util {

        /// <summary>
        /// Converts a Java-style array to a C# list.
        /// </summary>
        public static IList<T> ArraysAsList<T>(params T[] a) {
            return new List<T>(a);
        }
    }
}