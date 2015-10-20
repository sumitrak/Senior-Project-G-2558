<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CPE04.aspx.cs" Inherits="sproject.CPE04" %>

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
            width: 95px;
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


        
        .auto-style4 {
            width: 10%;
            height: 42px;
        }
        .auto-style5 {
            width: 80%;
            height: 42px;
        }


        
        .auto-style6 {
            width: 10%;
            height: 23px;
        }
        .auto-style7 {
            width: 80%;
            height: 23px;
        }


        
        .aa {
            float:left;
            width: 546px;
            text-align:center
        }


        
        .auto-style8 {
            width: 10%;
            height: 24px;
        }
        .auto-style9 {
            width: 80%;
            height: 24px;
        }


        
        .auto-style10 {
            width: 99%;
            background-color: #CCCCFF;
        }
        .auto-style11 {
            width: 528px;
            text-align: center;
        }
        .auto-style12 {
            text-align: center;
        }
        .auto-style13 {
            text-align: center;
            width: 117px;
        }
        .auto-style14 {
            width: 528px;
            text-align: left;
        }
        .auto-style15 {
            width: 528px;
            text-align: left;
            height: 23px;
        }
        .auto-style16 {
            text-align: center;
            width: 117px;
            height: 23px;
        }
        .auto-style17 {
            text-align: center;
            height: 23px;
        }
        .auto-style19 {
            width: 131px;
        }
        .auto-style20 {
            width: 130px;
        }
        .auto-style21 {
            width: 128px;
        }


        
        </style>
