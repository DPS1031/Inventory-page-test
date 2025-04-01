namespace ConsoleApp.Inventario
{
    public class Producto
    {
        private int id = 0;
        private int codigo_producto = 0;
        private string descripcion = "";

        public int Id { get => this.id; set => this.id = value; }
        public int Codigo_producto { get => this.codigo_producto; set => this.codigo_producto = value; }
        public string Descripcion { get => this.descripcion; set => this.descripcion = value; }

        public Inventario Guarda
        {
            get => default;
            set
            {
            }
        }
    }

    public class Inventario
    {
        private int id = 0;
        private int codigo_producto = 0;
        private int codigo_bodega = 0;
        private int codigo_estante = 0;
        private int cantidad = 0;
        private DateTime fecha = new DateTime(00, 00, 00);
        private string estado = "";


        public int Id { get => this.id; set => this.id = value; }
        public int Codigo_producto { get => this.codigo_producto; set => this.codigo_producto = value; }
        public int Codigo_bodega { get => this.codigo_bodega; set => this.codigo_bodega = value; }
        public int Codigo_estante { get => this.codigo_estante; set => this.codigo_estante = value; }
        public int Cantidad { get => this.cantidad; set => this.cantidad = value; }
        public DateTime Fecha { get => this.fecha; set => this.fecha = value; }
        public string Estado { get => this.estado; set => this.estado = value; }

        public void D()
        {
            throw new System.NotImplementedException();
        }
    }

    public class Proveedor
    {
        private int id = 0;
        private string direccion = "";
        private int contacto = 0;

        public int Id { get => this.id; set => this.id = value; }
        public string Direccion { get => this.direccion; set => this.direccion = value; }
        public int Contacto { get => this.contacto; set => this.contacto = value; }

        public Producto Distribuye
        {
            get => default;
            set
            {
            }
        }

        public void S()
        {
            throw new System.NotImplementedException();
        }
    }

    public class Estante
    {
        private int id = 0;
        private int codigo_estante = 0;
        private int codigo_bodega = 0;
        private string nombre = "";

        public int Id { get => this.id; set => this.id = value; }
        public string Nombre { get => this.nombre; set => this.nombre = value; }
        public int Codigo_estante { get => this.codigo_estante; set => this.codigo_estante = value; }
        public int Codigo_bodega { get => this.codigo_bodega; set => this.codigo_bodega = value; }

        public Inventario Archiva
        {
            get => default;
            set
            {
            }
        }
    }

    public class Bodega
    {
        private int id = 0;
        private int codigo_sucursal = 0;
        private int codigo_bodega = 0;

        public int Id { get => this.id; set => this.id = value; }
        public int Codigo_sucursal { get => this.codigo_sucursal; set => this.codigo_sucursal = value; }
        public int Codigo_bodega { get => this.codigo_bodega; set => this.codigo_bodega = value; }

        public Inventario Almacena
        {
            get => default;
            set
            {
            }
        }
    }

    public class Sucursal
    {
        private int id = 0;
        private int codigo_sucursal = 0;
        private string nombre = "";
        private string ubicacion = "";

        public int Id { get => this.id; set => this.id = value; }
        public string Nombre { get => this.nombre; set => this.nombre = value; }
        public int Codigo_sucursal { get => this.codigo_sucursal; set => this.codigo_sucursal = value; }
        public string Ubicacion { get => this.ubicacion; set => this.ubicacion = value; }

        public Bodega Pertenece
        {
            get => default;
            set
            {
            }
        }

        public void A()
        {
            throw new System.NotImplementedException();
        }
    }
}