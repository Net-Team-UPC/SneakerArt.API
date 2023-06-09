using System.ComponentModel.DataAnnotations;

namespace SneakerArt.API.Collection.Resources;

public class SaveCommentResource
{
    [Required]
    [MaxLength(150)]
    public string Name { get; set; }
    
    
}