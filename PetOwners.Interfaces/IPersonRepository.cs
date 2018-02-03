using PetOwners.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetOwners.Interfaces
{
    public interface IPersonRepository
    {
        IList<Person> ReadPeople();
        Task<IList<Person>> ReadPeopleAsync();
    }
}
