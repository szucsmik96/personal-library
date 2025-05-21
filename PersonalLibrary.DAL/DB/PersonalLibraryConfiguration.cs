using Microsoft.EntityFrameworkCore;

namespace PersonalLibrary.DAL.DB;

public class PersonalLibraryConfiguration
{
    private readonly ModelBuilder modelBuilder;

    public PersonalLibraryConfiguration(ModelBuilder modelBuilder)
    {
        this.modelBuilder = modelBuilder;
    }

    public void Seed()
    {
    }
}
