using Emloyee_Management_System.Atributes;
using System.ComponentModel.DataAnnotations;

namespace Emloyee_Management_System.ViewModels
{
    public class AddViewModel
    {
        [Required]
        [RegularExpression(@"[A-Za-z]{3,20}", ErrorMessage = "Firstname must be upper than 3 char and must consist of letters")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"[A-Za-z]{3,20}", ErrorMessage = "Lastname must be upper than 3 char and must consist of letters")]
        public string LastName { get; set; }

        [RegularExpression(@"[A-Za-z]{3,20}", ErrorMessage = "Father Name must be upper than 3 char and must consist of letters")]
        [Required]
        public string FatherName { get; set; }

        [Required]
        [FinnValidation(ErrorMessage = "Fincode must be exist of 7 char , less 1 fiqure and less 1 letter")]
        public string Fin { get; set; }

        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }


        public AddViewModel()
        {

        }   

        public AddViewModel(string firstName, string lastName, string fatherName, string fin, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            FatherName = fatherName;
            Fin = fin;
            Email = email;
        }
    }
}
