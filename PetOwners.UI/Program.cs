using PetOwners.Infrastructure;
using PetOwners.Interfaces;
using System.ComponentModel.Composition;

namespace PetOwners.UI
{
    class Program
    {
        [Import(typeof(IAppController))]
        private IAppController AppController { get; set; }

        private Program()
        {
            PlatformServiceHub.Instance.Initialize(this);
        }


        static void Main(string[] args)
        {
            Program program = new Program();
          

            program.Read();
        }

        private void Read()
        {
            AppController.ReadSortedCatNamesByGender();
        }
    }
}
