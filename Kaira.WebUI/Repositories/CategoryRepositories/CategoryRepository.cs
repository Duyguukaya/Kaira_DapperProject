using Dapper;
using Kaira.WebUI.Context;
using Kaira.WebUI.Dtos.CategoryDtos;
using System.Data;

namespace Kaira.WebUI.Repositories.CategoryRepositories
{
    public class CategoryRepository(AppDbContext _context) : ICategoryRepository
    {
        private readonly IDbConnection _db = _context.CreateConnection();


        public async Task CreateAsync(CreateCategoryDto categoryDto)
        {
            string query = "INSERT INTO Categories (Name) VALUES (@Name)";
            var parameters = new DynamicParameters(categoryDto);
            await _db.ExecuteAsync(query, parameters);

        }

        public async Task DeleteAsync(int id)
        {
            string query ="DELETE FROM Categories WHERE CategoryId=@CategoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@CategoryId", id);
           await _db.ExecuteAsync(query, parameters);
        }

        public async Task<IEnumerable<ResultCategoryDto>> GetAllAsync()
        {
            string query = "SELECT * FROM Categories";
            return await _db.QueryAsync<ResultCategoryDto>(query);
        }

        public async Task<UpdateCategoryDto> GetByIdAsync(int id)
        {
           string query = "SELECT * FROM Categories WHERE CategoryId=@CategoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@CategoryId", id);
            return await _db.QueryFirstOrDefaultAsync<UpdateCategoryDto>(query, parameters);
        }

        public async Task UpdateAsync(UpdateCategoryDto categoryDto)
        {
            string query = "UPDATE Categories SET Name=@Name WHERE CategoryId=@CategoryId";
            var parameters = new DynamicParameters(categoryDto);
            await _db.ExecuteAsync(query, parameters);
        }
    }
}
