using System.Diagnostics;

namespace Lib_utilidades
{
    public class LogConversor
    {
        public static void Log(Exception exception,
            IDictionary<string, object> ViewData)
        {
            Debug.WriteLine(exception.ToString());

            if (ViewData == null)
                return;
            var mensaje = exception.Message.ToString();
            if (exception.InnerException != null)
                mensaje = exception.InnerException!.Message.ToString();

            if (mensaje.Length >= 110)
                mensaje = mensaje.Substring(0, 110);

            var msg = Lib_lenguajes.RsErrores.ResourceManager.GetString(mensaje);
            if (!string.IsNullOrEmpty(msg))
            {
                ViewData!["Mensaje"] = msg;
                return;
            }
            ViewData!["Mensaje"] = mensaje;
        }
    }
}