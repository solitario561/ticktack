using backend.Models;
using Shared.Dtos.Usuarios;

namespace backend.Mappers
{
	public static class UsuarioMappers
	{
		public static SesionDto ToSesionFromLoginDTO(this Usuario dto)
		{
			return new SesionDto
			{
				Nombre = dto.Nombre,
				Correo = dto.Correo
			};
		}
	}
}
