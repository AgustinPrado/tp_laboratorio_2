using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using EntidadesAbstractas;


namespace TestUnitarioExcepcionesNumerico
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            try 
	        {	        
                //Persona pepe = new Persona("Agus", "Prado", "37.14.307.8", Persona.ENacionalidad.Argentino);
	        }
	        catch (Exception e)
	        {
                Assert.AreEqual("La nacionalidad no se condice con el número de DNI", e.Message);
                
	        }
            
            
            
        }
    }
}
