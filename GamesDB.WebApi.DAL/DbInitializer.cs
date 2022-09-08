﻿using GamesBaseAccess.Domain.GameAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesDB.WebApi.DAL
{
    public class DbInitializer
    {
        public static void Initialize(GamesDbContext context)
        {
            context.Database.EnsureCreated();
            AddInitialValues(context);
        }

        private static void AddInitialValues(GamesDbContext context)
        {
            using (context)
            {
                if (!context.Games.Any())
                {
                    Developer dev1 = new Developer { Name = "Valve" };
                    Developer dev2 = new Developer { Name = "Bethesda" };
                    Developer dev3 = new Developer { Name = "Bend Studio" };
                    Developer dev4 = new Developer { Name = "Microsoft" };

                    context.Developers.AddRange(new List<Developer> { dev1, dev2, dev3, dev4 });

                    Genre genre1 = new Genre { Name = "FPS" };
                    Genre genre2 = new Genre { Name = "Action-adventure" };
                    Genre genre3 = new Genre { Name = "Survival horror" };
                    Genre genre4 = new Genre { Name = "RPG" };
                    Genre genre5 = new Genre { Name = "Puzzle" };

                    context.Genres.AddRange(new List<Genre> { genre1, genre2, genre3, genre4, genre5 });

                    context.SaveChanges();

                    Game game1 = new Game { Title = "Days Gone" };
                    game1.Developer = dev3;
                    game1.Genres.Add(genre2);
                    game1.Genres.Add(genre3);

                    Game game2 = new Game { Title = "Doom Eternal" };
                    game2.Developer = dev2;
                    game2.Genres.Add(genre1);

                    Game game3 = new Game { Title = "Portal 2" };
                    game3.Developer = dev1;
                    game3.Genres.Add(genre1);
                    game3.Genres.Add(genre5);

                    Game game4 = new Game { Title = "Half life 3" };
                    game4.Developer = dev1;
                    game4.Genres.Add(genre1);
                    game4.Genres.Add(genre3);

                    context.Games.AddRange(new List<Game> { game1, game2, game3, game4 });
                    context.SaveChanges();
                }
            }



        }
    }
}
