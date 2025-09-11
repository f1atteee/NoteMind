using System.ComponentModel.DataAnnotations;

namespace NoteMind.DAL.Models
{
    public abstract class Model
    {
        [Key]
        public long Id { get; set; }
    }
}