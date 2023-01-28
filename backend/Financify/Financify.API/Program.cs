using Financify.Common.Authentication.Hashing;
using Financify.Core.Interfaces.Persons;
using Financify.Core.Services.Persons;
using Financify.Dal.db;
using Financify.Dal.Interfaces.Persons;
using Financify.Dal.Repositories.Persons;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FinancifyDataContext>(o =>
    o.UseNpgsql(builder.Configuration.GetConnectionString("Financify_Test_DB")));

builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IHashSaltHandler, HashSaltHandler>();

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();