namespace ConsoleApp2;

public class Blog
{
    public int BlogId { get; set; }
    public string Url { get; set; }
    public DateTimeOffset CreatedAt { get; set; } =  DateTimeOffset.MinValue;
    public DateTimeOffset? UpdatedAt { get; set; } = DateTimeOffset.MinValue;

    public string CreatedBy { get; set;} = string.Empty;
    public string? UpdatedBy { get; set; } = string.Empty;


    public List<Post> Posts { get; } = new();
}
