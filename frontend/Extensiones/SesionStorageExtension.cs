using Blazored.SessionStorage;
using System.Text.Json;
using System.Text;
using Shared;

namespace frontend.Extensiones
{
	public static class SesionStorageExtension
	{
		public static async Task GuardarStorage<T>(this ISessionStorageService sessionStorageService,string key, T item)
			where T : class
		{
			var itemJson = JsonSerializer.Serialize(item);
			await sessionStorageService.SetItemAsStringAsync(key, itemJson);
		}
		public static async Task<T?> ObtenerStorage<T>(this ISessionStorageService sessionStorageService, string key)
			where T : class
		{
			var itemJson = await sessionStorageService.GetItemAsStringAsync(key);
			return itemJson == null ? null : JsonSerializer.Deserialize<T>(itemJson);
		}
	}
}
