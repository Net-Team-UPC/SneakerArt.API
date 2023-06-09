using SneakerArt.API.Collection.Domain.Models;
using SneakerArt.API.Collection.Domain.Repositories;
using SneakerArt.API.Collection.Domain.Services;
using SneakerArt.API.Collection.Domain.Services.Communication;
using SneakerArt.API.Shared.Domain.Repositories;

namespace SneakerArt.API.Collection.Services;

public class DesignService : IDesignService
{
    private readonly IDesignRepository _designRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DesignService(IDesignRepository designRepository, IUnitOfWork unitOfWork)
    {
        _designRepository = designRepository;
        _unitOfWork = unitOfWork;
    }
    
    
    public async Task<IEnumerable<Design>> ListAsync()
    {
        return await _designRepository.ListAsync();
    }

    public async Task<DesignResponse> SaveAsync(Design design)
    {
        try
        {
            await _designRepository.AddAsync(design);
            await _unitOfWork.CompleteAsync();

            return new DesignResponse(design);
        }
        catch (Exception e)
        {
            return new DesignResponse($"An error occurred while saving the design: {e.Message}");
        }
    }

    public async Task<DesignResponse> UpdateAsync(int id, Design design)
    {
        var existingDesign = await _designRepository.FindByIdAsync(id);

        if (existingDesign == null)
            return new DesignResponse("Design not found.");

        existingDesign.Brand = design.Brand;
        existingDesign.Model = design.Model;
        existingDesign.Color = design.Color;
        existingDesign.Img = design.Img;
        existingDesign.Img = design.Img;

        try
        {
            _designRepository.Update(existingDesign);
            await _unitOfWork.CompleteAsync();

            return new DesignResponse(existingDesign);
        }
        catch (Exception e)
        {
            return new DesignResponse($"An error occurred while updating the design: {e.Message}");
        }
    }

    public async Task<DesignResponse> DeleteAsync(int id)
    {
        var existingDesign = await _designRepository.FindByIdAsync(id);
        if(existingDesign == null) 
            return new DesignResponse("Design not found.");

        try
        {
            _designRepository.Remove(existingDesign);
            await _unitOfWork.CompleteAsync();

            return new DesignResponse(existingDesign);
        }
        catch(Exception e)
        {
            return new DesignResponse($"An error occurred while deleting the design: {e.Message}");
        }
    }
}