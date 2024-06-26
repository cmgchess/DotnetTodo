using Microsoft.EntityFrameworkCore;
using Todo.Implementation.Data;
using Todo.Implementation.Mapping;
using Todo.Implementation.Services;
using Todo.Interface.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.b

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(MapperProfile));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection"));
});

builder.Services.AddScoped<ITodosService, TodosService>();

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
