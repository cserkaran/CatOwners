using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CatOwners.Infrastructure
{
    /// <summary>
    /// Helper class to handle Assemblies
    /// </summary>
    public static class AssemblyHelper
    {
        /// <summary>
        /// List of delegates to determine if specified assembly should be ignored. 
        /// Note: List the checks from fastest to slowest.
        /// </summary>
        private static readonly List<Func<Assembly, bool>> IgnoreChecks = new List<Func<Assembly, bool>>
                {
                    asm => asm.GlobalAssemblyCache,
                    asm => asm.FullName.StartsWith("Microsoft.", StringComparison.OrdinalIgnoreCase),
                    asm => asm.FullName.StartsWith("xUnit.", StringComparison.OrdinalIgnoreCase),
                    asm => asm.FullName.StartsWith("System.", StringComparison.OrdinalIgnoreCase)
                };

        /// <summary>
        /// Retrieve the list of assemblies relevant to this application.
        /// </summary>
        /// <value></value>
        public static IEnumerable<Assembly> Assemblies
        {
            get
            {
                return AppDomain.CurrentDomain.GetAssemblies().Where(a =>  IgnoreChecks.All(check => !check(a)));
            }
        }
    }
}
