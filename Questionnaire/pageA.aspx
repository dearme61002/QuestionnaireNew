<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pageA.aspx.cs" Inherits="Questionnaire.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%--主題與前言--%>
            <div style="text-align:center">
                <h1><asp:Label ID="Lable_M_title" runat="server"></asp:Label></h1>
            </div>
            <br />
            <asp:Label ID="Lable_M_Summary" runat="server"></asp:Label>
        </div>
        <%--主題與前言--%>
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
    </form>
</body>
</html>
