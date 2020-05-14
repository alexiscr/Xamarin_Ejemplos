using System;
using System.Collections.Generic;
using System.Text;

namespace Cost3DPrint.Models
{
    public class ModelPrint
    {
        public int Id { get; set; }
        public Tiempo TiempoImpresion { get; set; }
        public double KwhCosto { get; set; }
        public double FilamentoPrecio { get; set; }
        public double RatioGanancia { get; set; }
        public int Gramos { get; set; }
        public double CostoImpresion { get; set; }
        public String Material { get; set; }
        public String NombreImpresion { get; set; }
        public int ThingID { get; set; }
    }

    public class Tiempo {
        public int Horas { get; set; }
        public int Minutos { get; set; }
    }


}
