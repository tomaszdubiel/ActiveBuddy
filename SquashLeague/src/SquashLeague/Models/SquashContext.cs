﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SquashLeague.Models
{
    public class SquashContext :  DbContext
    {
        public IConfigurationRoot _config;

        public SquashContext(IConfigurationRoot config, DbContextOptions options) : base(options)
        {
            _config = config;
        }

        public DbSet <Trip> Trips { get; set; }
        public DbSet <Stop> Stops { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)     
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_config["ConnectionString:SquashContextConnection"]);
        }
    }
}