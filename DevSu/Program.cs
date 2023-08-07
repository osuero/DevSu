using DevSu.Core.Interfaces;
using DevSu.Infrastructure.Contexts;
using DevSu.Infrastructure.Repositories;
using DevSu.Services.Mapping;
using Microsoft.EntityFrameworkCore;
using DevSu.Infrastructure.RepositoryExtenxion;
using DevSu.Services.ServiceExtension;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
var services = builder.Services;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DefaultDbContext>(options => options.UseSqlServer(connectionString));
try {
builder.Services.AddRepositories();
builder.Services.AddServices();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
}
catch (Exception ex) {
    var error= ex.Message;
}
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
