using System.Collections.Generic;
using CatOwners.Model;
using CatOwners.Utilities;
using System.Threading.Tasks;

namespace CatOwners.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private const string _peopleUrl = "http://agl-developer-test.azurewebsites.net/people.json";

        public IList<Person> ReadPeople()
        {
            return HttpClientHelper.GetItemsAsync<Person>(_peopleUrl).Result;
        }

        public async Task<IList<Person>> ReadPeopleAsync()
        {
            return await HttpClientHelper.GetItemsAsync<Person>(_peopleUrl);
        }
    }
}
