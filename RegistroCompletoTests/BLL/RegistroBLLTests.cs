using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroCompleto.BLL;
using RegistroCompleto.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroCompleto.BLL.Tests
{
    [TestClass()]
    public class RegistroBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Persona persona = new Persona();
            persona.PersonaID = 0;
            persona.Nombre = "Prueba del primer Test";
            persona.Telefono = " 8297825981";
            persona.Direccion = "Bombillo de Villa Riva";
            persona.FechaNacimiento = DateTime.Now;
            paso = RegistroBLL.Guardar(persona);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Persona persona = new Persona();
            persona.PersonaID = 0;
            paso = RegistroBLL.Modificar(persona);
            Assert.AreEqual(paso, true);

        }


        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            Persona persona = new Persona();
            persona.PersonaID = 0;
            paso = RegistroBLL.Eliminar(persona.PersonaID);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            bool paso = false;
            Persona persona = new Persona();
            persona = RegistroBLL.Buscar(3);
            if (persona != null)
                paso = true;
            Assert.AreEqual(paso, true);

        }

        [TestMethod()]
        public void GetListTest()
        {
            Assert.Fail();
        }
    }
}