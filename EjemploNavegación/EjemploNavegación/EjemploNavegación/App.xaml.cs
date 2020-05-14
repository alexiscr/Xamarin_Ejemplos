using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace EjemploNavegación
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Por defecto tiene como inicio nuestra MainPage,
            // pero es necesario habilitarla, modificaremos un poco esta linea.

            MainPage = new NavigationPage(new MainPage());

            // Al anteponer NavigationPage, estamos indicando que a partir de esa pagina
            // se habilitara la navegacion, vamos a compilar y comprobarlo
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
