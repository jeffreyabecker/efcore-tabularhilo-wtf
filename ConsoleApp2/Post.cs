namespace ConsoleApp2;

public class Post
{
    public int PostId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }

    public int BlogId { get; set; }
    public Blog Blog { get; set; }

    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? UpdatedAt { get; set; } = null;

    public string CreatedBy { get; set; } = string.Empty;
    public string? UpdatedBy { get; set; } = string.Empty;
}