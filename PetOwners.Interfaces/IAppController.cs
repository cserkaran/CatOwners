using System.Collections.Generic;

namespace PetOwners.Interfaces
{
    /// <summary>
    /// Application Controller with Business Logic e.g. reading and sorting pets.
    /// </summary>
    public interface IAppController
    { 
        /// <summary>
        /// Reads the sorted cat names by gender.
        /// </summary>
        /// <returns><see cref="IDictionary"/>object where key is the gender of the owner
        /// and value is list of cat names sorted by their name</returns>
        IDictionary<string, List<string>> ReadSortedCatNamesByGender();
    }
}
