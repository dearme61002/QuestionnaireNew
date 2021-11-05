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

        public string 回答 { get; set; }

        public Boolean 必須 { get; set; }

        public HyperLink hyperLink { get; set; }

         List<p15> p15s = new List<p15>();

        public  List<p15> getp15_data()
        {
            
           
            
           
            return p15s;

         }
        public void setp15_data(string myname, string mytype, string myanswer_D2,Boolean myD1_mustKeyin)
        {

            問題 = myname;
            種類 = mytype;
            回答 = myanswer_D2;
            必須 = myD1_mustKeyin;
            p15s.Add(new p15 { 問題 = myname, 種類 = mytype, 回答= myanswer_D2, 必須= myD1_mustKeyin });
        }

        public void deletep15_data(int i)
        {
            p15s.RemoveAt(i);
          

        }

        public void changp15_data(int i, string myname, string mytype, string myanswer_D2, Boolean myD1_mustKeyin)
        {
            p15s[i].問題 = myname;
            p15s[i].種類 = mytype;
            p15s[i].回答 = myanswer_D2;
            p15s[i].必須 = myD1_mustKeyin;



        }

        public p15 getp15_At_data(int i)
        {
            return p15s[i];


        }
    }
    //getp15_data
}
