// -----------------------------------------------------------------------------------------------------------------
// <copyright file="PathToStringConverter.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters;

/// <summary>
///     Converts a full path to a section from it.
/// </summary>
[ValueConversion(typeof(string), typeof(string))]
public class PathToStringConverter : IValueConverter
{
    /// <summary>
    ///     Defines what section to extract from the given path.
    /// </summary>
    /// <value>Default: PathSection.FileName.</value>
    public PathSection Section { get; set; } = PathSection.FileName;

    /// <summary>
    ///     Converts a full path to a section from it.
    /// </summary>
    /// <param name="value">The full path to separate.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The path section.</returns>
    /// <exception cref="ArgumentOutOfRangeException">PathSection got extended but the switch case is not updated.</exception>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value == null)
            return string.Empty;

        var path = value.ToString();
        switch (Section)
        {
            case PathSection.Drive:
                return Path.GetPathRoot(path);
            case PathSection.Directory:
                return Path.GetDirectoryName(path);
            case PathSection.FileName:
                return Path.GetFileName(path);
            case PathSection.Extension:
                return Path.GetExtension(path);
            case PathSection.PathWithoutExtension:
                return Path.Combine(Path.GetDirectoryName(path)!, Path.GetFileNameWithoutExtension(path)!);
            case PathSection.FileWithoutExtension:
                return Path.GetFileNameWithoutExtension(path);
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    /// <summary>
    ///     ConvertBack is not implemented.
    /// </summary>
    /// <param name="value">Unused.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>Nothing.</returns>
    /// <exception cref="NotImplementedException">ConvertBack is not implemented.</exception>
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}