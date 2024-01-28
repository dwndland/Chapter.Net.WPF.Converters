// -----------------------------------------------------------------------------------------------------------------
// <copyright file="PathToStringConverter.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Windows.Data;

#pragma warning disable CA2208
// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters;

/// <summary>
///     Reads out part of a given path.
/// </summary>
[ValueConversion(typeof(string), typeof(string))]
public class PathToStringConverter : ValueConverter
{
    /// <summary>
    ///     Defines what section to extract from the given path.
    /// </summary>
    /// <value>Default: PathSection.FileName.</value>
    [DefaultValue(PathSection.FileName)]
    public PathSection Section { get; set; } = PathSection.FileName;

    /// <summary>
    ///     Reads out part of a given path.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted value.</returns>
    /// <exception cref="ArgumentOutOfRangeException">PathSection got extended but not covered.</exception>
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value == null)
            return string.Empty;

        var path = value.ToString();
        return Section switch
        {
            PathSection.Drive => Path.GetPathRoot(path),
            PathSection.Directory => Path.GetDirectoryName(path),
            PathSection.FileName => Path.GetFileName(path),
            PathSection.Extension => Path.GetExtension(path),
            PathSection.PathWithoutExtension => Path.Combine(Path.GetDirectoryName(path)!, Path.GetFileNameWithoutExtension(path)!),
            PathSection.FileWithoutExtension => Path.GetFileNameWithoutExtension(path),
            _ => throw new ArgumentOutOfRangeException(nameof(Section), Section, "PathSection got extended but not covered.")
        };
    }
}