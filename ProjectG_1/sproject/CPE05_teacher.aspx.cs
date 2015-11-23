using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sproject
{
    public partial class CPE05_teacher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = Session["loginName"].ToString();

            if (!IsPostBack)
            {
                isApprove();
                FillData();
            }
        }

        private void isApprove()
        {
            string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd3 = new SqlCommand("SELECT status FROM CPE05 WHERE PID=" + Session["whatPID"].ToString() + " ", con);
            SqlDataReader reader3 = cmd3.ExecuteReader();
            while (reader3.Read())
            {
                string stat = reader3["status"].ToString();
                if (stat == "wait")
                {
                    Button2.Enabled = true;
                    Button1.Enabled = true;
                    //checkStatus();
                }
                else if (stat == "approve" || stat == "reject")
                {
                    Button1.Enabled = false;
                    Button2.Enabled = false;
                }
            }
            con.Close();
        }

        private void FillData()
        {
            string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            con.Open();
            SqlDataAdapter dtAd;
            DataTable dt = new DataTable();
            int rowCount;

            dtAd = new SqlDataAdapter("SELECT s.SID,s.SName,s.STel,s.SEmail, p.* FROM student s JOIN project p on s.PID=p.PID JOIN CPE01 c ON c.PID=p.PID WHERE p.PID=" + Session["whatPID"] + " ", con);
            dtAd.Fill(dt);
            rowCount = dt.Rows.Count;
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Messagebox", "alert('" + rowCount.ToString() + "');", true);
            if (rowCount == 1)
            {
                SID1.ReadOnly = true;
                PNameTH.Text = dt.Rows[0]["PNameTH"].ToString();
                PNameENG.Text = dt.Rows[0]["PNameENG"].ToString();
                SID1.Text = dt.Rows[0]["SID"].ToString();
                SName1.Text = dt.Rows[0]["SName"].ToString();
                STel1.Text = dt.Rows[0]["STel"].ToString();
                SEmail1.Text = dt.Rows[0]["SEmail"].ToString();
            }
            else if (rowCount == 2)
            {
                SID1.ReadOnly = true;
                SID2.ReadOnly = true;
                PNameTH.Text = dt.Rows[0]["PNameTH"].ToString();
                PNameENG.Text = dt.Rows[0]["PNameENG"].ToString();
                SID1.Text = dt.Rows[0]["SID"].ToString();
                SID2.Text = dt.Rows[1]["SID"].ToString();
                SName1.Text = dt.Rows[0]["SName"].ToString();
                SName2.Text = dt.Rows[1]["SName"].ToString();
                STel1.Text = dt.Rows[0]["STel"].ToString();
                STel2.Text = dt.Rows[1]["STel"].ToString();
                SEmail1.Text = dt.Rows[0]["SEmail"].ToString();
                SEmail2.Text = dt.Rows[1]["SEmail"].ToString();
            }
            else if (rowCount == 3)
            {
                SID1.ReadOnly = true;
                SID2.ReadOnly = true;
                SID3.ReadOnly = true;
                PNameTH.Text = dt.Rows[0]["PNameTH"].ToString();
                PNameENG.Text = dt.Rows[0]["PNameENG"].ToString();
                SID1.Text = dt.Rows[0]["SID"].ToString();
                SID2.Text = dt.Rows[1]["SID"].ToString();
                SID3.Text = dt.Rows[2]["SID"].ToString();
                SName1.Text = dt.Rows[0]["SName"].ToString();
                SName2.Text = dt.Rows[1]["SName"].ToString();
                SName3.Text = dt.Rows[2]["SName"].ToString();
                STel1.Text = dt.Rows[0]["STel"].ToString();
                STel2.Text = dt.Rows[1]["STel"].ToString();
                STel3.Text = dt.Rows[2]["STel"].ToString();
                SEmail1.Text = dt.Rows[0]["SEmail"].ToString();
                SEmail2.Text = dt.Rows[1]["SEmail"].ToString();
                SEmail3.Text = dt.Rows[2]["SEmail"].ToString();
            }
            con.Close();
        }

        private void Addratio()
        {
            string s1 = "";
            string s2 = "";
            string s3 = "";
            string s4 = "";

            if (RadioButton1.Checked == true)
            {
                s1 = "เหมาะสม";
            }
            if (RadioButton3.Checked == true)
            {
                s2 = "เหมาะสม";
            }
            if (RadioButton5.Checked == true)
            {
                s3 = "เหมาะสม";
            }
            if (RadioButton7.Checked == true)
            {
                s4 = "เหมาะสม";
            }

            if (RadioButton2.Checked == true)
            {
                s1 = "ไม่เหมาะสม";
            }
            if (RadioButton4.Checked == true)
            {
                s2 = "ไม่เหมาะสม";
            }
            if (RadioButton6.Checked == true)
            {
                s3 = "ไม่เหมาะสม";
            }
            if (RadioButton8.Checked == true)
            {
                s4 = "ไม่เหมาะสม";
            }

            string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            int rowCount;
            SqlDataAdapter dtAd;
            DataTable dt = new DataTable();
            dtAd = new SqlDataAdapter("SELECT * FROM CPE05_data WHERE PID='" + Session["whatPID"] + "' ", con);
            dtAd.Fill(dt);
            rowCount = dt.Rows.Count;
            if (RadioButton1.Checked == false && RadioButton2.Checked == false)
            {
                //error1.Text = "กรุณากรอกผลการประเมิน";
            }
            else
            {
                if (rowCount == 0)
                {
                    SqlCommand com = new SqlCommand("INSERT INTO CPE05_data VALUES(" + Session["whatPID"] + ", '" + s1 + "', '" + s2 + "', '" + s3 + "', '" + s4 + "')", con);
                    com.ExecuteNonQuery();
                }
                else if (rowCount > 0)
                {
                    SqlCommand com2 = new SqlCommand("UPDATE CPE05_data SET PID= " + Session["whatPID"] + ", progress='" + s1 + "', completeness='" + s2 + "', knowledge='" + s3 + "', nteam='" + s4 + "' WHERE PID = '" + Session["whatPID"] + "'  ", con);
                    com2.ExecuteNonQuery();
                    con.Close();
                }
            }

        }

        private void AddCPE05()
        {
            string s = "";
            string PID = Session["whatPID"].ToString();
            string txtbox = TextBox1.Text;

            if (CheckBox5.Checked == true)
            { s = "ผ่าน"; }
            else if (CheckBox10.Checked == true)
            { s = "ไม่ผ่าน"; }

            string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            SqlDataAdapter dtAd;
            DataTable dt = new DataTable();
            int rowCount;

            dtAd = new SqlDataAdapter("SELECT * FROM CPE05 WHERE PID='" + PID + "' ", con);
            dtAd.Fill(dt);
            rowCount = dt.Rows.Count;
            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");

            if (TextBox1.Text != "")
            {
                if (CheckBox5.Checked == true || CheckBox10.Checked == true )
                {
                    if (rowCount == 0)
                    {
                        SqlCommand com = new SqlCommand("INSERT INTO CPE05 VALUES(" + PID + ", ' 5 ', 'wait', '" + date + "', '" + txtbox + "', '" + s + "')", con);
                        com.ExecuteNonQuery();
                    }
                    else if (rowCount > 0)
                    {
                        SqlCommand com2 = new SqlCommand("UPDATE CPE05 SET PID= " + PID + ",status='wait',date='" + date + "',Suggest='" + txtbox + "', conclude='" + s + "' WHERE PID = '" + PID + "' ", con);
                        com2.ExecuteNonQuery();

                        SqlCommand com1 = new SqlCommand("UPDATE HomeTeacher SET dateA='" + date + "' WHERE PID = '" + Session["whatPID"].ToString() + "' ", con);
                        com1.ExecuteNonQuery();
                    }
                    //error3.Text = "";
                    //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert(\"Success! ->Form4\");", true);
                }
                else
                { //error3.Text = "กรุณากรอกความเห็นของอาจารย์ผู้ประเมิณ"; 
                }
                //error2.Text = "";
            }
            else
            { //error2.Text = "กรุณากรอกข้อเสนอแนะ"; 
            }

        }

        protected void Button1_Click(object sender, EventArgs e)    //บันทึก
        {
            string checkStatus = Session["tStatus"].ToString();
            if (checkStatus == "0")
            {
                Addratio();
                AddCPE05();
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert(\"Success! ->Form5\");", true);
            }
            else if (checkStatus == "2")
            {
                AddCPE05();
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert(\"Success! ->Form5\");", true);
            } 
        }

        protected void LinkButton1_Click(object sender, EventArgs e)    //หน้าแรก
        {
            Response.Redirect("HomeTeacher.aspx");
        }

        protected void LinkButton2_Click1(object sender, EventArgs e)   //คำร้องขอ
        {
            Response.Redirect("Request.aspx");
        }

        protected void LinkButton3_Click1(object sender, EventArgs e)   //logout
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            // clear authentication cookie
            HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie1.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie1);

            // clear session cookie (not necessary for your current problem but i would recommend you do it anyway)
            HttpCookie cookie2 = new HttpCookie("ASP.NET_SessionId", "");
            cookie2.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie2);

            FormsAuthentication.RedirectToLoginPage();
            Response.Redirect("index.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)    //ยกเลิก
        {
            Response.Redirect("HomeTeacher.aspx");
        }   
    }
}