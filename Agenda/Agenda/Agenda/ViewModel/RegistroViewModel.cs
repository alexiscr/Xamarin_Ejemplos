using System;
using System.Collections.Generic;
using System.Text;
using Agenda.Models;

namespace Agenda.ViewModel
{
    public class RegistroViewModel
    {
        public static bool RegistrarUsuario(String Nombre, String Apellido, String Contacto) {
            bool valReturn = true;
            try
            {
                Contactos nuevoContacto = new Contactos();
                nuevoContacto.Nombre = Nombre;
                nuevoContacto.Apellido = Apellido;
                nuevoContacto.Telefono = Contacto;

               valReturn = Contactos.AgregarContacto(nuevoContacto);
            }
            catch (Exception)
            {
                valReturn = false;
            }
            return valReturn;
        }
    }
}
