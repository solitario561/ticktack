using backend.Data;
using backend.Dtos.Tarea;
using backend.Mappers;
using backend.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
		/*[HttpGet("{id_usuario}")]
		public IActionResult GetAll([FromRoute] int id_usuario)
		{
			var tarea = _context.Tarea.ToList().Where(x => x.UsuariosId.Equals(id_usuario));

			return Ok(tarea);
		}*/

		/*[HttpGet("{id_usuario}")]
		public IActionResult GetByUser([FromRoute] int id_usuario)
		{
			//var tarea = _context.Tarea.Find(id);
			var tarea = _context.Tarea.ToList().Where(x => x.UsuariosId.Equals(id_usuario)).
				Select(x => x.ToTareaDTO());

			return tarea == null ? NotFound() : Ok(tarea);
		}*/
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById([FromRoute] int id)
		{
			var tarea = await _context.Tarea.FindAsync(id);
			return tarea == null ? NotFound() : Ok(tarea.ToTareaDTO());
		}
		[HttpGet]
		public async Task<IActionResult> GetList()
		{
			var tarea = await _context.Tarea.ToListAsync();
			var tareaDto = tarea.Select(x => x.ToTareaDTO());
			return Ok(tareaDto);
		}
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateTareaRequestDto tarea_dto)
		{
			var tareaModel = tarea_dto.ToTareaFromCreateDTO();
			await _context.Tarea.AddAsync(tareaModel);
			await _context.SaveChangesAsync();
			return CreatedAtAction(nameof(GetById), new { id = tareaModel.Id },tareaModel.ToTareaDTO());
		}
		[HttpPut]
		[Route("{id}")]
		public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateTareaRequestDto update_dto)
		{
			var tareaModel = await _context.Tarea.FirstOrDefaultAsync(x => x.Id == id);

			return tareaModel == null ?
				NotFound() :
				await UpdateInDatabase(tareaModel, update_dto);
		}
		private async Task<OkObjectResult> UpdateInDatabase(Tarea tareaGuardada,UpdateTareaRequestDto datosModificacion)
		{
			tareaGuardada.Title = datosModificacion.Title;
			tareaGuardada.Description = datosModificacion.Description;
			tareaGuardada.Baja = datosModificacion.Baja;
			tareaGuardada.Updated_at = DateTime.Now;
			await _context.SaveChangesAsync();
			return Ok(tareaGuardada.ToTareaDTO());
		}
		[HttpDelete]
		[Route("{id}")]
		public async Task<IActionResult> Delete([FromRoute] int id)
		{
			var tareaModel = await _context.Tarea.FirstOrDefaultAsync(x => x.Id == id);
			return tareaModel == null ? NotFound() : await DeleteInDatabase(tareaModel);
		}
		private async Task<NoContentResult> DeleteInDatabase(Tarea tareaGuardada)
		{
			_context.Tarea.Remove(tareaGuardada);
			await _context.SaveChangesAsync();
			return NoContent();
		}
	}
}
