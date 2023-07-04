using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static System.Net.WebRequestMethods;

namespace dperezS5
{
    public partial class MainPage : ContentPage
    {
        private const string url = "http://192.168.17.34/moviles/post.php";
        private HttpClient cliente = new HttpClient();
        private ObservableCollection<dperezS5.Datos> post;
        public MainPage()
        {
            InitializeComponent();
        }

        private async  void btnMostrar_Clicked(object sender, EventArgs e)
        {
            var contenido = await cliente.GetStringAsync (url);
            List<dperezS5.Datos> listapost = JsonConvert.DeserializeObject<List<dperezS5.Datos>>(contenido);
            post = new ObservableCollection<Datos>(listapost);
            listaCanciones.ItemsSource = post; 

        }
    }
}
