using backend.Data;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
	[Route("/ValidacionTag")]
	[ApiController]
	public class UsuariosController: ControllerBase
	{
		private readonly ApplicationDBContext _context;
		public UsuariosController(ApplicationDBContext context)
		{
			_context = context;
		}
	}
}
