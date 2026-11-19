using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace WebApplication1
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

            // builder.Services.AddSingleton<StudentStorage>();
            //dependency injection, da mozemo koristiti objekat klase Student Storage gdje god nam zatreba, npr u klasi StudentController

            //Ispod opet koristimo dependency injection, ali se ovdje automatski primjenjuje Scoped = Svaki http zahtjev ce dobiti svoju instancu.
            //To nam je bitno jer svaki put kada napravimo odredjeni http request, mi cemo komunicirati sa bazom podataka.
            // Tada cemo koristiti asinkrone metode, medjutim svaki put kada kominiciramo sa bazom podataka, moramo znati da te operacije predstavljaju jako teske operacije za program.
            //Ako vadimo puno podataka, moze da uspori nas program
            //Ako bismo kreirali ovo kao singleton, napravili bismo usko grlo jer bi svi iz jedne instance povlacili podatke i moze jako puno stvari poci po zlu
            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Main"))

            );

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