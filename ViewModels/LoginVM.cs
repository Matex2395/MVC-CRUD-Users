using System.ComponentModel.DataAnnotations;

namespace MVC_CRUD_Users.ViewModels
{
    public class LoginVM
    {
        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
