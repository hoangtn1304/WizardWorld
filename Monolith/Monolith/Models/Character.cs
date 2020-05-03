using System.ComponentModel.DataAnnotations.Schema;

namespace Monolith.Models
{
	public class Character : Entity
	{
		public string Name { get; set; }
		public string Birthdate { get; set; }
		public string Bio { get; set; }
		public Sex Sex { get; set; }
		public Race Race { get; set; }
		public Descent Descent { get; set; }
		public MaritalStatus MaritalStatus { get; set; }

		[NotMapped]
		public string[] Nicknames { get; set; }

		[NotMapped]
		public string[] Titles { get; set; }
	}
}
