using System.ComponentModel.DataAnnotations;

namespace SneakerArt.API.Collection.Resources;

public class SaveShoeResource
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Description { get; set; }
    
    [Required]
    public string Price { get; set; }
    
    [Required]
    public string Img { get; set; }
}