using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStoreApi2.Dtos;

namespace GameStoreApi2.Entities
{
    public static class EntityExtentions
    {
        public static GameDto AsDto(this Game game){
            return new GameDto(
                game.Id,
                game.Name,
                game.Genre,
                game.Price,
                game.ReleaseDate,
                game.ImageUri
            );
        }
    }
}