</head>
<body style="height: 1396px">
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
            <asp:LinkButton CssClass="x" ID="LinkButton2" runat="server" ForeColor="White" OnClick="LinkButton2_Click" >แบบฟอร์ม</asp:LinkButton>
           

            <div style="float:right; width:50%; height: 27px;">
                <div style="float:right; height:25px; width:20px;"></div>
                <div style="float:right; text-align:right; height: 23px;">
                     <asp:LinkButton CssClass="x" ID="LinkButton3" runat="server" ForeColor="White" OnClick="LinkButton3_Click1">ออกจากระบบ</asp:LinkButton>
                </div>


                <div style="float:right; height:25px; width:40px;"></div>

                <div style="float:right; text-align:right ">
                
                    <asp:Label ID="Label6" runat="server" ForeColor="Yellow" Text="สวัสดี! : "></asp:Label>
                    <asp:Label ID="Label1" runat="server" ForeColor="Yellow" Text=" NAME "></asp:Label>
                
                </div>

            </div>
            
        </div>

        

        <div style="height: 1216px">
    
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
                    <asp:Label ID="Label2" runat="server" Font-Size="X-Large" Text="CPE04 - แบบประเมินข้อเสนอโครงงาน"></asp:Label>
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
                <td class="auto-style2">ชื่อโครงงาน</td>
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
                        <div class="a">
                            ภาษาไทย</div>
                        <div class="aa">
                            <asp:TextBox ID="PNameTH" runat="server" Width="468px" ReadOnly="True"></asp:TextBox>
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
                            ภาษาอังกฤษ</div>
                        <div class="aa">
                            <asp:TextBox ID="PNameENG" runat="server" Width="468px" ReadOnly="True"></asp:TextBox>
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
                    <div style="float:left; width: 213px;">
                        <asp:Label ID="Label3" runat="server" Text="รายชื่อนิสิตผู้ทำโครงงาน"></asp:Label>
                    </div>
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
                <td class="auto-style5">&nbsp;
                    <div style="width: 100%">
                        <div class="a">
                            <asp:Label ID="Label4" runat="server" Text="ลำดับ"></asp:Label>
                        </div>
                        <div class="a">
                            <asp:Label ID="Label8" runat="server" Text="รหัสนิสิต"></asp:Label>
                        </div>
                        <div class="b">
                            <asp:Label ID="Label7" runat="server" Text="ชื่อ-นามสกุล"></asp:Label>
                        </div>                        
                        <div class="a">
                            <asp:Label ID="Label9" runat="server" Text="เบอร์โทร"></asp:Label>
                        </div>
                        <div class="b">
                            <asp:Label ID="Label10" runat="server" Text="อีเมลล์"></asp:Label>
                        </div>                        
                    </div>
                </td>
                <td class="auto-style4">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    <div style="float:left; width: 626px;">
                        <div class="a">
                            <asp:Label ID="Label11" runat="server" Text="1"></asp:Label>
                        </div>
                        <div class="a">
                            <asp:TextBox ID="SID1" runat="server" Width="90px" ReadOnly="True"></asp:TextBox>
                        </div>
                        <div class="b">
                            <asp:TextBox ID="SName1" runat="server" Width="147px" ReadOnly="True"></asp:TextBox>
                        </div>                        
                        <div class="a">
                            <asp:TextBox ID="STel1" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
                        </div>
                        <div class="b">
                            <asp:TextBox ID="SEmail1" runat="server" ReadOnly="True"></asp:TextBox>
                        </div>
                    </div>
                    <div style="float:left;">
                    </div>
                </td>
                <td class="auto-style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    <div style="float:left; width: 626px;">
                        <div class="a">
                            <asp:Label ID="Label13" runat="server" Text="2"></asp:Label>
                        </div>
                        <div class="a">                            
                            <asp:TextBox ID="SID2" runat="server" Width="90px" ReadOnly="True" ></asp:TextBox>
                        </div>
                        <div class="b">
                            <asp:TextBox ID="SName2" runat="server" Width="147px" ReadOnly="True"></asp:TextBox>
                        </div> 
                        <div class="a">
                            <asp:TextBox ID="STel2" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
                        </div>
                        <div class="b">
                            <asp:TextBox ID="SEmail2" runat="server" ReadOnly="True"></asp:TextBox>
                        </div>
                        
                    </div>
                    <div style="float:left;">
                    </div>
                </td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    <div style="float:left; width: 626px;">
                        <div class="a">
                            <asp:Label ID="Label18" runat="server" Text="3"></asp:Label>
                        </div>
                       <div class="a">
                            <asp:TextBox ID="SID3" runat="server" Width="90px" ReadOnly="True" ></asp:TextBox>
                        </div>
                        <div class="b">
                            <asp:TextBox ID="SName3" runat="server" Width="147px" ReadOnly="True"></asp:TextBox>
                        </div> 
                        <div class="a">
                            <asp:TextBox ID="STel3" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
                        </div>
                        <div class="b">
                            <asp:TextBox ID="SEmail3" runat="server" ReadOnly="True"></asp:TextBox>
                        </div>
                    </div>
                    <div style="float:left;">                        
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
                    <asp:Label ID="Label20" runat="server" Text="ผลการประเมิน"></asp:Label>
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
                    <table class="auto-style10">
                        <tr>
                            <td class="auto-style11">หัวข้อการประเมิน</td>
                            <td class="auto-style13">เหมาะสม</td>
                            <td class="auto-style12">ไม่เหมาะสม</td>
                        </tr>
                        <tr>
                            <td class="auto-style14">1.&nbsp; จำนวนนิสิตที่ทำโครงงาน</td>
                            <td class="auto-style13">
                                <input id="Radio1" type="radio" /></td>
                            <td class="auto-style12">
                                <input id="Radio7" type="radio" /></td>
                        </tr>
                        <tr>
                            <td class="auto-style14">2.&nbsp; ที่มาและความสำคัญของปัญหา</td>
                            <td class="auto-style13">
                                <input id="Radio2" type="radio" /></td>
                            <td class="auto-style12">
                                <input id="Radio8" type="radio" /></td>
                        </tr>
                        <tr>
                            <td class="auto-style15">3.&nbsp; วัตถุประสงค์ของโครงงาน</td>
                            <td class="auto-style16">
                                <input id="Radio3" type="radio" /></td>
                            <td class="auto-style17">
                                <input id="Radio9" type="radio" /></td>
                        </tr>
                        <tr>
                            <td class="auto-style14">4.&nbsp; การศึกษาเกี่ยวกับหลักการและทฤษฎีที่เกียวข้อง </td>
                            <td class="auto-style13">&nbsp;<input id="Radio4" type="radio" /></td>
                            <td class="auto-style12">
                                <input id="Radio10" type="radio" /></td>
                        </tr>
                        <tr>
                            <td class="auto-style14">5.&nbsp; ความเหมาะสมของวิธีการดำเนินงานที่นำเสนอ</td>
                            <td class="auto-style13">
                                <input id="Radio5" type="radio" /></td>
                            <td class="auto-style12">
                                <input id="Radio11" type="radio" /></td>
                        </tr>
                        <tr>
                            <td class="auto-style14">6.&nbsp; ขอบเขตการศึกษา</td>
                            <td class="auto-style13">
                                <input id="Radio6" type="radio" /></td>
                            <td class="auto-style12">
                                <input id="Radio12" type="radio" /></td>
                        </tr>
                    </table>
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
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">ข้อเสนอแนะ</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBox1" runat="server" Height="119px" Width="689px"></asp:TextBox>
                </td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6"></td>
                <td class="auto-style7">
                    &nbsp;</td>
                <td class="auto-style6"></td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    สรุป</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    <table class="auto-style10">
                        <tr>
                            <td colspan="3" style="text-align: center">ความเห็นของอาจารย์ผู้ประเมิณ</td>
                            <td colspan="3" style="text-align: center">มติกรรมการ</td>
                        </tr>
                        <tr>
                            <td class="auto-style20">
                                <asp:CheckBox ID="CheckBox1" runat="server" Text="ผ่าน" />
                            </td>
                            <td class="auto-style19">
                                <asp:CheckBox ID="CheckBox2" runat="server" Text="สมควรแก้ใหม่" />
                            </td>
                            <td class="auto-style20">
                                <asp:CheckBox ID="CheckBox5" runat="server" Text="ไม่ผ่าน" />
                            </td>
                            <td class="auto-style21">
                                <asp:CheckBox ID="CheckBox6" runat="server" Text="ผ่าน" />
                            </td>
                            <td class="auto-style19">
                                <asp:CheckBox ID="CheckBox7" runat="server" Text="สมควรแก้ใหม่" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBox10" runat="server" Text="ไม่ผ่าน" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style20">&nbsp;</td>
                            <td class="auto-style19">
                                <asp:CheckBox ID="CheckBox3" runat="server" Text="สอบใหม่" />
                            </td>
                            <td class="auto-style20">&nbsp;</td>
                            <td class="auto-style21">&nbsp;</td>
                            <td class="auto-style19">
                                <asp:CheckBox ID="CheckBox8" runat="server" Text="สมควรแก้ใหม่" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style20">&nbsp;</td>
                            <td class="auto-style19">
                                <asp:CheckBox ID="CheckBox4" runat="server" Text="ไม่ต้องสอบใหม่" />
                            </td>
                            <td class="auto-style20">&nbsp;</td>
                            <td class="auto-style21">&nbsp;</td>
                            <td class="auto-style19">
                                <asp:CheckBox ID="CheckBox9" runat="server" Text="ไม่ต้องสอบใหม่" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    <div>
                        </div> 
                    &nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    <div style="height: 32px; text-align: center">
                        <div style="float:left; text-align:center; width: 239px;">
                           
                            <asp:Button ID="Button1" runat="server" Text="ส่ง" Width="60px"  />
                           
                        </div>
                        <div style="float:left; text-align:center; width: 132px; height: 21px;">
                            
                        </div>
                        <div style="float:left; text-align:left; width: 132px;">
                           
                            <asp:Button ID="Button2" runat="server" Text="ยกเลิก" Width="60px"  />
                           
                        </div>&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8"></td>
                <td class="auto-style9"></td>
                <td class="auto-style8"></td>
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
            Page 12</div>
    

    </body>
</html>