using Dapper;
using Kaira.WebUI.Context;
using Kaira.WebUI.Dtos.ProductDtos;
using System.Data;

namespace Kaira.WebUI.Repositories.ProductRepositories
{
    public class ProductRepository(AppDbContext _context) : IProductRepository
    {
        private readonly IDbConnection _db = _context.CreateConnection();

        public async Task CreateAsync(CreateProductDto productDto)
        {
            string query = "INSERT INTO Products (Name,ImageUrl,Description,Price,CategoryId) VALUES (@Name,@ImageUrl,@Description,@Price,@CategoryId)";
            var parameters = new DynamicParameters(productDto);
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task DeleteAsync(int id)
        {
            string query = "DELETE FROM Products WHERE ProductId = @ProductId";
            var parameters = new DynamicParameters();
            parameters.Add("@ProductId", id);
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task<IEnumerable<ResultProductDto>> GetAllAsync()
        {
            string query = "SELECT p.Name,c.Name AS CategoryName,Price,ImageUrl,Description,ProductId FROM Products AS p INNER JOIN Categories AS c ON c.CategoryId=p.CategoryId";
            return await _db.QueryAsync<ResultProductDto>(query);
        }

        public async Task<UpdateProductDto> GetByIdAsync(int id)
        {
            string query = "SELECT * FROM Products WHERE ProductId=@ProductId";
            var parameters = new DynamicParameters();
            parameters.Add("@ProductId", id);
            return await _db.QueryFirstOrDefaultAsync<UpdateProductDto>(query,parameters);
        }

        public async Task UpdateAsync(UpdateProductDto productDto)
        {
            string query = "UPDATE Products SET Name=@Name, ImageUrl=@ImageUrl, Description=@Description, Price=@Price, CategoryId=@CategoryId WHERE ProductId=@ProductId";
            var parameters = new DynamicParameters(productDto);
            await _db.ExecuteAsync(query, parameters);
        }
    }
}
