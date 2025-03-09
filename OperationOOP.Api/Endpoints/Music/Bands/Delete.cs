namespace OperationOOP.Api.Endpoints.Music.Bands
{
    public class Delete : IEndpoint
    {
        public static void MapEndpoint(IEndpointRouteBuilder app) => app
            .MapDelete("/bands/{id}", Handle)
            .WithSummary("Delete a band");

        private static IResult Handle(int id, IDatabase db)
        {
            try
            {
                if (id <= 0)
                {
                    return Results.BadRequest("Bandets ID måste vara ett positivt tal.");
                }

                var band = db.Bands.FirstOrDefault(b => b.Id == id);

                if (band == null)
                {
                    return Results.NotFound($"Band med ID {id} hittades inte.");
                }

                db.Bands.Remove(band);

                return Results.NoContent();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Fel vid borttagning av band: {ex.Message}");
                return Results.Problem("Ett oväntat fel inträffade när bandet skulle tas bort.");
            }
        }
    }
}
