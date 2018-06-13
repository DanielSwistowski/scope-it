using System.ComponentModel.DataAnnotations;

namespace Scope_IT.Models
{
    public class ContactEmail
    {
        [Required(ErrorMessage ="Wpisz swoje imię")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Wpisz swoje nazwisko")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Wpisz swój adres e-mail")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",ErrorMessage = "Wpisany adres jest nieprawidłowy")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Wpisz swój numer telefonu")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Wpisz temat wiadomości")]
        [StringLength(50,ErrorMessage ="Temat wiadomości jest za długi")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Wpisz treść wiadomości")]
        [StringLength(250, ErrorMessage = "Wiadomość jest za długa")]
        public string Message { get; set; }
    }
}