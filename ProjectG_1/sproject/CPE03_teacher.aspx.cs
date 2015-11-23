using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sproject
{
    public partial class CPE03_teacher : System.Web.UI.Page
    {
        public string whatCommit = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label1.Text = Session["loginName"].ToString();
                WhatDrop();
                Session["whatCommittee"] = whatCommit;
                FillDropDownList();
                FillCommittee();
                FillData();
                isApprove();
            }
        }

        private void isApprove()
        {
            string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd3 = new SqlCommand("SELECT status FROM CPE03 WHERE PID=" + Session["whatPID"].ToString() + " ", con);
            SqlDataReader reader3 = cmd3.ExecuteReader();
            while (reader3.Read())
            {
                string stat = reader3["status"].ToString();
                if (stat == "wait")
                {
                    //Button1.Enabled = true;
                    checkStatus();
                }
                else if (stat == "approve")
                {
                    string checkStatus = Session["tStatus"].ToString();
                    if (checkStatus == "0" || checkStatus == "1")
                    {
                        Button1.Enabled = false;
                        Button2.Enabled = false;
                    }
                    if (checkStatus == "2")
                    {
                        Button1.Enabled = false;
                        Button2.Enabled = false;
                    }
                    else if (checkStatus == "3")
                    {
                        Button1.Enabled = true;
                        Button2.Enabled = false;
                        DropDownList1.Enabled = true;
                        DropDownList2.Enabled = true;
                        DropDownList3.Enabled = true;
                    }

                }
                else if (stat == "reject")
                {
                    string checkStatus = Session["tStatus"].ToString();
                    if (checkStatus == "0" || checkStatus == "1")
                    {
                        Button1.Enabled = false;
                        Button2.Enabled = false;
                    }
                    if (checkStatus == "2")
                    {
                        Button1.Enabled = false;
                        Button2.Enabled = false;
                    }
                    else if (checkStatus == "3")
                    {
                        Button1.Enabled = true;
                        Button2.Enabled = false;
                        DropDownList1.Enabled = true;
                        DropDownList2.Enabled = true;
                        DropDownList3.Enabled = true;
                    }
                }
            }
            con.Close();
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

            con.Open();
            SqlCommand cmd3 = new SqlCommand("SELECT * FROM project p WHERE p.PID=" + Session["whatPID"] + " ", con);
            SqlDataReader reader3 = cmd3.ExecuteReader();
            while (reader3.Read())
            {
                DropDownList1.SelectedValue = reader3["committee1ID"].ToString();
                DropDownList2.SelectedValue = reader3["committee2ID"].ToString();
                DropDownList3.SelectedValue = reader3["committee3ID"].ToString();
            }
            con.Close();

            con.Open();

            SqlCommand com2 = new SqlCommand("SELECT * FROM CPE03 WHERE PID='" + Session["whatPID"] + "' ", con);
            SqlDataReader reader = com2.ExecuteReader();
            while (reader.Read())
            {
                TextBox1.Text = reader["scope"].ToString();
            }

            con.Close();   

        }

        private void FillCommittee()
        {
            string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM CPE03 WHERE  PID = '" + Session["whatPID"].ToString() + "' ", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                /***** Commit1 ****/
                if (reader["c1"].ToString() == "1")
                {
                    Committee3.Text = "Approve";
                    Committee3.ForeColor = System.Drawing.Color.Green;
                }
                else if (reader["c1"].ToString() == "0")
                {
                    Committee3.Text = "wait";
                    Committee3.ForeColor = System.Drawing.Color.Yellow;
                }
                else if (reader["status"].ToString() == "Inject")
                {
                    Committee3.Text = "Inject";
                    Committee3.ForeColor = System.Drawing.Color.Red;
                }

                /***** Commit2 ****/
                if (reader["c2"].ToString() == "1")
                {
                    Committee4.Text = "Approve";
                    Committee4.ForeColor = System.Drawing.Color.Green;
                }
                else if (reader["c2"].ToString() == "0")
                {
                    Committee4.Text = "wait";
                    Committee4.ForeColor = System.Drawing.Color.Yellow;
                }
                else if (reader["status"].ToString() == "Inject")
                {
                    Committee4.Text = "Inject";
                    Committee4.ForeColor = System.Drawing.Color.Red;
                }

                /***** Commit3 ****/
                if (reader["c3"].ToString() == "1")
                {
                    Committee5.Text = "Approve";
                    Committee5.ForeColor = System.Drawing.Color.Green;
                }
                else if (reader["c3"].ToString() == "0")
                {
                    Committee5.Text = "wait";
                    Committee5.ForeColor = System.Drawing.Color.Yellow;
                }
                else if (reader["status"].ToString() == "Inject")
                {
                    Committee5.Text = "Inject";
                    Committee5.ForeColor = System.Drawing.Color.Red;
                }
            }
            con.Close();
        }

        private void checkStatus()
        {
            string checkStatus = Session["tStatus"].ToString();
            if (checkStatus == "0" || checkStatus == "1")
            {
                Button1.Enabled = false;
                Button2.Enabled = false;
            }
            if (checkStatus == "2")
            {
                Button1.Enabled = true;
                Button2.Enabled = true;
            }
            else if (checkStatus == "3")
            {
                Button1.Enabled = true;
                Button2.Enabled = false;
                DropDownList1.Enabled = true;
                DropDownList2.Enabled = true;
                DropDownList3.Enabled = true;
            }
            else
            {
                Button1.Enabled = true;
                Button2.Enabled = true;
            }
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");

            con.Open();
            SqlCommand com = new SqlCommand("UPDATE CPE03 SET c1='0', c2='0', c3='0', status='reject' WHERE PID = '" + Session["whatPID"].ToString() + "' ", con);
            com.ExecuteNonQuery();

            SqlCommand com1 = new SqlCommand("INSERT INTO history VALUES(" + Session["whatPID"].ToString() + ", '" + PNameTH.Text + "', '3', '" + Session["loginSID"].ToString() + "', 'Reject', '" + date + "', 'reject'  )", con);
            com1.ExecuteNonQuery();

            con.Close();
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert(\"Success! ->Form3\");", true);
            Response.Redirect("HomeTeacher.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string checkStatus = Session["tStatus"].ToString();
            

            if(checkStatus == "3")
            {
                if (DropDownList1.SelectedIndex != 0 && DropDownList2.SelectedIndex != 0 && DropDownList3.SelectedIndex != 0)
                {
                    if (DropDownList1.SelectedIndex != DropDownList2.SelectedIndex && DropDownList1.SelectedIndex != DropDownList3.SelectedIndex && DropDownList2.SelectedIndex != DropDownList3.SelectedIndex)
                    {
                        error2.Text = "";
                        adminCMD();
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert(\"Success! ->Form3\");", true);
                        Response.Redirect("HomeTeacher.aspx");
                    }
                    else { error2.Text = "ห้ามมีรายชื่อคณะกรรมการที่ซ้ำกัน"; }
                }
                else { error2.Text = "กรุณาเลือกคณะกรรมการให้ครบทั้ง 3 ท่าน"; }
            }
            else if(checkStatus == "2")
            {
                if (DropDownList1.SelectedIndex != 0 && DropDownList2.SelectedIndex != 0 && DropDownList3.SelectedIndex != 0)
                {
                    error2.Text = "";
                    teacherCMD();
                    //alert
                    Response.Write("<script type='text/javascript'>");
                    Response.Write("alert('Success! ->Form3');");
                    Response.Write("document.location.href='CPE03_teacher.aspx';");
                    Response.Write("</script>");

                }
                else { error2.Text = "ไม่สามารถดำเนินการได้ เนื่องจากกรรมการยังไม่ครบ 3 ท่าน"; }
            }
        }

        private void WhatDrop()
        {
            string s1 = "", s2 = "", s3 = "";
            string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            SqlCommand cmd3 = new SqlCommand("SELECT * FROM project WHERE PID=" + Session["whatPID"].ToString() + " ", con);
            SqlDataReader reader3 = cmd3.ExecuteReader();
            while (reader3.Read())
            {
                s1 = reader3["committee1ID"].ToString();
                s2 = reader3["committee2ID"].ToString();
                s3 = reader3["committee3ID"].ToString();
            }
            con.Close();
            string ID = Session["loginSID"].ToString();
            if (ID == s1)
            {
                whatCommit = "1";
            }
            else if (ID == s2)
            {
                whatCommit = "2";
            }
            else if (ID == s3)
            {
                whatCommit = "3";
            }
        }

        private void teacherCMD()
        {
            string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            string whatCommitt = Session["whatCommittee"].ToString();
            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");

            if (whatCommitt == "1")
            {
                con.Open();

                SqlCommand com = new SqlCommand("UPDATE CPE03 SET c1='1' WHERE PID = '" + Session["whatPID"].ToString() + "' ", con);
                com.ExecuteNonQuery();

                SqlCommand com1 = new SqlCommand("UPDATE HomeTeacher SET dateC1='"+date+"' WHERE PID = '" + Session["whatPID"].ToString() + "' ", con);
                com1.ExecuteNonQuery();
                //SqlCommand com1 = new SqlCommand("INSERT INTO history VALUES(" + Session["whatPID"].ToString() + ", '" + PNameTH.Text + "', '3', '" + Session["loginSID"].ToString() + "', 'Approve', '" + date + "', 'wait'  )", con);
                //com1.ExecuteNonQuery();

                con.Close();
            }
            else if (whatCommitt == "2")
            {
                con.Open();

                SqlCommand com = new SqlCommand("UPDATE CPE03 SET c2='1' WHERE PID = '" + Session["whatPID"].ToString() + "' ", con);
                com.ExecuteNonQuery();

                SqlCommand com1 = new SqlCommand("UPDATE HomeTeacher SET dateC2='" + date + "' WHERE PID = '" + Session["whatPID"].ToString() + "' ", con);
                com1.ExecuteNonQuery();

                //SqlCommand com1 = new SqlCommand("INSERT INTO history VALUES(" + Session["whatPID"].ToString() + ", '" + PNameTH.Text + "', '3', '" + Session["loginSID"].ToString() + "', 'Approve', '" + date + "', 'wait'  )", con);
                //com1.ExecuteNonQuery();

                con.Close();
            }
            else if (whatCommitt == "3")
            {
                con.Open();

                SqlCommand com = new SqlCommand("UPDATE CPE03 SET c3='1' WHERE PID = '" + Session["whatPID"].ToString() + "' ", con);
                com.ExecuteNonQuery();

                SqlCommand com1 = new SqlCommand("UPDATE HomeTeacher SET dateC3='" + date + "' WHERE PID = '" + Session["whatPID"].ToString() + "' ", con);
                com1.ExecuteNonQuery();

                //SqlCommand com1 = new SqlCommand("INSERT INTO history VALUES(" + Session["whatPID"].ToString() + ", '" + PNameTH.Text + "', '3', '" + Session["loginSID"].ToString() + "', 'Approve', '" + date + "', 'wait'  )", con);
                //com1.ExecuteNonQuery();

                con.Close();
            }

            con.Open();
            bool isAllApprove = false;
            SqlCommand cmddd = new SqlCommand("SELECT * FROM CPE03 WHERE  PID = '" + Session["whatPID"].ToString() + "' ", con);
            SqlDataReader reader = cmddd.ExecuteReader();
            while(reader.Read())
            {
                if( reader["c1"].ToString() == "1" && reader["c2"].ToString() == "1" && reader["c3"].ToString() == "1"  )
                {
                    isAllApprove = true;
                }
            }

            con.Close();

            //Thread.Sleep(2000);

            if (isAllApprove == true)
            {

                con.Open();
                SqlCommand com = new SqlCommand("UPDATE CPE03 SET status='approve' WHERE PID = '" + Session["whatPID"].ToString() + "' ", con);
                com.ExecuteNonQuery();
                con.Close();
                //SqlCommand com1 = new SqlCommand("INSERT INTO history VALUES(" + Session["whatPID"].ToString() + ", '" + PNameTH.Text + "', '3', 'Auto Gen', 'Approve', '" + date + "', 'approve'  )", con);
                //com1.ExecuteNonQuery();

                con.Open();
                SqlCommand com3 = new SqlCommand(" INSERT INTO CPE04 VALUES(" + Session["whatPID"] + ",'4','wait','" + date + "','','','') ", con);
                com3.ExecuteNonQuery();
                con.Close();
                
            }

        }

        private void adminCMD()
        {
            string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");

            SqlCommand com34 = new SqlCommand("UPDATE project SET committee1ID='" + DropDownList1.SelectedValue.ToString() + "', committee2ID='" + DropDownList2.SelectedValue.ToString() + "', committee3ID='" + DropDownList3.SelectedValue.ToString() + "' WHERE PID = '" + Session["whatPID"] + "' ", con);
            com34.ExecuteNonQuery();

            SqlCommand com = new SqlCommand("UPDATE CPE03 SET status= 'wait' WHERE PID = '" + Session["whatPID"].ToString() + "' ", con);
            com.ExecuteNonQuery();

            SqlCommand com2 = new SqlCommand("UPDATE HomeTeacher SET dateAd='" + date + "' WHERE PID = '" + Session["whatPID"].ToString() + "' ", con);
            com2.ExecuteNonQuery();

            SqlCommand com1 = new SqlCommand("INSERT INTO history VALUES(" + Session["whatPID"].ToString() + ", '" + PNameTH.Text + "', '3', '" + Session["loginSID"].ToString() + "', 'Add committee', '" + date + "', 'wait'  )", con);
            com1.ExecuteNonQuery();

            con.Close();
        }


    }
}