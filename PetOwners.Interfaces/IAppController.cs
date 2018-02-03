using PetOwners.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetOwners.Interfaces
{
    public interface IAppController
    {
        IDictionary<string, List<string>> ReadSortedCatNamesByGender();
        //IList<Person> GetCatsByOwnerGender();
        //Task<IList<Person>> GetCatsByOwnerGenderAsync();
    }
}
