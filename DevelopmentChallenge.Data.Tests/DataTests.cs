using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [Test]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>", Reporte.Imprimir(new List<IFormaGeometrica>(), Idioma.Castellano));
        }

        [Test]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>", Reporte.Imprimir(new List<IFormaGeometrica>(), Idioma.Ingles));
        }

        [Test]
        public void TestResumenListaConUnCuadradoEnCastellano()
        {
            var cuadrados = new List<IFormaGeometrica> { new Cuadrado(5) };
            var resumen = Reporte.Imprimir(cuadrados, Idioma.Castellano);
            Assert.AreEqual("<h1>Reporte de Formas</h1>Cuadrado: 1 | Perímetro 20,00 | Área 25,00 <br/>TOTAL:<br/>1 formas | Perímetro 20,00 | Área 25,00", resumen);
        }

        [Test]
        public void TestResumenListaConMasCuadradosEnIngles()
        {
            var cuadrados = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Cuadrado(1),
                new Cuadrado(3)
            };
            var resumen = Reporte.Imprimir(cuadrados, Idioma.Ingles);
            Assert.AreEqual("<h1>Shapes report</h1>Square: 3 | Perimeter 36,00 | Area 35,00 <br/>TOTAL:<br/>3 shapes | Perimeter 36,00 | Area 35,00", resumen);
        }

        [Test]
        public void TestResumenListaConMasTiposEnIngles()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m),
                new Trapecio(4, 6, 5, 5, 3)
            };
            var resumen = Reporte.Imprimir(formas, Idioma.Ingles);
            Assert.AreEqual("<h1>Shapes report</h1>Square: 2 | Perimeter 28,00 | Area 29,00 <br/>Circle: 2 | Perimeter 18,06 | Area 13,01 <br/>Triangle: 3 | Perimeter 51,60 | Area 49,64 <br/>Trapezoid: 1 | Perimeter 20,00 | Area 15,00 <br/>TOTAL:<br/>8 shapes | Perimeter 117,66 | Area 106,65", resumen);
        }

        [Test]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m),
                new Trapecio(4, 6, 5, 5, 3)
            };
            var resumen = Reporte.Imprimir(formas, Idioma.Castellano);
            Assert.AreEqual("<h1>Reporte de Formas</h1>Cuadrado: 2 | Perímetro 28,00 | Área 29,00 <br/>Círculo: 2 | Perímetro 18,06 | Área 13,01 <br/>Triángulo: 3 | Perímetro 51,60 | Área 49,64 <br/>Trapecio: 1 | Perímetro 20,00 | Área 15,00 <br/>TOTAL:<br/>8 formas | Perímetro 117,66 | Área 106,65", resumen);
        }

        [Test]
        public void TestResumenListaConTrapecioEnItaliano()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Trapecio(4, 6, 5, 5, 3)
            };
            var resumen = Reporte.Imprimir(formas, Idioma.Italiano);
            Assert.AreEqual("<h1>Rapporto sulle forme</h1>Trapezio: 1 | Perimetro 20,00 | Area 15,00 <br/>TOTAL:<br/>1 forme | Perimetro 20,00 | Area 15,00", resumen);
        }

        [Test]
        public void TestCuadradoNegativo()
        {
            Assert.Throws<ArgumentException>(() => new Cuadrado(-5));
        }

        [Test]
        public void TestCirculoNegativo()
        {
            Assert.Throws<ArgumentException>(() => new Circulo(-3));
        }

        [Test]
        public void TestTrianguloNegativo()
        {
            Assert.Throws<ArgumentException>(() => new TrianguloEquilatero(-4));
        }

        [Test]
        public void TestTrapecioConLadoNegativo()
        {
            Assert.Throws<ArgumentException>(() => new Trapecio(-4, 6, 5, 5, 3));
        }

        [Test]
        public void TestTrapecioConAlturaNegativa()
        {
            Assert.Throws<ArgumentException>(() => new Trapecio(4, 6, 5, 5, -3));
        }
    }
}
