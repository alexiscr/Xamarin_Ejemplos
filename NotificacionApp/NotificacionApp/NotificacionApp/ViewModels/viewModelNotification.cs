using System;
using System.Collections.Generic;
using System.Text;

namespace NotificacionApp.ViewModels
{
    public class viewModelNotification
    {
        public static String mensaje;

        public String Mensaje{ get; set; }

        public viewModelNotification() {
            this.Mensaje = mensaje;
        }
    }
}
