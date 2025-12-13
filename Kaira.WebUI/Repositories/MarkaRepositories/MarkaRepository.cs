using Dapper;
using Kaira.WebUI.Context;
using Kaira.WebUI.Dtos.MarkaDtos;
using System.Data;

namespace Kaira.WebUI.Repositories.MarkaRepositories
{
    public class MarkaRepository(AppDbContext _context) : IMarkaRepository
    {
        private readonly IDbConnection _db = _context.CreateConnection();
        public async Task CreateAsync(CreateMarkaDto markaDto)
        {
            string query = "INSERT INTO Markalar (MarkaImg) VALUES (@MarkaImg)";
            var parameters = new DynamicParameters(markaDto);
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task DeleteAsync(int id)
        {
            string query = "DELETE FROM Markalar WHERE MarkaId=@MarkaId";
            var parameters = new DynamicParameters();
            parameters.Add("@MarkaId", id);
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task<IEnumerable<ResultMarkaDto>> GetAllAsync()
        {
            string query = "SELECT * FROM Markalar";
            return await _db.QueryAsync<ResultMarkaDto>(query);
        }

        public async Task<UpdateMarkaDto> GetByIdAsync(int id)
        {
            string query = "SELECT * FROM Markalar WHERE MarkaId=@MarkaId";
            var parameters = new DynamicParameters();
            parameters.Add("@MarkaId", id);
            return await _db.QueryFirstOrDefaultAsync<UpdateMarkaDto>(query, parameters);
        }

        public async Task UpdateAsync(UpdateMarkaDto markaDto)
        {
            string query = "UPDATE Markalar SET MarkaImg=@MarkaImg WHERE MarkaId=@MarkaId";
            var parameters = new DynamicParameters(markaDto);
            await _db.ExecuteAsync(query, parameters);
        }
    }
}
