using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Voucher
    {
        public string Code { get; set; }
        public int IDClient { get; set; }
        public DateTime DateExchange { get; set; }
        public int IDArticle { get; set; }
    }
}
