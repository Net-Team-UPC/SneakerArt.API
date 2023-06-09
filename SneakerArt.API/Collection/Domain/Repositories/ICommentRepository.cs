using SneakerArt.API.Collection.Domain.Models;

namespace SneakerArt.API.Collection.Domain.Repositories;

public interface ICommentRepository
{
    Task<IEnumerable<Comment>> ListAsync();
    Task AddAsync(Comment comment);
    Task<Comment> FindByIdAsync(int id);
    void Update(Comment comment);
    void Remove(Comment comment);
}