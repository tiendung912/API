using System.Collections;
namespace dungDAL.Models
{
    public class Category
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
    }
}