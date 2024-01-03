using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Web.Models
{
    public class MainPage
    {
        [Key]
        public int Id { get; set; }
        [StringLength(128)]
        public string? ImageUrl { get; set; }
        [Required, StringLength(64)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
