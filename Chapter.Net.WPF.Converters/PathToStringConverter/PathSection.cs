// -----------------------------------------------------------------------------------------------------------------
// <copyright file="PathSection.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters;

/// <summary>
///     Defines what part of the path to return in the <see cref="PathToStringConverter" />.
/// </summary>
public enum PathSection
{
    /// <summary>
    ///     C:\
    /// </summary>
    Drive,

    /// <summary>
    ///     C:\Demo
    /// </summary>
    Directory,

    /// <summary>
    ///     File.txt
    /// </summary>
    FileName,

    /// <summary>
    ///     .txt
    /// </summary>
    Extension,

    /// <summary>
    ///     C:\Demo\File
    /// </summary>
    PathWithoutExtension,

    /// <summary>
    ///     File
    /// </summary>
    FileWithoutExtension
}