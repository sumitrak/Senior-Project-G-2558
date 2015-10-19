<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="sproject.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>     
    <form id="form1" runat="server">
    <div>
    
       

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="PID" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="PID" HeaderText="PID" ReadOnly="True" SortExpression="PID" />
                <asp:BoundField DataField="PNameTH" HeaderText="PNameTH" SortExpression="PNameTH" />
                <asp:BoundField DataField="FormNo" HeaderText="FormNo" SortExpression="FormNo" />
                <asp:BoundField DataField="status" HeaderText="status" SortExpression="status" />
                <asp:BoundField DataField="date" HeaderText="date" SortExpression="date" />
            </Columns>
        </asp:GridView>
                        <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="700px" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="PID" DataSourceID="SqlDataSource1">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="PID" HeaderText="รหัสโครงงาน" ReadOnly="True" SortExpression="PID" />
                                <asp:BoundField DataField="PNameTH" HeaderText="ชื่อโครงงาน (ไทย)" SortExpression="PNameTH" />
                                <asp:BoundField DataField="PNameENG" HeaderText="ชื่อโครงงาน (อังกฤษ)" SortExpression="PNameENG" />
                                <asp:HyperLinkField DataNavigateUrlFields="PID" DataNavigateUrlFormatString="ChooseForm_teacher.aspx?PID={0}" Text="ดูรายละเอียด" />
                            </Columns>
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Dbconnection %>" SelectCommand="SELECT project.PID, project.PNameTH, CPE01.FormNo, CPE01.status, CPE01.date FROM CPE01 INNER JOIN project ON CPE01.PID = project.PID WHERE (project.advisorID = @aPID)"> 
        <SelectParameters>
            <asp:SessionParameter Name="aPID" SessionField="aPID" Type="String" />
        </SelectParameters>
        </asp:SqlDataSource>
    
                        <asp:GridView ID="GridView3" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="700px" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="PID" DataSourceID="SqlDataSource1">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="PID" HeaderText="รหัสโครงงาน" ReadOnly="True" SortExpression="PID" />
                                <asp:BoundField DataField="PNameTH" HeaderText="ชื่อโครงงาน" SortExpression="PNameTH" />
                                <asp:BoundField DataField="FormNo" HeaderText="หมายเลขฟอร์ม" SortExpression="FormNo" />
                                <asp:BoundField DataField="status" HeaderText="สถานะ" SortExpression="status" />
                                <asp:BoundField DataField="date" HeaderText="วันที่" SortExpression="date" />
                                <asp:HyperLinkField DataNavigateUrlFields="PID" DataNavigateUrlFormatString="ChooseForm_teacher.aspx?PID={0}" Text="ตรวจสอบ" />
                            </Columns>
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
    
    </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    </form>
</body>
</html>
