using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Monolith.Data;
using Monolith.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Monolith.Controllers
{
	public class CharactersController : Controller
	{
		private readonly ILogger<CharactersController> _logger;
		private readonly ApplicationDbContext _context;
		private readonly IMapper _mapper;

		public CharactersController(ILogger<CharactersController> logger, ApplicationDbContext context, IMapper mapper)
		{
			_logger = logger;
			_context = context;
			_mapper = mapper;
		}

		public async Task<IActionResult> Index()
		{
			var models = await _context.Characters.ToArrayAsync();

			return View(models.Where(t => !t.IsDeleted));
		}

		public async Task<IActionResult> Details(int id)
		{
			var model = await _context.Characters.FirstOrDefaultAsync(t => t.Id == id);

			return View(model);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(Character model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			model.CreatedAt = DateTime.Now;
			model.ModifiedAt = DateTime.Now;

			await _context.AddAsync(model);
			await _context.SaveChangesAsync();

			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Edit(int id)
		{
			var model = await _context.Characters.FirstOrDefaultAsync(t => t.Id == id);

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(Character model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			model.ModifiedAt = DateTime.Now;

			_context.Update(model);
			await _context.SaveChangesAsync();

			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Delete(int id)
		{
			var model = await _context.Characters.FirstOrDefaultAsync(t => t.Id == id);

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Delete(Character model)
		{
			var toDelete = await _context.Characters.FirstOrDefaultAsync(t => t.Id == model.Id);

			toDelete.ModifiedAt = DateTime.Now;
			toDelete.IsDeleted = true;

			_context.Update(toDelete);
			await _context.SaveChangesAsync();

			return RedirectToAction("Index");
		}

	}
}
