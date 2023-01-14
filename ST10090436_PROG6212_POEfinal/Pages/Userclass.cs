using System.ComponentModel.DataAnnotations;

namespace ST10090436_PROG6212_POEfinal.Pages
{
    public class Userclass
    {
        [Required(ErrorMessage = "Please Enter Username!")]
        [Display(Name ="Username")]
        public string Username { get; set; }

        [Required(ErrorMessage ="Please Enter Password!")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
