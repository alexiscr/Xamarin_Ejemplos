using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EjemploNavegación.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Formulario : ContentPage
	{
		public Formulario ()
		{
			InitializeComponent ();
		}

        private async void BackClic(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}