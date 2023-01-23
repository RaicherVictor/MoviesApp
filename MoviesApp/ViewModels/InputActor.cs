using MoviesApp.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.ViewModels {
	public class InputActor {
		[Required]
		[SymbolsAtribut]
		public string Name {get; set;}

		[Required]
		[SymbolsAtribut]
		public string LastName {get; set;}

		[Required]
		public DateTime Birthday {get; set;}
	}
}
