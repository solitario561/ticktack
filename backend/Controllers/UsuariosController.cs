using backend.Data;
using backend.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Dtos.Usuarios;

namespace backend.Controllers
{
	[Route("/Login")]
	[ApiController]
	public class UsuariosController: ControllerBase
	{
		private readonly ApplicationDBContext _context;
		public UsuariosController(ApplicationDBContext context)
		{
			_context = context;
		}
		[HttpPost]
		public async Task<IActionResult> Login([FromBody] LoginDto login)
		{
			var usuario_model = await _context.Usuario.
				FirstOrDefaultAsync(x => x.Correo == login.Correo && x.Pass == login.Pass);
			return usuario_model == null ? NotFound() : Ok(usuario_model.ToSesionFromLoginDTO());
		}
	}
}
