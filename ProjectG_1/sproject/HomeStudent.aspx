<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeStudent.aspx.cs" Inherits="sproject.HomeStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type = "text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("คุณต้องการออกจากกลุ่มใช่หรือไม่ \n\n*หากในกลุ่มไม่มีสมาชิก โครงงานนั้นจะถูกลบทิ้งทันที")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
    <style type="text/css">

        body{
            width: 960px;
            margin: 5px auto;
            border-radius: 10px 10px 0px 0px;
            -moz-box-shadow: 5px 5px 5px  #ccc;
            -webkit-box-shadow: 5px 5px  5px #ccc;
            box-shadow: 5px 5px 5px  #ccc;
        }        

        .cover{
            background-color: #ffd800;
            height: 157px;
            border-radius: 10px 10px 0px 0px;
        }

        .menu{
            background-color: #000000;
            height: 35px;
        }

        .x{
            float: left;
            height: 19px;
        }


        
        .footer {
            background-color: #ffd800;
            height: 60px;
            text-align: center;
            border-radius: 0px 0px 10px 10px;
            -moz-box-shadow: 5px 5px 5px  #ccc;
            -webkit-box-shadow: 5px 5px  5px #ccc;
            box-shadow: 5px 5px 5px  #ccc;
        }


        
        .body {
            text-align: center;
            height: 488px;
            background-color: #F7F7F7;
        }


        
        .auto-style1 {
            height: 23px;
        }
        .auto-style3 {
            height: 23px;
            width: 295px;
        }


        
        .auto-style4 {
            height: 199px;
        }
        .auto-style5 {
            width: 295px;
            height: 199px;
        }


        
        .auto-style6 {
            height: 30px;
        }
        .auto-style7 {
            width: 295px;
            height: 30px;
        }


        
        </style>
</head>
<body style="height: 741px">
    <form id="form1" runat="server">
    <div>
    
    <div class="cover">
        <div style="height: 54px">
            <div style="float:left width: 85px; height: 25px; width: 805px; text-align: left;">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/web 1024x768 Color.png" Width="169px" Height="158px" style="margin-left: 19px" />
            </div>
            <div style="float:left width: 85px; height: 25px;">
        
            </div>
        </div>
        <div style="float: left; width: 954px; text-align: left;">
            <div style="float:left; width: 211px; height: 25px;">
            </div>
            <asp:Label ID="Label5" runat="server" Text="แบบฟอร์มโครงการ    ภาควิชาวิศวกรรมคอมพิวเตอร์" Font-Bold="True" Font-Size="XX-Large" style="text-align: left"></asp:Label>
        </div>
    </div>
    

        </div>
    

        <div class="menu">
            <div style="height: 7px"></div>
            <div class="x" style="width: 85px; height: 25px;">
            </div>
            <asp:LinkButton CssClass="x" ID="LinkButton1" runat="server" ForeColor="White" Width="112px" OnClick="LinkButton1_Click" >หน้าแรก</asp:LinkButton>
            <asp:LinkButton CssClass="x" ID="LinkButton2" runat="server" ForeColor="White" OnClick="LinkButton2_Click">แบบฟอร์ม</asp:LinkButton>
           
            <div style="float:right; width:50%; height: 27px;">
                <div style="float:right; height:25px; width:20px;"></div>
                <div style="float:right; text-align:right; height: 23px;">
                     <asp:LinkButton CssClass="x" ID="LinkButton3" runat="server" ForeColor="White" OnClick="LinkButton3_Click">ออกจากระบบ</asp:LinkButton>
                </div>


                <div style="float:right; height:25px; width:40px;"></div>

                <div style="float:right; text-align:right ">
                
                    <asp:Label ID="Label6" runat="server" ForeColor="Yellow" Text="สวัสดี! : "></asp:Label>
                    <asp:Label ID="Label1" runat="server" ForeColor="Yellow" Text=" NAME "></asp:Label>
                
                </div>

            </div>
            
        </div>

        <div class="body" id="body">

            <table style="width:100%; height: 366px;">
                <tr>
                    <td class="auto-style1"></td>
                    <td class="auto-style3"></td>
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td class="auto-style1"></td>
                    <td class="auto-style3">
                        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="ประวัติ" Width="83px" style="text-align: center" />
                    </td>
                    <td class="auto-style1">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style1">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4"></td>
                    <td class="auto-style5">
                        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="700px" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" AllowPaging="True" PageSize="8">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="PID" HeaderText="รหัสโครงงาน" ReadOnly="True" SortExpression="PID" />
                                <asp:BoundField DataField="PNameTH" HeaderText="ชื่อโครงงาน" ReadOnly="True" SortExpression="PNameTH" />
                                <asp:BoundField DataField="FormNo" HeaderText="หมายเลขฟอร์ม" ReadOnly="True" SortExpression="FormNo" />
                                <asp:BoundField DataField="status" HeaderText="สถานะ" ReadOnly="True" SortExpression="status" />
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
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Dbconnection %>" SelectCommand="SELECT project.PID, project.PNameTH, CPE01.FormNo, CPE01.status FROM CPE01 INNER JOIN project ON CPE01.PID = project.PID WHERE (project.PID = @PID) 
UNION SELECT project_2.PID, project_2.PNameTH, CPE02.FormNo, CPE02.status FROM CPE02 INNER JOIN project AS project_2 ON CPE02.PID = project_2.PID WHERE (project_2.PID = @PID) 
UNION SELECT project_1.PID, project_1.PNameTH, CPE03.formNo, CPE03.status FROM CPE03 INNER JOIN project AS project_1 ON CPE03.PID = project_1.PID WHERE (project_1.PID = @PID)">
                            <SelectParameters>
                                <asp:SessionParameter Name="PID" SessionField="sesPID" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                    <td class="auto-style4"></td>
                </tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style7">
                        &nbsp;</td>
                    <td class="auto-style6">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6"></td>
                    <td class="auto-style7">
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="ออกจากกลุ่ม" Width="83px" OnClientClick = "Confirm()" style="text-align: center" />
                    </td>
                    <td class="auto-style6"></td>
                </tr>
                <tr>
                    <td class="auto-style1"></td>
                    <td class="auto-style3"></td>
                    <td class="auto-style1"></td>
                </tr>
                </table>

        </div>


    <div class="footer">

        <br />
        Copyright © 2015 By Kitchen Line
        <br />
&nbsp;AND&nbsp; G , Naresuan University</div>

    </form>



    

    </body>
</html>
