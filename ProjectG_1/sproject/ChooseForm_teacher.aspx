<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChooseForm_teacher.aspx.cs" Inherits="sproject.ChooseForm_teacher" %>

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
            height: 375px;
            background-color: #F7F7F7;
        }


        
        .auto-style3 {
            height: 23px;
            width: 135px;
        }


        
        .auto-style4 {
            width: 89px;
        }
        .auto-style5 {
            width: 81px;
        }


        
        .auto-style9 {
            text-align: left;
        }
        .auto-style10 {
            width: 94px;
        }
        .auto-style11 {
            text-align: left;
            width: 94px;
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

       
    <div id="body" style="height: 195px; text-align: center;">
    
        <table style="width:100%;">
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style5" style="text-align:right">
                    &nbsp;</td>
                <td class="auto-style4">
                    &nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style5" style="text-align:right">
                    &nbsp;</td>
                <td class="auto-style4">
                    &nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style8">&nbsp;</td>
                <td class="auto-style11">&nbsp;</td>
                <td class="auto-style9"></td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style5">
                    <asp:Label ID="Label2" runat="server" Text="แบบฟอร์ม : "></asp:Label>
                </td>
                <td class="auto-style4">

                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem Value="0">กรุณาเลือกแบบฟอร์ม</asp:ListItem>
                        <asp:ListItem Value="1">CPE01 - แบบเสนอหัวข้อโครงงาน</asp:ListItem>
                        <asp:ListItem Value="2">CPE02 - แบบบันทึกการดำเนินงานโครงงาน</asp:ListItem>
                        <asp:ListItem Value="3">CPE03 - แบบขอสอบข้อเสนอโครงงาน</asp:ListItem>
                        <asp:ListItem Value="4">CPE04 - แบบประเมินข้อเสนอโครงงาน</asp:ListItem>
                        <asp:ListItem Value="5">CPE05 - แบบประเมินความก้าวหน้าโครงงาน</asp:ListItem>
                        <asp:ListItem Value="6">CPE06 - แบบขอสอบโครงงาน</asp:ListItem>
                        <asp:ListItem Value="7">CPE07 - แบบประเมินโครงงาน</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style10">

                        <asp:Button ID="okBtn" runat="server" Text="ยืนยัน" Width="81px" OnClick="okBtn_Click" style="height: 26px" />
                    </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style4">

                    &nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>

    <div class="footer">

        <br />
        Copyright © 2015 By Kitchen Line
        <br />
&nbsp;AND&nbsp; G , Naresuan University</div>
    </form>


        


    <div style="text-align: right; height: 28px;">
            Page 4</div>

    

    </body>
</html>
