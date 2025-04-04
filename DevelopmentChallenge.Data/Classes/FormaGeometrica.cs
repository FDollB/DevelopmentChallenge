/******************************************************************************************************************/
/******* ¿Qué pasa si debemos soportar un nuevo idioma para los reportes, o agregar más formas geométricas? *******/
/******************************************************************************************************************/

/*
 * TODO: 
 * Refactorizar la clase para respetar principios de la programación orientada a objetos.
 * Implementar la forma Trapecio/Rectangulo. 
 * Agregar el idioma Italiano (o el deseado) al reporte.
 * Se agradece la inclusión de nuevos tests unitarios para validar el comportamiento de la nueva funcionalidad agregada (los tests deben pasar correctamente al entregar la solución, incluso los actuales.)
 * Una vez finalizado, hay que subir el código a un repo GIT y ofrecernos la URL para que podamos utilizar la nueva versión :).
 */

using DevelopmentChallenge.Data.Interfaces;
using System;

namespace DevelopmentChallenge.Data.Classes
{
    public abstract class FormaGeometrica : IFormaGeometrica
    {
        public abstract decimal CalcularArea();
        public abstract decimal CalcularPerimetro();
        public abstract string ObtenerNombre(Idioma idioma);
    }

    public class Cuadrado : FormaGeometrica
    {
        private readonly decimal _lado;

        public Cuadrado(decimal lado)
        {
            if (lado <= 0)
                throw new ArgumentException("El lado del cuadrado debe ser mayor a cero.");

            _lado = lado;
        }

        public override decimal CalcularArea()
        {
            return _lado * _lado;
        }

        public override decimal CalcularPerimetro()
        {
            return _lado * 4;
        }

        public override string ObtenerNombre(Idioma idioma)
        {
            return Traductor.Traducir(Terminos.Cuadrado, idioma);
        }
    }

    public class Circulo : FormaGeometrica
    {
        private readonly decimal _diametro;

        public Circulo(decimal diametro)
        {
            if (diametro <= 0)
                throw new ArgumentException("El diámetro del círculo debe ser mayor a cero.");

            _diametro = diametro;
        }

        public override decimal CalcularArea()
        {
            return (decimal)Math.PI * (_diametro / 2) * (_diametro / 2);
        }

        public override decimal CalcularPerimetro()
        {
            return (decimal)Math.PI * _diametro;
        }

        public override string ObtenerNombre(Idioma idioma)
        {
            return Traductor.Traducir(Terminos.Circulo, idioma);
        }
    }

    public class TrianguloEquilatero : FormaGeometrica
    {
        private readonly decimal _lado;

        public TrianguloEquilatero(decimal lado)
        {
            if (lado <= 0)
                throw new ArgumentException("El lado del triángulo debe ser mayor a cero.");

            _lado = lado;
        }

        public override decimal CalcularArea()
        {
            return (decimal)(Math.Sqrt(3) / 4) * _lado * _lado;
        }

        public override decimal CalcularPerimetro()
        {
            return _lado * 3;
        }

        public override string ObtenerNombre(Idioma idioma)
        {
            return Traductor.Traducir(Terminos.Triangulo, idioma);
        }
    }

    public class Trapecio : FormaGeometrica
    {
        private readonly decimal _baseMayor;
        private readonly decimal _baseMenor;
        private readonly decimal _lado1;
        private readonly decimal _lado2;
        private readonly decimal _altura;

        public Trapecio(decimal baseMayor, decimal baseMenor, decimal lado1, decimal lado2, decimal altura)
        {
            if (baseMayor <= 0 || baseMenor <= 0 || lado1 <= 0 || lado2 <= 0 || altura <= 0)
                throw new ArgumentException("Todos los lados y la altura del trapecio deben ser mayores a cero.");

            _baseMayor = baseMayor;
            _baseMenor = baseMenor;
            _lado1 = lado1;
            _lado2 = lado2;
            _altura = altura;
        }

        public override decimal CalcularArea()
        {
            return ((_baseMayor + _baseMenor) * _altura) / 2;
        }

        public override decimal CalcularPerimetro()
        {
            return _baseMayor + _baseMenor + _lado1 + _lado2;
        }

        public override string ObtenerNombre(Idioma idioma)
        {
            return Traductor.Traducir(Terminos.Trapecio, idioma);
        }
    }
}
