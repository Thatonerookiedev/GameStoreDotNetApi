using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStoreApi2.Dtos;
using GameStoreApi2.Entities;
using GameStoreApi2.Repositories;

namespace GameStoreApi2.Endpoints
{
    public static class GamesEndpoints
    {
        const string GetGameEnpointName = "GetGame";

        public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes){
                
                var group = routes.MapGroup("/games").WithParameterValidation();

                routes.MapGet("/", () => "Hello World");

                group.MapGet("/", (IGamesRepository repository) =>{
                    return repository.GetAll().Select(game => game.AsDto());
                });
                group.MapGet("/{id}", (IGamesRepository repository,int id) =>
                {
                    Game? game = repository.Get(id);

                    if (game is null)
                    {
                    return Results.NotFound();
                    }

                    return Results.Ok(game.AsDto());
                    }).WithName(GetGameEnpointName);
                group.MapPost("/", (IGamesRepository repository,CreateGameDto gameDto) =>
                {
                    Game game = new(){
                        Name = gameDto.Name,
                        Genre = gameDto.Genre,
                        Price = gameDto.Price,
                        ReleaseDate = gameDto.ReleaseDate,
                        ImageUri = gameDto.ImageUri
                    };
                    repository.Create(game);

                    return Results.CreatedAtRoute(GetGameEnpointName, new { id = game.Id }, game);
                });
                group.MapPut("/{id}", (IGamesRepository repository,int id, UpdateGameDto updatedGameDto) =>
                {
                    Game? existingGame = repository.Get(id);

                    if (existingGame is null)
                    {
                        return Results.NotFound();
                    }

                    existingGame.Name = updatedGameDto.Name;
                    existingGame.Genre = updatedGameDto.Genre;
                    existingGame.Price = updatedGameDto.Price;
                    existingGame.ReleaseDate = updatedGameDto.ReleaseDate;
                    existingGame.ImageUri = updatedGameDto.ImageUri;

                    repository.Update(existingGame);

                    return Results.NoContent();
                });
                group.MapDelete("/{id}",(IGamesRepository repository,int id)=>{
                    Game? existingGame = repository.Get(id);

                    if (existingGame is not null)
                    {
                        repository.Delete(id);
                    }

                    return Results.NoContent();
                    });
                
                return group;
            }
    }
}