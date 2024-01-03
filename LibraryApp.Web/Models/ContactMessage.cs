using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Web.Models
{
    public class ContactMessage
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "İsim alanını doldurun.")]
        [StringLength(32, ErrorMessage = "İsim alanı en fazla 32 karakter içermeli.")]
        [MinLength(2, ErrorMessage = "İsim alanı en az 2 karakter içermeli.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Soyisim alanını doldurun")]
        [StringLength(32, ErrorMessage = "Soyisim alanı en fazla 32 karakter içermeli.")]
        [MinLength(2, ErrorMessage = "Soyisim alanı en az 2 karakter içermeli.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email alanını doldurun")]
        [StringLength(100, ErrorMessage = "Email alanı en fazla 100 karakter içermeli.")]
        [MinLength(4, ErrorMessage = "Email alanı en az 4 karakter içermeli.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Telefon alanını doldurun")]
        [StringLength(13, ErrorMessage = "Telefon alanı en fazla 13 karakter içermeli")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Konu alanını doldurun")]
        [StringLength(32, ErrorMessage = "Başlık alanı en fazla 32 karakter içermeli.")]
        [MinLength(2, ErrorMessage = "Başlık alanı en az 2 karakter içermeli.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Mesaj alanını doldurun")]
        [StringLength(256, ErrorMessage = "Mesaj alanı en fazla 256 karakter içermeli.")]
        [MinLength(10, ErrorMessage = "Mesaj alanı en az 10 karakter içermeli.")]
        public string Description { get; set; }
        public bool? Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
