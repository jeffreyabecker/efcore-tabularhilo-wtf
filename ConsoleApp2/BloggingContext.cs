using ConsoleApp2.HiLo;
using Microsoft.EntityFrameworkCore;


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
            .UseSqlite($"Data Source=c:\\temp\\blogging.db")
            //.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=blogging;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=True")
            .UseTabularHiLo()
            ;
        
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

    }
}
