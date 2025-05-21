using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PersonalLibrary.DAL.DB.Objects;
using PersonalLibrary.DAL.Interfaces;
using Z.EntityFramework.Plus;

namespace PersonalLibrary.DAL.DB;

public class PersonalLibraryContext : DbContext
{
    // Add-Migration -OutputDir "./DB/Migrations" Init
    // Add-Migration Init
    // Update-Database

    public IAppSettings AppSettings { get; set; }

    public PersonalLibraryContext(IAppSettings appSettings, DbContextOptions<PersonalLibraryContext> options)
        : base(options)
    {
        AppSettings = appSettings;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        SetTables(modelBuilder);
        SetUniqueKeys(modelBuilder);
        SetIndexes(modelBuilder);
        SetComputedColumns(modelBuilder);
        SetDefaultDeleteBehavior(modelBuilder, DeleteBehavior.NoAction);

        new PersonalLibraryConfiguration(modelBuilder).Seed();
    }

    private void SetTables(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>();
    }

    private static void SetUniqueKeys(ModelBuilder modelBuilder)
    {
    }

    private static void SetIndexes(ModelBuilder modelBuilder)
    {
    }

    private static void SetComputedColumns(ModelBuilder modelBuilder)
    {
    }

    public static void SetDefaultDeleteBehavior(ModelBuilder modelBuilder, DeleteBehavior deleteBehavior)
    {
        // Forrás: https://www.red-gate.com/simple-talk/blogs/change-delete-behavior-and-more-on-ef-core/

        foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
        {
            entityType.GetForeignKeys()
                .Where(fk => fk.IsOwnership == false && fk.DeleteBehavior == DeleteBehavior.Cascade)
                .ToList()
                .ForEach(fk => fk.DeleteBehavior = deleteBehavior);
        }
    }
}
