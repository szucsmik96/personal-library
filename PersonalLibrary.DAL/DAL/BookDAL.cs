using Microsoft.EntityFrameworkCore;
using PersonalLibrary.DAL.DB;
using PersonalLibrary.DAL.DB.Objects;
using PersonalLibrary.DAL.DTO;
using PersonalLibrary.DAL.Interfaces;

namespace PersonalLibrary.DAL.DAL
{
    public class BookDAL: IBookDAL
    {
        private readonly PersonalLibraryContext _context;
        public BookDAL(PersonalLibraryContext context)
        {
            _context = context;
        }

        public async Task<List<BookDTO>> GetAllAsync()
        {
            return await _context.Set<Book>()
                .Select(BookDTO.DbEntityToDto)
                .ToListAsync();
        }

        public async Task<BookDTO?> GetByIdAsync(int id)
        {
            return await _context.Set<Book>()
                .Where(b => b.Id == id)
                .Select(BookDTO.DbEntityToDto)
                .FirstOrDefaultAsync();
        }

        public async Task<int> CreateAsync(BookDTO bookDTO)
        {
            var book = new Book();
            bookDTO.UpdateDbEntity(book);

            _context.Set<Book>().Add(book);
            await _context.SaveChangesAsync();
            return book.Id;
        }

        public async Task<bool> UpdateAsync(BookDTO bookDTO)
        {
            var book = await _context.Set<Book>().FindAsync(bookDTO.Id);
            if (book == null) return false;

            bookDTO.UpdateDbEntity(book);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var book = await _context.Set<Book>().FindAsync(id);
            if (book == null) return false;

            _context.Set<Book>().Remove(book);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
