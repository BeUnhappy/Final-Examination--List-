using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;
using System.Data;

namespace BLL
{
    public class InformationBLL
    {
        //public static DataTable QueryZB()
        //{
        //    return InformationDAL.QueryZB();
        //}
        //查询全部
        public static List<ZBinformation> QueryZB()
        {
            return InformationDAL.QueryZB();
        }
        //按条件查询
        public static List<ZBinformation> QueryZB(string name)
        {
            return InformationDAL.QueryZB(name);
        }
        //删除
        public static bool QueryZBDel(string name)
        {
            return InformationDAL.QueryZBDel(name);
        }
        //新增
        public static bool QueryZBIns(ZBinformation xz)
        {
            return InformationDAL.QueryZBIns(xz);
        }
    }
}
