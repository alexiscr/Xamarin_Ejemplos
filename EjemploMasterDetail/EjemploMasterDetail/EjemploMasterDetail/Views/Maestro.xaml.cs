using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EjemploMasterDetail.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Maestro : MasterDetailPage
	{
        // Lista para crear los items del menu maestro
        private List<string> _listaPaginas;

		public Maestro ()
		{
			InitializeComponent ();

            // Inicialización de los items del menu
            _listaPaginas = new List<string>() {
                "Pagina 1",
                "Pagina 2",
                "Pagina 3",
                "Pagina 4",
                "Pagina 5"
            };

            // Cargamos la lista con los items del menu
            ListaPaginas.ItemsSource = _listaPaginas;
        }

        // Evento ItemTapped que se ejecutara al seleccionar un item
        private void SeleccionPaginas(object sender, ItemTappedEventArgs e)
        {
            // Chequeamos que el argumento no sea nulo
            if (e.Item != null)
            {
                /** Capturamos el valor que se ha seleccionado, para ello es necesario realizar un casting de datos
                 * ya que lo que se recibe es un object, primeramente lo debemos convertir a ListView y luego a string 
                 * y asi poder obtner el valor del item seleccionado.
                 * **/
                string _pagina = (string)((ListView)sender).SelectedItem ;

                // En este caso comparamos el valor recibido y acorde a ese valor la página de detalle cambiara
                switch (_pagina)
                {
                    case "Pagina 1":
                        // En caso de que el valor recibido es Pagina 1 cargara a la Vista XAML creada
                        Detail = new NavigationPage(new Pagina_01());
                        break;
                    case "Pagina 2":
                        Detail = new NavigationPage(new Pagina_02());
                        break;
                    case "Pagina 3":
                        Detail = new NavigationPage(new Pagina_03());
                        break;
                    case "Pagina 4":
                        Detail = new NavigationPage(new Pagina_04());
                        break;
                    case "Pagina 5":
                        Detail = new NavigationPage(new Pagina_05());
                        break;
                }

                // Esta propiedad esconde el master luego de seleccionar una opción
                IsPresented = false;
               
            }
        }
    }
}