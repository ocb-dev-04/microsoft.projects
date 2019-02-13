using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainDI.Entities
{
    public class Products
    {
        #region Properties

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Need 10 words or more.")]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int Stock { get; set; }

        #region ForeignKeys

        public Categories Category { get; set; }

        #endregion

        #endregion
    }
}
