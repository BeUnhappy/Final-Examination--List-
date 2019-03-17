using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DBhelp
    {
        private static string connStr = "Data Source=.;Initial Catalog=G2text;Integrated Security=True";
        public static DataTable Read(string sql)
        {
            DataTable table = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(sql, connStr);
            adp.Fill(table);
            return table;
        }
        public static bool Write(string sql)
        {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            int rs = cmd.ExecuteNonQuery();
            conn.Close();
            return rs > 0;
        }
    }
}
