using backend.Data;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
	[Route("/Tasks")]
	[ApiController]
	public class TareaController: ControllerBase
	{
		private readonly ApplicationDBContext _context;
		public TareaController(ApplicationDBContext context)
		{
			_context = context;
		}
		[HttpGet]
		public IActionResult GetAll()
		{
			var tarea = _context.Tarea.ToList();

			return Ok(tarea);
		}

		[HttpGet("{id}")]
		public IActionResult GetById([FromRoute] int id)
		{
			var tarea = _context.Tarea.Find(id);

			return tarea == null ? NotFound() : Ok(tarea);
		}
	}
}
