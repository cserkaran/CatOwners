using CatOwners.Model;
using CatOwners.Repository;
using System.Collections.Generic;
using Xunit;

namespace CatOwners.Tests
{
    public class Class1
    {
        [Fact]
        public void Test_1()
        {
            IPersonRepository repository = new PersonRepository();
            IList<Person> people = repository.ReadPeople().Result;
        }
    }
}
