using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Web.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(64)]
        public string Title { get; set; }
        [Required, StringLength(100)]
        public string Email { get; set; }
        [Required, StringLength(13)]
        public string Phone { get; set; }
        [Required, StringLength(64)]
        public string Address { get; set; }

    }
}
