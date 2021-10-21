using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
  public  class getPageA//共用部分
    {
        /// <summary>
        /// 計算這個問卷有多少題目
        /// </summary>
        /// <param name="M_id"></param>
        /// <returns></returns>
        public int Compute_QNo(int M_id)
        {
            string sql = "select count(1) from Question_D1 where M_id = @M_id";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@M_id",M_id)
        };
           int count = Convert.ToInt32(sqlhelp.executeScalarsql(sql, sqlParameters, false)) ;
            return count;
        }


    }
}
