using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesDB.WebApi.Domain.Entities.GamesAggregate
{
   public class GameDBInitializer
    {
        private void Initialize()
        {
            Game game1 = new Game { Title = "Days Gone" };
            Game game2 = new Game { Title = "Doom Eternal" };
            Game game3 = new Game { Title = "Portal 2" };
            Game game4 = new Game { Title = "Half life 3" };


            Developer dev1 = new Developer { Name = "Valve" };
            Developer dev2 = new Developer { Name = "Bethesda" };
            Developer dev3 = new Developer { Name = "Bend Studio" };
            Developer dev4 = new Developer { Name = "Microsoft" };

            Genre genre1 = new Genre { Name = "FPS" };
            Genre genre2 = new Genre { Name = "Action-adventure" };
            Genre genre3 = new Genre { Name = "Survival horror" };
            Genre genre4 = new Genre { Name = "RPG" };
            Genre genre5 = new Genre { Name = "Puzzle" };

        }
    }
}
