using System.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using WebApplicationApi;
using WebApplicationApi.Data;
using WebApplicationApi.Interfaces;
using WebApplicationApi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// transient is going to add object at very begin
builder.Services.AddTransient<Seed>();
builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});



var app = builder.Build();


if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedData(app);

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<Seed>();
        service.SeedDataContext();
    }
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
// TestConnection();
// Console.ReadKey();
app.Run();



//  static NpgsqlConnection GetConnection()
//  {
//      return new NpgsqlConnection(@"Server=localhost;port=5432;User Id=procoder;password=malecha96.;Database=postgres;");
//  }
//
// static void TestConnection()
// {
//     using (NpgsqlConnection connection = GetConnection())
//     {
//         connection.Open();
//         if (connection.State == ConnectionState.Open)
//         {
//             Console.WriteLine("connected");
//         }
//       
//     }
//     
// }