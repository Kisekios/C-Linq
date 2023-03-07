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
//ImprimirValores(queries.TercerYCuartoLibrodeMasDe400Paginas());

//Tres primeros libros filtrados con select
//ImprimirValores(queries.TresPrimerosLibrosDelaColeccion());

//Cantidad de libros que tienen entre 200 y 500 paginas
//WriteLine($"Cantidad de libros entre 200 y 500 paginas: {queries.CantidadDeLibrosEntre200Y500Paginas()}");

//FechaDe publicacion menor de todos los libros
//WriteLine($"Fecha de publicacion menor: {queries.FechaDePublicacionMenor()}");

//El libro con mas paginas
//WriteLine(queries.ElLibroConMasPaginas());

//Libro con menor numero de paginas
//Write($"Libro con menor numero de paginas {queries.LibroConMenorNumeroDePaginas()?.Title} - {queries.LibroConMenorNumeroDePaginas()?.PageCount}");

//Libro con fecha de publicacion mas reciente
//Write($"Libro con fecha de publicacion mas reciente: {queries.LibroConLaFechaDePublicacionMasReciente()?.Title} - {queries.LibroConLaFechaDePublicacionMasReciente()?.PublishedDate.ToShortDateString()}");

//Suma de paginas de libros con mas de 0 paginas hasta 500
//WriteLine($"Suma total de las paginas de los libros entre 0 a 500 paginas: {queries.SumaDeTodasLasPaginasLibrosEntre0Y500()}");

//Lirbos publicados despues del 2015
//WriteLine(queries.LibrosDespuesDel2015Concatenados());

//Promedio de caracteres del titulo de los libros
//WriteLine($"Promedio de caracteres de los titulos de los libros: {queries.PromedioCaracteresTitulos()}");

//Libros publicados despues del año 2000 agrupados por año
//ImprimirGrupo(queries.LibrosDespuesDel2000AgrupadosPorYear());

//Diccionario de libros agrupados por primera letra del titulo
//ImprimirDiccionario(queries.DiccionarioDeLibrosPorLetra(), 'S');

//Libros filtrados con la clausula Join
ImprimirValores(queries.LibrosDespuesDel2005ConMasDe500Paginas());

void ImprimirValores(IEnumerable<Book> listaDeLibros)
{
    WriteLine("{0,-60} {1,15} {2,15}\n", "Titulo", "N. Paginas", "Fecha de publicacion");
    foreach (var item in listaDeLibros)
    {
        WriteLine("{0,-60} {1,15} {2,15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }

}

void ImprimirGrupo(IEnumerable<IGrouping<int, Book>> listaDeLibros)
{
    foreach (var grupo in listaDeLibros)
    {
        WriteLine("");
        WriteLine($"Grupo: {grupo.Key}");
        WriteLine("{0,-60} {1,15} {2,15}\n", "Titulo", "N.Pagina", "Fecha de Publicacion");
        foreach (var item in grupo)
        {
            WriteLine("{0,-60} {1,15} {2,15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
        }
    }
}

void ImprimirDiccionario(ILookup<char, Book> ListadeLibros, char letra)
{
    WriteLine("{0,-60} {1,15} {2,15}\n", "Titulo", "N.Pagina", "Fecha de Publicacion");
    foreach (var item in ListadeLibros[letra])
    {
        WriteLine("{0,-60} {1,15} {2,15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}
