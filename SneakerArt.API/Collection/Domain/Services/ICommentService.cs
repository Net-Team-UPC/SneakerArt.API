using SneakerArt.API.Collection.Domain.Models;
using SneakerArt.API.Collection.Domain.Services.Communication;

namespace SneakerArt.API.Collection.Domain.Services;

public interface ICommentService
{
    Task<IEnumerable<Comment>> ListAsync();
    Task<CommentResponse> SaveAsync(Comment comment);
    Task<CommentResponse> UpdateAsync(int id, Comment comment);
    Task<CommentResponse> DeleteAsync(int id);
}