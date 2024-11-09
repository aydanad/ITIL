namespace ITIL.Services.Contract
{
    public interface ICityService
    {
        Task<IList<CityDto>> GetAllAsync();
        Task<CityDto?> GetAsync(Guid id);
        Task<Guid?> InsertAsync(CreateCityDto createCityDto, CancellationToken cancellationToken);
        Task<bool> RemoveAsync(Guid id, CancellationToken cancellationToken);
        Task<bool> UpdateAsync(UpdateCityDto updateCityDto, CancellationToken cancellationToken);
    }

}
