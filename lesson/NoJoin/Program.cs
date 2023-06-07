List<Author> authors = new List<Author>();

authors.Add(new Author(1, 18));
authors.Add(new Author(2, 28));
authors.Add(new Author(3, 38));
authors.Add(new Author(4, 48));
authors.Add(new Author(5, 58));

List<Book> books = new List<Book>();
books.Add(new Book(1, 1));
books.Add(new Book(2, 2));
books.Add(new Book(3, 1));
books.Add(new Book(4, 3));
books.Add(new Book(5, 2));
books.Add(new Book(6, 4));
books.Add(new Book(7, 5));
books.Add(new Book(8, 1));
books.Add(new Book(9, 2));
books.Add(new Book(10, 5));
books.Add(new Book(11, 2));
books.Add(new Book(12, 3));
books.Add(new Book(13, 4));

var authorsAndBooks = authors.Select(a => new { author = a, books = books.Where(b => b.authorId == a.id) }).SelectMany(a => a.books, (a,b) => new {age = a.author.age, id = b.authorId, bookId = b.id}) ;

var authorsAndBooksSQLLike = from a in (from a in authors
                                        select new
                                        {
                                            authors = a,
                                            books =
                                        (from b in books
                                         where b.authorId == a.id
                                         select b)
                                        })
                             from b in a.books
                             select new { age = a.authors.age, id = b.authorId, bookId = b.id };
var authorsAndBooksWithJoin = authors.Join(books, a => a.id, b => b.authorId, (a, b) => new { age = a.age, id = b.authorId, bookId = b.id });
foreach (var author in authorsAndBooks) 
{
    Console.WriteLine(author.ToString());
}
foreach (var author in authorsAndBooksWithJoin)
{
    Console.WriteLine(author.ToString());
}
foreach (var author in authorsAndBooksSQLLike)
{
    Console.WriteLine(author.ToString());
}
record class Author(int id,int age);
record class Book(int id, int authorId);

