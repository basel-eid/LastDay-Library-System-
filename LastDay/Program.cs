
using LastDay.Data;
using LastDay.Repos.AuthorRepos;
using LastDay.Repos.BookRepos;
using Microsoft.EntityFrameworkCore;

namespace LastDay
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Def")));
            // Add services to the container.
            builder.Services.AddScoped<IBookRepo, BookRepo>();
            builder.Services.AddScoped<IAuthorRepo, AuthorRepo>();
            
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
        }
    }
}
