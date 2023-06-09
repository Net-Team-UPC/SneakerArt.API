using SneakerArt.API.Collection.Domain.Models;
using SneakerArt.API.Collection.Domain.Repositories;
using SneakerArt.API.Collection.Domain.Services;
using SneakerArt.API.Collection.Domain.Services.Communication;
using SneakerArt.API.Shared.Domain.Repositories;

namespace SneakerArt.API.Collection.Services;

public class ShoeService : IShoeService
{

    private readonly IShoeRepository _shoeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ShoeService(IShoeRepository shoeRepository, IUnitOfWork unitOfWork)
    {
        _shoeRepository = shoeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Shoe>> ListAsync()
    {
        return await _shoeRepository.ListAsync();
    }

    public async Task<IEnumerable<Shoe>> ListByCommentIdAsync(int commentId)
    {
        return await _shoeRepository.FindByCommentIdAsync(commentId);
    }

    public async Task<ShoeResponse> SaveAsync(Shoe shoe)
    {
        try
        {
            await _shoeRepository.AddAsync(shoe);
            await _unitOfWork.CompleteAsync();

            return new ShoeResponse(shoe);
        }
        catch (Exception e)
        {
            return new ShoeResponse($"An error occurred while saving the shoe: {e.Message}");
        }
    }

    public async Task<ShoeResponse> UpdateAsync(int id, Shoe shoe)
    {
        var existingShoe = await _shoeRepository.FindByIdAsync(id);

        if (existingShoe == null)
            return new ShoeResponse("Shoe not found.");

        existingShoe.Name = shoe.Name;
        existingShoe.Description = shoe.Description;
        existingShoe.Price = shoe.Price;
        existingShoe.Img = shoe.Img;

        try
        {
            _shoeRepository.Update(existingShoe);
            await _unitOfWork.CompleteAsync();

            return new ShoeResponse(existingShoe);
        }
        catch (Exception e)
        {
            return new ShoeResponse($"An error occurred while updating the shoe: {e.Message}");
        }
    }

    public async Task<ShoeResponse> DeleteAsync(int id)
    {
        var existingShoe = await _shoeRepository.FindByIdAsync(id);
        if(existingShoe == null) 
            return new ShoeResponse("Shoe not found.");

        try
        {
            _shoeRepository.Remove(existingShoe);
            await _unitOfWork.CompleteAsync();

            return new ShoeResponse(existingShoe);
        }
        catch(Exception e)
        {
            return new ShoeResponse($"An error occurred while deleting the shoe: {e.Message}");
        }
    }
}