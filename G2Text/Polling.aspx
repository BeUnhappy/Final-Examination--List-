<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Polling.aspx.cs" Inherits="G2Text.Polling" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        #left {
            float: left;
            width: 276px;
            height: 500px;
            border: 1px solid #ffd800
        }

        #right {
            float: left;
            margin-left: 100px;
            width: 550px;
            height: 500px;
            border: 1px dashed #ffd800
        }

        .style {
            margin-top: 20px;
            margin-left: 20px;
        }

        #ziti {
            color: #0e9af9;
            margin-left: 110px;
            font-weight: 900;
        }

        #ziti2 {
            color: #0e9af9;
            margin-left: 200px;
            font-weight: 900;
        }

        #btn {
            margin-top: 30px;
            margin-left: 100px;
        }
    </style>
    <script type="text/javascript">
        function del() {
            var qr = confirm("确认删除吗？");
            return qr;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <%-- 数据操作 --%>
        <div id="left">
            <label id="ziti">单表新增</label>
            <div class="style">
                <asp:Label ID="lable_id" runat="server" Text="装备等级："></asp:Label><asp:TextBox ID="txt_id" runat="server"></asp:TextBox>
            </div>
            <div class="style">
                <asp:Label ID="lable_name" runat="server" Text="装备名称："></asp:Label><asp:TextBox ID="txt_name" runat="server"></asp:TextBox>
            </div>
            <div class="style">
                <asp:Label ID="lable_price" runat="server" Text="装备价格："></asp:Label><asp:TextBox ID="txt_price" runat="server"></asp:TextBox>
            </div>

            <%-- 单选按钮 --%>
            <%-- Text属性---按钮的值，GroupName---绑定分类 --%>
            <%--<asp:RadioButton ID="RadioButton1" runat="server" Text="选项A" GroupName="RB1" />
            <asp:RadioButton ID="RadioButton2" runat="server" Text="选项B" GroupName="RB1" />
            <asp:RadioButton ID="RadioButton3" runat="server" Text="选项C" GroupName="RB1" />--%>

            <%-- 图片上传 --%>
            <div class="style">
                <asp:FileUpload ID="upload" runat="server" />
                <div style="margin-top: 10px;">
                    <asp:Image ID="Image" runat="server" Width="240" Height="150" />
                </div>
                <div>
                    <asp:Button ID="btn_shangchuan" runat="server" Text="上传图片" OnClick="btn_shangchuan_Click" />
                </div>
            </div>

            <div class="style">
                <asp:Label ID="lable_type" runat="server" Text="装备类型："></asp:Label><asp:TextBox ID="txt_type" runat="server"></asp:TextBox>
            </div>
            <div id="btn">
                <asp:Button ID="btn_xj" runat="server" Text="点击新建" OnClick="btn_xj_Click" />
            </div>
        </div>

        <div id="right">
            <label id="ziti2">数据显示</label>
            <div class="style">
                <asp:Label ID="lbl_name" runat="server" Text="装备名称："></asp:Label>
                <asp:TextBox ID="text_name" runat="server"></asp:TextBox>
                <asp:Button ID="btn_cx" runat="server" Text="查询" OnClick="btn_cx_Click" />
                <asp:Button ID="btn_sx" runat="server" Text="刷新" OnClick="btn_sx_Click"/>
            </div>
            <%-- 引入控件--Repeater，添加属性--OnItemCommand --%>
            <asp:Repeater ID="Rep" runat="server" OnItemCommand="Rep_ItemCommand">
                <HeaderTemplate>
                    <table class="style">
                        <tr>
                            <td>装备等级</td>
                            <td>装备名称</td>
                            <td>装备价格</td>
                            <td>装备图片</td>
                            <td>装备类型</td>
                            <td>操作</td>
                        </tr>
                </HeaderTemplate>

                <ItemTemplate>
                    <tr>
                        <td><%#Eval("ZBId")%></td>
                        <td><%#Eval("ZBName")%></td>
                        <%-- 保留两位小数 --%>
                        <td><%#Convert.ToDecimal(Eval("ZBPrice").ToString()).ToString("F2")%></td>
                        <td><asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("ZBImage")%>' Width="65" Height="30" /></td>
                        <td><%#Eval("Xianshi")%></td>
                        <td>
                            <%-- 客户端点击事件--OnClientClick --%>
                            <%-- 指定CommandName和CommandArgument --%>
                            <asp:LinkButton ID="link_btn" CommandName="sc" CommandArgument='<%#Eval("ZBName")%>' runat="server" OnClientClick="return del()">删除</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>

                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
