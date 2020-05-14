using System;
using System.Collections.Generic;
using System.Text;

namespace Agenda.Models
{
    public class Contactos
    {
        public int IdContacto { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String Telefono { get; set; }
        public String Imagen { get; set; }

        //Elementos estaticos para Almacenar datos de una persona
        public static List<Contactos> listaContactos = new List<Contactos>();

        //DECLARACION DE METODOS DM
        //=========================================================
        //Agregar
        public static bool AgregarContacto(Contactos nuevo) {
            bool valreturn = true;
            try
            {
                //Creamos el Id del contacto
                if (Contactos.listaContactos.Count == 0)
                {
                    //Si es el primero le asignamos el valor de 1
                    nuevo.IdContacto = 1;
                }
                else {
                    //Si existen contactos buscamos el ultimo para asignarle el ID
                    nuevo.IdContacto = Contactos.listaContactos[Contactos.listaContactos.Count-1].IdContacto + 1;
                }
                nuevo.Imagen = "user.png";
                Contactos.listaContactos.Add(nuevo);
            }
            catch (Exception)
            {
                valreturn = false;
            }
            return valreturn;
        }
        //Eliminar
        public static bool Eliminar(Contactos contacto) {
            bool valReturn = true;
            try
            {
              valReturn=  listaContactos.Remove(contacto);
            }
            catch (Exception)
            {
                valReturn = false;
            }
            return valReturn;
        }
        //=========================================================
    }
}
