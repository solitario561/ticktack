namespace backend.Models
{
	public class Usuarios
	{
		public int Id { get; set; }
		public string TagUsuario { get; set; } = string.Empty;
		public string NombreUsuario { get; set; } = string.Empty;
		public string Pass { get; set; } = string.Empty;
		public List<Tarea> Tareas { get; set; } = new List<Tarea>();
	}
}
