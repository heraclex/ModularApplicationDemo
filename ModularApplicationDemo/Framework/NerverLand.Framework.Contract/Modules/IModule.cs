using System;
using System.Collections.Generic;

namespace NerverLand.Framework.Contract.Modules
{
    using NerverLand.Framework.Common.Export;

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
