using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoviesApp.Models;
using MoviesApp.ViewModels;
using MoviesApp.Data;
using Microsoft.Extensions.Logging;
using AutoMapper;
using System.Data.Entity.Infrastructure;
using MoviesApp.Filters;

namespace MoviesApp.Controllers {
	public class ActorController : Controller {
		private readonly MoviesContext _context;
		private readonly ILogger<HomeController> _logger;
		private readonly IMapper _mapper;

		public ActorController(MoviesContext context, ILogger<HomeController> logger, IMapper mapper) {
			_context = context;
			_logger = logger;
			_mapper = mapper;
		}
		// GET: ActorController
		public ActionResult Index() {
			var actors = _mapper.Map<ICollection<Actor>, ICollection<ActorViewModel>>(_context.Actors.ToList());
			return View(actors);
		}

		// GET: ActorController/Details/5
		[HttpGet]
		public ActionResult Details(int id) {
			var actor = _mapper.Map<ActorViewModel>(_context.Actors.Find(id));
			return View(actor);
		}

		// GET: ActorController/Create
		public ActionResult Create() {
			
			return View();
		}

		// POST: ActorController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
        [AgeFilter]
        public ActionResult Create([Bind("Name,LastName,Birthday")] InputActor inputModel) {
			if (ModelState.IsValid) {
				_context.Add(_mapper.Map<Actor>(inputModel));
				_context.SaveChanges();
				return RedirectToAction(nameof(Index));
			}
			return View(inputModel);

		}

		// GET: ActorController/Edit/5
		
		public ActionResult Edit(int id) {
			var editModel = _mapper.Map<EditActor>(_context.Actors.FirstOrDefault(idi => idi.Id == id));
			if (editModel == null) {
				return NotFound();
			}
			return View(editModel);
		}

		// POST: ActorController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		[AgeFilter]
		public ActionResult Edit(int id, [Bind("Name,LastName,Birthday")] EditActor editModel) {
			if (ModelState.IsValid) {
				try {
					var actor = _mapper.Map<Actor>(editModel);
					actor.Id = id;
					_context.Update(actor);
					_context.SaveChanges();
				} catch (DbUpdateException) {
					if (!ActorExists(id)) {
						return NotFound();
					} else {
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			return View(editModel);
		}


		// GET: ActorController/Delete/5
		public ActionResult Delete(int id) {
			var actor = _mapper.Map<DeleteActor>(_context.Actors.Find(id));
			return View(actor);
		}

		// POST: ActorController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection) {
			var deleteModel = _mapper.Map<DeleteActor>(_context.Actors.FirstOrDefault(idi => idi.Id == id));
			if (deleteModel == null) {
				return NotFound();
			}
			return View(deleteModel);
		}
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(int id) {
			var actor = _context.Actors.Find(id);
			_context.Actors.Remove(actor);
			_context.SaveChanges();
			_logger.LogError($"Movie with id {actor.Id} has been deleted!");
			return RedirectToAction(nameof(Index));
		}

		private bool ActorExists(int id) {
			return _context.Actors.Any(idi => idi.Id == id);
		}
	}
}