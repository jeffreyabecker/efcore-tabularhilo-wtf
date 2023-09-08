using ConsoleApp2.Audits;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;


namespace ConsoleApp2;


public class BloggingContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }




    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options
            .EnableSensitiveDataLogging()
            .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=test-db;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=True")
            ;
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Blog>().Property(b => b.CreatedBy)
            .HasValueGenerator<TestValueGenerator>() 
            .ValueGeneratedOnAddOrUpdate();

        //modelBuilder.Entity<Blog>().HasAuditProperties();
        //modelBuilder.Entity<Post>().HasAuditProperties();   

    }
}
public class TestValueGenerator : ValueGenerator<string>
{
    public TestValueGenerator() : base() 
    { 
        Console.WriteLine($"constructed {nameof(TestValueGenerator)}");
    }
    public override bool GeneratesTemporaryValues
    {
        get
        {
            return false;
        }
    }

    public override string Next(EntityEntry entry)
    {
        return "Example";
    }
}

public class ExampleCurrentUserAccessor : ICurrentUserValueAccessor<string>
{
    public ExampleCurrentUserAccessor() {
        Console.WriteLine("Constructed");
    }
    public string GetUserValue() => "Example";
}
