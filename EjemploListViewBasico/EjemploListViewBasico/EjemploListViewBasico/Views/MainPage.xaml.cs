using EjemploListViewBasico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EjemploListViewBasico
{
    public partial class MainPage : ContentPage
    {
        // Definición de lista 
        private List<Persona> _listaPersona;

        public MainPage()
        {
            InitializeComponent();

            // Inicialización de la lista con valores al momento de inicializar la vista
            _listaPersona = new List<Persona>() { 
                new Persona() { Id = 1, Nombre = "Juan", Avatar = "avatar.png" },
                new Persona() { Id = 2, Nombre = "Maria", Avatar = "avatar.png" },
                new Persona() { Id = 3, Nombre = "Pablo", Avatar = "avatar.png" },
                new Persona() { Id = 4, Nombre = "Ester", Avatar = "avatar.png" },
                new Persona() { Id = 5, Nombre = "Ronald", Avatar = "avatar.png" },
                new Persona() { Id = 6, Nombre = "Carlos", Avatar = "avatar.png" },
                new Persona() { Id = 7, Nombre = "Pedro", Avatar = "avatar.png" },
                new Persona() { Id = 8, Nombre = "Julio", Avatar = "avatar.png" },
                new Persona() { Id = 9, Nombre = "Alex", Avatar = "avatar.png" },
                new Persona() { Id = 9, Nombre = "Ruben", Avatar = "avatar.png" }
            };

            // Carga de ListView a partir del nombre de referencia x:Name y la propiedad ItemsSource con la lista creada
            ListaPersona.ItemsSource = _listaPersona;
    }
    }
}
