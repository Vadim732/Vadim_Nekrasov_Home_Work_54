namespace PhoneStore.Models;

public class Phone
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Company { get; set; }
    public string Characteristics { get; set; }
    public string Image { get; set; }
    public int Price { get; set; }
    
    public int BrandId { get; set; }
    public Brand Brand { get; set; }
}