<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="front06.aspx.cs" Inherits="Questionnaire.front06" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="Scripts/jquery-3.4.1.js"></script>
    <link href="Scripts/jqueryui/jquery-ui.css" rel="stylesheet" />
    <script src="Scripts/jqueryui/jquery-ui.js"></script>



    <script>
        $(document).ready(function () {

            $('#<% =txtStartDate.ClientID %>').datepicker({ dateFormat: 'yy-mm-dd' });
            $('#<% =txtEndDate.ClientID %>').datepicker({ dateFormat: 'yy-mm-dd' });
        });
    </script>


    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-left: auto; margin-right: auto; width:1400px">

            <asp:Label ID="Label1" runat="server" Text="前台" Style="font-size: 100px"></asp:Label>
            <div style="width:1200px; margin-left: 50px; border: solid 1px black;">
                <div>
                    <span style="margin-right: 20px; font-size: 30px">問卷標題</span><asp:TextBox ID="TitleTextBoxSearch" runat="server" Height="20px" Style="font-size: 30px; line-height: 30px"></asp:TextBox>
                </div>
                <div>
                    <span style="margin-right: 20px; font-size: 30px">開始/結束</span>
                    <asp:TextBox ID="txtStartDate" runat="server" Height="20px" Style="font-size: 30px; line-height: 30px" onkeydown="return false;" autocomplete="off"></asp:TextBox>
                    <asp:TextBox ID="txtEndDate" runat="server" Height="20px" Style="font-size: 30px; line-height: 30px" onkeydown="return false;" autocomplete="off"></asp:TextBox>
                    <asp:Button ID="searchButton" runat="server" Text="搜尋" Height="30px" Style="font-size: 20px; line-height: 20px" OnClick="searchButton_Click" />
                     <asp:Button ID="ButtonCancel" runat="server" Text="取消" Height="30px" Style="font-size: 20px; line-height: 20px" OnClick="ButtonCancel_Click" />
                </div>
                
            </div>
            <div style="margin-left:auto;margin-right:auto;width:1000px;text-align:center;margin-top:50px">

                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="M_id" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" style="width:900px" >
                        <Columns>
                            <asp:BoundField DataField="M_id" HeaderText="#" InsertVisible="False" ReadOnly="True" SortExpression="M_id" />
                            <asp:TemplateField HeaderText="標題">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("M_id", "pageA.aspx?M_id={0}") %>' Text='<%# Eval("M_title") %>'></asp:HyperLink>
                                </ItemTemplate>
                                <ItemStyle Font-Bold="True" Font-Size="Larger" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="狀態">
                                <ItemTemplate>
                                    <asp:Label ID="state" runat="server" Text=''></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="start_time" HeaderText="開始時間" SortExpression="start_time" DataFormatString="{0:yyyy-MM-dd}" />
                            <asp:TemplateField HeaderText="結束時間" SortExpression="end_time">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("end_time") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("end_time","{0:yyyy-MM-dd}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:HyperLinkField DataNavigateUrlFields="M_id" DataNavigateUrlFormatString="front10.aspx?M_id={0}" HeaderText="觀看統計" Text="前往" />
                        </Columns>
                    </asp:GridView>


                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:QuestionnaireConnectionString %>" SelectCommand="SELECT [start_time], [end_time], [M_id], [M_title] FROM [Question_M] WHERE ([M_title] LIKE '%' + @M_title + '%')">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="TitleTextBoxSearch" Name="M_title" PropertyName="Text" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>


                </div>
        </div>
        <asp:SqlDataSource ID="SqlDataSourceALL" runat="server" ConnectionString="<%$ ConnectionStrings:QuestionnaireConnectionString %>" SelectCommand="SELECT [M_id], [M_title], [start_time], [end_time] FROM [Question_M]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSourceTIME" runat="server" ConnectionString="<%$ ConnectionStrings:QuestionnaireConnectionString %>" SelectCommand="SELECT [start_time], [end_time], [M_title], [M_id] FROM [Question_M] WHERE (([start_time] &gt;= @start_time) AND ([end_time] &lt;= @end_time))">
            <SelectParameters>
                <asp:ControlParameter ControlID="txtStartDate" Name="start_time" PropertyName="Text" Type="DateTime" />
                <asp:ControlParameter ControlID="txtEndDate" Name="end_time" PropertyName="Text" Type="DateTime" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSourcefalst" runat="server" ConnectionString="<%$ ConnectionStrings:QuestionnaireConnectionString %>" SelectCommand="SELECT [start_time], [end_time], [M_title], [M_id] FROM [Question_M] WHERE (([M_title] LIKE '%' + @M_title + '%') AND ([start_time] &gt;= @start_time) AND ([end_time] &lt;= @end_time))">
            <SelectParameters>
                <asp:ControlParameter ControlID="TitleTextBoxSearch" Name="M_title" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="txtStartDate" Name="start_time" PropertyName="Text" Type="DateTime" />
                <asp:ControlParameter ControlID="txtEndDate" Name="end_time" PropertyName="Text" Type="DateTime" />
            </SelectParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
