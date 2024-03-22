﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model
{
    public class ImageFile
    {
        [Key]
        public int Id { get; set; }

        public string FileName {  get; set; }   
    
        public byte[] ImageData { get; set; }
    }
}
