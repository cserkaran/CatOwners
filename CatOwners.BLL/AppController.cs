using CatOwners.Interfaces;
using CatOwners.Model;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;

namespace CatOwners.Bll
{
    [Export(typeof(IAppController))]
    public class AppController : IAppController
    {
        [Import(typeof(IPersonRepository))]
        private IPersonRepository PersonRepository { get; set; }

        public void GetCatsByOwnerGender()
        {
            var person = PersonRepository.ReadPeople();


            //var infos = (from p in person
            //            select new { p.Gender, p.Pets })
            //           .GroupBy(item => item.Gender);

            //foreach(var info in infos)
            //{
            //    var k = info.Key;
                
            //}

            //Dictionary<string, List<Pet>> petsByGender = new Dictionary<string, List<Pet>>();
            //foreach(var p in person)
            //{
            //    if (petsByGender.ContainsKey(p.Gender))
            //    {
            //        petsByGender[p.Gender].AddRange(p.Pets);
            //    }
            //    else
            //    {
            //        petsByGender.Add(p.Gender, p.Pets);
            //    }
            //}

            //foreach(var key in petsByGender.Keys)
            //{
            //    petsByGender[key] = petsByGender[key].OrderBy(item => item.Name).ToList();
            //} 

            //return person;
        }

        //public Task<IList<Person>> GetCatsByOwnerGenderAsync()
        //{
        //    return PersonRepository.ReadPeopleAsync();
        //}
    }
}
