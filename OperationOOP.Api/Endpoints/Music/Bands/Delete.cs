namespace OperationOOP.Api.Endpoints.Music.Bands
{
    public class Delete : IEndpoint
    {
        public static void MapEndpoint(IEndpointRouteBuilder app) => app
            .MapDelete("/bands/{id}", Handle)
            .WithSummary("Delete a band");

        private static IResult Handle(int id, IDatabase db)
        {
            var idValidationResult = Validator.ValidateId(id, "Bandets ID");
            if (idValidationResult != null) return idValidationResult;

            try
            {
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
                return ErrorHandler.HandleError(ex);
            }
        }
    }
}
