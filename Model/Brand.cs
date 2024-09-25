using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Brand
    {
        public int Id { get; set; }
        [DisplayName("Brand")]
        public string Description { get; set; }

        public override string ToString()
        {
            return Description;
        }

    }

}
