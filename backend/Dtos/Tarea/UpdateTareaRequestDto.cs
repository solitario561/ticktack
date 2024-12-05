namespace backend.Dtos.Tarea
{
	public class UpdateTareaRequestDto
	{
		public string Title { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public bool Completed { get; set; }
		public bool Baja { get; set; }
	}
}
