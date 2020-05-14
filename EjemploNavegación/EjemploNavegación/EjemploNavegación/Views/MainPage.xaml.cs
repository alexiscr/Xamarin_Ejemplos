using EjemploNavegación.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EjemploNavegación
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
              
        private async void LoginClick(object sender, EventArgs e)
        {
            
            await Navigation.PushAsync(new Formulario());

          
        }
    }
}
