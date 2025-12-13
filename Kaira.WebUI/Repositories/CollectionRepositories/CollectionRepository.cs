using Dapper;
using Kaira.WebUI.Context;
using Kaira.WebUI.Dtos.CollectionDtos;
using System.Data;

namespace Kaira.WebUI.Repositories.CollectionRepositories
{
    public class CollectionRepository(AppDbContext _context) : ICollectionRepository
    {
        private readonly IDbConnection _db = _context.CreateConnection();

        public async Task CreateAsync(CreateCollectionDto collectionDto)
        {
            string query = "INSERT INTO Collections (ImageUrl,Tittle, Description) VALUES (@ImageUrl, @Tittle, @Description)";
            var parameters = new DynamicParameters(collectionDto);
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task DeleteAsync(int id)
        {
            string query = "DELETE FROM Collections WHERE CollectionId=@CollectionId";
            var parameters = new DynamicParameters();
            parameters.Add("@CollectionId", id);
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task<IEnumerable<ResultCollectionDto>> GetAllAsync()
        {
            string query = "SELECT * FROM Collections";
            return await _db.QueryAsync<ResultCollectionDto>(query);
        }

        public async Task<UpdateCollectionDto> GetByIdAsync(int id)
        {
            string query = "SELECT * FROM Collections WHERE CollectionId=@CollectionId";
            var parameters = new DynamicParameters();
            parameters.Add("@CollectionId", id);
            return await _db.QueryFirstOrDefaultAsync<UpdateCollectionDto>(query, parameters);
        }

        public async Task UpdateAsync(UpdateCollectionDto collectionDto)
        {
            string query = "UPDATE Collections SET ImageUrl=@ImageUrl, Tittle=@Tittle, Description=@Description WHERE CollectionId=@CollectionId";
            var parameters = new DynamicParameters(collectionDto);
            await _db.ExecuteAsync(query, parameters);
        }
    }
}
