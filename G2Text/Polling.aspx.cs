using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;

namespace G2Text
{
    public partial class Polling : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Rep.DataSource = InformationBLL.QueryZB();
                Rep.DataBind();
            }
        }
        //查询
        protected void btn_cx_Click(object sender, EventArgs e)
        {
            string name = this.text_name.Text;
            Rep.DataSource = InformationBLL.QueryZB(name);
            Rep.DataBind();
        }
        //删除
        protected void Rep_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            var cmd_name = e.CommandName;
            if (cmd_name == "sc")
            {
                string name =e.CommandArgument.ToString();
                InformationBLL.QueryZBDel(name);
                //刷新页面
                Response.Redirect(Request.Url.ToString());
            }
        }
        //上传图片
        protected void btn_shangchuan_Click(object sender, EventArgs e)
        {
            //1.判断是否选择了文件
            //---上传控件.HasFiles
            if (upload.HasFiles)
            {
                //2.上传
                //---上传控件.SaveAs(路径)
                //在根目录创建uploadimg文件夹
                string path = Server.MapPath("/uploadimg/");
                upload.SaveAs(path + upload.FileName);
                this.Image.ImageUrl = "/uploadimg/" + upload.FileName;
            }
        }
        //新增
        protected void btn_xj_Click(object sender, EventArgs e)
        {
            string id = this.txt_id.Text;
            string name = this.txt_name.Text;
            decimal price = Convert.ToDecimal(this.txt_price.Text);
            string img = Image.ImageUrl;
            int type = Convert.ToInt32(this.txt_type.Text);

            ZBinformation zb = new ZBinformation();
            zb.ZBId = id;
            zb.ZBName = name;
            zb.ZBPrice = price;
            zb.ZBImage = img;
            zb.ZBType = type;
            InformationBLL.QueryZBIns(zb);
            Response.Redirect(Request.Url.ToString());
        }
        //刷新
        protected void btn_sx_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.ToString());
        }
    }
}