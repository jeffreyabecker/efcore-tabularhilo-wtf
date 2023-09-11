using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ConsoleApp2.HiLo;
namespace ConsoleApp2.ModelConfig;
public class BlogConfiguration : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseTabularHiLo();
        builder.Property(x => x.Url).IsRequired().HasMaxLength(2048);
        builder.HasMany(x => x.Posts).WithOne(x => x.Blog).HasForeignKey(x => x.BlogId);

    }
}
public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseTabularHiLo();
    }
}