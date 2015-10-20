using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sproject
{
    public partial class CPE02_teacher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = Session["loginName"].ToString();
            
            if (!IsPostBack)
            {
                autoFill();
                isApprove();   
            }
            
        }

        private void checkStatus()
        {
            string checkStatus = Session["tStatus"].ToString();
            if (checkStatus == "0" || checkStatus == "1")
            {
                Button1.Enabled = true;
                Button2.Enabled = true;
            }
            if (checkStatus == "2")
            {
                Button1.Enabled = false;
                Button2.Enabled = false;
            }
            else if (checkStatus == "3")
            {
                Button1.Enabled = false;
                Button2.Enabled = false;
            }
        }

        private void isApprove()
        {
            string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd3 = new SqlCommand("SELECT status FROM CPE02 WHERE PID=" + Session["whatPID"].ToString() + " ", con);
            SqlDataReader reader3 = cmd3.ExecuteReader();
            while (reader3.Read())
            {
                string stat = reader3["status"].ToString();
                if (stat == "wait")
                {
                    //Button1.Enabled = true;
                    checkStatus();
                }
                else if (stat == "approve" || stat == "reject")
                {
                    Button1.Enabled = false;
                    Button2.Enabled = false;
                }
            }
            con.Close();
        }

        private void autoFill()
        {
            string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM project WHERE PID='" + Session["whatPID"] + "' ", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                PIDBox.Text = reader["PID"].ToString();
                PNameTH.Text = reader["PNameTH"].ToString();
                PNameENG.Text = reader["PNameENG"].ToString();
            }
            con.Close();

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomeTeacher.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Request.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");

            SqlCommand com3 = new SqlCommand("UPDATE CPE02 SET status= 'reject' WHERE PID = '" + Session["whatPID"].ToString() + "' ", con);
            com3.ExecuteNonQuery();
            con.Close();

            con.Open();
            SqlCommand com1 = new SqlCommand("INSERT INTO history VALUES(" + Session["whatPID"].ToString() + ", '" + PNameTH.Text + "', '2', '" + Session["loginSID"].ToString() + "', 'Reject', '" + date + "', 'reject'  )", con);
            com1.ExecuteNonQuery();

            con.Close();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Messagebox", "alert('ตรวจโครงงานเรีบยร้อย');", true);
            Response.Redirect("CPE02_teacher.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");

            SqlCommand com3 = new SqlCommand("UPDATE CPE02 SET status= 'approve' WHERE PID = '" + Session["whatPID"].ToString() + "' ", con);
            com3.ExecuteNonQuery();
            con.Close();

            con.Open();
            SqlCommand com1 = new SqlCommand("INSERT INTO history VALUES(" + Session["whatPID"].ToString() + ", '" + PNameTH.Text + "', '2', '"+Session["loginSID"].ToString()+"', 'Approve', '" + date + "', 'approve'  )", con);
            com1.ExecuteNonQuery();

            con.Close();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Messagebox", "alert('ตรวจโครงงานเรีบยร้อย');", true);
            Response.Redirect("CPE02_teacher.aspx");
        }
    }
}