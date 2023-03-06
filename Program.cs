using static System.Console;

LinqQueries queries = new LinqQueries();


//Toda la coleccion
//ImprimirValores(queries.TodaLaColeccion());

//Libros despues del 2000
//ImprimirValores(queries.LibrosDespuesdel2000());

//Libros que tienen mas de 250 paginas y tienen la palabra in action
//ImprimirValores(queries.LibroConMasDe250PaginasConPalabrasInAction());

//Todos los libros tienen estatus
//WriteLine($"]Todos los libros tienen estatus: {queries.TodosLosLibrosTienenEstatus()}");

//Si algun libro fue publicado en 2005
//WriteLine($"Algun libro fue publicado en 2005: {queries.AlgunLibroFuePublicadoEn2005()}");

//Lirbos que son de Python
//ImprimirValores(queries.LibrosDePython());

//Libros de Java por nombre ascendente
//ImprimirValores(queries.LibrosDeJavaPorNombreAscendete());

//Libros que tienen mas de 450 paginas ordenados por cantidad de paginas
//ImprimirValores(queries.LibrosConMasDe450Paginas());

//Los tres libros de java mas publicados recientemente
//ImprimirValores(queries.TresPrimerosLibrosOrdenadosPorFecha());

//Tercer y cuarto libro con mas de 400 paginas
ImprimirValores(queries.TercerYCuartoLibrodeMasDe400Paginas());

void ImprimirValores(IEnumerable<Book> listaDeLibros)
{
    WriteLine("{0,-60} {1,15} {2,15}\n", "Titulo", "N. Paginas", "Fecha de publicacion");
    foreach (var item in listaDeLibros)
    {
        WriteLine("{0,-60} {1,15} {2,15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}
