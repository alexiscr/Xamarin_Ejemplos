using Com.OneSignal;
using Com.OneSignal.Abstractions;
using NotificacionApp.ViewModels;
using NotificacionApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace NotificacionApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
            //OneSignal.Current.StartInit("053b4f87-80dd-4512-9d98-b83a7b531f98").EndInit();
            OneSignal.Current.StartInit("053b4f87-80dd-4512-9d98-b83a7b531f98")
                .HandleNotificationOpened(OnHandleNotificationOpended).EndInit();
            //Procesamos el evento de la pagina principal[MainPage] 
            MainPage.Appearing += (seneder, e) =>
            {
                //Validamos que exista un mensaje para procesar
                if (!String.IsNullOrEmpty(viewModelNotification.mensaje))
                {
                    var informacionPage = new Informacion
                    {
                        BindingContext = new viewModelNotification()
                    };
                    var modelPage = new NavigationPage(informacionPage);
                    MainPage.Navigation.PushModalAsync(modelPage);
                    viewModelNotification.mensaje = "";
                }
            };
        }
        //Metodo para procesar el evento de apartura del notificacion
        private void OnHandleNotificationOpended(OSNotificationOpenedResult result)
        {
            //Verificamos la llave que esta viajando en la [Push Notification]
            if (result.notification.payload.additionalData.ContainsKey("Mensaje_Add"))
            {
                //Si en la notificacion existe la llave [Mensaje_Add]
                viewModelNotification.mensaje = result.notification.payload.additionalData["Mensaje_Add"].ToString();
                if (!String.IsNullOrEmpty(viewModelNotification.mensaje))
                {
                    var informacionPage = new Informacion
                    {
                        BindingContext = new viewModelNotification()
                    };
                    var modelPage = new NavigationPage(informacionPage);
                    MainPage.Navigation.PushModalAsync(modelPage);
                    viewModelNotification.mensaje = "";
                }
            }
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
