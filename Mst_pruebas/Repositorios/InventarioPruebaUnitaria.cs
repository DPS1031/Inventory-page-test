using Lib_repositorios;
using Lib_repositorios.Implementaciones;
using Lib_repositorios.Interfaces;
using System.Diagnostics.Contracts;
using static mst_pruebas.Repositorios.InventarioPruebaUnitaria;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace mst_pruebas.Repositorios
{
    [TestClass]
    public class InventarioPruebaUnitaria
    {
        private IInventarioRepositorio? iRepositorio = null;
        private Producto? entidad_Producto = null;
        private Inventario? entidad_Inventario = null;
        private Proveedor? entidad_Proveedor = null;
        private Estante? entidad_Estante = null;
        private Bodega? entidad_Bodega = null;
        private Sucursal? entidad_Sucursal = null;
        
        public InventarioPruebaUnitaria()
        {
            var conexion = new Conexion();
            conexion.StringConnection = "Server=DESKTOP-SOSVV67\\DEV;Database=db_Inventario;User Id=sa;Password=12345678; TrustServerCertificate = true; ";
            iRepositorio = new InventarioRepositorio(conexion);
        }
        [TestMethod]
        public void Ejecutar()
        {
            Guardar_Producto();
            Guardar_Inventario();
            Guardar_Proveedor();
            Guardar_Estante();
            Guardar_Bodega();
            Guardar_Sucursal();
            
        }
        private void Guardar_Producto()
        {
            entidad_Producto = new Producto()
            {
                id_producto = "A111",
                codigo_producto = "Pan1",
                descripcion = "Pan integral rico en fibra, perfecto para quienes buscan una alimentación equiLibrada.",

            };
            entidad_Producto = iRepositorio!.Guardar(entidad_Producto);

        }

        private void Guardar_Inventario()
        {
            entidad_Inventario = new Inventario()
            {
                Id_Inventario = "1",
                codigo_producto = "Pan1",
                codigo_bodega = "Sur1",
                codigo_estante = "Reposteria1",
                cantidad = 30,
                fecha = DateTime.Now,
                estado = "Optimo"

            };
            entidad_Inventario = iRepositorio!.Guardar(entidad_Inventario);

        }

        private void Guardar_Proveedor()
        {
            entidad_Proveedor = new Proveedor()
            {
                id_Proveedor = "1",
                Codigo_Proveedor = "Postobon",
                direccion = "Calle1A#10-31",
                contacto = 234567891
            };
            entidad_Proveedor = iRepositorio!.Guardar(entidad_Proveedor);

        }

        private void Guardar_Estante()
        {
            entidad_Estante = new Estante()
            {
                id_Estante = "A1",
                codigo_estante = "Reposteria1",
                codigo_bodega = "Sur1",
                nombre = "Panadería"
            };
            entidad_Estante = iRepositorio!.Guardar(entidad_Estante);

        }

        private void Guardar_Bodega()
        {
            entidad_Bodega = new Bodega()
            {
                id_Bodega = "0015",
                codigo_sucursal = "Bog1",
                codigo_bodega = "Sur1",
            };
            entidad_Bodega = iRepositorio!.Guardar(entidad_Bodega);

        }

        private void Guardar_Sucursal()
        {
            entidad_Sucursal = new Sucursal()
            {
                id_Sucursal = "B1",
                codigo_Sucursal = "Bog1",
                Nombre = "Bogotá1",
                ubicacion = "Bogotá",
            };
            entidad_Sucursal = iRepositorio!.Guardar(entidad_Sucursal);

        }
    }
}

