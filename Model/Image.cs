using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Image
    {
        public int Id { get; set; }
        public int IdArticle { get; set; }
        public string UrlImage { get; set; }
        public override string ToString()
        {
            return UrlImage;
        }
    }
}
