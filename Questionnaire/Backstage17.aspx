<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Backstage17.aspx.cs" Inherits="Questionnaire.Backstage17" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <link href="Scripts/jqueryui/jquery-ui.css" rel="stylesheet" />
    <script src="Scripts/jqueryui/jquery-ui.js"></script>
    <script src="Scripts/chartmy.js"></script>
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
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="Backstage.aspx">問卷管理</asp:HyperLink>
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
                    <div style="margin-top: 30px; padding-left: 10px;margin-bottom:20px" >
                        &nbsp;&nbsp;
                        <asp:Button ID="Button_outData" runat="server" Text="匯出" OnClick="Button_outData_Click" />
                    </div>
                    <div>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="AM_id" DataSourceID="SqlDataSource1" OnRowCreated="GridView1_RowCreated" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowPaging="True">
                            <Columns>
                                <asp:BoundField DataField="AM_id" HeaderText="AM_ID" ReadOnly="True" SortExpression="AM_id" />
                                <asp:TemplateField HeaderText="#">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1%>
                                    </ItemTemplate>

                                </asp:TemplateField>
                                <asp:BoundField DataField="name" HeaderText="姓名" SortExpression="name" />
                                <asp:BoundField DataField="writeTime" HeaderText="填寫時間" SortExpression="writeTime" />
                                <asp:HyperLinkField DataNavigateUrlFields="AM_id,M_id" DataNavigateUrlFormatString="https://localhost:44374/Backstage17?M_id={1}&amp;AM_id={0}" HeaderText="觀看細節" Text="前往" />
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:QuestionnaireConnectionString %>" SelectCommand="SELECT [AM_id], [name], [writeTime], [M_id] FROM [Answer_M] WHERE ([M_id] = @M_id)">
                            <SelectParameters>
                                <asp:QueryStringParameter Name="M_id" QueryStringField="M_id" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>

                            <%--固定問題--%>
        <div style="margin-left:20px;margin-bottom:20px">
            <div>
           <asp:Label ID="Label3" runat="server" Text="姓名 :" Visible="false"></asp:Label><asp:TextBox ID="name" runat="server" Visible="false" Enabled="false"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Label4" runat="server" Text="手機 :" Visible="false"></asp:Label><asp:TextBox ID="phone" runat="server" Visible="false" Enabled="false"></asp:TextBox>
            </div>
            <div>
          <asp:Label ID="Label5" runat="server" Text="E-mail :" Visible="false"></asp:Label><asp:TextBox ID="email" runat="server" Visible="false" Enabled="false"></asp:TextBox>
            </div>
            <div>
           <asp:Label ID="Label6" runat="server" Text="年齡 :" Visible="false"></asp:Label><asp:TextBox ID="age" runat="server" Visible="false" Enabled="false"></asp:TextBox>
            </div>
        </div>
        <%--固定問題--%>


                        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>

                        <div>
                            <asp:Button ID="TOP_Button1" runat="server" Text="上一頁" OnClick="TOP_Button1_Click" />
                        </div>

                    </div>

                </div>
                <div id="tab02" class="tab-inner" style="display: none">
                    <%--統計--%>
                    <canvas id="myChart" width="400" height="400"></canvas>
                    <canvas id="myChart2" width="400" height="400"></canvas>
                   <%--統計--%>
                </div>

            </div>
            <%--內容--%>

            <div style="clear: both">
            </div>
        </div>
    </form>
</body>
</html>
