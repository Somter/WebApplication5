using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }
    }
}
