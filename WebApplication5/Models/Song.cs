using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FilePath { get; set; }
        public int GenreId { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public Genre? Genre { get; set; }
    }
}
