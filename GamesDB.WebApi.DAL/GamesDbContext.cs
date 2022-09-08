﻿using GamesDB.WebApi.Domain.Entities.GameAggregate;
using GamesDB.WebApi.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesDB.WebApi.DAL
{
    public class GamesDbContext : DbContext, IGamesDbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public GamesDbContext(DbContextOptions<GamesDbContext> options)
            : base(options)
        {  }
    }
}
