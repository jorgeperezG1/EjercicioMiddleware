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
        private const string MiddlewareUrl = "http://localhost/sdtiendas/middleware/middleware.php"; // Cambia según tu configuración

        public Form1()
        {
            InitializeComponent();
            CargarTiendas();
        }

        private async void CargarTiendas()
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

        private async void buttonSolicitar_Click(object sender, EventArgs e)
        {
            if (comboBoxTiendas.SelectedValue != null)
            {
                var tiendaId = comboBoxTiendas.SelectedValue.ToString();
                var response = await httpClient.GetAsync($"{MiddlewareUrl}?action=obtenerProductosPorTienda&tienda_id={tiendaId}");

                if (response.IsSuccessStatusCode)
                {
                    var productosJson = await response.Content.ReadAsStringAsync();
                    var productos = JsonConvert.DeserializeObject<List<Producto>>(productosJson);
                    dataGridViewProductos.DataSource = productos;
                }
                else
                {
                    MessageBox.Show("Error al cargar los productos.");
                }
            }
        }
    }

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
