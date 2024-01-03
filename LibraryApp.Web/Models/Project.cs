using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Web.Models {
    public class Project {
        public Project()
        {
            Assignments = new HashSet<Assignment>();
        }
        [Key]
        public int Id { get; set; }
        public string? ImageUrl { get; set; }
        [Required]
        [StringLength(64)]
        public string Name { get; set; }
        [Required]
        [StringLength(256)]
        public string Description { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }

        public ICollection<Assignment> Assignments { get; set; }

    }
}
