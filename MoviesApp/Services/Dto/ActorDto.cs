using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System;

namespace MoviesApp.Services.Dto {
	public class ActorDto {
		public int? Id { get; set; }
		[Required] //add atribut
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		[Required]
		[DataType(DataType.Date)]
		public DateTime Birthday { get; set; }
	}
}
