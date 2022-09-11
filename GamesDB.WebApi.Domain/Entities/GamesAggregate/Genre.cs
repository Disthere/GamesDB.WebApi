﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesDB.WebApi.Domain.Entities.GamesAggregate
{
   public class Genre : BaseEntity
    {
        public Genre()
        {
            this.Games = new List<Game>();
        }
        //public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}