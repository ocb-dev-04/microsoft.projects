using System;
using System.ComponentModel.DataAnnotations;

namespace ModelCore.Entities.SameProperties
{
    public class BaseEntity
    {
        #region Properties

        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Create { get; set; }

        #endregion
    }
}
