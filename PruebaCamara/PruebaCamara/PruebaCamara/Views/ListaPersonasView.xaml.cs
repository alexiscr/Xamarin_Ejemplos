using PruebaCamara.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PruebaCamara.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListaPersonasView : ContentPage
	{
        // Definición de variables
        private PersonaDBContext db;
        private string dataBase = "PersonaDB.db3";
        private string ubicacion = "";
        ObservableCollection<Persona> _listaPersonas;

		public ListaPersonasView ()
		{
			InitializeComponent ();

            // Obtencion de la ubicación de la DB
            this.ubicacion = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                this.dataBase);
            this.db = new PersonaDBContext(this.ubicacion);            
            
        }

        // Sobreescritura del método OnAppearing el cual actualizara la vista cada vez que vuelva a mostrarse
        protected override void OnAppearing()
        {
            base.OnAppearing();
            CargarPersonas();
        }

        // Método para obtener todos los registros de la tabla solicitada
        private void CargarPersonas()
        {            
            Persona _obtenerPersonas = new Persona(this.db);
            var _personas = _obtenerPersonas.ObtenerTodos("SELECT * FROM [Persona]").Result;
            if (!(_personas == null) || _personas.Count == 0)
            {
                _listaPersonas = new ObservableCollection<Persona>(_personas);
                ListaPersonas.ItemsSource = _listaPersonas;
            }

        }

        // Evento Clic para navegar al formulario de registro
        private async void Add_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}