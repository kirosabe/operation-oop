﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using OperationOOP.Core.Models;
using OperationOOP.Core.Services;
using OperationOOP.Api.Validation;
using OperationOOP.Api.Endpoints;

namespace OperationOOP.Endpoints.Albums;

public static class AlbumsEndpoints
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("/albums", GetAll);
        app.MapGet("/albums/{id:int}", Get);
        app.MapPost("/albums", Create);
        app.MapDelete("/albums/{id:int}", Delete);
        app.MapGet("/albums/year/{year:int}", GetByYear);
        app.MapGet("/albums/search", SearchByTitle);
        app.MapGet("/albums/sort/title", SortByTitle);
        app.MapGet("/albums/sort/year", SortByYear);
    }

    private static IResult GetAll(AlbumService service)
    {
        var albums = service.GetAll();
        return Results.Ok(albums);
    }

    private static IResult Get(int id, AlbumService service)
    {
        var album = service.GetById(id);
        return album is null
            ? ErrorHandler.HandleNotFound("Albumet hittades inte.")
            : Results.Ok(album);
    }

    private static IResult Create(CreateAlbumRequest request, AlbumService service)
    {
        var titleError = Validator.ValidateNotEmpty(request.Title, "Titel");
        if (titleError is not null) return titleError;

        var yearError = Validator.ValidatePositiveDuration(request.Year);
        if (yearError is not null) return yearError;

        var album = service.Create(request.Title, request.Year);
        return Results.Created($"/albums/{album.Id}", album);
    }

    private static IResult Delete(int id, AlbumService service)
    {
        var success = service.Delete(id);
        return success
            ? Results.Ok()
            : ErrorHandler.HandleNotFound("Albumet hittades inte.");
    }

    private static IResult GetByYear(int year, AlbumService service)
    {
        var albums = service.GetByYear(year);
        return Results.Ok(albums);
    }

    private static IResult SearchByTitle(string title, AlbumService service)
    {
        var albums = service.SearchByTitle(title);
        return Results.Ok(albums);
    }

    private static IResult SortByTitle(bool descending, AlbumService service)
    {
        var albums = service.SortByTitle(descending);
        return Results.Ok(albums);
    }

    private static IResult SortByYear(bool descending, AlbumService service)
    {
        var albums = service.SortByYear(descending);
        return Results.Ok(albums);
    }
}

public record CreateAlbumRequest(string Title, int Year);