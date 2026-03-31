using GaiaProject.Database;
using GaiaProject.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

public partial class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var connection = builder.Configuration.GetConnectionString("DefaultConnection");

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddScoped<CalculatorService>();
        builder.Services.AddScoped<CalculatorDbContext>();
        builder.Services.AddDbContext<CalculatorDbContext>(options => options.UseSqlServer(connection));


        var app = builder.Build();
        

       
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.UseDefaultFiles(); 
        app.UseStaticFiles(); 

       
       
        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<CalculatorDbContext>();
            db.Database.EnsureCreated();
        }
        app.Run();
    }
}