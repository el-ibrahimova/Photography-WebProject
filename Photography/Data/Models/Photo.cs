using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Photography.Data.Models
{
    [Comment("Photo information")]
    public class Photo
    {
        [Key]
        [Comment("Photo identifier")]
        public int Id { get; set; } 
    }
}
