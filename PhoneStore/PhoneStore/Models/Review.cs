using System.ComponentModel.DataAnnotations;

namespace PhoneStore.Models;

public class Review
{
    public int Id { get; set; }
    [Required]
    [StringLength(26, MinimumLength = 2)]
    public string Name { get; set; }
    [Required]
    [StringLength(200, MinimumLength = 24)]
    public string Message { get; set; }
    [Required]
    [Range(1, 5, ErrorMessage = "The rating must be from 1 to 5!")]
    public int Grade { get; set; }
    
    [Required]
    public int? PhoneId { get; set; }
    public Phone? Phone { get; set; }
}