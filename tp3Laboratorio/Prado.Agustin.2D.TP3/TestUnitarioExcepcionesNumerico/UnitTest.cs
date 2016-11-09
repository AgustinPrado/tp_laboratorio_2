using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using EntidadesAbstractas;
using EntidadesInstanciables;

namespace TestUnitarioExcepcionesNumerico
{
    [TestClass]
    public class UnitTest
    {
        /// <summary>
        /// Valido que el DNI no pueda tener ni puntos ni letras.
        /// </summary>
        [TestMethod]
        public void DNI_Invalido_Texto()
        {
            // DNI con punto
            string dniComa = "37.143.078";
            try 
	        {
                Alumno alu = new Alumno(65, "Agustin", "Prado", dniComa, Persona.ENacionalidad.Argentino, Gimnasio.EClases.Natacion, Alumno.EEstadoCuenta.AlDia);
                Assert.Fail("Sin excepción para DNI inválido: {0}.", dniComa);
	        }
	        catch (Exception e)
	        {
                // DNIInvalidoException lanza NacionalidadInvalidaException siempre.
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));                
	        }
            
            // DNI con texto
            string dniTexto = "37agus078";
            try
            {
                Alumno alu = new Alumno(65, "Agustin", "Prado", dniTexto, Persona.ENacionalidad.Argentino, Gimnasio.EClases.Natacion, Alumno.EEstadoCuenta.AlDia);
                Assert.Fail("Sin excepción para DNI inválido: {0}.", dniTexto);
            }
            catch (Exception e)
            {
                // DNIInvalidoException lanza NacionalidadInvalidaException siempre.
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }            
        }

        /// <summary>
        /// Valido que no se ingrese DNI con valores por debajo del mínimo.
        /// </summary>
        [TestMethod]
        public void DNI_Invalido_Bajo()
        {
            // DNI mínimo para argentino.
            int dniBajo = 0;
            try
            {
                Alumno alu = new Alumno(65, "Agustin", "Prado", dniBajo.ToString(), Persona.ENacionalidad.Argentino, Gimnasio.EClases.Natacion, Alumno.EEstadoCuenta.AlDia);
                Assert.Fail("Sin excepción para DNI inválido: {0}.", dniBajo);
            }
            catch (Exception e)
            {
                // DNIInvalidoException lanza NacionalidadInvalidaException siempre.
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }

            // DNI mínimo para extranjero.
            dniBajo = 89999999;
            try
            {
                Alumno alu = new Alumno(65, "Agustin", "Prado", dniBajo.ToString(), Persona.ENacionalidad.Extranjero, Gimnasio.EClases.Natacion, Alumno.EEstadoCuenta.AlDia);
                Assert.Fail("Sin excepción para DNI inválido: {0}.", dniBajo);
            }
            catch (Exception e)
            {
                // DNIInvalidoException lanza NacionalidadInvalidaException siempre.
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }  
        }

        /// <summary>
        /// Valido que no se ingrese DNI con valores por arriba del máximo.
        /// </summary>
        [TestMethod]
        public void DNI_Invalido_Alto()
        {
            // DNI máximo para argentino.
            int dniAlto = 90000000;
            try
            {
                Alumno alu = new Alumno(65, "Agustin", "Prado", dniAlto.ToString(), Persona.ENacionalidad.Argentino, Gimnasio.EClases.Natacion, Alumno.EEstadoCuenta.AlDia);
                Assert.Fail("Sin excepción para DNI inválido: {0}.", dniAlto);
            }
            catch (Exception e)
            {
                // DNIInvalidoException lanza NacionalidadInvalidaException siempre.
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }

            // DNI mínimo para extranjero.
            dniAlto = 100000000;
            try
            {
                Alumno alu = new Alumno(65, "Agustin", "Prado", dniAlto.ToString(), Persona.ENacionalidad.Extranjero, Gimnasio.EClases.Natacion, Alumno.EEstadoCuenta.AlDia);
                Assert.Fail("Sin excepción para DNI inválido: {0}.", dniAlto);
            }
            catch (Exception e)
            {
                // DNIInvalidoException lanza NacionalidadInvalidaException siempre.
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }  
        }

        /// <summary>
        /// Valido los rangos de DNI para argentino.
        /// </summary>
        [TestMethod]
        public void DNI_Valido_Argentino()
        {
            // DNI al azar
            int dniMedio = new Random().Next(1, 90000000);
            Alumno alu = new Alumno(65, "Agustin", "Prado", dniMedio.ToString(), Persona.ENacionalidad.Argentino, Gimnasio.EClases.Natacion, Alumno.EEstadoCuenta.AlDia);
            // Cargó OK?
            Assert.AreEqual(alu.DNI, dniMedio);

            // Primer DNI válido
            int dniPrimero = 1;
            alu = new Alumno(65, "Agustin", "Prado", dniPrimero.ToString(), Persona.ENacionalidad.Argentino, Gimnasio.EClases.Natacion, Alumno.EEstadoCuenta.AlDia);
            // Cargó OK?
            Assert.AreEqual(alu.DNI, dniPrimero);

            // Último DNI válido
            int dniUltimo = 89999999;
            alu = new Alumno(65, "Agustin", "Prado", dniUltimo.ToString(), Persona.ENacionalidad.Argentino, Gimnasio.EClases.Natacion, Alumno.EEstadoCuenta.AlDia);
            // Cargó OK?
            Assert.AreEqual(alu.DNI, dniUltimo);
        }

        /// <summary>
        /// Valido los rangos de DNI para extranjero.
        /// </summary>
        [TestMethod]
        public void DNI_Valido_Extranjero()
        {
            // DNI al azar
            int dniMedio = new Random().Next(90000000, 100000000);
            Alumno alu = new Alumno(65, "Agustin", "Prado", dniMedio.ToString(), Persona.ENacionalidad.Extranjero, Gimnasio.EClases.Natacion, Alumno.EEstadoCuenta.AlDia);
            // Cargó OK?
            Assert.AreEqual(alu.DNI, dniMedio);

            // Primer DNI válido
            int dniPrimero = 90000000;
            alu = new Alumno(65, "Agustin", "Prado", dniPrimero.ToString(), Persona.ENacionalidad.Extranjero, Gimnasio.EClases.Natacion, Alumno.EEstadoCuenta.AlDia);
            // Cargó OK?
            Assert.AreEqual(alu.DNI, dniPrimero);

            // Último DNI válido
            int dniUltimo = 99999999;
            alu = new Alumno(65, "Agustin", "Prado", dniUltimo.ToString(), Persona.ENacionalidad.Extranjero, Gimnasio.EClases.Natacion, Alumno.EEstadoCuenta.AlDia);
            // Cargó OK?
            Assert.AreEqual(alu.DNI, dniUltimo);
        }

        /// <summary>
        /// Valido que ninguno de los atributos de Alumno sea nulo.
        /// </summary>
        [TestMethod]
        public void Alumno_NoNulo()
        {
            Alumno alu = new Alumno(65, "Agustin", "Prado", "37143078", Persona.ENacionalidad.Argentino, Gimnasio.EClases.Natacion, Alumno.EEstadoCuenta.AlDia);
            // Es nulo alu?
            Assert.IsNotNull(alu);
            // Es nulo cada atributo?
            Assert.AreNotEqual(null, alu.Apellido);
            Assert.AreNotEqual(null, alu.DNI);
            Assert.AreNotEqual(null, alu.Nacionalidad);
            Assert.AreNotEqual(null, alu.Nombre);
            Assert.AreNotEqual(null, alu.ToString());
        }

        /// <summary>
        /// Valido que ninguno de los atributos de Instructor sea nulo.
        /// </summary>
        [TestMethod]
        public void Instructor_NoNulo()
        {
            Instructor ins = new Instructor(25, "Agustin", "Prado", "37143078", Persona.ENacionalidad.Argentino);
            // Es nulo ins?
            Assert.IsNotNull(ins);
            // Es nulo cada atributo?
            Assert.AreNotEqual(null, ins.Apellido);
            Assert.AreNotEqual(null, ins.DNI);
            Assert.AreNotEqual(null, ins.Nacionalidad);
            Assert.AreNotEqual(null, ins.Nombre);
            Assert.AreNotEqual(null, ins.ToString());
        }

        /// <summary>
        /// Valido que ninguno de los atributos de Jornada sea nulo.
        /// </summary>
        [TestMethod]
        public void Jornada_NoNulo()
        {
            Instructor ins = new Instructor(25, "Agustin", "Prado", "37143078", Persona.ENacionalidad.Argentino);
            Jornada jor = new Jornada(Gimnasio.EClases.Natacion, ins);
            // Es nulo jor?
            Assert.IsNotNull(jor);
            // Es nulo cada atributo?
            Assert.AreNotEqual(null, jor.ToString());
        }

        /// <summary>
        /// Valido que ninguno de los atributos de Gimnasio sea nulo.
        /// </summary>
        [TestMethod]
        public void Gimnasio_NoNulo()
        {
            Gimnasio gim = new Gimnasio();
            // Es nulo gim?
            Assert.IsNotNull(gim);
            // Es nulo cada atributo?
            Assert.AreNotEqual(null, gim.ToString());
            Assert.AreNotEqual(null, gim.Alumnos);
            Assert.AreNotEqual(null, gim.Instructores);
        }

        /// <summary>
        /// Valido que se lance la excepción AlumnoRepetidoException cuando se repiten alumnos.
        /// </summary>
        [TestMethod]
        public void Alumno_Repetido()
        {
            // Repetido por DNI
            try
            {
                Gimnasio gim = new Gimnasio();
                Alumno alu1 = new Alumno(65, "Agustin", "Prado", "37143078", Persona.ENacionalidad.Argentino, Gimnasio.EClases.Natacion, Alumno.EEstadoCuenta.AlDia);
                Alumno alu2 = new Alumno(66, "Santiago", "Prado", "37143078", Persona.ENacionalidad.Argentino, Gimnasio.EClases.CrossFit, Alumno.EEstadoCuenta.AlDia);
                
                gim += alu1;
                gim += alu2;

                Assert.Fail("Sin excepción para alumno repetido.");
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }

            // Repetido por ID
            try
            {
                Gimnasio gim = new Gimnasio();
                Alumno alu1 = new Alumno(65, "Agustin", "Prado", "37143078", Persona.ENacionalidad.Argentino, Gimnasio.EClases.Natacion, Alumno.EEstadoCuenta.AlDia);
                Alumno alu2 = new Alumno(65, "Santiago", "Prado", "40000000", Persona.ENacionalidad.Argentino, Gimnasio.EClases.CrossFit, Alumno.EEstadoCuenta.AlDia);
                
                gim += alu1;
                gim += alu2;

                Assert.Fail("Sin excepción para alumno repetido.");
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }
        }

        /// <summary>
        /// Valido que se lance la excepción SinInstructorException cuando no hay instructor para una clase.
        /// </summary>
        [TestMethod]
        public void SinInstructor()
        {
            try
            {
                Gimnasio gim = new Gimnasio();
                
                Instructor ins1 = new Instructor(65, "Agustin", "Prado", "37143078", Persona.ENacionalidad.Argentino);
                
                gim += ins1;

                // Un instructor tiene 2 clases, así que en alguna debería fallar.
                gim += Gimnasio.EClases.CrossFit;
                gim += Gimnasio.EClases.Natacion;
                gim += Gimnasio.EClases.Pilates;
                gim += Gimnasio.EClases.Yoga;

                Assert.Fail("Sin excepción para la falta de instructores para una clase.");
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(SinInstructorException));
            }
        }
    }
}
