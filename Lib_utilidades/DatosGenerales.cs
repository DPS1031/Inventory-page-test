using System;
using System.Collections.Generic;

namespace Lib_utilidades
{
    public class DatosGenerales
    {
        public static string ruta_json = @"C:\Users\david\Development\Inventario\Asp_servicios\Recursos\secrets.json";
        public static bool usa_azure = false;
        public static string clave = "EVBgi345936456ghhVBJGtgnifytsidi3456678jhgUTytutyiiyi";
        public static string usuario_datos = EncriptarConversor.Encriptar("Test.Trghhjsgdj");


        public static Dictionary<string, string> Usuarios = new Dictionary<string, string>
        {
            { "David", "12345" },
            { "Alex", "12345" }
        };

        public static Dictionary<string, string> UsuarioDatos = new Dictionary<string, string>
        {
            { "David", EncriptarConversor.Encriptar("David.Trghhjsgdj")},
            { "Alex", EncriptarConversor.Encriptar("Alex.Trghhjsgdj")}
        };
    }
} 