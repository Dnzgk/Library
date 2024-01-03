using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Web.Models
{
	public class Skill {
		[Key]
        public int Id { get; set; }
        [Required, StringLength(64)]
        public string Title { get; set; }
        [StringLength(256)]
        public string? Description { get; set; }
        [Required]
        public int Score { get; set; }
		[Required]
		public bool Status { get; set; }
    }
}
