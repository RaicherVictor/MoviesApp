using AutoMapper;
using MoviesApp.Data;
using MoviesApp.Models;
using MoviesApp.Services.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Services {
	public class ServiceActor : IServiceActor {
        private readonly MoviesContext _context;
        private readonly IMapper _mapper;

        public ServiceActor(MoviesContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }
        public ActorDto Get(int id) {
            return _mapper.Map<ActorDto>(_context.Actors.FirstOrDefault(idi => idi.Id == id));
        }
        public ICollection<ActorDto> GetActors() {
            return _mapper.Map<ICollection<Actor>, ICollection<ActorDto>>(_context.Actors.ToList());
        }
        public ActorDto Update(ActorDto actorDto) {
            if (actorDto.Id == null) {
               
                return null;
            }
            try {
                var actor = _mapper.Map<Actor>(actorDto);

                _context.Update(actor);
                _context.SaveChanges();

                return _mapper.Map<ActorDto>(actor);
            } catch (DbUpdateException) {
                if (!ActorExists((int)actorDto.Id)) {                    
                    return null;
                } else {             
                    return null;
                }
            }
        }
        public ActorDto AddMovie(ActorDto actorDto) {
            var actor = _context.Add(_mapper.Map<Actor>(actorDto)).Entity;
            _context.SaveChanges();
            return _mapper.Map<ActorDto>(actor);
        }
        public ActorDto Delete(int id) {
            var actor = _context.Actors.Find(id);
            if (actor == null) {
               
                return null;
            }
            _context.Actors.Remove(actor);
            _context.SaveChanges();

            return _mapper.Map<ActorDto>(actor);
        }
        private bool ActorExists(int id) {
            return _context.Actors.Any(idishka => idishka.Id == id);
        }

		ActorDto IServiceActor.Get(int id)
		{
			throw new NotImplementedException();
		}

		ICollection<ActorDto> IServiceActor.GetActors()
		{
			throw new NotImplementedException();
		}

		

		ActorDto IServiceActor.Delete(int id)
		{
			throw new NotImplementedException();
		}

		public ActorDto Add(ActorDto actor)
		{
			throw new NotImplementedException();
		}
	}
}

