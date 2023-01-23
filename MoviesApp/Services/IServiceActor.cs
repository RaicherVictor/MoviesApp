using MoviesApp.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Services {
	public interface IServiceActor {
		ActorDto Get(int id);
		ICollection<ActorDto> GetActors();
		ActorDto Update(ActorDto actor);
		ActorDto Delete(int id);
		ActorDto Add(ActorDto actor);
	}
}
