<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pageA.aspx.cs" Inherits="Questionnaire.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <div style="float:left">
     <asp:Label ID="front" runat="server" Text="前台" Style="font-size: 100px"></asp:Label>
    </div>
    <div style="float:right;margin-right:50px">
        <h3>投票中</h3>
        <asp:Label ID="frontLabel1" runat="server" Text="Label"></asp:Label>
    </div>
    <div style="clear:both"></div>
    <form id="form1" runat="server">
        <div>
            <%--主題與前言--%>
            <div style="text-align: center">
                <h1>
                    <asp:Label ID="Lable_M_title" runat="server"></asp:Label></h1>
            </div>
            <br />
            <p style="text-align: center">
                <asp:Label ID="Lable_M_Summary" runat="server"></asp:Label>
            </p>
        </div>
        <%--主題與前言--%>
        <%--固定問題--%>
        <div style="margin-left:20px;margin-bottom:20px">
            <div>
            <span>姓名 :</span><asp:TextBox ID="name" runat="server"></asp:TextBox>
            </div>
            <div>
            <span>手機 :</span><asp:TextBox ID="phone" runat="server"></asp:TextBox>
            </div>
            <div>
            <span>E-mail :</span><asp:TextBox ID="email" runat="server"></asp:TextBox>
            </div>
            <div>
            <span>年齡 :</span><asp:TextBox ID="age" runat="server"></asp:TextBox>
            </div>
        </div>
        <%--固定問題--%>
        <%--問卷--%>
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
        <%--問卷--%>
        <div style="text-align:center;margin-top:20px">
             <asp:Button ID="Button1" runat="server" Text="送出" Font-Size="30px" OnClick="Button1_Click" />
             <asp:Button ID="Button2" runat="server" Text="回前台搜尋" Font-Size="30px" OnClick="Button2_Click" />
        </div>
        
    </form>
</body>
</html>
