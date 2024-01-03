using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Web.Models {
    public class Assignment {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }

        [Required]
        [StringLength(64)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime Deadline { get; set; }    

    }
}
