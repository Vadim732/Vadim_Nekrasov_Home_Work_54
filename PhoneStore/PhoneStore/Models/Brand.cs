using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using PhoneStore.Controllers;

namespace PhoneStore.Models;

public class Brand
{
    public int Id { get; set; }
    [Required]
    [StringLength(26, MinimumLength = 2)]
    [Remote(action: "CheckName", controller: "Brand", ErrorMessage = "A brand with this name already exists!")]
    public string Name { get; set; }
    [Required]
    [EmailAddress]
    [StringLength(26, MinimumLength = 2)]
    public string Email { get; set; }
    [Required]
    [Remote(action: "CheckDate", controller: "Brand", ErrorMessage = "The founding date cannot be in the future or earlier than 100 years!")]
    public DateTime DateFoundation { get; set; }
}