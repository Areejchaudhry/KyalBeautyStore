using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP_Project
{
    public class global
    {

        public static List<productclass> cartList = new List<productclass>();
        public static int LoggedInUserId { get; set; }
        public static string Name { get; set; }
        public static string Email { get; set; }
        public static string Phone { get; set; }
        public static string Address { get; set; }


    }
}
