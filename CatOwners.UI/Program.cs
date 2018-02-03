using CatOwners.Infrastructure;
using CatOwners.Interfaces;
using System.ComponentModel.Composition;

namespace CatOwners.UI
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
            AppController.GetCatsByOwnerGender();
        }
    }
}
