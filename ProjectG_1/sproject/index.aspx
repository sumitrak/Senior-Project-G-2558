<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="sproject.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.3.0/jquery.min.js"></script>
    <script type="text/javascript">                
        $(document).ready(function () {            
            $.ajaxSetup({
                cache:false,
                dataType:"html",
                error:function(xhr,status,error) {
                    alert('An error occured: '+error);
                },
                timeout:30000,
                type:"GET",
                beforeSend:function() {
                    console.log('In Ajax complete function');
                }
            });
            $("#LinkButton2").click(function (e) {
                e.preventDefault();
                $.ajax({
                    url:"about.aspx",
                    success:function(data){
                        $("#contentArea").html("").append(data);
                    }
                });
            });
        });
    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            $.ajaxSetup({
                cache: false,
                dataType: "html",
                error: function (xhr, status, error) {
                    alert('An error occured: ' + error);
                },
                timeout: 30000,
                type: "GET",
                beforeSend: function () {
                    console.log('In Ajax complete function');
                }
            });
            $("#LinkButton3").click(function (e) {
                e.preventDefault();
                $.ajax({
                    url: "allProject.aspx",
                    success: function (data) {
                        $("#contentArea").html("").append(data);
                    }
                });
            });
        });
    </script>


    <style>

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
            background-color: #F7F7F7;
        }

        
        </style>
</head>
<body style="height: 605px">
    <form id="form1" runat="server">
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
    

        <div class="menu">
            <div style="height: 7px"></div>
            <div class="x" style="width: 85px; height: 25px;">
            </div>
            <asp:LinkButton CssClass="x" ID="LinkButton1" runat="server" ForeColor="White" Width="86px" OnClick="LinkButton1_Click">หน้าแรก</asp:LinkButton>
            <asp:LinkButton CssClass="x" ID="LinkButton3" runat="server" ForeColor="White"  Width="141px" >โครงงานทั้งหมด</asp:LinkButton>
            <asp:LinkButton CssClass="x" ID="LinkButton2" runat="server" ForeColor="White">ติดต่อเรา</asp:LinkButton>
        </div>

        <div id="contentArea" class="body">

        <div style="height: 80px; ">
            <br />
            <br />
            <div style="float: left; width: 303px; height: 35px;"></div>
            <asp:Label ID="checkLogin" runat="server" ForeColor="Red"></asp:Label>
            </div>
        <div style="height: 228px">

                 <div>
                     <div style="float: left; width: 303px; height: 35px;"></div>
                     <div style="float: left; width: 81px;">
                         <asp:Label ID="Label3" runat="server" Text="ชื่อผู้ใช้"></asp:Label>
                     </div>
                        <asp:TextBox ID="IDBox" runat="server"></asp:TextBox>

                 </div>
            <div style="height: 41px"></div>
                 <div>
                     <div style="float: left; width: 300px; height: 40px;"></div>
                     <div style="float: left; width: 83px;">
                         <asp:Label ID="Label4" runat="server" Text="รหัสผ่าน"></asp:Label>
                     </div>
                        <asp:TextBox ID="PWBox" runat="server" TextMode="Password"></asp:TextBox>

                 </div>
            <div style="height: 57px"></div>
            <div>
                <div style="float: left; width: 321px; height: 25px;">&nbsp;</div>
                 <div style="float: left; width: 129px;"> 
                 <asp:Button BackColor="#1e90ff" Font-Size="Medium" Font-Bold ForeColor="White" ID="Button1" runat="server" Text="เข้าสู่ระบบ" Width="90px" Height="34px" OnClick="Button1_Click1" />
                </div>
                <asp:Button BackColor="Chocolate" Font-Size="Medium" Font-Bold ForeColor="White" ID="Button2" runat="server" Text="สมัคร" Width="90px" Height="34px" OnClick="Button2_Click" />
                 </div>

        </div>
        </div>

        <div class="footer">

            <br />
            Copyright © 2015 By Kitchen Line
            <br />
&nbsp;AND&nbsp; G , Naresuan University<br />
    </div>

        

    </form>
    
        <div style="text-align: right; height: 28px;">
            Page 1</div>
    
        </body>
</html>
