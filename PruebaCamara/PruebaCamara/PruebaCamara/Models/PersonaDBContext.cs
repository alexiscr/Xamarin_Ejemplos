using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using SQLite;

namespace PruebaCamara.Models
{
    public class PersonaDBContext
    {
        // Propiedad que establecera la conexion a la DB
        public SQLiteAsyncConnection Conexion { get; set; }

        
        public PersonaDBContext(string pSqlitePath)
        {
            try
            {
                // Generamos una nueva conexión enviando la ruta de la DB como parametro
                Conexion = new SQLiteAsyncConnection(pSqlitePath);

                // En caso que la tabla no exista se creara
                this.Conexion.CreateTableAsync<Persona>().Wait();
            }
            catch (Exception ex)
            {
                Debug.Print("Error " + ex.Message);
            }
           
        }
    }
}
