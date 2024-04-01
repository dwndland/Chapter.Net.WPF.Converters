// -----------------------------------------------------------------------------------------------------------------
// <copyright file="MultiValueConverterGroup.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters
{
    /// <summary>
    ///     Calls the EntryConverter and then one converter after another by passing the result of the previous as a value to
    ///     the second.
    /// </summary>
    public class MultiValueConverterGroup : List<IValueConverter>, IMultiValueConverter
    {
        /// <summary>
        ///     The entry converter which result to pass to the other.
        /// </summary>
        public IMultiValueConverter EntryConverter { get; set; }

        /// <summary>
        ///     Calls the EntryConverter and then one converter after another by passing the result of the previous as a value to
        ///     the second.
        /// </summary>
        /// <param name="values">The values to convert.</param>
        /// <param name="targetType">The target type passed to all converters.</param>
        /// <param name="parameter">The parameter passed to all converters.</param>
        /// <param name="culture">The culture passed to all converters.</param>
        /// <returns>The result of the last converter.</returns>
        /// <exception cref="InvalidOperationException">The EntryConverter is not set.</exception>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (EntryConverter == null)
                throw new InvalidOperationException("The EntryConverter is not set.");

            if (values == null)
                return null;

            var value = EntryConverter.Convert(values, targetType, parameter, culture);
            return this.Aggregate(value, (current, converter) => converter.Convert(current, targetType, parameter, culture));
        }

        /// <summary>
        ///     ConvertBack is not implemented.
        /// </summary>
        /// <param name="value">Unused.</param>
        /// <param name="targetTypes">Unused.</param>
        /// <param name="parameter">Unused.</param>
        /// <param name="culture">Unused.</param>
        /// <returns>Nothing.</returns>
        /// <exception cref="NotImplementedException">The ConvertBack is not implemented.</exception>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}