using System.ComponentModel.DataAnnotations;
using ModelCore.Entities.SameProperties;

namespace ModelCore.Entities
{
    public class Products : BaseEntity
    {
        #region Properties

        [Required]
        [MinLength(5)]
        public string Name { get; set; }
        [Required]
        [MinLength(10)]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Stock { get; set; }

        #endregion
    }
}
