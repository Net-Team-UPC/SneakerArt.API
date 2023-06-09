using SneakerArt.API.Collection.Domain.Models;
using SneakerArt.API.Collection.Domain.Repositories;
using SneakerArt.API.Collection.Domain.Services;
using SneakerArt.API.Collection.Domain.Services.Communication;
using SneakerArt.API.Shared.Domain.Repositories;

namespace SneakerArt.API.Collection.Services;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CommentService(ICommentRepository commentRepository, IUnitOfWork unitOfWork)
    {
        _commentRepository = commentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Comment>> ListAsync()
    {
        return await _commentRepository.ListAsync();
    }

    public async Task<CommentResponse> SaveAsync(Comment comment)
    {
        try
        {
            await _commentRepository.AddAsync(comment);
            await _unitOfWork.CompleteAsync();

            return new CommentResponse(comment);
        }
        catch (Exception e)
        {
            return new CommentResponse($"An error occurred while saving the comment: {e.Message}");
        }
    }

    public async Task<CommentResponse> UpdateAsync(int id, Comment comment)
    {
        var existingComment = await _commentRepository.FindByIdAsync(id);

        if (existingComment == null)
            return new CommentResponse("Comment not found.");

        existingComment.Name = comment.Name;

        try
        {
            _commentRepository.Update(existingComment);
            await _unitOfWork.CompleteAsync();

            return new CommentResponse(existingComment);
        }
        catch (Exception e)
        {
            return new CommentResponse($"An error occurred while updating the comment: {e.Message}");
        }
    }

    public async Task<CommentResponse> DeleteAsync(int id)
    {
        var existingComment = await _commentRepository.FindByIdAsync(id);
        if(existingComment == null) 
            return new CommentResponse("Comment not found.");

        try
        {
            _commentRepository.Remove(existingComment);
            await _unitOfWork.CompleteAsync();

            return new CommentResponse(existingComment);
        }
        catch(Exception e)
        {
            return new CommentResponse($"An error occurred while deleting the comment: {e.Message}");
        }
    }
}