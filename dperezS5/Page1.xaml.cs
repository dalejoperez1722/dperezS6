using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace dperezS5
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    
    public partial class Page1 : ContentPage
    {
        private const string url = "http://192.168.17.34/moviles/post.php";
        private HttpClient cliente = new HttpClient();
        private ObservableCollection<dperezS5.Datos> post;
        public Page1()
        {
            InitializeComponent();
            obtener();
        }

        public async void obtener()
        {
            var contenido = await cliente.GetStringAsync(url);
            List<dperezS5.Datos> listapost = JsonConvert.DeserializeObject<List<dperezS5.Datos>>(contenido);
            post = new ObservableCollection<Datos>(listapost);
            listaCanciones.ItemsSource = post;
        }

        private void listaCanciones_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var objetoEstudiante =(Datos)e.SelectedItem;
            var codigo=Convert.ToInt32(objetoEstudiante.Codigo.ToString());
            string nombre = objetoEstudiante.nombre.ToString();
            string apellido = objetoEstudiante.apellido.ToString();
            int edad=Convert.ToInt32(objetoEstudiante.edad.ToString());
            Navigation.PushAsync(new AcEliminar(codigo,nombre,apellido,edad));



        }

        private void btnInsertar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page2());
        }
    }
}