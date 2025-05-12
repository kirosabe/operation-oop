using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using OperationOOP.Core.Models;
using OperationOOP.Core.Services;
using OperationOOP.Api.Validation;
using OperationOOP.Api.Endpoints;

namespace OperationOOP.Endpoints.Songs;

public static class SongsEndpoints
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("/songs", GetAll);
        app.MapGet("/songs/{id:int}", Get);
        app.MapPost("/songs", Create);
        app.MapDelete("/songs/{id:int}", Delete);
        app.MapGet("/songs/longer-than/{duration:int}", GetSongsLongerThan);
        app.MapGet("/songs/search", SearchByTitle);
        app.MapGet("/songs/sort/title", SortByTitle);
        app.MapGet("/songs/sort/duration", SortByDuration);
    }

    private static IResult GetAll(SongService service)
    {
        var songs = service.GetAll();
        return Results.Ok(songs);
    }

    private static IResult Get(int id, SongService service)
    {
        var song = service.GetById(id);
        return song is null
            ? ErrorHandler.HandleNotFound("Låten hittades inte.")
            : Results.Ok(song);
    }

    private static IResult Create(CreateSongRequest request, SongService service)
    {
        var titleError = Validator.ValidateNotEmpty(request.Title, "Titel");
        if (titleError is not null) return titleError;

        var durationError = Validator.ValidatePositiveDuration(request.Duration);
        if (durationError is not null) return durationError;

        var song = service.Create(request.Title, request.Duration);
        return Results.Created($"/songs/{song.Id}", song);
    }

    private static IResult Delete(int id, SongService service)
    {
        var success = service.Delete(id);
        return success
            ? Results.Ok()
            : ErrorHandler.HandleNotFound("Låten hittades inte.");
    }

    private static IResult GetSongsLongerThan(int duration, SongService service)
    {
        var songs = service.GetSongsLongerThan(duration);
        return Results.Ok(songs);
    }

    private static IResult SearchByTitle(string title, SongService service)
    {
        var songs = service.SearchByTitle(title);
        return Results.Ok(songs);
    }

    private static IResult SortByTitle(bool descending, SongService service)
    {
        var songs = service.SortByTitle(descending);
        return Results.Ok(songs);
    }

    private static IResult SortByDuration(bool descending, SongService service)
    {
        var songs = service.SortByDuration(descending);
        return Results.Ok(songs);
    }
}

public record CreateSongRequest(string Title, int Duration);