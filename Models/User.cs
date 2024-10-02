using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_CRUD_Users.Models;

public partial class User
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
    [StringLength(100, ErrorMessage = "El nombre no puede contener más de 100 caracteres")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "El email es obligatorio")]
    [EmailAddress(ErrorMessage = "El formato del email es incorrecto")]
    [StringLength(100, ErrorMessage = "El email no puede contener más de 100 caracteres")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "La contraseña es obligatoria")]
    [StringLength(255, MinimumLength = 8, ErrorMessage = "La contraseña debe tener mínimo 8 caracteres y máximo 255")]
    public string Password { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? Role { get; set; }
}
