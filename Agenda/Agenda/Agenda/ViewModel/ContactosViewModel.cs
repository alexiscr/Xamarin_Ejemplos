using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Agenda.Models;

namespace Agenda.ViewModel
{
    class ContactosViewModel
    {
        //Declaracion de variables
        public ObservableCollection<Contactos> ListContactos { get; set; } = new ObservableCollection<Contactos>();

        public ContactosViewModel() {
            //Cargamos la lista de personas
            foreach (var Contacto in Models.Contactos.listaContactos) {
                ListContactos.Add(Contacto);
            }
        }
    }
    
}
