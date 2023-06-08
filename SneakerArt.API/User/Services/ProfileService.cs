using SneakerArt.API.User.Domain.Models;
using SneakerArt.API.User.Domain.Responsitories;
using SneakerArt.API.User.Domain.Services;
using SneakerArt.API.User.Domain.Services.Communication;
using SneakerArt.API.Shared.Domain.Repositories;

namespace SneakerArt.API.User.Services;

public class ProfileService : IProfileService
{
    private readonly IProfileService _profileRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProfileService(IProfileService profileRepository, IUnitOfWork unitOfWork)
    {
        _profileRepository = profileRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Profile>> ListAsync()
    {
        return await _profileRepository.ListAsync();
    }

    public async Task<ProfileResponse> SaveAsync(Profile profile)
    {
        try
        {
            await _profileRepository.AddAsync(profile);
            await _unitOfWork.CompleteAsync();

            return new ProfileResponse(profile);
        }
        catch (Exception e)
        {
            return new ProfileResponse($"An error occurred while saving the profile: {e.Message}");
        }
    }

    public async Task<ProfileResponse> UpdateAsync(int id, Profile profile)
    {
        var existingProfile = await _profileRepository.FindByIdAsync(id);

        if (existingProfile == null)
            return new ProfileResponse("Profile not found.");

        existingProfile.Name = profile.Name;
        existingProfile.Email = profile.Email;
        existingProfile.Password = profile.Password;

        try
        {
            _profileRepository.Update(existingProfile);
            await _unitOfWork.CompleteAsync();

            return new ProfileResponse(existingProfile);
        }
        catch (Exception e)
        {
            return new ProfileResponse($"An error occurred while updating the profile: {e.Message}");
        }
    }

    public async Task<ProfileResponse> DeleteAsync(int id)
    {
        var existingProfile = await _profileRepository.FindByIdAsync(id);
        if(existingProfile == null) 
            return new ProfileResponse("Profile not found.");

        try
        {
            _profileRepository.Remove(existingProfile);
            await _unitOfWork.CompleteAsync();

            return new ProfileResponse(existingProfile);
        }
        catch(Exception e)
        {
            return new ProfileResponse($"An error occurred while deleting the profile: {e.Message}");
        }
    }
}