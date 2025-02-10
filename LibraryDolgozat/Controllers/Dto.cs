namespace LibraryDolgozat.Controllers
{
    public record CreateBookDto(string Title, string Author, int PublishedYear, string Genre, decimal Price);
}
