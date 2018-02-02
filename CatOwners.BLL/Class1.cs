using CatOwners.Repository;

namespace CatOwners.Bll
{
    public class PeopleFormatter
    {
        private IPersonRepository personRepository;

        public void GetCatsByOwnerGender()
        {
            personRepository.ReadPeople();
        }
    }
}
