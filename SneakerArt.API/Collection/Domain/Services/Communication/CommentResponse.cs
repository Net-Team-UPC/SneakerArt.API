using SneakerArt.API.Collection.Domain.Models;
using SneakerArt.API.Shared.Domain.Services.Communication;

namespace SneakerArt.API.Collection.Domain.Services.Communication;

public class CommentResponse : BaseResponse<Comment>
{
    public CommentResponse(string message) : base(message)
    {
    }

    public CommentResponse(Comment resource) : base(resource)
    {
    }
}