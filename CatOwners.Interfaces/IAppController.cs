using CatOwners.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatOwners.Interfaces
{
    public interface IAppController
    {
        void GetCatsByOwnerGender();
        //IList<Person> GetCatsByOwnerGender();
        //Task<IList<Person>> GetCatsByOwnerGenderAsync();
    }
}
