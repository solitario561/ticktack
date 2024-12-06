using Shared.Dtos.Tarea;

namespace frontend.Extensiones
{
	public static class TareaMapper
	{
		public static TareaRequestDto TareaToTareaRequestDto(this TareaDto request)
		{
			return new TareaRequestDto 
			{ 
				Title = request.Title,
				Description = request.Description,
				Completed = request.Completed
			};
		}
	}
}
