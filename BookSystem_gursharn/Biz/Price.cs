using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSystem_gursharn.Biz
{
    public class Price
    {
        public int ID { get; set; }
        public string Rate { get; set; }
        public List<Book> Books { get; set; }
    }
}
