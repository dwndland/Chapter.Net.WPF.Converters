// -----------------------------------------------------------------------------------------------------------------
// <copyright file="IsLastItemInListConverter.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters;

/// <summary>
///     Checks if the given item container is the last in the list.
/// </summary>
[ValueConversion(typeof(DependencyObject), typeof(bool))]
public class IsLastItemInListConverter : ValueConverter
{
    /// <summary>
    ///     Checks if the given item container is the last in the list.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted value.</returns>
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not DependencyObject container)
            return false;

        var itemsControl = ItemsControl.ItemsControlFromItemContainer(container);
        if (itemsControl == null)
            return false;

        return itemsControl.ItemContainerGenerator.IndexFromContainer(container) == itemsControl.Items.Count - 1;
    }
}