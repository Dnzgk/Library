using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Web.Models
{
    public class About
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(32)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [StringLength(128)]
        public string? ImageUrl { get; set; }
    }
}