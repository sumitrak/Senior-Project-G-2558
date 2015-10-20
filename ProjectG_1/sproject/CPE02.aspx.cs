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
    public partial class CPE02 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {   
            Label1.Text = Session["loginName"].ToString();
            string Status02 = Session["SCPE02"].ToString();
            if(!IsPostBack)
            {
                autoFill();
                if (Status02 == "approve")
                {
                    Button1.Enabled = false;
                    Button2.Enabled = false;
                }
                else if (Status02 == "wait")
                {
                    Button1.Enabled = true;
                    Button2.Enabled = true;
                }
            }

        }

        private void autoFill()
        {
            string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM project WHERE PID='"+Session["sesPID"]+"' ", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                PIDBox.Text = reader["PID"].ToString();
                PNameTH.Text = reader["PNameTH"].ToString();
                PNameENG.Text = reader["PNameENG"].ToString();
            }
            con.Close();

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
        {
            string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            SqlDataAdapter dtAd;
            DataTable dt = new DataTable();
            int rowCount;

            dtAd = new SqlDataAdapter("SELECT * FROM CPE02 WHERE PID='"+Session["sesPID"]+"' ", con);
            dtAd.Fill(dt);
            rowCount = dt.Rows.Count;

            
                if (TextBox1.Text != "")
                {
                    if (TextBox2.Text != "")
                    {
                        if (TextBox3.Text != "")
                        {
                            if (rowCount == 0)
                            {
                                createProgress();
                                Response.Redirect("CPE02.aspx");
                            }
                            else if(rowCount > 0)
                            {
                                addProgress();
                                Response.Redirect("CPE02.aspx");
                            }
                        }
                        else { error3.Text = "กรุณาใส่ หมายเหตุ"; }
                    }
                    else { error3.Text = "กรุณาใส่ ข้อสรุป/ความคืบหน้า"; }
                }
                else { error3.Text = "กรุณาใส่ ประเด็น/หัวข้อ/งานที่มอบหมาย"; }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            SqlDataAdapter dtAd;
            DataTable dt = new DataTable();
            int rowCount;
            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");

            dtAd = new SqlDataAdapter("SELECT * FROM CPE02 WHERE PID='" + Session["sesPID"] + "' ", con);
            dtAd.Fill(dt);
            rowCount = dt.Rows.Count;

            if (rowCount == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Messagebox", "alert('ไม่สามารถส่งแบบฟอร์มที่ว่างเปล่าได้');", true);
            }
            else if (rowCount > 0)
            {
                con.Open();
                SqlCommand com44 = new SqlCommand("UPDATE CPE02 SET PID= " + Session["sesPID"] + ", FormNo='2', status='wait', date='" + date + "'  WHERE PID = '" + Session["sesPID"] + "' ", con);
                com44.ExecuteNonQuery();
                con.Close();

                con.Open();
                SqlCommand com4 = new SqlCommand(" INSERT INTO history VALUES(" + Session["sesPID"] + ", '" + PNameTH.Text + "', '2', '" + Session["loginSID"].ToString() + "', 'Edit', '" + date + "', 'wait' ) ", con);
                com4.ExecuteNonQuery();
                con.Close();
                Response.Redirect("HomeStudent.aspx");
            }

            Response.Redirect("ChooseForm.aspx");
        }

        private void createProgress()
        {
            string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");

            con.Open();
            SqlCommand com2 = new SqlCommand("INSERT INTO CPE02 VALUES('" + Session["sesPID"] + "', ' 2 ', 'wait', '" + date + "' )", con);
            com2.ExecuteNonQuery();
            con.Close();

            con.Open();
            SqlCommand com3 = new SqlCommand("INSERT INTO CPE02_data VALUES('" + Session["sesPID"] + "','"+date+"' , '" + TextBox1.Text + "', '" + TextBox2.Text + "', '" + TextBox3.Text + "' )", con);
            com3.ExecuteNonQuery();
            con.Close();

            con.Open();
            SqlCommand com4 = new SqlCommand(" INSERT INTO history VALUES(" + Session["sesPID"] + ", '" + PNameTH.Text + "', '2', '"+Session["loginSID"].ToString()+"' , 'Create', '" + date + "', 'wait' ) ", con);
            com4.ExecuteNonQuery();
            con.Close();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Messagebox", "alert('เพิ่ม 1 รายการใหม่');", true);
        }

        private void addProgress()
        {
            string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");

            con.Open();
            SqlCommand com3 = new SqlCommand("INSERT INTO CPE02_data VALUES('" + Session["sesPID"] + "','" + date + "' , '" + TextBox1.Text + "', '" + TextBox2.Text + "', '" + TextBox3.Text + "' )", con);
            com3.ExecuteNonQuery();
            con.Close();

            con.Open();
            SqlCommand com44 = new SqlCommand("UPDATE CPE02 SET PID= " + Session["sesPID"] + ", FormNo='2', status='wait', date='" + date + "'  WHERE PID = '" + Session["sesPID"] + "' ", con);
            com44.ExecuteNonQuery();
            con.Close();

            con.Open();
            SqlCommand com4 = new SqlCommand(" INSERT INTO history VALUES(" + Session["sesPID"] + ", '" + PNameTH.Text + "', '2', '" + Session["loginSID"].ToString() + "', 'Edit', '" + date + "', 'wait' ) ", con);
            com4.ExecuteNonQuery();
            con.Close();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Messagebox", "alert('เพิ่ม 1 รายการใหม่');", true);
        }
    }
}