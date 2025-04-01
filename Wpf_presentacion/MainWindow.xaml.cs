using Lib_repositorios;
using Lib_repositorios.Implementaciones;
using System.Windows;
using wpf_presentacion.Nucleo;

namespace wpf_presentacion
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var conexion = new Conexion();
            conexion.StringConnection = Configuracion.ObtenerValor("ConectionString");
            var iRepositorio = new AuditoriasRepositorio(conexion);
            this.dgLista.ItemsSource = iRepositorio.Listar();
        }
    }
}