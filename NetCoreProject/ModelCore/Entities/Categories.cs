using System.ComponentModel.DataAnnotations;
using ModelCore.Entities.SameProperties;

namespace ModelCore.Entities
{
    public class Categories : BaseEntity
    {
        #region Properties

        [Required]
        [MinLength(8)]
        public string Name { get; set; }
        [Required]
        [MinLength(10)]
        public string Description { get; set; }

        #endregion
    }
}
