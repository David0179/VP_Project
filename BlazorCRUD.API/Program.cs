using BlazorCRUD.API.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUD.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var ConString = builder.Configuration.GetConnectionString("ConString");
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(ConString));
            builder.Services.AddCors(options => options.AddPolicy("BlazorPolicy", policyBuilder =>
            {
                // Allow Blazor app's origin
                policyBuilder.WithOrigins("https://localhost:7293")
                             .AllowAnyHeader()
                             .AllowAnyMethod();
            }));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("BlazorPolicy");
            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseStaticFiles();


            app.MapControllers();

            app.Run();
        }
    }
}




