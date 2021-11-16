<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Questionnaire.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center">
            <h1>簡易動態問卷系統</h1>
            <p>帳號為:admin</p>
            <p>密碼為:admin</p>
        </div>
        <div style="margin-top: 30px; text-align: center">
            <div>
                <asp:Label ID="Label2_account" runat="server" Text="帳號"></asp:Label>
                <asp:TextBox ID="TextBox_account" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Label1_account" runat="server" Text="密碼"></asp:Label>
                <asp:TextBox ID="TextBox_passworld" runat="server"></asp:TextBox>
            </div>
            <asp:Button ID="Button_submit" runat="server" Text="登入" OnClick="Button_submit_Click" />
            <div style="margin-top:30px">
                <span>
                    <asp:Button ID="Button_front" runat="server" Text="前台" Visible="False" OnClick="Button_front_Click" /></span>
                <span>
                    <asp:Button ID="Button_back" runat="server" Text="後台" Visible="False" OnClick="Button_back_Click" /></span>
                
            </div>
            <div>
                <asp:Label ID="Label1_p" runat="server" Text="請選擇你要去前台還是後台" Visible="false"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
