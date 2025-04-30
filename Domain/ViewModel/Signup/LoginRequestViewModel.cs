using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModel.Signup
{
    public class LoginRequestViewModel
    {
        [Required(ErrorMessage = "Username is required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

    }
}
