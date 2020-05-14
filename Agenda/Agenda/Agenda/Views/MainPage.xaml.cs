using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Agenda.ViewModel;
using Agenda.Views;

namespace Agenda
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
        }

        private async void Click_BotonIniciar(Object sender, EventArgs e) {
            //Creamos la instancia del nuevo inicio de sesión
            PrincipalViewModel.UsurioSesion = new Models.Usuarios();
            PrincipalViewModel.UsurioSesion.IdUsuer = 1;
            PrincipalViewModel.UsurioSesion.Login = this.txtUser.Text;
            PrincipalViewModel.UsurioSesion.Password = this.txtPass.Text;

            //Validamos que el usuario es un usuario correcto
            if (PrincipalViewModel.UsurioSesion.Login.Equals("User") &&
                PrincipalViewModel.UsurioSesion.Password.Equals("123"))
            {
                await DisplayAlert("Agenda FGK", "Inicio de Sesion Ok", "Aceptar");
                Navigation.InsertPageBefore(new Contactos(), this);
                await Navigation.PopAsync();
            }
            else {
                await DisplayAlert("Agenda FGK", "Error al iniciar Sesion", "Aceptar");
            }
        }
	}
}
