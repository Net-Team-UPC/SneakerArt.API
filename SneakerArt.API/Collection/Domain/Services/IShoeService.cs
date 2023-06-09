using SneakerArt.API.Collection.Domain.Models;
using SneakerArt.API.Collection.Domain.Services.Communication;

namespace SneakerArt.API.Collection.Domain.Services;

public interface IShoeService
{
    Task<IEnumerable<Shoe>> ListAsync();
    Task<IEnumerable<Shoe>> ListByCommentIdAsync(int commentId);
    Task<ShoeResponse> SaveAsync(Shoe shoe);
    Task<ShoeResponse> UpdateAsync(int id, Shoe shoe);
    Task<ShoeResponse> DeleteAsync(int id);
}