using backend.Models;
using Shared.Dtos.Tarea;

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
				Updated_at = tareaModel.Updated_at
			};
		}
		public static Tarea ToTareaFromCreateDTO(this TareaRequestDto tarea)
		{
			return new Tarea
			{
				Title = tarea.Title,
				Description = tarea.Description,
				Completed = tarea.Completed,
				Creadet_at = DateTime.Now,
				Updated_at = DateTime.Now
			};
		}
	}
}
