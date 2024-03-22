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

        public string Name { get; set; }

        public string? Description { get; set; }

        public string? ShortDescription { get; set; }

        public double Price { get; set; }

        public int ImageFileId { get; set; }

        [ForeignKey("ImageFileId")]
        public ImageFile ImageFile { get; set; }    
    }
}
