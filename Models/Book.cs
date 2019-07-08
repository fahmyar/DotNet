using System.ComponentModel.DataAnnotations;

namespace BookStoreMySQL.Models
{
    public class Book
    {
        [Key]
        public int Id {get; set;}
        public string BookName {get; set;}
        public string Author {get; set;}
        public decimal Price {get; set;}
        public string Category {get; set;}
    }
}