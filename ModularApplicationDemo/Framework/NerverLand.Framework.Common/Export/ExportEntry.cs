// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExportEntry.cs">
//   copyright  NerverLand 2012 https://github.com/heraclex/
// </copyright>
// <summary>
//   An module export entry.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace NerverLand.Framework.Common.Export
{
    using System;

    /// <summary>
    /// An module export entry.
    /// </summary>
    public class ExportEntry
    {
        /// <summary>
        /// Gets the entry name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the interface type.
        /// </summary>
        public Type InfType { get; private set; }

        /// <summary>
        /// Gets the implementation type.
        /// </summary>
        public Type ImplType { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the entry is a singleton.
        /// </summary>
        public bool IsSingleton { get; private set; }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="infType">
        /// The interface type.
        /// </param>
        /// <param name="implType">
        /// The implementation type.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The created entry.
        /// </returns>
        public static ExportEntry Instance(Type infType, Type implType, string name = null)
        {
            return Create(infType, implType, name, false);
        }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="implType">
        /// The implementation type.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The created entry.
        /// </returns>
        public static ExportEntry Instance(Type implType, string name = null)
        {
            return Create(implType, implType, name, false);
        }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <typeparam name="TInf">
        /// The interface type.
        /// </typeparam>
        /// <typeparam name="TImpl">
        /// The implementation type.
        /// </typeparam>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The created entry.
        /// </returns>
        public static ExportEntry Instance<TInf, TImpl>(string name = null)
        {
            return Create(typeof(TInf), typeof(TImpl), name, false);
        }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <typeparam name="TImpl">
        /// The implementation type.
        /// </typeparam>
        /// <returns>
        /// The export entity.
        /// </returns>
        public static ExportEntry Instance<TImpl>(string name = null)
        {
            return Create(typeof(TImpl), typeof(TImpl), name, false);
        }

        /// <summary>
        /// Create a new singleton instance.
        /// </summary>
        /// <param name="infType">
        /// The interface type.
        /// </param>
        /// <param name="implType">
        /// The implementation type.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The created entry.
        /// </returns>
        public static ExportEntry Singleton(Type infType, Type implType, string name = null)
        {
            return Create(infType, implType, name, true);
        }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="implType">
        /// The implementation type.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The created entry.
        /// </returns>
        public static ExportEntry Singleton(Type implType, string name = null)
        {
            return Create(implType, implType, name, true);
        }

        /// <summary>
        /// The singleton.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <typeparam name="TInf">
        /// The interface type
        /// </typeparam>
        /// <typeparam name="TImpl">
        /// The implementation type.
        /// </typeparam>
        /// <returns>
        /// The created entry.
        /// </returns>
        public static ExportEntry Singleton<TInf, TImpl>(string name = null)
        {
            return Create(typeof(TInf), typeof(TImpl), name, true);
        }

        /// <summary>
        /// The singleton.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <typeparam name="TImpl">
        /// The implementation type.
        /// </typeparam>
        /// <returns>
        /// The created entry.
        /// </returns>
        public static ExportEntry Singleton<TImpl>(string name = null)
        {
            return Create(typeof(TImpl), typeof(TImpl), name, true);
        }

        /// <summary>
        /// Create new entry instance
        /// </summary>
        /// <param name="infType">
        /// The interface type.
        /// </param>
        /// <param name="implType">
        /// The implementation type.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="singleton">
        /// The flag indicating the entry is a singleton.
        /// </param>
        /// <returns>
        /// The created entry.
        /// </returns>
        private static ExportEntry Create(Type infType, Type implType, string name, bool singleton)
        {
            var ret = new ExportEntry { Name = name, InfType = infType, ImplType = implType, IsSingleton = singleton };
            return ret;
        }
    }
}
