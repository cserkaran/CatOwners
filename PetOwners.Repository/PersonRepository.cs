using System.Collections.Generic;
using PetOwners.Model;
using PetOwners.Infrastructure;
using System.ComponentModel.Composition;
using PetOwners.Interfaces;

namespace PetOwners.Repository
{
    /// <summary>
    /// IPersonRepository implementation.
    /// </summary>
    /// <seealso cref="PetOwners.Interfaces.IPersonRepository" />
    [Export(typeof(IPersonRepository))]
    public class PersonRepository : IPersonRepository
    {
        /// <summary>
        /// The people URL
        /// </summary>
        private const string _peopleUrl = "http://agl-developer-test.azurewebsites.net/people.json";

        /// <summary>
        /// Reads the people.
        /// </summary>
        /// <returns></returns>
        public IList<Person> ReadPeople()
        {
            return HttpClientHelper.GetItemsAsync<Person>(_peopleUrl).Result;
        }
    }
}
