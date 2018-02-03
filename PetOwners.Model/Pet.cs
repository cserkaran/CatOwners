namespace PetOwners.Model
{
    /// <summary>
    /// The pet model.Models the Pet object of the domain.
    /// </summary>
    public class Pet
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public PetType Type { get; set; }
    }
}
