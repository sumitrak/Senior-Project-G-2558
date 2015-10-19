<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="allProject.aspx.cs" Inherits="sproject.allProject" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 200px;
        }
        .auto-style2 {
            width: 200px;
        }
        .auto-style3 {
            width: 560px;
        }
    </style>
</head>
<body style="height: 356px; text-align: center">
    <form id="form1" runat="server">
    <div style="height: 339px; text-align:center">
    
        <table style="width:100%;">
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">
    
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="PID" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" Width="560px">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="PID" HeaderText="รหัสโครงงาน" ReadOnly="True" SortExpression="PID" />
                <asp:BoundField DataField="PNameTH" HeaderText="ชื่อโครงงาน" SortExpression="PNameTH" />
                <asp:BoundField DataField="PNameENG" HeaderText="Project Name" SortExpression="PNameENG" />
                <asp:HyperLinkField Text="รายละเอียด" DataNavigateUrlFields="PID" DataNavigateUrlFormatString="allDetail.aspx?PID={0}" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
                </td>
                <td class="auto-style1">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
            </tr>
        </table>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Dbconnection %>" SelectCommand="SELECT [PID], [PNameTH], [PNameENG] FROM [project]"></asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
