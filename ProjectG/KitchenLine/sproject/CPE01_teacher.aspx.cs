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
    public partial class CPE01_teacher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = Session["loginName"].ToString();
            if (!IsPostBack)
            {
                FillDropDownList();
                FillData();
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
            else if(checkStatus == "3")
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
            SqlCommand cmd3 = new SqlCommand("SELECT status FROM CPE01 WHERE PID=" + Session["whatPID"].ToString() + " ", con);
            SqlDataReader reader3 = cmd3.ExecuteReader();
            while(reader3.Read())
            {
                string stat = reader3["status"].ToString();
                if(stat == "wait")
                {
                    //Button1.Enabled = true;
                    checkStatus();
                }
                else if(stat == "approve")
                {
                    Button1.Enabled = false;
                    Button2.Enabled = false;
                }
                else if (stat == "reject")
                {
                    Button1.Enabled = false;
                    Button2.Enabled = false;
                }
            }
            con.Close();
        }

        private void FillDropDownList()
        {
            DropDownList1.Items.Clear();
            DropDownList2.Items.Clear();
            DropDownList3.Items.Clear();
            DropDownList1.Items.Insert(0, new ListItem("กรุณาเลือกอาจารย์ที่ปรึกษา", "0"));
            DropDownList2.Items.Insert(0, new ListItem("เลือกอาจารย์ที่ปรึกษาร่วม", "0"));
            DropDownList2.Items.Insert(1, new ListItem("ไม่เลือก", null));
            DropDownList3.Items.Insert(0, new ListItem("กรุณาเลือกกรรมการ", "0"));
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

            SqlDataAdapter dtAd;
            DataTable dt = new DataTable();
            int rowCount;

            dtAd = new SqlDataAdapter("SELECT s.SID,s.SName,s.STel,s.SEmail, p.* FROM student s JOIN project p on s.PID=p.PID JOIN CPE01 c ON c.PID=p.PID WHERE p.PID=" + Session["whatPID"].ToString() + " ", con);
            dtAd.Fill(dt);
            rowCount = dt.Rows.Count;
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Messagebox", "alert('" + rowCount.ToString() + "');", true);
            if (rowCount == 1)
            {
                PNameTH.Text = dt.Rows[0]["PNameTH"].ToString();
                PNameENG.Text = dt.Rows[0]["PNameENG"].ToString();
                SID1.Text = dt.Rows[0]["SID"].ToString();
                SName1.Text = dt.Rows[0]["SName"].ToString();
                STel1.Text = dt.Rows[0]["STel"].ToString();
                SEmail1.Text = dt.Rows[0]["SEmail"].ToString();
            }
            else if (rowCount == 2)
            {
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
            SqlCommand cmd3 = new SqlCommand("SELECT * FROM project p WHERE p.PID=" + Session["whatPID"].ToString() + " ", con);
            SqlDataReader reader3 = cmd3.ExecuteReader();
            while (reader3.Read())
            {
                DropDownList1.SelectedValue = reader3["advisorID"].ToString();
                DropDownList2.SelectedValue = reader3["coAdvisorID"].ToString();
                DropDownList3.SelectedValue = reader3["committee1ID"].ToString();
            }
            con.Close();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            SqlCommand com3 = new SqlCommand("UPDATE CPE01 SET status= 'approve' WHERE PID = '" + Session["whatPID"].ToString() + "' ", con);
            com3.ExecuteNonQuery();

            con.Close();

            con.Open();

            SqlCommand com1 = new SqlCommand("INSERT INTO history VALUES(" + Session["whatPID"].ToString() + ", '" + PNameTH.Text + "', '1', '" + Session["loginSID"].ToString() + "', 'Approve', '" + DateTime.Now + "', 'approve'  )", con);
            com1.ExecuteNonQuery();

            con.Close();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Messagebox", "alert('อนุมัติโครงงานแล้ว');", true);
            Response.Redirect("CPE01_teacher.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            SqlCommand com3 = new SqlCommand("UPDATE CPE01 SET status= 'reject' WHERE PID = '" + Session["whatPID"].ToString() + "' ", con);
            com3.ExecuteNonQuery();

            con.Close();

            con.Open();

            SqlCommand com1 = new SqlCommand("INSERT INTO history VALUES(" + Session["whatPID"].ToString() + ", '" + PNameTH.Text + "', '1', '" + Session["loginSID"].ToString() + "', 'Reject', '" + DateTime.Now + "', 'reject'  )", con);
            com1.ExecuteNonQuery();

            con.Close();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Messagebox", "alert('ไม่อนุมัติโครงงาน');", true);
            Response.Redirect("CPE01_teacher.aspx");
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
            Response.Redirect("Index.aspx");
        }

    }
}