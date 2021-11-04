using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace lom
{
  
    public  class p15
    {
        public string 問題 { get; set; }
        public string 種類 { get; set; }

         public HyperLink hyperLink { get; set; }

         List<p15> p15s = new List<p15>();

        public  List<p15> getp15_data()
        {
            
           
            
           
            return p15s;

         }
        public void setp15_data(string myname, string mytype)
        {

            問題 = myname;
            種類 = mytype;
            p15s.Add(new p15 { 問題 = myname, 種類 = mytype });
        }
    }
    //getp15_data
}
