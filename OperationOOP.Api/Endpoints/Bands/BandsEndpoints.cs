using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using OperationOOP.Core.Models;
using OperationOOP.Core.Services;
using OperationOOP.Api.Validation;
using OperationOOP.Api.Endpoints;

namespace OperationOOP.Endpoints.Bands;

public static class BandsEndpoints
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("/bands", GetAll);
        app.MapGet("/bands/{id:int}", Get);
        app.MapPost("/bands", Create);
        app.MapDelete("/bands/{id:int}", Delete);
        app.MapGet("/bands/genre/{genre}", GetBandsByGenre);
        app.MapGet("/bands/without-genre", GetBandsWithoutGenre);
        app.MapGet("/bands/search", SearchByName);
        app.MapGet("/bands/sort/name", SortByName);
        app.MapGet("/bands/sort/genre", SortByGenre);
    }

    private static IResult GetAll(BandService service)
    {
        var bands = service.GetAll();
        return Results.Ok(bands);
    }

    private static IResult Get(int id, BandService service)
    {
        var band = service.GetById(id);
        return band is null
            ? ErrorHandler.HandleNotFound("Bandet hittades inte.")
            : Results.Ok(band);
    }

    private static IResult Create(CreateBandRequest request, BandService service)
    {
        var error = Validator.ValidateNotEmpty(request.Name, "Namn");
        if (error is not null) return error;

        var band = service.Create(request.Name, request.Genre ?? string.Empty);
        return Results.Created($"/bands/{band.Id}", band);
    }

    private static IResult Delete(int id, BandService service)
    {
        var success = service.Delete(id);
        return success
            ? Results.Ok()
            : ErrorHandler.HandleNotFound("Bandet hittades inte.");
    }

    private static IResult GetBandsByGenre(string genre, BandService service)
    {
        var bands = service.FilterByGenre(genre);
        return Results.Ok(bands);
    }

    private static IResult GetBandsWithoutGenre(BandService service)
    {
        var bands = service.GetBandsWithoutGenre();
        return Results.Ok(bands);
    }

    private static IResult SearchByName(string name, BandService service)
    {
        var bands = service.SearchByName(name);
        return Results.Ok(bands);
    }

    private static IResult SortByName(bool descending, BandService service)
    {
        var bands = service.SortByName(descending);
        return Results.Ok(bands);
    }

    private static IResult SortByGenre(bool descending, BandService service)
    {
        var bands = service.SortByGenre(descending);
        return Results.Ok(bands);
    }
}

public record CreateBandRequest(string Name, string? Genre);