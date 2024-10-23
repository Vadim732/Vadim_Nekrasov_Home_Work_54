using System.ComponentModel.DataAnnotations;

namespace PhoneStore.Models;

public class Phone
{
    public int Id { get; set; }
    [Required]
    [StringLength(26, MinimumLength = 2)]
    public string Name { get; set; }
    [Required]
    [StringLength(26, MinimumLength = 2)]
    public string Company { get; set; }
    [Required]
    [StringLength(500, MinimumLength = 34)]
    public string Characteristics { get; set; }
    [Required]
    [Url]
    public string Image { get; set; }
    [Required]
    [Range(45, 10000, ErrorMessage = "Price must be between 45$ and 10,000$!")]
    public int Price { get; set; }
    
    [Required]
    public int? BrandId { get; set; }
    public Brand? Brand { get; set; }
}