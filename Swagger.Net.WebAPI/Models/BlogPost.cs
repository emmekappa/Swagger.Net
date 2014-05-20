namespace Swagger.Net.WebApi.Models
{
    public class BlogPost
    {
        public string Title { get; set; } 
        public Author Author { get; set; }
        public string Body { get; set; }
        public int Id { get; set; }
    }
}