using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monolith.Models
{
	public class Entity
	{
		public int Id { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime ModifiedAt { get; set; }
	}
}
