using Lib_comunicaciones.Interfaces;
using Lib_entidades;
using Lib_presentaciones.Interfaces;
using Lib_utilidades;
using System.Diagnostics;
using System;

namespace Lib_presentaciones.Implementaciones
{
    public class SucursalPresentacion : ISucursalPresentacion
    {
        private ISucursalComunicacion? iComunicacion = null;

        public SucursalPresentacion(ISucursalComunicacion iComunicacion)
        {
            this.iComunicacion = iComunicacion;
        }

        public async Task<List<Sucursal>> Listar()
        {
            var lista = new List<Sucursal>();
            var datos = new Dictionary<string, object>();

            var respuesta = await iComunicacion!.Listar(datos);
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<Sucursal>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }

        public async Task<List<Sucursal>> Buscar(Sucursal entidad, string tipo)
        {
            var lista = new List<Sucursal>();
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;
            datos["Tipo"] = tipo;

            var respuesta = await iComunicacion!.Buscar(datos);
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<Sucursal>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }

        public async Task<Sucursal> Guardar(Sucursal entidad)
        {
            if (entidad.Id != 0 || !entidad.Validar())
            {
                throw new Exception("lbFaltaInformacion");
            }

            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            var respuesta = await iComunicacion!.Guardar(datos);
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<Sucursal>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }

        public async Task<Sucursal> Modificar(Sucursal entidad)
        {
            if (entidad.Id == 0 || !entidad.Validar())
            {
                throw new Exception("lbFaltaInformacion");
            }

            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            var respuesta = await iComunicacion!.Modificar(datos);
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<Sucursal>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }

        public async Task<Sucursal> Borrar(Sucursal entidad)
        {
            if (entidad.Id == 0 || !entidad.Validar())
            {
                throw new Exception("lbFaltaInformacion");
            }

            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            var respuesta = await iComunicacion!.Borrar(datos);
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<Sucursal>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }
    }
}