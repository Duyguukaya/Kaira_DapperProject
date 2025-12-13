
using Kaira.WebUI.Dtos.MarkaDtos;

namespace Kaira.WebUI.Repositories.MarkaRepositories
{
    public interface IMarkaRepository
    {
        Task<IEnumerable<ResultMarkaDto>> GetAllAsync();
        Task<UpdateMarkaDto> GetByIdAsync(int id);
        Task CreateAsync(CreateMarkaDto markaDto);
        Task UpdateAsync(UpdateMarkaDto markaDto);
        Task DeleteAsync(int id);
    }
}
