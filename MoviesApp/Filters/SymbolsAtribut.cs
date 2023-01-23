using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Filters {
	public class SymbolsAtribut : ValidationAttribute {
        

        public string Symbols { get; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
            if (((string)value).Length <= 4) {
                return new ValidationResult("Слишком мало символов");
			}
              
            return ValidationResult.Success;
        }
    }
}
