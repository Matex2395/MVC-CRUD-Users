using System.ComponentModel.DataAnnotations;

namespace MVC_CRUD_Users.ViewModels
{
    public class UserVM
    {
        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string ConfirmPassword { get; set; } = null!;
    }
}
