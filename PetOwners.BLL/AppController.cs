using PetOwners.Interfaces;
using PetOwners.Model;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.SqlClient;
using System.Linq;

namespace PetOwners.Bll
{
    [Export(typeof(IAppController))]
    public class AppController : IAppController
    {
        [Import(typeof(IPersonRepository))]
        private IPersonRepository PersonRepository { get; set; }

        public IDictionary<string, List<string>> ReadSortedCatNamesByGender()
        {
            var people = PersonRepository.ReadPeople();

            IDictionary<string, List<string>> catsByGender = new Dictionary<string, List<string>>();

            var groups = people.GroupBy(p => p.Gender);

            foreach (var grp in groups)
            {
                List<string> catNames = PetNamesInSortOrder(grp.ToList(),PetType.Cat,SortOrder.Ascending);
                catsByGender.Add(grp.Key, catNames);
            }

            return catsByGender;
        }

        private List<string> PetNamesInSortOrder(List<Person> people,PetType petType,SortOrder sortOrder)
        {
            if (people == null)
            {
                return null;
            }
            List<string> petNames = new List<string>();


            var allNames = people.Where(person => person.Pets != null)
                .Select(p => p.Pets.Where(pet => pet.Type == petType)
                                        .Select(pet => pet.Name))
                .SelectMany(petName => petName);

            // order ASC/DESC or none
            switch (sortOrder)
            {
                case SortOrder.Ascending:
                    {
                        petNames = allNames.OrderBy(petName => petName).ToList();
                    }
                    break;
                case SortOrder.Descending:
                    {
                        petNames = allNames.OrderByDescending(petName => petName).ToList();
                    }
                    break;
                case SortOrder.Unspecified:
                    {
                        petNames = allNames.ToList();
                    }
                    break;
            }

            return petNames;
        }
    }
}
