﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="front06.aspx.cs" Inherits="Questionnaire.front06" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-left:auto;margin-right:auto;width:1200px">
            
            <asp:Label ID="Label1" runat="server" Text="前台" style="font-size:100px"></asp:Label>
            <div style="width:980px;margin-left:50px;border:solid 1px black;">
                <div>
                <span style="margin-right:20px;font-size:30px">問卷標題</span><asp:TextBox ID="TextBox1" runat="server" Height="20px" style="font-size:30px;line-height:30px" ></asp:TextBox>
                 </div>
            </div>
        </div>
    </form>
</body>
</html>
