using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace UnitTest
{
    [TestClass]
    public class TestNulos
    {
        [TestMethod]
        public void TestMethod1()
        {
            Correo kreo = new Correo();
            Assert.IsNotNull(kreo.Paquetes);
        }
    }
}
