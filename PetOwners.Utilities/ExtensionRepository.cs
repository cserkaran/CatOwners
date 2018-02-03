using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace PetOwners.Infrastructure
{
    /// <summary>
    /// Load MEF Import Extensions.
    /// </summary>
    public class ExtensionRepository
    {
        private static readonly Lazy<ExtensionRepository> LazyInstance =
            new Lazy<ExtensionRepository>(() => new ExtensionRepository());

        /// <summary>
        /// Indicates whether the repository has been loaded or not
        /// </summary>
        private bool isLoaded;

        private SafeDirectoryCatalog _catalog;

        /// <summary>
        /// Private constructor for singleton pattern
        /// </summary>
        private ExtensionRepository()
        {
        }

        /// <summary>
        /// Gets an instance of the extension repository
        /// </summary>
        public static ExtensionRepository Instance
        {
            get
            {
                return LazyInstance.Value;
            }
        }

        /// <summary>
        /// Load MEF Imports.
        /// </summary>
        public void Load(object root)
        {
            if (isLoaded)
            {
                return;
            }

            try
            {
                 _catalog = CatalogProvider.DirectoryCatalog;
                var container = new CompositionContainer(_catalog);
                container.ComposeParts(root);
                isLoaded = true;
                container.Dispose();
            }
            catch (Exception ex)
            {
                // Log exception with a specified Application logger here.
            }
        }
    }
}
