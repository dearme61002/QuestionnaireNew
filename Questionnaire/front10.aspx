<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="front10.aspx.cs" Inherits="Questionnaire.front10" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>

</head>
<body>
    <div style="text-align:center;width:1000px;margin-right:auto;margin-left:auto">
    <form id="form1" runat="server">
        <div style="text-align:center">
        <asp:Label ID="LabelTitle" runat="server" Text="LabelTitle"></asp:Label>
</div>
        <div style="text-align:center">
        <asp:Label ID="LabelM_summary" runat="server" Text="Label"></asp:Label>
</div>
        <div style="text-align:left;margin-top:20px">
             
             <asp:Button ID="Button2" runat="server" Text="回前台搜尋" Font-Size="35px" OnClick="Button2_Click" />
        </div>
    </form>
</div>
</body>
</html>
