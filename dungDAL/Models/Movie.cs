using System;
namespace dungDAL.Models
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Rate { get; set; }
    }
}