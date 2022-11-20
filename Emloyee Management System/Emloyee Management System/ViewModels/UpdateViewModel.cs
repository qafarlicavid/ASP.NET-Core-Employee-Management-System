using Emloyee_Management_System.Atributes;
using System.ComponentModel.DataAnnotations;

namespace Emloyee_Management_System.ViewModels
{
    public class UpdateViewModel
    {
        [RegularExpression(@"[A-Za-z]{3,20}", ErrorMessage = "Firstname must be upper than 3 char and must consist of letters")]
        [Required]
        public string FirstName { get; set; }

        [RegularExpression(@"[A-Za-z]{3,20}", ErrorMessage = "Lastname must be upper than 3 char and must consist of letters")]
        [Required]
        public string LastName { get; set; }

        [RegularExpression(@"[A-Za-z]{3,20}", ErrorMessage = "Father Name must be upper than 3 char and must consist of letters")]
        [Required]
        public string FatherName { get; set; }

        [FinnValidation(ErrorMessage = "Finn code must be exist of 7 char , less 1 fiqure and less 1 letter")]
        [Required]
        public string Fin { get; set; }

        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }

        [Required]
        public string EmpCode { get; set; }

        public UpdateViewModel()
        {

        }

        public UpdateViewModel(string firstName, string lastName, string fatherName, string fin, string email, string empCode)
        {
            FirstName = firstName;
            LastName = lastName;
            FatherName = fatherName;
            Fin = fin;
            Email = email;
            EmpCode = empCode;
        }
    }
}
