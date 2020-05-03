using Microsoft.EntityFrameworkCore;
using Monolith.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monolith.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}

		public DbSet<Character> Characters { get; set; }
	}
}
