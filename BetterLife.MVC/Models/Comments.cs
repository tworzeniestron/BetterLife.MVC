namespace BetterLife.MVC.Models
{
    public class Comments
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public List<string> Comment { get; set; } = new List<string>();
    }
}
