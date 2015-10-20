<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeTeacher.aspx.cs" Inherits="sproject.HomeTeacher" %>

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
            height: 400px;
            background-color: #F7F7F7;
        }


        
        .auto-style1 {
            height: 23px;
            width: 200px;
        }
        .auto-style2 {
            width: 265px;
        }
        .auto-style3 {
            height: 23px;
            width: 560px;
            text-align: right;
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
                    <td class="auto-style1">
                        </td>
                    <td class="auto-style3">
                        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Width="150px" >
                            <asp:ListItem Value="0">อาจารย์ที่ปรึกษา</asp:ListItem>
                            <asp:ListItem Value="1">อาจารย์ที่ปรึกษาร่วม</asp:ListItem>
                            <asp:ListItem Value="2">กรรมการ</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                    <td class="auto-style1">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1"></td>
                    <td class="auto-style3"></td>
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style2">
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" Width="560px" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                            <asp:HyperLinkField DataNavigateUrlFields="PID" DataNavigateUrlFormatString="detailProject.aspx?PID={0}" Text="รายละเอียด" />
                            <asp:HyperLinkField DataNavigateUrlFields="PID" DataNavigateUrlFormatString="tSeeHistory.aspx?PID={0}" Text="ประวัติ" />
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

    <br />
    <div style="text-align: right; height: 28px;">
            Page 6</div>
    

    </body>
</html>
