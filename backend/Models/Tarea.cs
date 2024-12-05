namespace backend.Models
{
	public class Tarea
	{
		public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public bool Completed { get; set; }
		public DateTime Creadet_at { get; set; }
		public DateTime Updated_at { get; set; }
		public bool Baja { get; set; }
	}
}
