using Dapper;
using Organization.Database.Entities;
using System.Data;

namespace Organization.DataAccess.Repositories
{
    public class CompanyRepository : IGenericRepository<CompanyEntity>
    {
        private readonly IDbConnection _dbConnection;

        public CompanyRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task Create(CompanyEntity entity)
        {
            string query = "INSERT INTO Companies (Index, Name, OrganizationFk) VALUES (@Index, @Name, @OrganizationFk); SELECT CAST(SCOPE_IDENTITY() as long);";
            long id = await _dbConnection.ExecuteScalarAsync<long>(query, entity);
            entity.Id = id;
        }

        public async Task Delete(long id)
        {
            string query = "DELETE FROM Companies WHERE Id = @id";
            await _dbConnection.ExecuteAsync(query, id);
        }

        public async Task<CompanyEntity?> Find(long id)
        {
            string query = "SELECT * FROM Companies WHERE Id = @id";
            return await _dbConnection.QueryFirstOrDefaultAsync<CompanyEntity?>(query, new { id = id });
        }

        public async Task<CompanyEntity?> Get(string query, CompanyEntity obj)
            => await _dbConnection.QueryFirstOrDefaultAsync<CompanyEntity>(query, obj);

        public async Task<IEnumerable<CompanyEntity>> GetAll()
        {
            string query = "SELECT * FROM Companies";
            return await _dbConnection.QueryAsync<CompanyEntity>(query);
        }

        public async Task<IEnumerable<CompanyEntity>> GetAll(string query, CompanyEntity obj)
            => await _dbConnection.QueryAsync<CompanyEntity>(query, obj);

        public async Task Update(CompanyEntity entity)
        {
            string query = "UPDATE Companies SET [Index] = @Index, Name = @Name, OrganizationFk = @OrganizationFk WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(query, entity);
        }
    }
}