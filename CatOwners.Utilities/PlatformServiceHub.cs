using System;

namespace CatOwners.Infrastructure
{
    public class PlatformServiceHub
    {
        private static readonly Lazy<PlatformServiceHub> LazyObject =
          new Lazy<PlatformServiceHub>(() => new PlatformServiceHub());

        /// <summary>
        /// The singleton instance of PlatformServiceHub
        /// </summary>
        public static PlatformServiceHub Instance
        {
            get
            {
                return LazyObject.Value;
            }
        }

        /// <summary>
        /// Private constructor for singleton pattern
        /// </summary>
        private PlatformServiceHub()
        {

        }

        public void Initialize(object root)
         {
            ExtensionRepository.Instance.Load(root);
        }

       
    }
}
