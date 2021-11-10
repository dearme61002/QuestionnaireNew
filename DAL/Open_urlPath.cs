using lom;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
    public class Open_urlPath
    {
        string Myfilename = string.Empty;
        string[] titles = { };

        List<B17exel> mydata_b17s_list { get; set; }
        public void setExcel_Title(string my_filename, params string[] Settitle)
        {
            Myfilename = my_filename;
            titles = Settitle;
        }

        public void setExcel_MyList_data(List<B17exel> b17Exels)
        {
            mydata_b17s_list = b17Exels;
        }
        public void getExcel()
        {
            //OpenFileDialog ofd = new OpenFileDialog();
            ////ofd.Filter = "Microsoft Office Excel(*.xls;*.xlsx)|*.xls;*.xlsx";
            //ofd.FilterIndex = 1;
            //ofd.RestoreDirectory = true;
            //string s = ofd.FileName;
            //if (ofd.ShowDialog() == DialogResult.OK)
            //{
            //    //檢測開啟檔案路徑是否為空地址
            //    if (!string.IsNullOrEmpty(ofd.InitialDirectory))
            //    {

            //    }
            //    else
            //    {

            //    }
            //}
            //var dialog = new SaveFileDialog();
            //dialog.Title = "Save File";
            //dialog.FileName = "Product.xls";
            //dialog.Filter = "Excel Files(*.xls)|*.xls";
            //var isValid = dialog.ShowDialog();

            //FolderBrowserDialog path = new FolderBrowserDialog();
            //path.Description = "請選擇欲轉換的主目錄,程序會找到底下的子目錄及檔案";
            //path.ShowDialog();
            //path.SelectedPath = null;
            //string path2 = path.SelectedPath;
            IWorkbook workbook = new HSSFWorkbook();
            try
            {
                

                    ISheet sheet = workbook.CreateSheet("簡單報表文件檔");

                    //設定欄位名稱的cell style
                    var style = workbook.CreateCellStyle();
                    var font = workbook.CreateFont();
                    font.Underline = FontUnderlineType.Single;
                    font.Color = HSSFColor.White.Index;
                    style.SetFont(font);
                    style.FillForegroundColor = HSSFColor.BlueGrey.Index;
                    style.FillPattern = FillPattern.SolidForeground;

                    var i = 0;


                //string M_id_b17 = 25.ToString();
                //string sql_Mydata = "SELECT　DISTINCT Q_M.M_title, Q_M.M_summary,Q_1.D1_title, A_D1.Answer,A_M.name,A_M.age,A_M.email,A_M.phone,A_M.writeTime,Q_M.start_time,Q_M.end_time from Answer_M as A_M INNER JOIN Question_M as Q_M  on A_M.M_id = Q_M.M_id inner join Answer_D1 as A_D1 on A_D1.AM_id = A_M.AM_id inner join Question_D1 as Q_1 on Q_1.M_id = A_M.M_id inner join Question_D2 as Q_2 on Q_2.M_id = A_M.M_id where A_M.M_id = @M_id";
                //System.Data.SqlClient.SqlParameter[] sqlParameters_b17 = new SqlParameter[]
                //{
                //new SqlParameter("@M_id",M_id_b17)
                //};

                //List<B17exel> mydata_b17s_list = new List<B17exel>();

                //SqlDataReader sqlData_b17 = sqlhelp.executeReadesql(sql_Mydata, sqlParameters_b17, false);
                //if (sqlData_b17.HasRows)
                //{
                //    while (sqlData_b17.Read())
                //    {
                //        B17exel my_out_b17 = new B17exel();
                //        my_out_b17.M_title = (string)sqlData_b17["M_title"];
                //        my_out_b17.M_summary = (string)sqlData_b17["M_summary"];
                //        my_out_b17.D1_title = (string)sqlData_b17["D1_title"];
                //        my_out_b17.Answer = (string)sqlData_b17["Answer"];
                //        my_out_b17.name = (string)sqlData_b17["name"];
                //        my_out_b17.age = (int)sqlData_b17["age"];
                //        my_out_b17.email = (string)sqlData_b17["email"];
                //        my_out_b17.phone = (string)sqlData_b17["phone"];
                //        my_out_b17.writeTime = sqlData_b17["writeTime"].ToString();
                //        my_out_b17.start_time = sqlData_b17["start_time"].ToString();
                //        my_out_b17.end_time = sqlData_b17["end_time"].ToString();
                //        mydata_b17s_list.Add(my_out_b17);
                //    };
                //}
                //sqlData_b17.Close();


                foreach (var item in mydata_b17s_list)
                    {
                        var j = 0;
                        var row = sheet.CreateRow(i);
                        if (i == 0)
                        {
                            foreach (var title in titles)
                            {
                                var cell = row.CreateCell(j);
                                cell.SetCellValue(title);//標題
                                cell.CellStyle = style;
                                sheet.AutoSizeColumn(j);
                                j++;
                            }

                            i++;
                            j = 0;
                            row = sheet.CreateRow(i);
                        }

                        foreach (var property in item.GetType().GetProperties())
                        {
                            row.CreateCell(j).SetCellValue(property.GetValue(item, null)?.ToString());
                            j++;
                        }
                        i++;
                    

                    //跳出視窗讓使用著選擇儲存路徑
                    
                    
                }



                SaveFileDialog dialog = new SaveFileDialog();
                    dialog.Title = "Save File";
                    dialog.FileName = Myfilename+ DateTime.UtcNow.ToString("MMddyyyyhhmmssffftt") +".xls";  //檔名
                    dialog.Filter = "Excel Files(*.xls)|*.xls";
                     dialog.ShowDialog();

                dialog.CheckFileExists = true;
               
                       FileStream file = new FileStream(dialog.FileName, FileMode.Create);
                        workbook.Write(file);
                       
                   file.Close();
                
                  


            }
            catch
            {
              
            }
            finally
            {
                workbook.Close();
            }

        }
    }
}
