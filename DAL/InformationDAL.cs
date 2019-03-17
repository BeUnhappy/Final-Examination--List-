using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data;

namespace DAL
{
    public class InformationDAL
    {
        //单表查询显示
        //public static DataTable QueryZB()
        //{
        //    string sql = string.Format("select * from ZBinformation");
        //    return DBhelp.Read(sql);
        //}
        //查询全部
        public static List<ZBinformation> QueryZB()
        {
            string sql = string.Format("select * from ZBinformation");
            var table = DBhelp.Read(sql);
            List<ZBinformation> list = new List<ZBinformation>();
            foreach (DataRow row in table.Rows)
            {
                ZBinformation zb = new ZBinformation();
                zb.ZBId = row["ZBId"].ToString();
                zb.ZBName = row["ZBName"].ToString();
                zb.ZBPrice = Convert.ToDecimal(row["ZBPrice"]);
                zb.ZBImage = row["ZBImage"].ToString();
                zb.ZBType = Convert.ToInt32(row["ZBType"]);
                list.Add(zb);
            }
            return list;
        }
        //按条件查询
        public static List<ZBinformation> QueryZB(string name)
        {
            string sql = string.Format("select * from ZBinformation where ZBName like '%{0}%'",name);
            var table = DBhelp.Read(sql);
            List<ZBinformation> list = new List<ZBinformation>();
            foreach (DataRow row in table.Rows)
            {
                ZBinformation zb = new ZBinformation();
                zb.ZBId = row["ZBId"].ToString();
                zb.ZBName = row["ZBName"].ToString();
                zb.ZBPrice = Convert.ToDecimal(row["ZBPrice"]);
                zb.ZBImage = row["ZBImage"].ToString();
                zb.ZBType = Convert.ToInt32(row["ZBType"]);
                list.Add(zb);
            }
            return list;
        }
        //删除
        public static bool QueryZBDel(string name)
        {
            string sql = string.Format("delete from [dbo].[ZBinformation] where ZBName='{0}'", name);
            return DBhelp.Write(sql);
        }
        //新增
        public static bool QueryZBIns(ZBinformation ZB)
        {
            string sql = string.Format("insert [dbo].[ZBinformation] values('{0}','{1}','{2}','{3}','{4}')", ZB.ZBId, ZB.ZBName, ZB.ZBPrice, ZB.ZBImage, ZB.ZBType);
            return DBhelp.Write(sql);
        }
    }
}
