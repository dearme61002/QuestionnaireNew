using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lom
{
  
    public class p15
    {
        public string name { get; set; }
        public string type { get; set; }

         List<p15> p15s = new List<p15>();

        public List<p15> getp15_data()
        {
            
           
            
           
            return p15s;

         }
        public void setp15_data(string myname, string mytype)
        {
          
            name = myname;
            type = mytype;
            p15s.Add(new p15 { name = name, type = type });
        }
    }
    //getp15_data
}
