using Ambev.DeveloperEvaluation.Application;
using Ambev.DeveloperEvaluation.Common.HealthChecks;
using Ambev.DeveloperEvaluation.Common.Logging;
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.IoC;
using Ambev.DeveloperEvaluation.ORM;
using Ambev.DeveloperEvaluation.WebApi.Features.Product.ProductFeature;
using Ambev.DeveloperEvaluation.WebApi.Middleware;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Serilog;

namespace Ambev.DeveloperEvaluation.WebApi;

public class Program
{
    private static readonly HttpClient client = new HttpClient();


    public static void Main(string[] args)
    {
        try
        {
            Log.Information("Starting web application");

            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            builder.AddDefaultLogging();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            builder.AddBasicHealthChecks();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<DefaultContext>(options =>
                options.UseNpgsql(
                    builder.Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("Ambev.DeveloperEvaluation.ORM")
                   
                )
            );

            builder.Services.AddMemoryCache();


            builder.Services.AddJwtAuthentication(builder.Configuration);

            builder.RegisterDependencies();

            builder.Services.AddAutoMapper(typeof(Program).Assembly, typeof(ApplicationLayer).Assembly);

            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(
                    typeof(ApplicationLayer).Assembly,
                    typeof(Program).Assembly
                );
            });

            builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            var app = builder.Build();
            app.UseMiddleware<ValidationExceptionMiddleware>();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseBasicHealthChecks();

            app.MapControllers();


            //feed table product..necessary to run dotnet ef update first!
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<DefaultContext>();
                SeedDatabaseAsync(dbContext).GetAwaiter().GetResult(); 
            }

            app.Run();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Application terminated unexpectedly");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

    /// <summary>
    /// seed products from fakestoreapi and add to database. Used for the first time running the application
    /// </summary>
    /// <param name="dbContext"></param>
    private static async Task SeedDatabaseAsync(DefaultContext dbContext)
    {
        if (!await dbContext.Products.AnyAsync())
        {
            try
            {
                var response = await client.GetStringAsync("https://fakestoreapi.com/products");
                var products = JsonConvert.DeserializeObject<List<ProductRequest>>(response);

                if (products != null && products.Count > 0)
                {
                    var productsToInsert = products.Select(p => new Product
                    {
                        Title = p.Title,
                        Description = p.Description,
                        Image = p.Image,
                        Price = p.Price,
                        category = p.Category,
                        Rating = (decimal)p.Rating.Rate,
                        RatingCount = p.Rating.Count
                    }).ToList();

                    await dbContext.Products.AddRangeAsync(productsToInsert);
                    await dbContext.SaveChangesAsync();
                    Log.Information($"{productsToInsert.Count} products added to the database.");
                }
                else
                {
                    Log.Warning("No products retrieved from FakeStoreAPI.");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while seeding the database.");
            }
        }
    }



}
