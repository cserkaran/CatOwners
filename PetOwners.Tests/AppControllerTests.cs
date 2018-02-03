using Moq;
using Newtonsoft.Json;
using PetOwners.Bll;
using PetOwners.Interfaces;
using PetOwners.Model;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Xunit;

namespace PetOwners.Tests
{
    /// <summary>
    /// Unit tests for App Controller.
    /// </summary>
    public class AppControllerTests
    {
        /// <summary>
        /// The person repository moq
        /// </summary>
        private Mock<IPersonRepository> personRepositoryMoq;

        /// <summary>
        /// The application controller
        /// </summary>
        private AppController appController;

        /// <summary>
        /// The sorted cat names by owner
        /// </summary>
        private IDictionary<string, List<string>> sortedCatNamesByOwner;

        private List<string> keys;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppControllerTests"/> class.
        /// </summary>
        public AppControllerTests()
        {
            // setup Moqs and get the sorted cat names
            List<Person> items;
            var peopleJsonData = Path.GetDirectoryName(Assembly.GetExecutingAssembly().EscapedCodeBase.Remove(0,8)) + "\\people.json";
            using (StreamReader r = new StreamReader(peopleJsonData))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<Person>>(json);
            }

            personRepositoryMoq = new Mock<IPersonRepository>();
            personRepositoryMoq.Setup(repo => repo.ReadPeople()).Returns(() => items);

            appController = new AppController();

            var field = typeof(AppController)
                    .GetProperty("PersonRepository", BindingFlags.Instance | BindingFlags.NonPublic);

            field.SetValue(appController, personRepositoryMoq.Object);
            sortedCatNamesByOwner = appController.ReadSortedCatNamesByGender();
            keys = sortedCatNamesByOwner.Keys.ToList();
        }

        [Fact]
        public void Test_SortedCatsOwners_HaveTwoGender()
        {
            // assert there are only two keys.
            Assert.Equal(2, sortedCatNamesByOwner.Keys.Count);
        }

        [Fact]
        public void Test_SortedCatsOwners_AreMaleAndFemale()
        {
            var keys = sortedCatNamesByOwner.Keys.ToList();
            // test two keys are there for male and female.
            Assert.Equal("Male", keys[0]);
            Assert.Equal("Female", keys[1]);
        }

        [Fact]
        public void Test_Males_Have_Four_Cats()
        {
            Assert.Equal(4, sortedCatNamesByOwner[keys[0]].Count);
        }

        [Fact]
        public void Test_Females_Have_Three_Cats()
        {
            Assert.Equal(3, sortedCatNamesByOwner[keys[1]].Count);
        }

        [Fact]
        public void Test_Male_CatNames_AreOrdered()
        {
            var catsOfMales = sortedCatNamesByOwner[keys[0]];

            Assert.Equal("Garfield", catsOfMales[0]);
            Assert.Equal("Jim", catsOfMales[1]);
            Assert.Equal("Max", catsOfMales[2]);
            Assert.Equal("Tom", catsOfMales[3]);
        }

        [Fact]
        public void Test_Female_CatNames_AreOrdered()
        {
            var catsOfFemales = sortedCatNamesByOwner[keys[1]];

            Assert.Equal("Garfield", catsOfFemales[0]);
            Assert.Equal("Simba", catsOfFemales[1]);
            Assert.Equal("Tabby", catsOfFemales[2]);
        }
    }
}
