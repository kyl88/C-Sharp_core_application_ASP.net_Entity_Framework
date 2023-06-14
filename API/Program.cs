using Microsoft.EntityFrameworkCore;
using Persistence;

// scopes to the http request
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//10. adding EF Db content and connection string
builder.Services.AddDbContext<DataContext>(opt=>{
opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// 12. Run the database command

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

// next use try catch to catch the exemption

try
{
    var context = services.GetRequiredService<DataContext>();
    // seed data to the database
    await context.Database.MigrateAsync();
    await Seed.SeedData(context);
}
catch (Exception ex)
{
    
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occured during migration");
}

app.Run();
