using System.ComponentModel.DataAnnotations;

namespace SneakerArt.API.Collection.Resources;

public class SaveDesignResource
{
    [Required]
    [MaxLength(50)]
    public string Brand { get; set; }
    
    [Required]
    public string Model { get; set; }
    
    [Required]
    public string Color { get; set; }
    
    
    public string Size { get; set; }
    
    [Required]
    [MaxLength(200)]
    public string Img { get; set; }
}