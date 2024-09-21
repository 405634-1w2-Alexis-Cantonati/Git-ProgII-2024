namespace Back.Models
{
    public class Article
    {
        public int IdArt { get; set; }
        public string Nombre { get; set; }
        public double PrecioUnitario { get; set; }

        public Article(int idArt, string nombre, int precioUnitario)
        {
            IdArt = idArt;
            Nombre = nombre;
            PrecioUnitario = precioUnitario;
        }
        public Article()
        {
            IdArt = 0;
            Nombre = "";
            PrecioUnitario = 0;
        }
    }
}
