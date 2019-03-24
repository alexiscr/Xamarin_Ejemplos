using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace PruebaCamara.Models
{
    public class Persona
    {
        // Definición de Campos de la tabla
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNac { get; set; }
        public byte[] Fotografia { get; set; }

        private PersonaDBContext db;

        // Definicion de constructores 
        public Persona() { }
        public Persona(PersonaDBContext pDataBase)
        {
            this.db = pDataBase;
        }

        // Función para Agregar una nueva Persona
        public Task<bool> AgregarPersona(Persona pPersona) {
            if (this.db.Conexion.InsertAsync(pPersona).Result == 1)
            {
                return Task.FromResult(true);
            }
            else {
                return Task.FromResult(false);
            }
        }

        // Función para obtner todos los registros
        public Task<List<Persona>> ObtenerTodos(string pSql) {
            return this.db.Conexion.QueryAsync<Persona>(pSql);
        }

    }
}
