using SneakerArt.API.Collection.Domain.Models;

namespace SneakerArt.API.Collection.Domain.Repositories;

public interface IShoeRepository
{
    Task<IEnumerable<Shoe>> ListAsync();
    Task AddAsync(Shoe shoe);
    Task<Shoe> FindByIdAsync(int id);
    void Update(Shoe shoe);
    void Remove(Shoe shoe);
}