<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="saveQuestion.aspx.cs" Inherits="Questionnaire.saveQuestion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-left: auto; margin-right: auto; width: 1400px">
            <asp:Label ID="Label1" runat="server" Text="常用問題管理" Style="font-size: 100px"></asp:Label>
            <div style="float: left;">
                <div style="margin-top: 250px">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="Backstage.aspx">問卷管理</asp:HyperLink>
                    <br />
                    <asp:HyperLink ID="HyperLink2" runat="server">常見問題管理</asp:HyperLink>
                </div>
            </div>
            <div id="tab-demo" style="text-align: left; margin-left: 230px; margin-top: 100px">
                <div>
                    <div>
                        <span>常用問題選項名子</span><asp:TextBox ID="TextBox1_name" runat="server"></asp:TextBox>
                    </div>
                    <div>
                        <span>問題</span><asp:TextBox ID="TextBox2_question" runat="server"></asp:TextBox>
                    </div>
                    <div>
                        <span>回答</span><asp:TextBox ID="TextBox1_answer" runat="server"></asp:TextBox>
                        <span style="margin-left: 100px">種類</span><asp:DropDownList ID="DropDownList1_type" runat="server">
                            <asp:ListItem Value="RB">單選題</asp:ListItem>
                            <asp:ListItem Value="CB">複選題</asp:ListItem>
                            <asp:ListItem Value="TB">文字方塊</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div style="text-align: center">
                        <asp:Button ID="Button1_Add" runat="server" Text="增加" />
                    </div>
                </div>
                <div style="margin-top: 50px">
                    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                </div>
            </div>
            <div style="clear: both"></div>

        </div>
    </form>
</body>
</html>
