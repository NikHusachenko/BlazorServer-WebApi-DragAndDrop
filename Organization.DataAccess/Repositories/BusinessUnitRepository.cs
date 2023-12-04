using Dapper;
using Organization.Database.Entities;
using System.Data;

namespace Organization.DataAccess.Repositories
{
    public class BusinessUnitRepository : IGenericRepository<BusinessUnitEntity>
    {
        private readonly IDbConnection _dbConnection;

        public BusinessUnitRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task Create(BusinessUnitEntity entity)
        {
            string query = "INSERT INTO [Business units] (Index, Name, CompanyFk) VALUES (@Index, @Name, @CompanyFk); SELECT CAST(SCOPE_IDENTITY() as long);";
            long id = await _dbConnection.ExecuteScalarAsync<long>(query, entity);
            entity.Id = id;
        }

        public async Task Delete(long id)
        {
            string query = "DELETE FROM [Business units] WHERE Id = @id";
            await _dbConnection.ExecuteAsync(query, id);
        }

        public async Task<BusinessUnitEntity?> Find(long id)
        {
            string query = "SELECT * FROM [Business units] WHERE Id = @id";
            return await _dbConnection.QueryFirstOrDefaultAsync<BusinessUnitEntity?>(query, new { id = id });
        }

        public async Task<BusinessUnitEntity?> Get(string query, BusinessUnitEntity obj)
        {
            return await _dbConnection.QueryFirstOrDefaultAsync<BusinessUnitEntity>(query, obj);
        }

        public async Task<IEnumerable<BusinessUnitEntity>> GetAll()
        {
            string query = "SELECT * FROM [Business units]";
            return await _dbConnection.QueryAsync<BusinessUnitEntity>(query);
        }

        public async Task<IEnumerable<BusinessUnitEntity>> GetAll(string query, BusinessUnitEntity obj)
            => await _dbConnection.QueryAsync<BusinessUnitEntity>(query, obj);

        public async Task Update(BusinessUnitEntity entity)
        {
            string query = "UPDATE [Business units] SET [Index] = @Index, Name = @Name, CompanyFk = @CompanyFk WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(query, entity);
        }
    }
}