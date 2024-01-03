using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Web.Models
{
	public class Article
	{
		[Key]
        public int Id { get; set; }

		[Required(ErrorMessage = "Bu alanı doldurmak zorunlu.")]
		[StringLength(64, ErrorMessage = "Bu alan en fazla 64 karakter içermelidir.")]
		[MinLength(3, ErrorMessage = "Bu alan en az 3 karakter içermelidir.")]
		public string Title { get; set; }

		[Required(ErrorMessage = "Bu alanı doldurmak zorunlu.")]
		[StringLength(512, ErrorMessage = "Bu alan en fazla 512 karakter içermelidir.")]
		[MinLength(3, ErrorMessage = "Bu alan en az 3 karakter içermelidir.")]
		public string Description { get; set; }

		[Required(ErrorMessage = "Bu alanı doldurmak zorunlu.")]
		[StringLength(50, ErrorMessage ="Bu alan en fazla 50 karakter içermelidir.")]
		[MinLength(4, ErrorMessage = "Bu alan en az 4 karakter içermelidir.")]
		public string Author { get; set; }
		
		[Required(ErrorMessage = "Bu alanı doldurmak zorunlu.")]
		[StringLength(64, ErrorMessage = "Bu alan en fazla 64 karakter içermelidir.")]
		[MinLength(3, ErrorMessage = "Bu alan en az 3 karakter içermelidir.")]
		public string Subject { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
		public DateTime? UpdatedDate { get; set; }
    }
}
