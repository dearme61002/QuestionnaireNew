<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Backstage17.aspx.cs" Inherits="Questionnaire.Backstage17" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <link href="Scripts/jqueryui/jquery-ui.css" rel="stylesheet" />
    <script src="Scripts/jqueryui/jquery-ui.js"></script>

    <style>
        #tab-demo {
            width: 1200px;
            /* height:1000px;*/
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
            /*height: 500px;*/ /*裡面的高度*/
        }
    </style>



        <script>
       

            $(function () {

                var $li = $('ul.tab-title li');
                /* $($li.eq(0).addClass('active').find('a').attr('href')).siblings('.tab-inner').hide();*/ //初始化 但會影響到動態表單所以取消

                $li.click(function () {
                    $($(this).find('a').attr('href')).show().siblings('.tab-inner').hide();
                    $(this).addClass('active').siblings('.active').removeClass('active');
                });

                //document.getElementById('tab01Button').addEventListener("click", function () {
                //    document.getElementById('tab02top').click();
                //   /* event.preventDefault();*/
                //});
                /*head頭*/
                document.getElementById('litab02top').addEventListener("click", () => {
                    document.getElementById('litab01top').style.borderBottom = '1px solid #BCBCBC';
                    document.getElementById('litab01top').style.backgroundColor = '#BCBCBC';
                    document.getElementById('litab02top').style.borderBottom = 'none';
                    document.getElementById('litab02top').style.backgroundColor = 'white';
                });

                document.getElementById('litab01top').addEventListener("click", () => {
                    document.getElementById('litab02top').style.borderBottom = '1px solid #BCBCBC';
                    document.getElementById('litab02top').style.backgroundColor = '#BCBCBC';
                    document.getElementById('litab01top').style.borderBottom = 'none';
                    document.getElementById('litab01top').style.backgroundColor = 'white';

                });
                /*head頭*/
                


             });
        </script>


    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-left: auto; margin-right: auto; width: 1400px">

            <asp:Label ID="Label1" runat="server" Text="後台管理詳細資料" Style="font-size: 100px"></asp:Label>
            <div style="float: left;">
                <div style="margin-top: 250px">
                    <asp:HyperLink ID="HyperLink1" runat="server">問卷管理</asp:HyperLink>
                    <br />
                    <asp:HyperLink ID="HyperLink2" runat="server">常見問題管理</asp:HyperLink>
                </div>
            </div>

            <%--內容--%>

            <div id="tab-demo" style="float: right; margin-top: 100px">
                <ul class="tab-title">
                    <li style="background-color: white; border-bottom: none" id="litab01top"><a href="#tab01" id="tab01top">詳細資料</a></li>
                    <li id="litab02top"><a href="#tab02" id="tab02top">統計</a></li>

                </ul>
                <div id="tab01" class="tab-inner">
                    11
                </div>
                <div id="tab02" class="tab-inner" style="display: none">
                    22
                   
                </div>

            </div>
            <%--內容--%>

            <div style="clear: both">
            </div>
        </div>
    </form>
</body>
</html>
