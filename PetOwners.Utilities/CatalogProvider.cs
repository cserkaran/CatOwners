using System.IO;

namespace PetOwners.Infrastructure
{
    /// <summary>
    /// Provider catalog for MEF
    /// </summary>
    public class CatalogProvider
    {

        /// <summary>
        /// Gets the<see cref="SafeDirectoryCatalog"/>.
        /// </summary>
        /// <value>
        /// The directory catalog.
        /// </value>
        public static SafeDirectoryCatalog DirectoryCatalog
        {
            get
            {
                var catalog = new SafeDirectoryCatalog(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
                return catalog;
            }
        }
    }
}
