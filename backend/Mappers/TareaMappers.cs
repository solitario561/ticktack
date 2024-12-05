using backend.Dtos.Tarea;
using backend.Models;

namespace backend.Mappers
{
	public static class TareaMappers
	{
		public static TareaDto ToTareaDTO(this Tarea tareaModel)
		{
			return new TareaDto
			{
				Id = tareaModel.Id,
				Title = tareaModel.Title,
				Description = tareaModel.Description,
				Completed = tareaModel.Completed,
				Creadet_at = tareaModel.Creadet_at,
				Updated_at = tareaModel.Updated_at,
				Baja = tareaModel.Baja
			};
		}
		public static Tarea ToTareaFromCreateDTO(this CreateTareaRequestDto tarea)
		{
			return new Tarea
			{
				Title = tarea.Title,
				Description = tarea.Description,
				Completed = tarea.Completed,
				Creadet_at = DateTime.Now,
				Updated_at = DateTime.Now,
				Baja = false
			};
		}
	}
}
