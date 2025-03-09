using Microsoft.Extensions.Options;
using OperationOOP.Api.Endpoints;
using OperationOOP.Core.Data;

namespace OperationOOP.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthorization();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.CustomSchemaIds(type => type.FullName?.Replace('+', '.'));
                options.InferSecuritySchemes();
            });

            builder.Services.AddSingleton<IDatabase, Database>();
            builder.Services.AddScoped<MusicRepository>();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var database = scope.ServiceProvider.GetRequiredService<IDatabase>();

                if (!database.Bands.Any())
                {
                    var band1 = new Band(1, "Metallica", "Heavy Metal");
                    var band2 = new Band(2, "Iron Maiden", "Heavy Metal");

                    var band3 = new Band(3, "Nas", "Hip Hop");
                    var band4 = new Band(4, "Wu-Tang Clan", "Hip Hop");

                    var band5 = new Band(5, "Charles Strouse", "Show tune");
                    var band6 = new Band(6, "Andrew Lloyd Webber", "Show tune");

                    var band7 = new Band(7, "John Williams", "Film Score");
                    var band8 = new Band(8, "Thomas Newman", "Film Score");

                    database.Bands.Add(band1);
                    database.Bands.Add(band2);
                    database.Bands.Add(band3);
                    database.Bands.Add(band4);
                    database.Bands.Add(band5);
                    database.Bands.Add(band6);
                    database.Bands.Add(band7);
                    database.Bands.Add(band8);

                    var album1 = new Album(1, "Master of Puppets", "1986", band1);
                    var album2 = new Album(2, "The Number of the Beast", "1982", band2);
                    var album3 = new Album(3, "Illmatic", "1994", band3);
                    var album4 = new Album(4, "Enter the Wu-Tang (36 Chambers)", "1993", band4);
                    var album5 = new Album(5, "Annie", "1977", band5);
                    var album6 = new Album(6, "The Phantom of the Opera", "1986", band6);
                    var album7 = new Album(7, "Symphony No. 5", "1808", band7);
                    var album8 = new Album(8, "Finding Nemo", "2003", band8);

                    database.Albums.Add(album1);
                    database.Albums.Add(album2);
                    database.Albums.Add(album3);
                    database.Albums.Add(album4);
                    database.Albums.Add(album5);
                    database.Albums.Add(album6);
                    database.Albums.Add(album7);
                    database.Albums.Add(album8);

                    var song1 = new Song(1, "Enter Sandman", "Master of Puppets", "5:31");
                    var song2 = new Song(2, "Hallowed Be Thy Name", "The Number of the Beast", "7:12");
                    var song3 = new Song(3, "N.Y. State of Mind", "Illmatic", "4:54");
                    var song4 = new Song(4, "C.R.E.A.M.", "Enter the Wu-Tang (36 Chambers)", "4:12");
                    var song5 = new Song(5, "Tomorrow", "Annie", "1:35");
                    var song6 = new Song(6, "The Phantom of the Opera", "The Phantom of the Opera", "3:36");
                    var song7 = new Song(7, "Symphony No. 5, Op. 67", "Symphony No. 5", "7:45");
                    var song8 = new Song(8, "Finding Nemo", "Finding Nemo", "1:19");

                    database.Songs.Add(song1);
                    database.Songs.Add(song2);
                    database.Songs.Add(song3);
                    database.Songs.Add(song4);
                    database.Songs.Add(song5);
                    database.Songs.Add(song6);
                    database.Songs.Add(song7);
                    database.Songs.Add(song8);
                }
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapEndpoints<Program>();

            app.Run();
        }
    }
}
