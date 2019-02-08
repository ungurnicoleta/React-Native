using System.ComponentModel.DataAnnotations;

namespace AccesaStart.WebApi.ViewModels
{
    public class UserViewModel
    {
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
