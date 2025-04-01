using Lib_utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Asp_presentacion.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [IgnoreAntiforgeryToken]
    public class IndexModel : PageModel
    {
        public bool EstaLogueado = false;
        [BindProperty] public string? Email { get; set; }
        [BindProperty] public string? Contraseña { get; set; }
        [BindProperty] public Enumerables.Ventanas Accion { get; set; }

        public void OnGet()
        {
            var variable_session = HttpContext.Session.GetString("Usuario");
            if (!String.IsNullOrEmpty(variable_session))
            {
                EstaLogueado = true;
                return;
            }
        }

        public void OnPostBtClean()
        {
            try
            {
                Email = string.Empty;
                Contraseña = string.Empty;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtEnter()
        {
            try
            {
                if (string.IsNullOrEmpty(Email) &&
                    string.IsNullOrEmpty(Contraseña))
                {
                    OnPostBtClean();
                    return;
                }

                /*if ("Usuario.123" != Email + "." + Contraseña)
                {
                    OnPostBtClean();
                    return;
                }*/

                if (!DatosGenerales.Usuarios.ContainsKey(Email) || Contraseña != DatosGenerales.Usuarios[Email]) {

                    OnPostBtClean();
                    throw new Exception ("Usuario o clave invalida");
                };

                ViewData["Logged"] = true;
                HttpContext.Session.SetString("Usuario", Email!);
                EstaLogueado = true;
                OnPostBtClean();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtClose()
        {
            try
            {
                HttpContext.Session.Clear();
                HttpContext.Response.Redirect("/");
                EstaLogueado = false;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
    }
}