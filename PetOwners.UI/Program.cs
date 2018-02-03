using PetOwners.Infrastructure;
using PetOwners.Interfaces;
using System;
using System.ComponentModel.Composition;

namespace PetOwners.UI
{
    /// <summary>
    /// A simple console app to read the cat names and print them on the  console.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Gets or sets the application controller. This will inject the AppController 
        /// implementation.
        /// </summary>
        /// <value>
        /// The application controller.
        /// </value>
        [Import(typeof(IAppController))]
        private IAppController AppController { get; set; }

        /// <summary>
        /// Prevents a default instance of the <see cref="Program"/> class from being created.
        /// </summary>
        private Program()
        {
            // Initial Service Hub to to platform level initializations.
            PlatformServiceHub.Instance.Initialize(this);
        }

        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            Program program = new Program();
            program.ReadAndPrint();
        }

        /// <summary>
        /// Reads the and print data.
        /// </summary>
        private void ReadAndPrint()
        {
            var sortedCatNames = AppController.ReadSortedCatNamesByGender();
            foreach (var catName in sortedCatNames)
            {
                // Gender is the key.
                Console.WriteLine(catName.Key);
                // actual name of the pet(cat) is the value
                foreach (var cat in catName.Value)
                {
                    Console.WriteLine($"-- {cat}");
                }
            }

            // Wait for user to exit by pressing any key.
            Console.Read();
        }
    }
}
