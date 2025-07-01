using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP_Project
{
    public class productclass
    {

        
            public int ID { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int CategoryID { get; set; }
        public int Quantity { get; set; }  = 1;
            public string Price { get; set; }
            public string ImagePath { get; set; }
        
    }
}
