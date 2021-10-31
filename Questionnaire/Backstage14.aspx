<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Backstage14.aspx.cs" Inherits="Questionnaire.Backstage14" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
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
            /*height: 500px;*/  /*裡面的高度*/
        }
    </style>
    <script>
 $(document).ready(function () {

                $('#<% =txtStartDate.ClientID %>').datepicker({ dateFormat: 'yy-mm-dd' });
                   $('#<% =txtEndDate.ClientID %>').datepicker({ dateFormat: 'yy-mm-dd' });
               });

        $(function () {
            var $li = $('ul.tab-title li');
            $($li.eq(0).addClass('active').find('a').attr('href')).siblings('.tab-inner').hide();

            $li.click(function () {
                $($(this).find('a').attr('href')).show().siblings('.tab-inner').hide();
                $(this).addClass('active').siblings('.active').removeClass('active');
            });

            document.getElementById('tab01Button').addEventListener("click", function () {
                document.getElementById('tab02top').click();
                event.preventDefault();
            });
           
            document.getElementById('<% =AddButton2.ClientID %>').addEventListener("click", function () {
        
                event.preventDefault();
            });

        });
    </script>
</head>
<body>
    <form id="form1" runat="server" >
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

            <div id="tab-demo" style="float:right;margin-top: 100px">
                <ul class="tab-title">
                    <li><a href="#tab01">問卷</a></li>
                    <li><a href="#tab02" id="tab02top">問題</a></li>
                   
                </ul>
                <div id="tab01" class="tab-inner">
                    <div>
                        <div>
                            <span>問卷名稱:</span><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                        </div>
                        <div>
                            <span>描述內容:</span><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                        </div>
                          <div>
                            <span>開始時間:</span><asp:TextBox ID="txtStartDate" runat="server" Height="20px" Style="font-size: 30px; line-height: 30px" onkeydown="return false;" autocomplete="off"></asp:TextBox>
                        </div>
                        <div>
                            <span>結束使間:</span><asp:TextBox ID="txtEndDate" runat="server" Height="20px" Style="font-size: 30px; line-height: 30px" onkeydown="return false;" autocomplete="off"></asp:TextBox>
                        </div>
                        <div>
                            <asp:CheckBox ID="CheckBox1" runat="server" /><span>已啟動</span>
                        </div>
                        <div>
                            <asp:Button ID="Button1" runat="server" Text="取消" />
                            <button id="tab01Button">下一頁</button>
                        </div>
                    </div>
                </div>
                <div id="tab02" class="tab-inner">
                   <div>
                       <span>種類</span>
                       <asp:DropDownList ID="DropDownList1" runat="server">
                           <asp:ListItem Value="0">自訂問題</asp:ListItem>
                       </asp:DropDownList>
                   </div>
                    <div style="margin-top:30px">
                        <span>問題</span><asp:DropDownList ID="DropDownList2" runat="server">
                            <asp:ListItem Value="RB">單選題</asp:ListItem>
                            <asp:ListItem Value="CB">複選題</asp:ListItem>
                            <asp:ListItem Value="TB">文字方塊</asp:ListItem>
                        </asp:DropDownList><span><asp:CheckBox ID="CheckBox2" runat="server" /><span>必須</span></span>
                        <div>
                            <span>回答</span><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><span>(多個答案以分號;分隔)</span><asp:Button ID="AddButton2" runat="server" Text="加入" />
                        </div>
                        <div>
                            <asp:Button ID="Button2" runat="server" Text="刪除" />
                        </div>
                        <%--表單--%>
                        <div>
                            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                        </div>
                        <%--表單--%>
                    </div>
                    <div><asp:Button ID="Button3" runat="server" Text="取消" />
                        <asp:Button ID="Button4" runat="server" Text="送出" /></div>
                </div>
                
            </div>
            <%--內容--%>
           
            <div style="clear:both"></div>
        </div>
    </form>
</body>
</html>
