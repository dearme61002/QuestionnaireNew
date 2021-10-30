﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Backstage14.aspx.cs" Inherits="Questionnaire.Backstage14" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="Scripts/jquery-3.4.1.min.js"></script>

    <style>
        #tab-demo {
            width: 1200px;
            height: 600px;
        }

            #tab-demo > ul {
                display: block;
                margin: 0;
                list-style: none;
            }

        .tab-title {
            list-style: none;
        }

        #tab-demo > ul > li {
            display: inline-block;
            vertical-align: top;
            font-family: '微軟正黑體';
            margin: 0 -1px -1px 0;
            border: 1px solid #BCBCBC;
            height: 25px;
            line-height: 25px;
            background: #cdcdcd;
            padding: 0 15px;
            list-style: none;
            box-sizing: border-box;
        }

            #tab-demo > ul > li a {
                color: #000;
                text-decoration: none;
            }

            #tab-demo > ul > li.active {
                border-bottom: 1px solid #fff;
                background: #fff;
            }

        #tab-demo > .tab-inner {
            clear: both;
            color: #000;
            border: 1px #BCBCBC solid;
        }

        .tab-inner {
            padding: 15px;
            height: 50px;
        }
    </style>
    <script>
        $(function () {
            var $li = $('ul.tab-title li');
            $($li.eq(0).addClass('active').find('a').attr('href')).siblings('.tab-inner').hide();

            $li.click(function () {
                $($(this).find('a').attr('href')).show().siblings('.tab-inner').hide();
                $(this).addClass('active').siblings('.active').removeClass('active');
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-left: auto; margin-right: auto; width: 1400px">

            <asp:Label ID="Label1" runat="server" Text="後台管理增加問卷" Style="font-size: 100px"></asp:Label>
            <div style="float: left;">
                <div style="margin-top: 250px">
                    <asp:HyperLink ID="HyperLink1" runat="server">問卷管理</asp:HyperLink>
                    <br />
                    <asp:HyperLink ID="HyperLink2" runat="server">常見問題管理</asp:HyperLink>
                </div>
            </div>

            <%--內容--%>

            <div id="tab-demo" style="text-align:center;float:right;margin-top: 100px">
                <ul class="tab-title">
                    <li><a href="#tab01">tab01</a></li>
                    <li><a href="#tab02">tab02</a></li>
                    <li><a href="#tab03">tab03</a></li>
                    <li><a href="#tab04">tab04</a></li>
                </ul>
                <div id="tab01" class="tab-inner">
                    <p>tab01的內容</p>
                    <asp:Button ID="Button1" runat="server" Text="Bufdfdfdftton" />
                </div>
                <div id="tab02" class="tab-inner">
                    <p>tab02的內容</p>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </div>
                <div id="tab03" class="tab-inner">
                    <p>tab03的內容</p>
                </div>
                <div id="tab04" class="tab-inner">
                    <p>tab0455的內容</p>
                </div>
            </div>
            <%--內容--%>
            <div style="clear:both"></div>
        </div>
    </form>
</body>
</html>
