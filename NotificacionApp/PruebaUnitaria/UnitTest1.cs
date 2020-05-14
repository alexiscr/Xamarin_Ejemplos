using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NotificacionApp.ViewModels;
namespace PruebaUnitaria
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Prueba()
        {
            var test = new viewModelNotification
            {
                Mensaje = "Hola Mundo"
            };
            Assert.AreEqual(test,"Hola Mundo");
        }
    }
}
