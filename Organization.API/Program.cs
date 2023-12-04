using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Organization.EntityFramework;
using System.Data;
using Organization.DataAccess;
using Organization.Database.Entities;
using Organization.DataAccess.Repositories;
using Organization.Services.OrganizationServices;
using Organization.API.Hubs;
using Organization.Services.CompanyServices;
using Organization.Services.BusinessUnitServices;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddControllers();
services.AddSignalR();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

string defaultConnection = builder.Configuration.GetConnectionString("DefaultConnection");
services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(defaultConnection));

SqlConnection dapperConnection = new SqlConnection(defaultConnection);
services.AddSingleton<IDbConnection>(dapperConnection);

services.AddScoped<IGenericRepository<BusinessUnitEntity>, BusinessUnitRepository>();
services.AddScoped<IGenericRepository<CompanyEntity>, CompanyRepository>();
services.AddScoped<IGenericRepository<OrganizationEntity>, OrganizationRepository>();

services.AddTransient<IOrganizationService, OrganizationService>();
services.AddTransient<ICompanyService, CompanyService>();
services.AddTransient<IBusinessUntiService, BusinessUnitService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHub<BusinessUnitHub>("/businessUnits");
app.MapHub<ValueHub>("/setvalue");

app.Run();