<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Backstage.aspx.cs" Inherits="Questionnaire.Backstage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-left: auto; margin-right: auto; width:1400px">
            <asp:Label ID="Label1" runat="server" Text="後台" Style="font-size: 100px"></asp:Label>
            <div style="float:left;">
                <div style="margin-top:250px">
                    <asp:Label ID="Label2" runat="server" Text="Label">問卷管理</asp:Label>
                    <asp:Label ID="Label3" runat="server" Text="Label">常見問題管理</asp:Label>
                </div>
                
            </div>
            <div style="width:1200px; margin-left: 50px; border: solid 1px black;float:right">
                <div>
                    <span style="margin-right: 20px; font-size: 30px">問卷標題</span><asp:TextBox ID="TitleTextBoxSearch" runat="server" Height="20px" Style="font-size: 30px; line-height: 30px"></asp:TextBox>
                </div>
                <div>
                    <span style="margin-right: 20px; font-size: 30px">開始/結束</span>
                    <asp:TextBox ID="txtStartDate" runat="server" Height="20px" Style="font-size: 30px; line-height: 30px" onkeydown="return false;" autocomplete="off"></asp:TextBox>
                    <asp:TextBox ID="txtEndDate" runat="server" Height="20px" Style="font-size: 30px; line-height: 30px" onkeydown="return false;" autocomplete="off"></asp:TextBox>
                    <asp:Button ID="searchButton" runat="server" Text="搜尋" Height="30px" Style="font-size: 20px; line-height: 20px" />
                     <asp:Button ID="ButtonCancel" runat="server" Text="取消" Height="30px" Style="font-size: 20px; line-height: 20px" />
                </div>
                
            </div>
            <div style="clear:both"></div>
        </div>
    </form>
</body>
</html>
