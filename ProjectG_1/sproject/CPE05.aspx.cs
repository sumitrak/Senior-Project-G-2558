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
    public partial class CPE05 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = Session["loginName"].ToString();

            if (!IsPostBack)
            {
                isApprove();
                FillData();
                Fillradio();
                FillCPE05();
            }
        }

        private void isApprove()
        {
            string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd3 = new SqlCommand("SELECT status FROM CPE05 WHERE PID=" + Session["sesPID"].ToString() + " ", con);
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

            dtAd = new SqlDataAdapter("SELECT s.SID,s.SName,s.STel,s.SEmail, p.* FROM student s JOIN project p on s.PID=p.PID JOIN CPE01 c ON c.PID=p.PID WHERE p.PID=" + Session["sesPID"] + " ", con);
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

        private void Fillradio()
        {
            string s1 = "";
            string s2 = "";
            string s3 = "";
            string s4 = "";
            string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            string query = "select * from CPE05_data where PID = '" + Session["sesPID"] + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                s1 = dr[1].ToString();
                s2 = dr[2].ToString();
                s3 = dr[3].ToString();
                s4 = dr[4].ToString();
            }
            dr.Close();
            con.Close();

            if (s1 == "เหมาะสม")
            {
                RadioButton1.Checked = true;
            }
            else if (s1 == "ไม่เหมาะสม")
            { RadioButton2.Checked = true; }
            if (s2 == "เหมาะสม")
            {
                RadioButton3.Checked = true;
            }
            else if (s2 == "ไม่เหมาะสม")
            { RadioButton4.Checked = true; }
            if (s3 == "เหมาะสม")
            {
                RadioButton5.Checked = true;
            }
            else if (s3 == "ไม่เหมาะสม")
            { RadioButton6.Checked = true; }
            if (s4 == "เหมาะสม")
            {
                RadioButton7.Checked = true;
            }
            else if (s4 == "ไม่เหมาะสม")
            { RadioButton8.Checked = true; }

        }

        private void FillCPE05()
        {
            string s2 = "";
            string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            string query = "select * from CPE05 where PID = '" + Session["sesPID"] + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                TextBox1.Text = dr[4].ToString();
                s2 = dr[5].ToString();
            }
            dr.Close();
            con.Close();

            if (s2 == "ผ่าน")
            { CheckBox5.Checked = true; }
            else if (s2 == "ไม่ผ่าน")
            { CheckBox10.Checked = true; }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)    //Home
        {
            Response.Redirect("HomeStudent.aspx");
        }

        protected void LinkButton2_Click1(object sender, EventArgs e)   
        {
            Response.Redirect("ChooseForm.aspx");
        }

        protected void LinkButton3_Click1(object sender, EventArgs e)   //Logout
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

        protected void Button1_Click(object sender, EventArgs e)    //ส่ง
        {
            string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");

            con.Open();
            bool isAllApprove = false;
            SqlCommand cmddd = new SqlCommand("SELECT * FROM CPE05 WHERE  PID = '" + Session["sesPID"].ToString() + "' ", con);
            SqlDataReader reader = cmddd.ExecuteReader();
            while (reader.Read())
            {
                if (reader["conclude"].ToString() == "ผ่าน")
                {
                    isAllApprove = true;
                }
                else
                {
                    error3.Text = "ความเห็นอาจารย์ ต้องผ่านเท่านั้น";
                }
            }
            con.Close();

            if (isAllApprove == true)
            {
                con.Open();
                SqlCommand com = new SqlCommand("UPDATE CPE05 SET status='approve' WHERE PID = '" + Session["sesPID"].ToString() + "' ", con);
                com.ExecuteNonQuery();
                con.Close();

                con.Open();
                SqlCommand com3 = new SqlCommand(" INSERT INTO CPE06 VALUES(" + Session["sesPID"] + ",'6','wait','" + date + "','','') ", con);
                com3.ExecuteNonQuery();
                con.Close();
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert(\"Success! ->Form5\");", true);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChooseForm.aspx");
        }
    }
}