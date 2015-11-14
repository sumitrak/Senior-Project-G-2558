using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace sproject
{
    public partial class CPE04 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = Session["loginName"].ToString();
            string Status04 = Session["SCPE04"].ToString();
            FillData();
            Fillradio();
            FillCPE04();

            if (Status04 == "approve")
            {
                Button1.Enabled = false;
                Button2.Enabled = false;
            }
            else if (Status04 == "wait")
            {
                Button1.Enabled = true;
                Button2.Enabled = true;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomeStudent.aspx");
        }
         
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChooseForm.aspx");
        }

        protected void LinkButton3_Click1(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
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
            string s4 = "", s5 = "", s6 = "";
            string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            string query = "select * from CPE04_data where PID = '" + Session["sesPID"] + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                s1 = dr[1].ToString();
                s2 = dr[2].ToString();
                s3 = dr[3].ToString();
                s4 = dr[4].ToString();
                s5 = dr[5].ToString();
                s6 = dr[6].ToString();
            }
            dr.Close();
            con.Close();

            if(s1=="เหมาะสม")
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
            if (s5 == "เหมาะสม")
            {
                RadioButton9.Checked = true;
            }
            else if (s5 == "ไม่เหมาะสม")
            { RadioButton10.Checked = true; }
            if (s6 == "เหมาะสม")
            {
                RadioButton11.Checked = true;
            }
            else if (s6 == "ไม่เหมาะสม")
            { RadioButton12.Checked = true; }
        }

        private void FillCPE04()
        {
            string s2 = "";
            string s3 = "";
            string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            string query = "select * from CPE04 where PID = '" + Session["sesPID"] + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                TextBox1.Text = dr[4].ToString();
                s2 = dr[5].ToString();
                s3 = dr[6].ToString();
            }
            dr.Close();
            con.Close();

            if (s2 == "ผ่าน")
            { CheckBox1.Checked = true; }   
            else if (s2 == "สมควรแก้ใหม่")
            { CheckBox2.Checked = true; }
            else if (s2 == "สอบใหม่")
            { CheckBox3.Checked = true; }
            else if (s2 == "ไม่ต้องสอบใหม่")
            { CheckBox4.Checked = true; }
            else if (s2 == "ไม่ผ่าน")
            { CheckBox5.Checked = true; }

            if (s3 == "ผ่าน")
            { CheckBox6.Checked = true; }
            else if (s3 == "สมควรแก้ใหม่")
            { CheckBox7.Checked = true; }
            else if (s3 == "สอบใหม่")
            { CheckBox8.Checked = true; }
            else if (s3 == "ไม่ต้องสอบใหม่")
            { CheckBox9.Checked = true; }
            else if (s3 == "ไม่ผ่าน")
            { CheckBox10.Checked = true; }

            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChooseForm.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            //string whatCommit = Session["whatCommittee"].ToString();
            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");

            con.Open();
            bool isAllApprove = false;
            SqlCommand cmddd = new SqlCommand("SELECT * FROM CPE04 WHERE  PID = '" + Session["sesPID"].ToString() + "' ", con);
            SqlDataReader reader = cmddd.ExecuteReader();
            while (reader.Read())
            {
                if (reader["StatusA"].ToString() == "ผ่าน" && reader["StatusC"].ToString() == "ผ่าน")
                {
                    isAllApprove = true;
                }
                else
                {
                    error3.Text = "ความเห็นอาจารย์ หรือมติกรรมต้องผ่านทั้ง2ท่าน";
                }
            }
            con.Close();

            if (isAllApprove == true)
            {
                con.Open();
                SqlCommand com = new SqlCommand("UPDATE CPE04 SET status='approve' WHERE PID = '" + Session["sesPID"].ToString() + "' ", con);
                com.ExecuteNonQuery();
                con.Close();

                con.Open();
                SqlCommand com3 = new SqlCommand(" INSERT INTO CPE05 VALUES(" + Session["sesPID"] + ",'5','wait','" + date + "','','') ", con);
                com3.ExecuteNonQuery();
                con.Close();
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert(\"Success! ->Form4\");", true);
            }
        }


    }
}