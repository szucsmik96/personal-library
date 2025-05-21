
using PersonalLibrary.DAL.DTO;

namespace PersonalLibrary.DAL.Interfaces
{
    public interface IAppSettings
    {
        string ConnectionString { get; }
    }

    public interface IBookDAL
    {
        Task<int> CreateAsync(BookDTO bookDTO);
        Task<bool> UpdateAsync(BookDTO bookDTO);
        Task<bool> DeleteAsync(int id);
        Task<List<BookDTO>> GetAllAsync();
        Task<BookDTO?> GetByIdAsync(int id);
    }
}
