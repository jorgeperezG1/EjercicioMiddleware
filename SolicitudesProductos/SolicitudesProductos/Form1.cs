using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace SolicitudesProductos
{
    public partial class Form1 : Form
    {
        private readonly HttpClient httpClient = new HttpClient();
        private const string MiddlewareUrl = "http://localhost/SDtienda/middleware/middleware.php"; // Cambia según tu configuración

        public Form1()
        {
            InitializeComponent();
            CargarTiendas();
        }

        // Método para cargar las tiendas desde el middleware
        private async void CargarTiendas()
        {
            try
            {
                var response = await httpClient.GetAsync($"{MiddlewareUrl}?action=obtenerTiendas");
                if (response.IsSuccessStatusCode)
                {
                    var tiendasJson = await response.Content.ReadAsStringAsync();
                    var tiendas = JsonConvert.DeserializeObject<List<Tienda>>(tiendasJson);
                    comboBoxTiendas.DataSource = tiendas;
                    comboBoxTiendas.DisplayMember = "nombre";
                    comboBoxTiendas.ValueMember = "id";
                }
                else
                {
                    MessageBox.Show("Error al cargar las tiendas.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar la solicitud: " + ex.Message);
            }
        }

        // Evento del botón para solicitar los productos de una tienda seleccionada
        private async void buttonSolicitar_Click(object sender, EventArgs e)
        {
            if (comboBoxTiendas.SelectedValue != null)
            {
                var tiendaId = comboBoxTiendas.SelectedValue.ToString();
                try
                {
                    var response = await httpClient.GetAsync($"{MiddlewareUrl}?action=obtenerProductosPorTienda&tienda_id={tiendaId}");

                    if (response.IsSuccessStatusCode)
                    {
                        var productosJson = await response.Content.ReadAsStringAsync();
                        var productos = JsonConvert.DeserializeObject<List<Producto>>(productosJson);

                        if (productos != null && productos.Count > 0)
                        {
                            dataGridViewProductos.DataSource = null; // Limpia la fuente de datos
                            dataGridViewProductos.DataSource = productos; // Asigna los nuevos productos
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron productos para esta tienda.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error al cargar los productos.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al realizar la solicitud: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una tienda.");
            }
        }

        // Este método se eliminó ya que no necesitas manejar el evento 'CellContentClick'
        // Puedes agregarlo si más adelante decides que lo necesitas.
    }

    // Clases para deserializar los datos recibidos desde el middleware
    public class Tienda
    {
        public int id { get; set; }
        public string nombre { get; set; }
    }

    public class Producto
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
        public int stock { get; set; }
        public int tienda_id { get; set; }
    }
}
