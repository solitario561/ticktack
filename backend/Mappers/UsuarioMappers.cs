using backend.Dtos.Usuarios;
using backend.Models;

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
