namespace Play.cleanarch.Domain;

public record Book(int Id, string Title, int AuthorId, int Year)
{
    public Author? Author {get; init;}
}
