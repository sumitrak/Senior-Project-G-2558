<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="detailProject.aspx.cs" Inherits="sproject.detailProject" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
            height: 440px;
            background-color: #F7F7F7;
        }


        
        .auto-style1 {
            height: 23px;
        }
        .auto-style2 {
            width: 221px;
        }
        .auto-style3 {
            height: 23px;
            width: 221px;
        }


        
        </style>
</head>
<body style="height: 631px">
    <form id="form1" runat="server">
    <div>
    
    <div class="cover">
        <div style="height: 54px">
            <div style="float:left width: 85px; height: 25px; width: 805px;">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/web 1024x768 Color.png" Width="169px" Height="158px" style="margin-left: 19px" />
            </div>
            <div style="float:left width: 85px; height: 25px;">
        
            </div>
        </div>
        <div style="float: left; width: 954px;">
            <div style="float:left; width: 211px; height: 25px;">
            </div>
            <asp:Label ID="Label5" runat="server" Text="แบบฟอร์มโครงการ    ภาควิชาวิศวกรรมคอมพิวเตอร์" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
        </div>
    </div>
    

        </div>
    

        <div class="menu">
            <div style="height: 7px"></div>
            <div class="x" style="width: 85px; height: 25px;">
            </div>
            <asp:LinkButton CssClass="x" ID="LinkButton1" runat="server" ForeColor="White" Width="112px" OnClick="LinkButton1_Click" >หน้าแรก</asp:LinkButton>
            <asp:LinkButton CssClass="x" ID="LinkButton2" runat="server" ForeColor="White" OnClick="LinkButton2_Click">คำร้องขอ</asp:LinkButton>

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

            <table style="width:100%;">
                <tr>
                    <td class="auto-style1"></td>
                    <td class="auto-style3"></td>
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td class="auto-style1"></td>
                    <td class="auto-style3"></td>
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style2">
                        <asp:GridView ID="GridView1" runat="server" CellPadding="2" ForeColor="Black" GridLines="None" Width="700px" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="PID" DataSourceID="SqlDataSource1" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" PageSize="8">
                            <AlternatingRowStyle BackColor="PaleGoldenrod" />
                            <Columns>
                                <asp:BoundField DataField="PID" HeaderText="รหัสโครงงาน" ReadOnly="True" SortExpression="PID" />
                                <asp:BoundField DataField="PNameTH" HeaderText="ชื่อโครงงาน" SortExpression="PNameTH" />
                                <asp:BoundField DataField="FormNo" HeaderText="หมายเลขฟอร์ม" SortExpression="FormNo" />
                                <asp:BoundField DataField="status" HeaderText="สถานะ" SortExpression="status" />
                                <asp:BoundField DataField="date" HeaderText="วันที่" SortExpression="date" />
                                <asp:HyperLinkField DataNavigateUrlFields="PID,FormNo" DataNavigateUrlFormatString="ChooseForm_teacher.aspx?PID={0}&amp;FormNo={1}" Text="ตรวจสอบ" />
                            </Columns>
                            <FooterStyle BackColor="Tan" />
                            <HeaderStyle BackColor="Tan" Font-Bold="True" />
                            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                            <SortedAscendingCellStyle BackColor="#FAFAE7" />
                            <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                            <SortedDescendingCellStyle BackColor="#E1DB9C" />
                            <SortedDescendingHeaderStyle BackColor="#C2A47B" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Dbconnection %>" SelectCommand="SELECT project.PID, project.PNameTH, CPE01.FormNo, CPE01.status, CPE01.date FROM CPE01 INNER JOIN project ON CPE01.PID = project.PID WHERE (project.PID = @formPID)
UNION SELECT project.PID, project.PNameTH, CPE02.FormNo, CPE02.status, CPE02.date FROM CPE02 INNER JOIN project ON CPE02.PID = project.PID WHERE (project.PID = @formPID)
UNION SELECT project.PID, project.PNameTH, CPE03.FormNo, CPE03.status, CPE03.date FROM CPE03 INNER JOIN project ON CPE03.PID = project.PID WHERE (project.PID = @formPID)
UNION SELECT project.PID, project.PNameTH, CPE04.FormNo, CPE04.status, CPE04.date FROM CPE04 INNER JOIN project ON CPE04.PID = project.PID WHERE (project.PID = @formPID)
UNION SELECT project.PID, project.PNameTH, CPE05.FormNo, CPE05.status, CPE05.date FROM CPE05 INNER JOIN project ON CPE05.PID = project.PID WHERE (project.PID = @formPID)
UNION SELECT project.PID, project.PNameTH, CPE06.FormNo, CPE06.status, CPE06.date FROM CPE06 INNER JOIN project ON CPE06.PID = project.PID WHERE (project.PID = @formPID)">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="formPID" QueryStringField="PID" />
                        </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>

        </div>


    </form>



    

    <div class="footer">

        <br />
        Copyright © 2015 By Kitchen Line
        <br />
&nbsp;AND&nbsp; G , Naresuan University</div>



    

    </body>
</html>
