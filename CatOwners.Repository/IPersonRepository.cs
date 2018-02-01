using CatOwners.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatOwners.Repository
{
    public interface IPersonRepository
    {
        Task<IList<Person>> ReadPeople();
    }
}
