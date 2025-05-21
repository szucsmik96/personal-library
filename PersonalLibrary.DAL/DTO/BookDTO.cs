using PersonalLibrary.DAL.DB.Objects;
using System.Linq.Expressions;

namespace PersonalLibrary.DAL.DTO
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;

        public static Expression<Func<Book, BookDTO>> DbEntityToDto =>
            x => new BookDTO
            {
                Id = x.Id,
                Title = x.Title,
                Author = x.Author,
                Genre = x.Genre
            };

        public void UpdateDbEntity(Book sqlType)
        {
            sqlType.Title = Title;
            sqlType.Author = Author;
            sqlType.Genre = Genre;
        }
    }
}
