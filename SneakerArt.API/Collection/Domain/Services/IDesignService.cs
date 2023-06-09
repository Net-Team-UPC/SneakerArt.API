using SneakerArt.API.Collection.Domain.Models;
using SneakerArt.API.Collection.Domain.Services.Communication;

namespace SneakerArt.API.Collection.Domain.Services;

public interface IDesignService
{
    Task<IEnumerable<Design>> ListAsync();
    Task<DesignResponse> SaveAsync(Design design);
    Task<DesignResponse> UpdateAsync(int id, Design design);
    Task<DesignResponse> DeleteAsync(int id);
}