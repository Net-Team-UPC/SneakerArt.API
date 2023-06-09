using System.ComponentModel.DataAnnotations;

namespace SneakerArt.API.Collection.Resources;

public class SaveShoeResource
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(200)]
    public string Description { get; set; }
    
    [Required]
    public string Price { get; set; }
    
    [Required]
    public string Img { get; set; }
    
    [Required]
    public int CommentId { get; set; }
}