namespace GraphQL.Helper
{
    public class Book
    {
        string Title { get; set; }
        string Author { get; set; }

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }
    }
}
