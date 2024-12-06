namespace Shared.Dtos.Tarea
{
	public class TareaRequestDto
	{
		public string Title { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public bool Completed { get; set; }
	}
}
