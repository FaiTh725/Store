using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("nvarchar(20)")]
        public string Name { get; set; }

        [Column("nvarchar(100)")]
        public string? Description { get; set; }

        [Column("nvarchar(20)")]
        public string? ShortDescription { get; set; }

        public double Price { get; set; }

        public int AvatarId { get; set; }

        public Avatar? Avatar { get; set; }
    }
}
