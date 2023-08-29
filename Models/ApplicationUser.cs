using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{
    [Display(Name = "Imię i Nazwisko")]
    public string FullName { get; set; }
}
