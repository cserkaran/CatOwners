using CatOwners.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatOwners.Interfaces
{
    public interface IPersonRepository
    {
        IList<Person> ReadPeople();
        Task<IList<Person>> ReadPeopleAsync();
    }
}
