using DevelopmentChallenge.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevelopmentChallenge.Data.Classes
{
    public static class Reporte
    {
        public static string Imprimir(List<IFormaGeometrica> formas, Idioma idioma)
        {
            if (!formas.Any())
            {
                return "<h1>" + Traductor.Traducir(Terminos.Vacio, idioma) + "</h1>";
            }

            var sb = new StringBuilder("<h1>" + Traductor.Traducir(Terminos.Titulo, idioma) + "</h1>");

            //Agrupo por forma y agrego los campos que voy a necesitar imprimir
            var resumen = formas.GroupBy(f => f.ObtenerNombre(idioma))
                .Select(g => new
                {
                    Nombre = g.Key,
                    Cantidad = g.Count(),
                    Area = g.Sum(f => f.CalcularArea()),
                    Perimetro = g.Sum(f => f.CalcularPerimetro())
                });

            foreach (var item in resumen)
            {
                sb.AppendFormat("{0}: {1} | {2} {3} | {4} {5} <br/>",
                    item.Nombre,
                    item.Cantidad,
                    Traductor.Traducir(Terminos.Perimetro, idioma),
                    item.Perimetro.ToString("0.00"),
                    Traductor.Traducir(Terminos.Area, idioma),
                    item.Area.ToString("0.00"));
            }

            sb.AppendFormat("TOTAL:<br/>{0} {1} | {2} {3} | {4} {5}",
                formas.Count,
                Traductor.Traducir(Terminos.Formas, idioma),
                Traductor.Traducir(Terminos.Perimetro, idioma),
                resumen.Sum(r => r.Perimetro).ToString("0.00"),
                Traductor.Traducir(Terminos.Area, idioma),
                resumen.Sum(r => r.Area).ToString("0.00"));

            return sb.ToString();
        }
    }
}
