﻿// <copyright file="QuickIOTransferFileCopyService_Events.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>06/20/2014</date>
// <summary>QuickIOTransferFileCopyService Events</summary>
using SchwabenCode.QuickIO.Transfer.Events;

namespace SchwabenCode.QuickIO.Transfer
{
    public partial class QuickIOTransferDirectoryCopyService
    {
        /// <summary>
        /// Copy events from observer to current instance
        /// </summary>
        private void RegisterInternalEventHandling()
        {
            this.Observer.FileCopyError += ( sender, e ) => OnFileCopyError( e );
            this.Observer.FileCopyFinished += ( sender, e ) => OnFileCopyFinished( e );
            this.Observer.FileCopyProgress += ( sender, e ) => OnFileCopyProgress( e );
            this.Observer.FileCopyStarted += ( sender, e ) => OnFileCopyStarted( e );

            this.Observer.DirectoryCreated += ( sender, e ) => OnDirectoryCreated( e );
            this.Observer.DirectoryCreating += ( sender, e ) => OnDirectoryCreating( e );
            this.Observer.DirectoryCreationError += ( sender, e ) => OnDirectoryCreationError( e );
        }

        #region Directory Create

        /// <summary>
        /// This event is raised if directory creation operation fails
        /// </summary>
        public event QuickIOTransferDirectoryCreationErrorHandler DirectoryCreationError;

        /// <summary>
        /// This event is raised before an upcoming directory creation operation is performed
        /// </summary>
        public event QuickIOTransferDirectoryCreatingHandler DirectoryCreating;

        /// <summary>
        /// This event is raised when a directory was created
        /// </summary>
        public event QuickIOTransferDirectoryCreatedHandler DirectoryCreated;

        /// <summary>
        /// Fire <see cref="DirectoryCreationError"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        public virtual void OnDirectoryCreationError( QuickIOTransferDirectoryCreationErrorEventArgs args )
        {
            if ( DirectoryCreationError != null )
            {
                DirectoryCreationError( this, args );
            }
        }
        /// <summary>
        /// Fire <see cref="DirectoryCreating"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        public virtual void OnDirectoryCreating( QuickIOTransferDirectoryCreatingEventArgs args )
        {
            if ( DirectoryCreating != null )
            {
                DirectoryCreating( this, args );
            }
        }
        /// <summary>
        /// Fire <see cref="DirectoryCreated"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        public virtual void OnDirectoryCreated( QuickIOTransferDirectoryCreatedEventArgs args )
        {
            if ( DirectoryCreated != null )
            {
                DirectoryCreated( this, args );
            }
        }
        #endregion
        #region File Copy

        /// <summary>
        /// This event is raised if file copy operation fails
        /// </summary>
        public event QuickIOTransferFileCopyErrorHandler FileCopyError;

        /// <summary>
        /// This event is raised during a copy of a file. It provides current information such as progress, speed and estimated time.
        /// </summary>
        public event QuickIOTransferFileCopyProgressHandler FileCopyProgress;

        /// <summary>
        /// This event is triggered at the beginning of the file copy operation.
        /// </summary>
        public event QuickIOTransferFileCopyStartedHandler FileCopyStarted;

        /// <summary>
        /// This event is raised at the end of the file copy operation.
        /// </summary>
        public event QuickIOTransferFileCopyFinishedHandler FileCopyFinished;

        /// <summary>
        /// Fire <see cref="FileCopyError"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        public virtual void OnFileCopyError( QuickIOTransferFileCopyErrorEventArgs args )
        {
            if ( FileCopyError != null )
            {
                FileCopyError( this, args );
            }
        }
        /// <summary>
        /// Fire <see cref="FileCopyProgress"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        public virtual void OnFileCopyProgress( QuickIOTransferFileCopyProgressEventArgs args )
        {
            if ( FileCopyProgress != null )
            {
                FileCopyProgress( this, args );
            }
        }
        /// <summary>
        /// Fire <see cref="FileCopyStarted"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        public virtual void OnFileCopyStarted( QuickIOTransferFileCopyStartedEventArgs args )
        {
            if ( FileCopyStarted != null )
            {
                FileCopyStarted( this, args );
            }
        }
        /// <summary>
        /// Fire <see cref="FileCopyFinished"/>
        /// </summary>
        /// <param name="args">Holds further event information</param>
        public virtual void OnFileCopyFinished( QuickIOTransferFileCopyFinishedEventArgs args )
        {
            if ( FileCopyFinished != null )
            {
                FileCopyFinished( this, args );
            }
        }
        #endregion
    }
}
