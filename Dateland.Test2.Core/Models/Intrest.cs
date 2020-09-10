namespace Dateland.Test2.Core
{
    // Required namespace
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Repsresents an intrest object
    /// </summary>
    public class Interest
    {
        /// <summary>
        /// Gets or sets the intrest identifier.
        /// </summary>
        [Key]
        public int IntrestID { get; set; }

        /// <summary>
        /// Gets or sets the name of the intrest.
        /// </summary>
        /// <value>
        /// The name of the intrest.
        /// </value>
        [Required]
        [DataType("NVARCHAR(MAX)")]
        public string IntrestName { get; set; }
    }
}
