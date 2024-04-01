// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ConcatenateStringConverter.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters
{
    /// <summary>
    ///     Concatenates all given values to a single string with an optional configurable separator.
    /// </summary>
    [ValueConversion(typeof(object[]), typeof(string))]
    public class ConcatenateStringConverter : MultiValueConverter
    {
        /// <summary>
        ///     The separator to use to concatenate the values.
        /// </summary>
        /// <value>Default: "".</value>
        [DefaultValue("")]
        public string Separator { get; set; } = string.Empty;

        /// <summary>
        ///     Indicator if null parts of the values shall be filtered out or not.
        /// </summary>
        /// <value>Default: false.</value>
        [DefaultValue(false)]
        public bool AcceptNullParts { get; set; } = false;

        /// <summary>
        ///     Concatenates all given values to a single string with an optional configurable separator.
        /// </summary>
        /// <param name="values">The values to convert.</param>
        /// <param name="targetType">Unused.</param>
        /// <param name="parameter">Unused.</param>
        /// <param name="culture">Unused.</param>
        /// <returns>The converted value.</returns>
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values == null ? string.Empty : string.Join(Separator, values.Where(x => AcceptNullParts || x != null));
        }
    }
}