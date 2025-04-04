using System.Collections.Generic;

namespace DevelopmentChallenge.Data.Classes
{
    public enum Idioma
    {
        Castellano = 1,
        Ingles = 2,
        Italiano = 3
    }

    public static class Terminos
    {
        public const string Titulo = "Reporte de Formas";
        public const string Formas = "formas";
        public const string Vacio = "Lista vacía de formas!";
        public const string Cuadrado = "Cuadrado";
        public const string Circulo = "Círculo";
        public const string Triangulo = "Triángulo";
        public const string Trapecio = "Trapecio";
        public const string Perimetro = "Perimetro";
        public const string Area = "Area";
    }

    public static class Traductor
    {
        private static readonly Dictionary<Idioma, Dictionary<string, string>> Traducciones = new Dictionary<Idioma, Dictionary<string, string>>
        {
            [Idioma.Castellano] = new Dictionary<string, string>
            {
                [Terminos.Titulo] = "Reporte de Formas",
                [Terminos.Formas] = "formas",
                [Terminos.Vacio] = "Lista vacía de formas!",
                [Terminos.Cuadrado] = "Cuadrado",
                [Terminos.Circulo] = "Círculo",
                [Terminos.Triangulo] = "Triángulo",
                [Terminos.Trapecio] = "Trapecio",
                [Terminos.Perimetro] = "Perímetro",
                [Terminos.Area] = "Área"
            },
            [Idioma.Ingles] = new Dictionary<string, string>
            {
                [Terminos.Titulo] = "Shapes report",
                [Terminos.Formas] = "shapes",
                [Terminos.Vacio] = "Empty list of shapes!",
                [Terminos.Cuadrado] = "Square",
                [Terminos.Circulo] = "Circle",
                [Terminos.Triangulo] = "Triangle",
                [Terminos.Trapecio] = "Trapezoid",
                [Terminos.Perimetro] = "Perimeter",
                [Terminos.Area] = "Area"
            },
            [Idioma.Italiano] = new Dictionary<string, string>
            {
                [Terminos.Titulo] = "Rapporto sulle forme",
                [Terminos.Formas] = "forme",
                [Terminos.Vacio] = "Elenco vuoto di forme!",
                [Terminos.Cuadrado] = "Quadrato",
                [Terminos.Circulo] = "Cerchio",
                [Terminos.Triangulo] = "Triangolo",
                [Terminos.Trapecio] = "Trapezio",
                [Terminos.Perimetro] = "Perimetro",
                [Terminos.Area] = "Area"
            }
        };

        public static string Traducir(string forma, Idioma idioma)
        {
            return Traducciones[idioma][forma];
        }
    }
}
