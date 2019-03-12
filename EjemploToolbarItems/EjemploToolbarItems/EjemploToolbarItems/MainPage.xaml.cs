using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EjemploToolbarItems
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        // Clic para el botón primario
        private void BotonHola(object sender, EventArgs e)
        {
            DisplayAlert("Mensaje","Hola Mundo","Ok");
        }
    }
}
