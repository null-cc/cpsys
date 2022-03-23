using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace WinFormsApp1
{
    class Dao
    {
     
        public SqlConnection connection()
        {
            string str = "Data Source=LAPTOP-5NCF3AOB;Initial Catalog=Demo;Integrated Security=True";
            SqlConnection sc = new SqlConnection(str);
            sc.Open();
            return sc;
        }
        public SqlCommand command(string sql)
        {
            SqlCommand sc = new SqlCommand(sql,connection());
            return sc;
        }
        //用于delete updata insert 返回受影响的行数
        public int Excute(string sql)
        {
            return command(sql).ExecuteNonQuery();
        }
        //用于select 返回sqldatareader对象 包含select到的对象
        public SqlDataReader read(string sql)
        {
            return command(sql).ExecuteReader();
        }
    }
}
