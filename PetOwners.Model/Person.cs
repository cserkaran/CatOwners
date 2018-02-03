using System.Collections.Generic;

namespace PetOwners.Model
{
    /// <summary>
    /// The person model.Models the Person object of the domain.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        /// <value>
        /// The gender.
        /// </value>
        public string Gender { get; set; }

        /// <summary>
        /// Gets or sets the age.
        /// </summary>
        /// <value>
        /// The age.
        /// </value>
        public int Age { get; set; }

        /// <summary>
        /// Gets or sets the pets.
        /// </summary>
        /// <value>
        /// The pets.
        /// </value>
        public List<Pet> Pets  { get; set; }
    }
}
