using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Agenda.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Formulario : ContentPage
	{
		public Formulario ()
		{
			InitializeComponent ();
		}

        //METODOS PARA LOS EVENTOS DE LOS CONTROLES
        //==================================================
        public async void btnAgregar_Click(Object sender, EventArgs e) {

          bool estado =  RegistroViewModel.RegistrarUsuario(this.txtNombre.Text, 
                                                this.txtApellido.Text, 
                                                this.txtTelefono.Text);
            if (estado)
            {
                //Mostramos el mensaje
                await DisplayAlert("Agenda FGK", "Contacto ingresado con exito!", "Aceptar");
                //Retornoamos a la pagina de Conctactos y Eliminamos de la pila la pagina actual
                Navigation.InsertPageBefore(new Contactos(), this);
                await Navigation.PopAsync();
            }
            else {
                //Mostramos el mensaje
                await DisplayAlert("Agenda FGK", "Error al Ingresar el Contacto", "Aceptar");
            }
            
        }
        //==================================================
    }
}