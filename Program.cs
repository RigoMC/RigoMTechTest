using Microsoft.EntityFrameworkCore;
using MTechTestAPI.Repositories;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "http://localhost";

builder.Services.AddControllers();

//Repositories
//builder.Services.AddDbContext<MTechTestIMDb>
//    (opt => opt.UseInMemoryDatabase("MTechTestDB"));
builder.Services.AddDbContext<MTechTestMYSQL>();
//builder.Services.AddDbContext<MTechTestSQLSERVER>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost").AllowAnyHeader().AllowAnyMethod();
                      });
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(MyAllowSpecificOrigins);

app.MapControllers();

app.Run();
