using System;
using _NETCHALLENGE.Models;
using Microsoft.EntityFrameworkCore;

namespace _NETCHALLENGE.Data
{
	public class ApplicationDbContext:DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			:base(options)
		{

		}

		public DbSet<Order> Orders { get; set; }
        public DbSet<Carrier> Carriers { get; set; }
        public DbSet<CarrierConfiguration> CarrierConfigurations { get; set; }

    }
}

