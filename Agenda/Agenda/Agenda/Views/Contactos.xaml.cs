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
	public partial class Contactos : ContentPage
	{
		public Contactos ()
		{
			InitializeComponent ();
            BindingContext = new ContactosViewModel();
        }

        //DECLARACION DE EVENTOS DE LA VISTA
        //====================================================
        private  void ItemMenuNuevo_Click(Object sender, EventArgs e) {
            Navigation.InsertPageBefore(new Formulario(), this);
            Navigation.PopAsync();
        }
        //====================================================
    }
}