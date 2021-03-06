﻿// <copyright file="QuickIODirectoryInfo_Operators.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>01/06/2014</date>
// <summary>Provides properties and instance methods for directories</summary>

using System;
using System.IO;
using SchwabenCode.QuickIO.Internal;

#if NET40_OR_GREATER
using System.Threading.Tasks;
#endif

namespace SchwabenCode.QuickIO
{
    public sealed partial class QuickIODirectoryInfo
    {
        /// <summary>
        /// Returns a <see cref="DirectoryInfo"/> of the current path of this folder
        /// </summary>
        /// <returns><see cref="DirectoryInfo"/></returns>
        public DirectoryInfo AsDirectoryInfo()
        {
            return new DirectoryInfo( base.FullName );
        }

        /// <summary>
        /// Explizit Cast
        /// </summary>
        /// <param name="directoryInfo"><see cref="DirectoryInfo"/></param>
        /// <returns><see cref="QuickIODirectoryInfo"/></returns>
        public static explicit operator QuickIODirectoryInfo( DirectoryInfo directoryInfo )
        {
            return InternalQuickIO.LoadDirectoryFromPathInfo( new QuickIOPathInfo( directoryInfo.FullName ) );
        }

        /// <summary>
        /// Receives <see cref="QuickIODirectoryMetadata"/> of current file
        /// </summary>
        /// <returns><see cref="QuickIODirectoryMetadata"/></returns>
        public QuickIODirectoryMetadata GetMetadata()
        {
            return InternalQuickIO.EnumerateDirectoryMetadata( FullNameUnc, FindData );
        }

#if NET40_OR_GREATER
        /// <summary>
        /// Receives <see cref="QuickIODirectoryMetadata"/> of current file using seperate task
        /// </summary>
        /// <returns><see cref="QuickIODirectoryMetadata"/></returns>
        public Task<QuickIODirectoryMetadata> GetMetadataAsync()
        {
            return Compatibility.NETCompatibility.AsyncExtensions.GetAsyncResult( () => InternalQuickIO.EnumerateDirectoryMetadata( FullNameUnc, FindData ) );
        }
#endif
    }
}
