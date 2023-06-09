namespace SneakerArt.API.Collection.Domain.Models;

public class Comment
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    //Relationships
    public List<Shoe> Shoes { get; set; }
}