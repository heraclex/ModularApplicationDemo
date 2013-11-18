// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExportEntry.cs">
//   copyright  NerverLand 2012 https://github.com/heraclex/
// </copyright>
// <summary>
//   Interface of Modules
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace NerverLand.Module.Contract.Modules
{
    using System;
    using System.Collections.Generic;
    using NerverLand.Module.Common.Export;
    
    /// <summary>
    /// Define a code module that provide a name, title and all export entries for import/use later.
    /// </summary>
    public interface IModule
    {
        #region Public Properties

        /// <summary>
        /// Gets the module name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the module title.
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Gets the module version.
        /// </summary>
        Version Version { get; }

        /// <summary>
        /// Gets all export entries.
        /// </summary>
        IEnumerable<ExportEntry> Entries { get; }

        #endregion
    }
}
