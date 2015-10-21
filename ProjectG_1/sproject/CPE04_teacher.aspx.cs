using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sproject
{
    public partial class CPE04_teacher : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = Session["LoginName"].ToString();
            if (!IsPostBack)
            {
                FillData();
                Fillradio();
                FillCPE04();
                whatCheck();
            }
            string s = Session["whatPID"].ToString();
            Session["sesPID"] = s;
            
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomeTeacher.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Request.aspx");
        }

        protected void LinkButton3_Click1(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
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

            string query = "select * from CPE04_data where PID = '" + Session["whatPID"] + "' ";
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

            string query = "select * from CPE04 where PID = '" + Session["whatPID"] + "' ";
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

        private void Addratio()
        {
            string s1 = "";
            string s2 = "";
            string s3 = "";
            string s4 = "", s5 = "", s6 = "";
            string PID = "";
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
            if (RadioButton9.Checked == true)
            {
                s5 = "เหมาะสม";
            }
            if (RadioButton11.Checked == true)
            {
                s6 = "เหมาะสม";
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
            if (RadioButton10.Checked == true)
            {
                s5 = "ไม่เหมาะสม";
            }
            if (RadioButton12.Checked == true)
            {
                s6 = "ไม่เหมาะสม";
            }

            string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            int rowCount;

            SqlDataAdapter dtAd;
            DataTable dt = new DataTable();
            dtAd = new SqlDataAdapter("SELECT * FROM CPE04_data WHERE PID='" + Session["whatPID"] + "' ", con);
            dtAd.Fill(dt);
            rowCount = dt.Rows.Count;

            if (rowCount == 0)
            {
                SqlCommand com = new SqlCommand("INSERT INTO CPE04_data VALUES(" + Session["whatPID"] + ", '" + s1 + "', '" + s2 + "', '" + s3 + "', '" + s4 + "', '" + s5 + "', '" + s6 + "')", con);
                com.ExecuteNonQuery(); 
            }
            else if (rowCount >0 )
            {
                SqlCommand com2 = new SqlCommand("UPDATE CPE04_data SET PID= " + Session["whatPID"] + ", NStudent='" + s1 + "', Provenance='" + s2 + "', Purpose='" + s3 + "', Theore='" + s4 + "',Convenience='" + s5 + "',scope='" + s6 + "' WHERE PID = '" + Session["whatPID"] + "'  ", con);
                com2.ExecuteNonQuery();
                con.Close(); 
            }
   
        }

        private void AddCPE04()
        {
            string s = "";
            string a = "";
            string PID = Session["whatPID"].ToString();
            string txtbox = TextBox1.Text; 

            if (CheckBox1.Checked == true )
            {s = "ผ่าน";} 
            else if (CheckBox2.Checked == true )
            {s = "สมควรแก้ใหม่"; }
            else if (CheckBox3.Checked == true )
            {s = "สอบใหม่";}
            else if (CheckBox4.Checked == true )
            {s = "ไม่ต้องสอบใหม่"; }
            else if (CheckBox5.Checked == true )
            {s = "ไม่ผ่าน";}

            if (CheckBox6.Checked == true)
            { a = "ผ่าน"; }
            else if (CheckBox7.Checked == true)
            { a = "สมควรแก้ใหม่"; }
            else if (CheckBox8.Checked == true)
            { a = "สอบใหม่"; }
            else if (CheckBox9.Checked == true)
            { a = "ไม่ต้องสอบใหม่"; }
            else if (CheckBox10.Checked == true)
            { a = "ไม่ผ่าน"; }
            

            string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            SqlDataAdapter dtAd;
            DataTable dt = new DataTable();
            int rowCount;

            dtAd = new SqlDataAdapter("SELECT * FROM CPE04 WHERE PID='" + PID + "' ", con);
            dtAd.Fill(dt);
            rowCount = dt.Rows.Count;
            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");

            if (TextBox1.Text != "")
            {
                if (CheckBox1.Checked == true || CheckBox2.Checked == true || CheckBox3.Checked == true || CheckBox4.Checked == true || CheckBox5.Checked == true)
                {
                        if (rowCount == 0)
                        {
                            SqlCommand com = new SqlCommand("INSERT INTO CPE04 VALUES(" + PID + ", ' 4 ', 'wait', '" + date + "', '" + txtbox + "', '" + s + "')", con);
                            com.ExecuteNonQuery();                          
                        }
                        else if (rowCount > 0)
                        {
                            SqlCommand com2 = new SqlCommand("UPDATE CPE04 SET PID= " + PID + ",date='" + date + "',Suggest='" + txtbox + "', StatusA='" + s + "' WHERE PID = '" + PID + "' ", con);
                            com2.ExecuteNonQuery();
                        }
                }
                else
                { error3.Text = "กรุณากรอกความเห็นของอาจารย์ผู้ประเมิณ"; }
            }
            else
            { error2.Text = "กรุณากรอกข้อเสนอแนะ"; }

            if (CheckBox6.Checked == true || CheckBox7.Checked == true || CheckBox8.Checked == true || CheckBox9.Checked == true || CheckBox10.Checked == true)
            {
                SqlCommand com3 = new SqlCommand("UPDATE CPE04 SET PID= " + PID + ",date='" + date + "', StatusC='" + a + "' WHERE PID = '" + PID + "' ", con);
                com3.ExecuteNonQuery();
                
            }

        }

        private void whatCheck()
        { 
            string checkStatus = Session["tStatus"].ToString();

            if (checkStatus == "0")
            {
                CheckBox6.Enabled = false;
                CheckBox7.Enabled = false;
                CheckBox8.Enabled = false;
                CheckBox9.Enabled = false;
                CheckBox10.Enabled = false;

            }
            else if (checkStatus == "2")
            {
                TextBox1.Enabled = false;
                RadioButton1.Enabled = false; RadioButton2.Enabled = false;
                RadioButton3.Enabled = false; RadioButton4.Enabled = false;
                RadioButton5.Enabled = false; RadioButton6.Enabled = false;
                RadioButton7.Enabled = false; RadioButton8.Enabled = false;
                RadioButton9.Enabled = false; RadioButton10.Enabled = false;
                RadioButton11.Enabled = false; RadioButton12.Enabled = false;
                CheckBox1.Enabled = false;
                CheckBox2.Enabled = false;
                CheckBox3.Enabled = false;
                CheckBox4.Enabled = false;
                CheckBox5.Enabled = false;
            }
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomeTeacher.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string checkStatus = Session["tStatus"].ToString();
            if (checkStatus == "0")
            {
                Addratio();
                AddCPE04();
            }
            else if (checkStatus == "2")
            {
                AddCPE04();
            }
          
        }

        
    }
}