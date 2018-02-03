using PetOwners.Interfaces;
using PetOwners.Model;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.SqlClient;
using System.Linq;

namespace PetOwners.Bll
{
    /// <summary>
    /// IAppController implementation.
    /// </summary>
    /// <seealso cref="PetOwners.Interfaces.IAppController" />
    [Export(typeof(IAppController))]
    public class AppController : IAppController
    {
        /// <summary>
        /// Gets or sets the person repository.
        /// </summary>
        /// <value>
        /// The IPersonRepository to read data from a data source.
        /// </value>
        [Import(typeof(IPersonRepository))]
        private IPersonRepository PersonRepository { get; set; }

        /// <summary>
        /// Reads the sorted cat names by gender.
        /// </summary>
        /// <returns><see cref="IDictionary"/>object where key is the gender of the owner
        /// and value is list of cat names sorted by their name</returns>
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

        /// <summary>
        /// Sorts the name of the pets.
        /// </summary>
        /// <param name="people">The person list.</param>
        /// <param name="petType">Type of the pet.</param>
        /// <param name="sortOrder">SortOrder type which is Ascending,Descending or Unspecified.</param>
        /// <returns></returns>
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
