using SneakerArt.API.Collection.Domain.Models;

namespace SneakerArt.API.Collection.Resources;

public class ShoeResource
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Price { get; set; }
    public string Img { get; set; }
    public CommentResource Comment { get; set; }
}