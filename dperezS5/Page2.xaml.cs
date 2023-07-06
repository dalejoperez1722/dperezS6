using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace dperezS5
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        public Page2()
        {
            InitializeComponent();
        }

        private void btnInsertar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                string Url = "http://192.168.17.34/moviles/post.php";
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("codigo", txtCodigo.Text);
                parametros.Add("nombre",txtNombre.Text);
                parametros.Add("apellido",txtApellido.Text);
                parametros.Add("edad",txtEdad.Text);
                cliente.UploadValues(Url, "POST", parametros);
                //mensaje toast
                var mensaje = "Dato Ingresado Correctamente";
                DependencyService.Get<Mensaje>().LongAlert(mensaje);
                Navigation.PushAsync(new Page1());

            }
            catch (Exception ex)
            {

                //mensaje toast
                var mensaje = "Cerrando";
                DependencyService.Get<Mensaje>().LongAlert(mensaje);
            }

        }
    }
}