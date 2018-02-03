using PetOwners.Model;
using System.Collections.Generic;

namespace PetOwners.Interfaces
{
    /// <summary>
    /// Repository pattern to read the list of person from a database or some other data source 
    /// e.g. a http service Url.
    /// Encapsulates the concrete type of data source from the consumer of the data.
    /// </summary>
    public interface IPersonRepository
    {
        IList<Person> ReadPeople();
    }
}
