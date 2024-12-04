using backend.Dtos.Tarea;
using backend.Models;

namespace backend.Mappers
{
	public static class TareaMappers
	{
		public static TareaDto ToTareaDtio(this Tarea tareaModel)
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
	}
}
