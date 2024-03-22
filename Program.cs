using Microsoft.EntityFrameworkCore;
using MTechTestAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

//Repositories
//builder.Services.AddDbContext<MTechTestIMDb>
//    (opt => opt.UseInMemoryDatabase("MTechTestDB"));
builder.Services.AddDbContext<MTechTestMYSQL>();
//builder.Services.AddDbContext<MTechTestSQLSERVER>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
