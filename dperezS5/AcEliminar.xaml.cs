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
    public partial class AcEliminar : ContentPage
    {
        public AcEliminar(int codigo,string nombre,string apellido,int edad)
        {
            InitializeComponent();
            txtCodigo.Text = codigo.ToString();
            txtNombre.Text = nombre.ToString();
            txtApellido.Text = apellido.ToString();
            txtEdad.Text = edad.ToString();
            

        }
        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                string Url = "http://192.168.17.34/moviles/post.php?codigo=" + txtCodigo.Text + "&nombre=" + txtNombre.Text + "&apellido=" + txtApellido.Text + "&edad=" + txtEdad.Text;
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Set("codigo", txtCodigo.Text);
                parametros.Set("nombre", txtNombre.Text);
                parametros.Set("apellido", txtApellido.Text);
                parametros.Set("edad", txtEdad.Text);
                cliente.UploadValues(Url, "PUT", parametros);
                //mensaje toast
                var mensaje = "Dato Actualizado";
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
        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            WebClient cliente = new WebClient();
            string Url = "http://192.168.17.34/moviles/post.php?codigo="+txtCodigo.Text;
            var parametros = new System.Collections.Specialized.NameValueCollection();
            parametros.Add("codigo", txtCodigo.Text);
            cliente.UploadValues(Url, "DELETE", parametros);
            //mensaje toast
            var mensaje = "Borrado Correcto";
            DependencyService.Get<Mensaje>().LongAlert(mensaje);
            Navigation.PushAsync(new Page1());
        }
    }
}
   
       
