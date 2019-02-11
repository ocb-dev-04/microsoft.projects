using System;
using System.ComponentModel.DataAnnotations;

namespace Asp.Net.MVC.Models
{
    public class BlogPost
    {
        #region Properties

        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(10, ErrorMessage ="*This property is required.")]
        public string Title { get; set; }
        [Required]
        [MinLength(25, ErrorMessage ="*Need 25 words or more.")]
        public string Content { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "*This property is required.")]
        public string Autor { get; set; }
        [Required]
        public DateTime Publication { get; set; }

        #endregion

        #region Construct

        public BlogPost()
            => Publication = DateTime.Now;

        #endregion
    }
}