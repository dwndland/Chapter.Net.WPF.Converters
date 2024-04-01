// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ValueToPathConverter.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Data;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters
{
    /// <summary>
    ///     Combines all given strings into a path.
    /// </summary>
    [ValueConversion(typeof(string[]), typeof(string))]
    public class ValueToPathConverter : MultiValueConverter
    {
        /// <summary>
        ///     Combines all given strings into a path.
        /// </summary>
        /// <param name="values">The values to convert.</param>
        /// <param name="targetType">Unused.</param>
        /// <param name="parameter">Unused.</param>
        /// <param name="culture">Unused.</param>
        /// <returns>The converted value.</returns>
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                return string.Empty;

            var sections = values.Where(x => x != null).Select(x => x.ToString()).ToArray();
            return Path.Combine(sections);
        }
    }
}