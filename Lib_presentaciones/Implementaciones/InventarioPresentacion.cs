using Lib_comunicaciones.Interfaces;
using Lib_entidades;
using Lib_presentaciones.Interfaces;
using Lib_utilidades;
using System.Diagnostics;
using System;

namespace Lib_presentaciones.Implementaciones
{
    public class InventarioPresentacion : IInventarioPresentacion
    {
        private IInventarioComunicacion? iComunicacion = null;

        public InventarioPresentacion(IInventarioComunicacion iComunicacion)
        {
            this.iComunicacion = iComunicacion;
        }

        public async Task<List<Inventario>> Listar()
        {
            var lista = new List<Inventario>();
            var datos = new Dictionary<string, object>();

            var respuesta = await iComunicacion!.Listar(datos);
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<Inventario>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }

        public async Task<List<Inventario>> Buscar(Inventario entidad, string tipo)
        {
            var lista = new List<Inventario>();
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;
            datos["Tipo"] = tipo;

            var respuesta = await iComunicacion!.Buscar(datos);
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<Inventario>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }

        public async Task<Inventario> Guardar(Inventario entidad)
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
            entidad = JsonConversor.ConvertirAObjeto<Inventario>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }

        public async Task<Inventario> Modificar(Inventario entidad)
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
            entidad = JsonConversor.ConvertirAObjeto<Inventario>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }

        public async Task<Inventario> Borrar(Inventario entidad)
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
            entidad = JsonConversor.ConvertirAObjeto<Inventario>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }
    }
}