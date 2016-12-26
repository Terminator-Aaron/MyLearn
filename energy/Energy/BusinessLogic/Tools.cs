using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Tools
    {
        public static string NewGuid()
        {
            return Guid.NewGuid().ToString().Replace("-", "_");
        }
    }
}
