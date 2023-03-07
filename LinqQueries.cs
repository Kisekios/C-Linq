public class LinqQueries
{
    private List<Book> librosCollection = new List<Book>();
    public LinqQueries()
    {
        using (StreamReader reader = new StreamReader("books.json"))
        {
            string json = reader.ReadToEnd();
            this.librosCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }

    public IEnumerable<Book> TodaLaColeccion()
    {
        return librosCollection;
    }

    public IEnumerable<Book> LibrosDespuesdel2000()
    {
        //Metodo extendido
        //return librosCollection.Where(p=> p.PublishedDate.Year > 2000);

        //query expression

        return from l in librosCollection where l.PublishedDate.Year > 2000 select l;
    }

    public IEnumerable<Book> LibroConMasDe250PaginasConPalabrasInAction()
    {
        //Extension methods
        //return librosCollection.Where(p => p.PageCount > 250 && p.Title.Contains("in Action"));

        //Query Expression
        return from l in librosCollection where l.PageCount > 250 && l.Title.Contains("in Action") select l;
    }

    public bool TodosLosLibrosTienenEstatus()
    {
        return librosCollection.All(p => p.Status != string.Empty);
    }
    public bool AlgunLibroFuePublicadoEn2005()
    {
        return librosCollection.Any(p => p.PublishedDate.Year == 2005);
    }

    public IEnumerable<Book> LibrosDePython()
    {
        return librosCollection.Where(p => p.Categories.Contains("Python"));
    }

    public IEnumerable<Book> LibrosDeJavaPorNombreAscendete()
    {
        return librosCollection.Where(p => p.Categories.Contains("Java")).OrderBy(p => p.Title);
    }

    public IEnumerable<Book> LibrosConMasDe450Paginas()
    {
        return librosCollection.Where(p => p.PageCount > 450).OrderByDescending(p => p.PageCount);
    }

    public IEnumerable<Book> TresPrimerosLibrosOrdenadosPorFecha()
    {
        return librosCollection.Where(p => p.Categories.Contains("Java")).OrderBy(p => p.PublishedDate).TakeLast(3);
    }

    public IEnumerable<Book> TercerYCuartoLibrodeMasDe400Paginas()
    {
        return librosCollection.Where(p => p.PageCount > 400).Take(4).Skip(2);
    }

    public IEnumerable<Book> TresPrimerosLibrosDelaColeccion()
    {
        return librosCollection.Take(3).Select(p => new Book() { Title = p.Title, PageCount = p.PageCount, });
    }

    public int CantidadDeLibrosEntre200Y500Paginas()
    {
        return librosCollection.Count(p => p.PageCount >= 200 && p.PageCount <= 500);
    }

    public DateTime FechaDePublicacionMenor()
    {
        return librosCollection.Min(p => p.PublishedDate);
    }

    public int ElLibroConMasPaginas()
    {
        return librosCollection.Max(p => p.PageCount);
    }

    public Book? LibroConMenorNumeroDePaginas()
    {
        return librosCollection.Where(p => p.PageCount > 0).MinBy(p => p.PageCount);
    }

    public Book? LibroConLaFechaDePublicacionMasReciente()
    {
        return librosCollection.MaxBy(p => p.PublishedDate);
    }

    public int SumaDeTodasLasPaginasLibrosEntre0Y500()
    {
        return librosCollection.Where(p => p.PageCount >= 0 && p.PageCount <= 500).Sum(p => p.PageCount);
    }

    public string LibrosDespuesDel2015Concatenados()
    {
        return librosCollection.Where(p => p.PublishedDate.Year > 2015).Aggregate("", (TitulosLibros, next) =>
        {
            if (TitulosLibros != String.Empty)
            {
                TitulosLibros += " - " + next.Title;
            }
            else
            {
                TitulosLibros += next.Title;
            }

            return TitulosLibros;
        });
    }
    public double PromedioCaracteresTitulos()
    {
        return librosCollection.Average(p => p.Title.Length);
    }

    public IEnumerable<IGrouping<int, Book>> LibrosDespuesDel2000AgrupadosPorYear()
    {
        return librosCollection.Where(p => p.PublishedDate.Year >= 2000).GroupBy(p => p.PublishedDate.Year);
    }

    public ILookup<char, Book> DiccionarioDeLibrosPorLetra()
    {
        return librosCollection.ToLookup(p=> p.Title[0], p=> p);
    }

    public IEnumerable<Book> LibrosDespuesDel2005ConMasDe500Paginas ()
    {
        var LibrosDespuesDel2005 = librosCollection.Where(p=> p.PublishedDate.Year > 2005);
        var LibrosConMasDe500Paginas = librosCollection.Where(p=> p.PageCount > 500);
        return LibrosDespuesDel2005.Join(LibrosConMasDe500Paginas, p=> p.Title, x=> x.Title, (p,x) => p);
    }
}