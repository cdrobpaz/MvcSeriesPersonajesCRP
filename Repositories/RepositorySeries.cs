using MvcSeriesPersonajesCRP.Data;
using MvcSeriesPersonajesCRP.Models;

namespace MvcSeriesPersonajesCRP.Repositories
{
    public class RepositorySeries
    {
        private SeriesContext context;
        public RepositorySeries(SeriesContext context) 
        { 
            this.context = context;
        }
        public List<Serie> GetSeries()
        {
            var consulta = from datos in this.context.Series
                           select datos;
            return consulta.ToList();
        }
        public Serie GetSerie(int idserie)
        {
            var consulta = from datos in this.context.Series
                           where datos.IdSerie == idserie
                           select datos;
            return consulta.FirstOrDefault();
        }
        public List<Personaje> GetPersonajes(int idserie)
        {
            var consulta = from datos in this.context.Personajes
                           where datos.IdSerie == idserie
                           select datos;
            return consulta.ToList();
        }
        public void AddSeries(int IdSerie, string nombre, string imagen, int anyo)
        {
            Serie s = new Serie();
            s.IdSerie = IdSerie;
            s.Nombre = nombre;
            s.Imagen = imagen;
            s.Anyo = anyo;
            this.context.Series.Add(s);
            this.context.SaveChanges();
        }
    }
}
