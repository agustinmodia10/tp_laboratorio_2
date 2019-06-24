using System;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class TackingIDReperido
    {
        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void TestMethod1()
        {
            Paquete paquete = new Paquete("HHHHHH 234", "0000000876");
            Paquete paquete2 = new Paquete("WWWWWW 345", "900000000000");
            Correo correo = new Correo();
            correo += paquete;
            correo += paquete2;
        }
    }
}
