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
    public partial class CPE03 : System.Web.UI.Page
    {
        public bool haveForm3 = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = Session["loginName"].ToString();

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Messagebox", "alert('" + Session["loginSID"].ToString() + "');", true);
            if (!IsPostBack)
            {
                FillDropDownList();
                FillData();
                haveForm();
            }

            if(haveForm3 == true)
            {
                string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);

                con.Open();

                SqlCommand com2 = new SqlCommand("SELECT * FROM CPE03 WHERE PID='" + Session["sesPID"] + "' ", con);
                SqlDataReader reader = com2.ExecuteReader();
                while(reader.Read())
                {
                    TextBox1.Text = reader["scope"].ToString();
                }

                con.Close();            
            }

           // ScriptManager.RegisterStartupScript(this, this.GetType(), "Messagebox", "alert('"+haveForm3.ToString()+"');", true);
        }

        private void FillDropDownList()
        {
            string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT TName, username FROM teacher", con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                DropDownList1.Items.Add(new ListItem(reader["TName"].ToString(), reader["username"].ToString()));
                DropDownList2.Items.Add(new ListItem(reader["TName"].ToString(), reader["username"].ToString()));
                DropDownList3.Items.Add(new ListItem(reader["TName"].ToString(), reader["username"].ToString()));

            }
            reader.Close();
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

            con.Open();
            SqlCommand cmd3 = new SqlCommand("SELECT * FROM project p WHERE p.PID=" + Session["sesPID"] + " ", con);
            SqlDataReader reader3 = cmd3.ExecuteReader();
            while (reader3.Read())
            {
                DropDownList1.SelectedValue = reader3["committee1ID"].ToString();
                DropDownList2.SelectedValue = reader3["committee2ID"].ToString();
                DropDownList3.SelectedValue = reader3["committee3ID"].ToString();
            }
            con.Close();

        }

        private void haveForm()
        {
            string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            SqlDataAdapter dtAd;
            DataTable dt = new DataTable();
            int rowCount;

            dtAd = new SqlDataAdapter("SELECT * FROM CPE03 WHERE PID='" + Session["sesPID"] + "' ", con);
            dtAd.Fill(dt);
            rowCount = dt.Rows.Count;

            if (rowCount == 0)
            {
                haveForm3 = false;
            }
            else if (rowCount > 0)
            {
                haveForm3 = true;
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

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {//บันทึก
            haveForm();
            if (haveForm3 == false)
            {
                if (TextBox1.Text != "")
                {
                    createForm();                    
                    Response.Redirect("HomeStudent.aspx");
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Messagebox", "alert('ส่งแบบฟอร์มแล้ว');", true);
                }
                else
                {
                    error2.Text = "กรุณาใส่ประเด็นปัญหาและขอบเขตของโครงงาน";
                }
            }
            else if (haveForm3 == true)
            {
                updateForm();
                Response.Redirect("HomeStudent.aspx");
            }
            
        }

        private void updateForm()
        {
            string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");

            SqlCommand com2 = new SqlCommand("UPDATE CPE03 SET PID= " + Session["sesPID"] + ", FormNo='3', status='wait', date='" + date + "', scope='"+TextBox1.Text+"'  WHERE PID = '" + Session["sesPID"] + "'  ", con);
            com2.ExecuteNonQuery();

            SqlCommand com33 = new SqlCommand("INSERT INTO history VALUES(" + Session["sesPID"] + ", '" + PNameTH.Text + "', '3', '" + Session["loginSID"].ToString() + "', 'Edit', '" + date + "', 'wait'  )", con);
            com33.ExecuteNonQuery();

            con.Close();
        }

        private void createForm()
        {
            string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");

            SqlCommand com2 = new SqlCommand("INSERT INTO CPE03 VALUES(" + Session["sesPID"] + ", ' 3 ', 'wait', '" + date + "', '" + TextBox1.Text + "', '0', '0', '0' )", con);
            com2.ExecuteNonQuery();

            SqlCommand com33 = new SqlCommand("INSERT INTO history VALUES(" + Session["sesPID"] + ", '" + PNameTH.Text + "', '3', '" + Session["loginSID"].ToString() + "', 'Create', '" + date + "', 'wait'  )", con);
            com33.ExecuteNonQuery();

            con.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {//ส่ง
            string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            SqlDataAdapter dtAd;
            DataTable dt = new DataTable();
            int rowCount;
            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");

            dtAd = new SqlDataAdapter("SELECT * FROM CPE03 WHERE PID='" + Session["sesPID"] + "' ", con);
            dtAd.Fill(dt);
            rowCount = dt.Rows.Count;

            if (rowCount == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Messagebox", "alert('ไม่สามารถส่งแบบฟอร์มที่ว่างเปล่าได้');", true);
            }
            else if (rowCount > 0)
            {
                con.Open();
                SqlCommand com44 = new SqlCommand("UPDATE CPE03 SET PID= " + Session["sesPID"] + ", FormNo='3', status='wait', date='" + date + "',scope='" + TextBox1.Text + "'  WHERE PID = '" + Session["sesPID"] + "' ", con);
                com44.ExecuteNonQuery();
                con.Close();

                con.Open();
                SqlCommand com4 = new SqlCommand(" INSERT INTO history VALUES(" + Session["sesPID"] + ", '" + PNameTH.Text + "', '3', '" + Session["loginSID"].ToString() + "', 'Edit', '" + date + "', 'wait' ) ", con);
                com4.ExecuteNonQuery();
                con.Close();

                con.Open();
                SqlCommand com3 = new SqlCommand(" INSERT INTO CPE04 VALUES(" + Session["sesPID"] + ",'4','wait','" + date + "','0','0','0') ", con);
                com3.ExecuteNonQuery();
                con.Close();
                Response.Redirect("HomeStudent.aspx");
            }

            Response.Redirect("ChooseForm.aspx");
        }
    }
}