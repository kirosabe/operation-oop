using OperationOOP.Endpoints.Albums;
using OperationOOP.Endpoints.Bands;
using OperationOOP.Endpoints.Songs;

namespace OperationOOP.Api.Endpoints;

public static class EndpointExtensions
{
    public static void MapAllEndpoints(this WebApplication app)
    {
        AlbumsEndpoints.Map(app);
        BandsEndpoints.Map(app);
        SongsEndpoints.Map(app);
    }
}