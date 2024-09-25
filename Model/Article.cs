using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Article
    {
        public int Id { get; set; }
        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Brand Brand { get; set; }
        public Category Category { get; set; }

        public List<Image> UrlImages { get; set; }

        public decimal Price { get; set; }
    }
}
