<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CPE02_teacher.aspx.cs" Inherits="sproject.CPE02_teacher" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style type="text/css">
        .Background
        {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }
        .Popup
        {
            background-color: #FFFFFF;
            border-width: 3px;
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;
            width: 400px;
            height: 350px;
        }
        .lbl
        {
            font-size:16px;
            font-style:italic;
            font-weight:bold;
        }
    </style>

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
            height: 375px;
            background-color: #F7F7F7;
        }

        .auto-style1 {
            width: 10%;
        }
        .auto-style2 {
            width: 80%;
        }
        .auto-style3 {
            width: 10%;
        }
        .a {
            float:left;
            width: 175px;
            text-align:center
        }
        .b {
            float:left;
            width: 164px;
            text-align:center
        }
        .c {
            float:left;
            width: 225px;
            text-align:center
        }


        
        .aa {
            float:left;
            width: 455px;
            text-align:center
        }
        
        .auto-style4 {
            width: 10%;
            height: 23px;
        }
        .auto-style5 {
            width: 80%;
            height: 23px;
        }
        
        </style>
</head>
<body style="height: 1135px">
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

        

        <div style="height: 945px">
    
        <table style="width:100%; height: 831px;">
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    <div>
                    <asp:Label ID="Label2" runat="server" Font-Size="X-Large" Text="CPE02 - แบบบันทึกการดำเนินโคงงาน"></asp:Label>
                    </div>
                </td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    <div style="float:left; text-align:center; width: 111px;">
                        รหัสโครงงาน
                    </div>
                    <div style="float:left; text-align:center">
                        <asp:TextBox ID="PIDBox" runat="server" ReadOnly="True"></asp:TextBox>
                    </div>

                </td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                        <div class="a">ชื่อโครงงาน ภาษาไทย</div>
                        <div class="aa">
                            <asp:TextBox ID="PNameTH" runat="server" Width="421px" ReadOnly="True" Height="18px"></asp:TextBox>
                    </div>
                </td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                        <div class="a">
                            ชื่อโครงงาน ภาษาอังกฤษ</div>
                        <div class="aa">
                            <asp:TextBox ID="PNameENG" runat="server" Width="414px" ReadOnly="True" Height="21px"></asp:TextBox>
                    </div>
                        </td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" DataKeyNames="NO" Enabled="False">
                        <AlternatingRowStyle BackColor="PaleGoldenrod" />
                        <Columns>
                            <asp:BoundField DataField="NO" HeaderText="NO" InsertVisible="False" ReadOnly="True" SortExpression="NO" Visible="False" />
                            <asp:BoundField DataField="PID" HeaderText="PID" SortExpression="PID" Visible="False" />
                            <asp:BoundField DataField="date" HeaderText="วันที่" SortExpression="date" />
                            <asp:BoundField DataField="topic" HeaderText="ประเด็น/หัวข้อ/งานที่มอบหมาย" SortExpression="topic" />
                            <asp:BoundField DataField="conclude" HeaderText="ข้อสรุป/ความคืบหน้าของโครงงาน" SortExpression="conclude" />
                            <asp:BoundField DataField="note" HeaderText="หมายเหตุ" SortExpression="note" />
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
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Dbconnection %>" SelectCommand="SELECT NO, PID, date, topic, conclude, note FROM CPE02_data WHERE (PID = @PID)">
                        <SelectParameters>
                            <asp:SessionParameter Name="PID" SessionField="whatPID" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4"></td>
                <td class="auto-style5">
                    
                    <asp:Label ID="error3" runat="server" ForeColor="Red"></asp:Label>
                    
                    </td>
                <td class="auto-style4">
                    </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">&nbsp;
                    <div style="float:left; width: 231px;">
                        <asp:Label ID="Label3" runat="server" Text="ประเด็น/หัวข้อ/งานที่มอบหมาย"></asp:Label>
                    </div>
                    <div style="float:left; width: 235px;">
                        <asp:Label ID="Label4" runat="server" Text="ข้อสรุป/ความคืบหน้าของงาน"></asp:Label>
                    </div>
                    <div style="float:left">
                        <asp:Label ID="Label7" runat="server" Text="หมายเหตุ"></asp:Label>
                    </div>
                </td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    <div style="float:left;">                        
                    </div>
                </td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    <div style="float:left; width: 231px;">
                        <asp:TextBox ID="TextBox1" TextMode="MultiLine" runat="server" Font-Size="14px" Height="65px" Width="200px" ReadOnly="True" ></asp:TextBox>
    
                    </div>
                    <div style="float:left; width: 235px;">
                        <asp:TextBox ID="TextBox2" TextMode="MultiLine" runat="server" Font-Size="14px" Height="65px" Width="200px" ReadOnly="True" ></asp:TextBox>
                    </div>
                    <div style="float:left">
                        <asp:TextBox ID="TextBox3" TextMode="MultiLine" runat="server" Font-Size="14px" Height="65px" Width="123px" ReadOnly="True" ></asp:TextBox>
                    </div>
                </td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    <div>
                        <div style="float:left; text-align:right; width: 239px;">
                           
                            <asp:Button ID="Button1" runat="server" Text="อนุมัติ" Width="60px" OnClick="Button1_Click" />
                           
                        </div>
                        <div style="float:left; text-align:right; width: 132px; height: 21px;">
                            
                        </div>
                        <div style="float:left; text-align:left; width: 132px;">
                           
                            <asp:Button ID="Button2" runat="server" Text="ไม่อนุมัติ" Width="60px" OnClick="Button2_Click" />
                           
                        </div>
                    </div>
                    &nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
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
            Page 9</div>
    

    </body>
</html>
