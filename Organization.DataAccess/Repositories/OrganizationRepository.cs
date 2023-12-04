using Dapper;
using Organization.Database.Entities;
using System.Data;

namespace Organization.DataAccess.Repositories
{
    public class OrganizationRepository : IGenericRepository<OrganizationEntity>
    {
        private readonly IDbConnection _dbConnection;

        public OrganizationRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task Create(OrganizationEntity entity)
        {
            string query = "INSERT INTO Organizations (Index, Name) VALUES (@Index, @Name); SELECT CAST(SCOPE_IDENTITY() as long);";
            long id = await _dbConnection.ExecuteScalarAsync<long>(query, entity);
            entity.Id = id;
        }

        public async Task Delete(long id)
        {
            string query = "DELETE FROM Organizations WHETE Id = @id";
            await _dbConnection.ExecuteAsync(query, id);
        }

        public async Task<OrganizationEntity?> Find(long id)
        {
            string query = "SELECT * FROM Organizations WHERE Id = @id";
            return await _dbConnection.QueryFirstOrDefaultAsync<OrganizationEntity?>(query, id);
        }

        public async Task<OrganizationEntity?> Get(string query, OrganizationEntity obj)
            => await _dbConnection.QueryFirstOrDefaultAsync<OrganizationEntity>(query, obj);

        public async Task<IEnumerable<OrganizationEntity>> GetAll()
        {
            string query = @"SELECT * 
                            FROM Organizations o 
                            LEFT JOIN Companies c ON o.Id = c.OrganizationFk
                            LEFT JOIN [Business units] b ON c.Id = b.CompanyFk
                            ORDER BY o.Id";

            Dictionary<long, OrganizationEntity> organizations = new Dictionary<long, OrganizationEntity>();
            var org = await _dbConnection.QueryAsync<OrganizationEntity, CompanyEntity, BusinessUnitEntity, OrganizationEntity>(query, (org, comp, bunit) =>
            {
                if (!organizations.TryGetValue(org.Id, out OrganizationEntity organization))
                {
                    organizations.Add(org.Id, org);
                    organization = org;
                }

                CompanyEntity company = organization.Companies.Find(company => company.Id == comp.Id);
                if (comp == null)
                {
                    return organization;
                }

                if (company == null)
                {
                    organization.Companies.Add(comp);
                    company = comp;
                }
                company.Organization = organization;

                BusinessUnitEntity businessUnit = company.BusinessUnits.Find(bu => bu.Id == bunit.Id);
                if (businessUnit == null)
                {
                    company.BusinessUnits.Add(bunit);
                    businessUnit = bunit;
                }
                businessUnit.Company = company;

                return organization;
            });

            return organizations.Values.Select(val => val);
        }

        public async Task<IEnumerable<OrganizationEntity>> GetAll(string query, OrganizationEntity obj)
            => await _dbConnection.QueryAsync<OrganizationEntity>(query, obj);

        public async Task Update(OrganizationEntity entity)
        {
            string query = "UPDATE Organizations SET Index = @Index, Name = @Name WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(query, entity);
        }
    }
}