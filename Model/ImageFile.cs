using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Store.Model
{
    public class ImageFile
    {
        [Key]
        public int Id { get; set; }

        public string FileName {  get; set; }   
    
        public byte[] ImageData { get; set; }

        [NotMapped]
        public ImageSource Img 
        {
            get
            {
                MemoryStream memoryStream = new();
                memoryStream.Write(ImageData, 0, (int)ImageData.Length);

                BitmapImage imgSource = new();
                imgSource.BeginInit();
                imgSource.StreamSource = memoryStream;
                imgSource.EndInit();
                return imgSource;
            }
        }
    }
}
