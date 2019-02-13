using System.ComponentModel.DataAnnotations;

namespace DomainDI.Entities
{
    public class Categories
    {
        #region Properties

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [MinLength(10, ErrorMessage ="Need 10 words or more.")]
        public string Description { get; set; }

        #endregion
    }
}
