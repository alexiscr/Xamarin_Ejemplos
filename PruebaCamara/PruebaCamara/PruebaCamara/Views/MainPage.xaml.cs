using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.Media;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms.Xaml;
using System.IO;
using Plugin.Media.Abstractions;
using PruebaCamara.Models;
using System.Reflection;

namespace PruebaCamara
{
    public partial class MainPage : ContentPage
    {
        // Variable para almacenar los byte de la imagen
        private byte[] ImagenByte;

        // Variables para el acceso a la DB
        private PersonaDBContext db;
        private string dataBase = "PersonaDB.db3";
        private string ubicacion = "";

        public MainPage()
        {
            InitializeComponent();

            // Obtenemos la ubicacion de la base de datos
            this.ubicacion = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), this.dataBase
                );
            this.db = new PersonaDBContext(this.ubicacion);

            // Creación de event Tapp en una imagen
            var TappedImage = new TapGestureRecognizer();
            TappedImage.Tapped += (s, e) => {

                // Método que se ejecutara al momento de tocar la imagen
                TomarFoto();

            };
            // Asignamos el evento creado 
            PhotoImage.GestureRecognizers.Add(TappedImage);
        }

        
        // Agregar una nueva persona
        private async void AddPersona_Clicked(object sender, EventArgs e)
        {
            
            // Variables para combinar DatePicker y TimePicker
            int _year = txtFecha.Date.Year;
            int _month = txtFecha.Date.Month;
            int _day = txtFecha.Date.Day;
            int _hour = txtHora.Time.Hours;
            int _minutes = txtHora.Time.Minutes;
            int _seconds = txtHora.Time.Seconds;
            DateTime fecha_nac = new DateTime(_year, _month, _day, _hour, _minutes, _seconds);

            // Instancia del Objeto a Guardar
            Persona _nuevaPersona = new Persona(this.db);

            _nuevaPersona.Nombre = txtNombre.Text;
            _nuevaPersona.Apellido = txtApellido.Text;
            _nuevaPersona.Fotografia = ImagenByte;
            _nuevaPersona.FechaNac = fecha_nac;

            // Ejecucion de la función que agrega personas
            bool resultado = await _nuevaPersona.AgregarPersona(_nuevaPersona);

            // Evaluamos si el registro fue exitoso o no
            if (resultado)
            {
               await DisplayAlert("Exito", "El registro fue almacenado con Exito", "Aceptar");
                txtNombre.Text = string.Empty;
                txtApellido.Text = string.Empty;
                PhotoImage.Source = "user.png";
            }
            else {
               await DisplayAlert("Error", "No fue posible almacenar el registro", "Aceptar");
            }

        }


        // Metodo para la toma de fotografia
        private async void TomarFoto() {

            // Inicializacion de CrossMedia
            await CrossMedia.Current.Initialize();

            // Capturamos el estado actual de los permisos
            var cameraStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
            var storageStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);

            // En caso que no esten otogados mostraremos un mensaje
            if (cameraStatus != PermissionStatus.Granted || storageStatus != PermissionStatus.Granted)
            {
                var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Camera, Permission.Storage });
                cameraStatus = results[Permission.Camera];
                storageStatus = results[Permission.Storage];

            }

            // En caso que los permisos esten otorgados procedemos a tomar la fotografia
            if (cameraStatus == PermissionStatus.Granted && storageStatus == PermissionStatus.Granted)
            {
                // Instancia de clase DateTime para obtener la fecha y hora actual del sistema
                DateTime _hora = DateTime.Now;

                // Ejecutamos el metodo TakePhotoAsync el cual tomara la fotografia
                var photo = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions()
                {

                    // Atributos personalizados 
                    Directory = "AlbumPruebaCam",
                    Name = "CDS" + _hora + ".jpg",
                    PhotoSize = PhotoSize.Medium,
                    CompressionQuality = 92,
                    SaveToAlbum = true

                });

                // En caso que no se obtenga la fotografia
                if (photo == null)
                    return;

                // Conversion Imagen a ByteArray 
                using (var memoryStream = new MemoryStream())
                {
                    photo.GetStream().CopyTo(memoryStream);
                    photo.Dispose();
                    ImagenByte = memoryStream.ToArray();
                }

                // Sustituimos el avatar de la imagen actual por la fotografia tomada
                // Nota: Tambien se puede utilizar el path de la imagen utilizando
                //PhotoImage.Source = photo.AlbumPath;

                PhotoImage.Source = ImageSource.FromStream(() => new MemoryStream(ImagenByte));
            }
            else
            {
                // En caso que los permisos esten denegados mostraremos un mensaje
                await DisplayAlert("Permisos Denegados",
                    "No es posible tomar fotos, no tiene los permisos correspondietes",
                    "Aceptar");
            }
        }
    }
}
