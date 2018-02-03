using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatOwners.Infrastructure
{
    public class CatalogProvider
    {
        public static SafeDirectoryCatalog DirectoryCatalog
        {
            get
            {
                var catalog = new SafeDirectoryCatalog(@"C:\Data\KARAN\Learning\CatOwners\Build\");

                return catalog;
            }
        }
    

        /// <summary>
        /// Gets the assembly catalogs.
        /// </summary>
        /// <value></value>
        public static AggregateCatalog AssemblyCatalogs
        {
            get
            {
                var catalog = new AggregateCatalog();
                var asms = AssemblyHelper.Assemblies;
                foreach (var assembly in asms)
                {
                    catalog.Catalogs.Add(new AssemblyCatalog(assembly));
                }

                return catalog;
            }
        }
    }
}
