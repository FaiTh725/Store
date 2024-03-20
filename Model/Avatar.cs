using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model
{
    public class Avatar
    {
        public int Id { get; set; }

        public string? PathAvatar {  get; set; }
    }
}
