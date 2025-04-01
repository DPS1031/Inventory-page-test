using asp_servicios.Nucleo;
using Lib_aplicaciones.Interfaces;
using Lib_entidades;
using Lib_utilidades;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Lib_repositorios;
using System;
using Lib_repositorios.Interfaces;
using Lib_repositorios.Implementaciones;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductoController : ControllerBase
    {
        private I_ProductoAplicacion? iAplicacion = null;
        private TokenController? tokenController = null;
        private I_AuditoriasAplicacion Traza = null;
        //private I_AuditoriasAplicacion? Traza = null;
        public ProductoController(I_ProductoAplicacion? iAplicacion,
            TokenController tokenController, I_AuditoriasAplicacion Traza)
        {
            this.iAplicacion = iAplicacion;
            this.tokenController = tokenController;
            this.Traza = Traza;
        }

        private Dictionary<string, object> ObtenerDatos()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = new StreamReader(Request.Body).ReadToEnd().ToString();
                if (string.IsNullOrEmpty(datos))
                    datos = "{}";
                return JsonConversor.ConvertirAObjeto(datos);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                return respuesta;
            }
        }

        [HttpPost]
        public string Listar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();
                if (!tokenController!.Validate(datos))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }

                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("ConectionString"));
                respuesta["Entidades"] = this.iAplicacion!.Listar();

                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
        }

        [HttpPost]
        public string Buscar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();
                if (!tokenController!.Validate(datos))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }

                var entidad = JsonConversor.ConvertirAObjeto<Producto>(
                    JsonConversor.ConvertirAString(datos["Entidad"]));
                var tipo = datos["Tipo"].ToString();

                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("ConectionString"));
                respuesta["Entidades"] = this.iAplicacion!.Buscar(entidad, tipo);

                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                respuesta["Error"] = ex.Message.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
        }

        [HttpPost]
        public string Guardar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();
                if (!tokenController!.Validate(datos))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }

                var entidad = JsonConversor.ConvertirAObjeto<Producto>(
                    JsonConversor.ConvertirAString(datos["Entidad"]));

                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("ConectionString"));
                entidad = this.iAplicacion!.Guardar(entidad);

                respuesta["Entidad"] = entidad;
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
                this.Traza.Guardar(Request.Headers["Usuario"], "Producto Creado");
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
        }

        [HttpPost]
        public string Modificar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();
                if (!tokenController!.Validate(datos))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }

                var entidad = JsonConversor.ConvertirAObjeto<Producto>(
                    JsonConversor.ConvertirAString(datos["Entidad"]));

                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("ConectionString"));
                entidad = this.iAplicacion!.Modificar(entidad);

                respuesta["Entidad"] = entidad;
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
                this.Traza.Guardar(Request.Headers["Usuario"], "Producto Modificado");
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
        }

        [HttpPost]
        public string Borrar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();
                if (!tokenController!.Validate(datos))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }

                var entidad = JsonConversor.ConvertirAObjeto<Producto>(
                    JsonConversor.ConvertirAString(datos["Entidad"]));

                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("ConectionString"));
                entidad = this.iAplicacion!.Borrar(entidad);

                respuesta["Entidad"] = entidad;
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
                this.Traza.Guardar(Request.Headers["Usuario"], "Producto Borrado");
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
        }
    }
}