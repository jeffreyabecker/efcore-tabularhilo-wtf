namespace ConsoleApp2;

public class Post
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }

    public long BlogId { get; set; }
    public Blog Blog { get; set; }


}