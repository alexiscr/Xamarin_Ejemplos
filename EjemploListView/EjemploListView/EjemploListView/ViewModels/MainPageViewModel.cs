using System;
using System.Collections.Generic;
using System.Text;

// Referencia hacia la carpeta Models para poder invocar la clase Persona
using EjemploListView.Models;

// Referencia hacia la libreria ObjectModel la cual habilita el uso de Colecciones Observables
using System.Collections.ObjectModel;

namespace EjemploListView.ViewModels
{
    // El nivel de acceso de la clase debe ser publico
    public class MainPageViewModel
    {
        // Declraración de la propiedad para la colección observable del tipo Persona
        public ObservableCollection<Persona> _listaPersona { get; set; }

        // Constructor de la clase
        public MainPageViewModel()
        {
            // Inicialización de la colección observable con datos pre establecidos
            _listaPersona = new ObservableCollection<Persona>() {
                new Persona(){ Id=1,Nombre="Juan",Avatar="avatar.png"},
                new Persona(){ Id=2,Nombre="Maria",Avatar="avatar.png"},
                new Persona(){ Id=3,Nombre="Pablo",Avatar="avatar.png"},
                new Persona(){ Id=4,Nombre="Ester",Avatar="avatar.png"},
                new Persona(){ Id=5,Nombre="Ronald",Avatar="avatar.png"},
                new Persona(){ Id=6,Nombre="Carlos",Avatar="avatar.png"},
                new Persona(){ Id=7,Nombre="Pedro",Avatar="avatar.png"},
                new Persona(){ Id=8,Nombre="Julio",Avatar="avatar.png"},
                new Persona(){ Id=9,Nombre="Alex",Avatar="avatar.png"},
                new Persona(){ Id=9,Nombre="Ruben",Avatar="avatar.png"}
            };
        }
    }
}
