
using Csiger_Krisztián_backend_vizsgaGyakorlat.Models;
using Csiger_Krisztián_backend_vizsgaGyakorlat.Services;
using System.Text.Json.Serialization;

namespace Csiger_Krisztián_backend_vizsgaGyakorlat
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<LibrarydbContext>();
            builder.Services.AddScoped<IAuthor, AuthorService>();
            builder.Services.AddScoped<IBook, BookService>();
            builder.Services.AddScoped<ICategory, CategoryService>();
            builder.Services.AddControllers();
            builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

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
        }
    }
}
