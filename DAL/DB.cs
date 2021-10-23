using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DB
    {
        /// <summary>
        /// pageA問卷寫入DBAnswer表單內
        /// </summary>
        /// <returns></returns>
        public Boolean pageAtoAnswer_M(string AM_id, int M_id,string name ,string phone,string email,int age)
        {
            string sql = "INSERT INTO Answer_M(AM_id,M_id,name,phone,email,age) VALUES (@AM_id,@M_id,@name,@phone,@email,@age);";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@AM_id",AM_id),
                new SqlParameter("@M_id",M_id),
                new SqlParameter("@name",name),
                new SqlParameter("@phone",phone),
                new SqlParameter("@email",email),
                new SqlParameter("@age",age)
            };
           int result = sqlhelp.executeNonQuerysql(sql, sqlParameters, false);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean pageAtoAnswer_D1(string AM_id,int D1_id,string Answer)
        {
            string sql = "INSERT INTO Answer_D1(AM_id, Answer, D1_id) VALUES(@AM_id, @Answer, @D1_id);";
            SqlParameter[] sqlParameters = new SqlParameter[]
           {
                new SqlParameter("@AM_id",AM_id),
                new SqlParameter("@Answer",Answer),
                new SqlParameter("@D1_id",D1_id)
           };
            int result = sqlhelp.executeNonQuerysql(sql, sqlParameters, false);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

     

    }
}
