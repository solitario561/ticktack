using Shared;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace frontend.Extensiones
{
	public class AutenticacionExtension : AuthenticationStateProvider
	{
		private readonly ISessionStorageService _sessionStorage;
		private ClaimsPrincipal _sinInformacion = new ClaimsPrincipal(new ClaimsIdentity());
		public AutenticacionExtension(ISessionStorageService sessionStorage)
		{
			_sessionStorage = sessionStorage;
		}
		public async Task ActualizarEstadoAutenticacion(SesionDto? sesionUsuario)
		{
			ClaimsPrincipal claimsPrincipal;

			if(sesionUsuario != null)
			{
				claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim> 
				{
					new Claim(ClaimTypes.Name,sesionUsuario.Nombre),
					new Claim(ClaimTypes.Email,sesionUsuario.Correo)
				},"JwtAuth"));
				await _sessionStorage.GuardarStorage("sesionUsuario",sesionUsuario);
			}
			else
			{
				claimsPrincipal = _sinInformacion;
				await _sessionStorage.RemoveItemAsync("sesionUsuario");
			}
			NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
		}
		public override async Task<AuthenticationState> GetAuthenticationStateAsync()
		{
			var sesionUsuario = await _sessionStorage.ObtenerStorage<SesionDto>("sesionUsuario");
			if (sesionUsuario == null)
				return await Task.FromResult(new AuthenticationState(_sinInformacion));
			var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
				{
					new Claim(ClaimTypes.Name,sesionUsuario.Nombre),
					new Claim(ClaimTypes.Email,sesionUsuario.Correo)
				}, "JwtAuth"));

			return await Task.FromResult(new AuthenticationState(claimsPrincipal));
		}
	}
}
