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
    public partial class CPE01 : System.Web.UI.Page
    {
        public string pStatus = "";
        public bool haveProject = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            Label1.Text = Session["loginName"].ToString();

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Messagebox", "alert('" + Session["loginSID"].ToString() + "');", true);
            if (!IsPostBack)
            {
                FillDropDownList();
            }
            /*            
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT CPE01.status FROM CPE01 JOIN Student_CPE01 ON CPE01.PID=Student_CPE01.PID WHERE Student_CPE01.SID='"+Session["loginSID"].ToString()+"'", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                pStatus = reader["status"].ToString();
            }
            con.Close();
            */

            con.Open();
            SqlCommand cmdd = new SqlCommand("SELECT PID FROM student WHERE SID ='" + Session["loginSID"].ToString() + "'", con);
            SqlDataReader reader2 = cmdd.ExecuteReader();
            string checkPID = "";
            while (reader2.Read())
            {
                if (reader2["PID"] != null)
                {
                    checkPID = reader2["PID"].ToString();

                    if (checkPID != "")
                    {
                        haveProject = true;
                    }
                    else haveProject = false;
                }
            }
            con.Close();            

            //มาหน้าแก้ไข
            if (haveProject == true)
            {
                if (!IsPostBack)
                {                    
                    FillData();
                }
            }
            else { FillFirstStudent(); }
            
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Messagebox", "alert('" + pStatus + "');", true);
            
        }

        private void FillData()
        {
            string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            con.Open();
            string whatPID = "";
            SqlCommand cmd = new SqlCommand("SELECT PID FROM student WHERE SID= '" + Session["loginSID"].ToString() + "' ", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            { whatPID = reader["PID"].ToString(); }
            con.Close();

            con.Open();

            SqlDataAdapter dtAd;
            DataTable dt = new DataTable();
            int rowCount;

            dtAd = new SqlDataAdapter("SELECT s.SID,s.SName,s.STel,s.SEmail, p.* FROM student s JOIN project p on s.PID=p.PID JOIN CPE01 c ON c.PID=p.PID WHERE p.PID=" + whatPID + " ", con);
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
            SqlCommand cmd3 = new SqlCommand("SELECT * FROM project p WHERE p.PID=" + whatPID + " ", con);
            SqlDataReader reader3 = cmd3.ExecuteReader();
            while (reader3.Read())
            {
                DropDownList1.SelectedValue = reader3["advisorID"].ToString();
                DropDownList2.SelectedValue = reader3["coAdvisorID"].ToString();
                DropDownList3.SelectedValue = reader3["committee1ID"].ToString();
            }
            con.Close();
            
        }

        private void FillDropDownList()
        {
            DropDownList1.Items.Clear();
            DropDownList2.Items.Clear();
            DropDownList3.Items.Clear();
            DropDownList1.Items.Insert(0,new ListItem("กรุณาเลือกอาจารย์ที่ปรึกษา","0"));
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
                DropDownList1.Items.Add(new ListItem(reader["TName"].ToString(), reader["username"].ToString() ));
                DropDownList2.Items.Add(new ListItem(reader["TName"].ToString(), reader["username"].ToString() ));
                DropDownList3.Items.Add(new ListItem(reader["TName"].ToString(), reader["username"].ToString() ));
                
            }
            reader.Close();
            con.Close();
        }

        private void FillFirstStudent()
        {
            string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM student WHERE SID='"+Session["loginSID"].ToString()+"' ", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                SID1.Text = reader["SID"].ToString();
                SName1.Text = reader["SName"].ToString();
                STel1.Text = reader["STel"].ToString();
                SEmail1.Text = reader["SEmail"].ToString();
            }
            reader.Close();
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

        public int amoutMember = 0;

        public void checkMember()
        {            
            if (SID1.Text != "" && SID2.Text == "" && SID3.Text == "")
            { amoutMember = 1; }
            if (SID1.Text != "" && SID2.Text != "" && SID3.Text == "")
            { amoutMember = 2; }
            if (SID1.Text != "" && SID2.Text != "" && SID3.Text != "")
            { amoutMember = 3; }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            checkMember();
            
            string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            con.Open();

            string whatPID1 = "";
            string whatPID2 = "";
            string whatPID3 = "";
            SqlCommand cmd = new SqlCommand("SELECT PID FROM student WHERE SID= '" + SID1.Text + "' ", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            { whatPID1 = reader["PID"].ToString(); }

            con.Close();
            con.Open();

            SqlCommand cmd2 = new SqlCommand("SELECT PID FROM student WHERE SID= '" + SID2.Text + "' ", con);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            { whatPID2 = reader2["PID"].ToString(); }

            con.Close();
            con.Open();

            SqlCommand cmd3 = new SqlCommand("SELECT PID FROM student WHERE SID= '" + SID3.Text + "' ", con);
            SqlDataReader reader3 = cmd3.ExecuteReader();
            while (reader3.Read())
            { whatPID3 = reader3["PID"].ToString(); }

            con.Close();

            string teacher = DropDownList1.SelectedValue.ToString();
            string coTeacher = DropDownList2.SelectedValue.ToString();
            string comittee = DropDownList3.SelectedValue.ToString();

            if (PNameTH.Text != "")
            {
                error3.Text = "";
                if ((SName1.Text != ""))
                {
                    error1.Text = "";
                   /* if ((whatPID1 != "") && (whatPID2 != "") && (whatPID3 != ""))
                    {
                        error1.Text = "";*/
                        if ((teacher != "0"))
                        {
                            error2.Text = "";
                            
                            if ((coTeacher != "0"))
                            {
                                error2.Text = "";
                               /* if (SID1.Text != SID2.Text && SID1.Text != SID3.Text && SID2.Text != SID3.Text)
                                {
                                    error1.Text = "";*/
                                    if ((comittee != "0"))
                                    {
                                        error1.Text = "";
                                        error2.Text = "";
                                        if (teacher != coTeacher)
                                        {
                                            error2.Text = "";
                                            if (haveProject == false)
                                            {                                                
                                                if (amoutMember == 2)
                                                {
                                                    if (SID1.Text != SID2.Text)
                                                    {
                                                        error1.Text = "";
                                                        if (whatPID1 == "" && whatPID2 == "" && whatPID3 == "")
                                                        {
                                                            createForm();
                                                        }
                                                        else { error1.Text = "มีนิสิตที่มีโครงงานแล้ว"; }
                                                    }
                                                    else { error1.Text = "รหัสนิสิตซ้ำกัน"; }
                                                }
                                                else if (amoutMember == 3)
                                                {
                                                    if (SID1.Text != SID2.Text && SID1.Text != SID3.Text && SID2.Text != SID3.Text)
                                                    {
                                                        error1.Text = "";
                                                        error1.Text = "";
                                                        if (whatPID1 == "" && whatPID2 == "" && whatPID3 == "")
                                                        {
                                                            createForm();
                                                        }
                                                        else { error1.Text = "มีนิสิตที่มีโครงงานแล้ว"; }
                                                    }
                                                    else { error1.Text = "รหัสนิสิตซ้ำกัน"; }
                                                }
                                                else if(amoutMember == 1)
                                                { createForm(); }
                                            }

                                            else if (haveProject == true)
                                            {
                                                /*
                                                con.Open();
                                                string whatPID = "";
                                                SqlCommand cmds = new SqlCommand("SELECT PID FROM student WHERE SID= '" + Session["loginSID"].ToString() + "' ", con);
                                                SqlDataReader readers = cmds.ExecuteReader();
                                                while (readers.Read())
                                                { whatPID = readers["PID"].ToString(); }
                                                con.Close();
                                                */

                                                if (amoutMember == 2)
                                                {
                                                    if (SID1.Text != SID2.Text)
                                                    {
                                                        if (whatPID1 != "" && whatPID2 != "" && whatPID3 != "") // ดูว่ามีโปรเจคยัง
                                                        {
                                                            if (whatPID1 == whatPID2 && whatPID1 == whatPID3 && whatPID2 == whatPID3) // ดูว่าโปรเจคตรงกันมั๊ย
                                                            { updateData(); }
                                                            else { error1.Text = "มีนิสิตที่อยู่ในโครงงานอื่น"; }
                                                        }
                                                        else { updateData(); }
                                                    }
                                                    else { error1.Text = "รหัสนิสิตซ้ำกัน"; }
                                                }
                                                else if (amoutMember == 3)
                                                {
                                                    if (SID1.Text != SID2.Text && SID1.Text != SID3.Text && SID2.Text != SID3.Text)
                                                    {
                                                        if (SID1.Text != SID2.Text)
                                                        {
                                                            if (whatPID1 != "" && whatPID2 != "" && whatPID3 != "")
                                                            {
                                                                if (whatPID1 == whatPID2 && whatPID1 == whatPID3 && whatPID2 == whatPID3)
                                                                { updateData(); }
                                                                else { error1.Text = "มีนิสิตที่อยู่ในโครงงานอื่น"; }
                                                            }
                                                            else { updateData(); }
                                                        }
                                                    }
                                                    else { error1.Text = "รหัสนิสิตซ้ำกัน"; }
                                                }
                                                else if (amoutMember == 1)
                                                { updateData(); }
                                            }
                                        }
                                        else { error2.Text = "อาจารย์ที่ปรึกษา กับ อาจารย์ที่ปรึกษาร่วม ซ้ำกัน"; }
                                    }
                                    else { error2.Text = "กรุณาเสนอชื่อกรรมการ 1 ท่าน"; }
                                /*}
                                else { error1.Text = "รหัสนิสิตซ้ำกัน"; }*/

                            }
                            else { error2.Text = "กรุณาเลือกอาจารย์ที่ปรึกษาร่วม หรือเลือก 'ไม่เลือก'"; }

                        }
                        else
                        {
                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Messagebox", "alert('" +teacher+ "' + '" +coTeacher+ "' + '" +comittee+ "');", true); 
                            error2.Text = "กรุณาเลือกอาจารย์ที่ปรึกษา";
                        }
                   /* }
                    else { error1.Text = "มีนิสิตที่ทำโครงงานอื่นแล้ว"; }*/
                }
                else { error1.Text = "ต้องมีนิสิตผู้ทำโครงการ อย่างน้อย 1 คน"; }

            }else {error3.Text = "กรุณากรอกชื่อโครงงานภาษาไทย"; }
            
        }

        private void createForm()
        {
            string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            SqlDataAdapter dtAd;
            DataTable dt = new DataTable();
            string txtPID = "";
            int rowCount;

            dtAd = new SqlDataAdapter("SELECT * FROM project", con);
            dtAd.Fill(dt);
            rowCount = dt.Rows.Count;
            rowCount = rowCount - 1;

            if (rowCount < 0)
            {
                txtPID = "1";
            }
            else
            {
                txtPID = (((Int32)dt.Rows[rowCount]["PID"]) + 1).ToString();
            }

            con.Close();

            con.Open();

            SqlCommand comm = new SqlCommand("INSERT INTO project VALUES( " + txtPID + ", '" + PNameTH.Text + "', '" + PNameENG.Text + "', '" + DropDownList1.SelectedValue.ToString() + "', '" + DropDownList2.SelectedValue.ToString() + "', '" + DropDownList3.SelectedValue.ToString() + "', '"+null+"', '"+null+"')", con);
            comm.ExecuteNonQuery();

            SqlCommand com2 = new SqlCommand("INSERT INTO CPE01 VALUES(" + txtPID + ", ' 1 ', 'wait', '" + date + "')", con);
            com2.ExecuteNonQuery();

            SqlCommand com33 = new SqlCommand("INSERT INTO history VALUES(" + txtPID + ", '" + PNameTH.Text + "', '1', '" + Session["loginSID"].ToString() + "', 'Create', '" + date + "', 'wait'  )", con);
            com33.ExecuteNonQuery();

            con.Close();

            con.Open();

            SqlCommand com3 = new SqlCommand("UPDATE student SET PID= " + txtPID + " WHERE SID = '" + SID1.Text + "' ", con);
            com3.ExecuteNonQuery();

            SqlCommand com4 = new SqlCommand("UPDATE student SET PID= " + txtPID + " WHERE SID = '" + SID2.Text + "' ", con);
            com4.ExecuteNonQuery();

            SqlCommand com5 = new SqlCommand("UPDATE student SET PID= " + txtPID + " WHERE SID = '" + SID3.Text + "' ", con);
            com5.ExecuteNonQuery();

            con.Close();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Messagebox", "alert('ส่งแบบฟอร์มเรียบร้อย');", true);
        }

        private void updateData()
        {
            string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            con.Open();

            string whatPID1 = "";
            string whatPID2 = "";
            string whatPID3 = "";
            SqlCommand cmd = new SqlCommand("SELECT PID FROM student WHERE SID= '" + SID1.Text + "' ", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            { whatPID1 = reader["PID"].ToString(); }

            con.Close();
            con.Open();

            SqlCommand cmd2 = new SqlCommand("SELECT PID FROM student WHERE SID= '" + SID2.Text + "' ", con);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            { whatPID2 = reader2["PID"].ToString(); }

            con.Close();
            con.Open();

            SqlCommand cmd3 = new SqlCommand("SELECT PID FROM student WHERE SID= '" + SID3.Text + "' ", con);
            SqlDataReader reader3 = cmd3.ExecuteReader();
            while (reader3.Read())
            { whatPID3 = reader3["PID"].ToString(); }

            con.Close();

            con.Open();
            SqlCommand com33 = new SqlCommand("INSERT INTO history VALUES(" + whatPID1 + ", '" + PNameTH.Text + "', '1', '" + Session["loginSID"].ToString() + "', 'Edit', '" + DateTime.Now + "', 'wait' )", con);
            com33.ExecuteNonQuery();
            con.Close();

            con.Open();

            SqlCommand com34 = new SqlCommand("UPDATE project SET PID= " + whatPID1 + ", PNameTH='" + PNameTH.Text + "', PNameENG='" + PNameENG.Text + "', advisorID='" + DropDownList1.SelectedValue.ToString() + "', coAdvisorID='" + DropDownList2.SelectedValue.ToString() + "', committee1ID='" + DropDownList3.SelectedValue.ToString() + "' WHERE PID = '" + whatPID1 + "' ", con);
            com34.ExecuteNonQuery();

            SqlCommand com44 = new SqlCommand("UPDATE CPE01 SET PID= " + whatPID1 + ", FormNo='1', status='wait', date='" + DateTime.Now + "'  WHERE PID = '" + whatPID1 + "' ", con);
            com44.ExecuteNonQuery();

            SqlCommand com3 = new SqlCommand("UPDATE student SET PID= " + whatPID1 + " WHERE SID = '" + SID1.Text + "' ", con);
            com3.ExecuteNonQuery();

            SqlCommand com4 = new SqlCommand("UPDATE student SET PID= " + whatPID1 + " WHERE SID = '" + SID2.Text + "' ", con);
            com4.ExecuteNonQuery();

            SqlCommand com5 = new SqlCommand("UPDATE student SET PID= " + whatPID1 + " WHERE SID = '" + SID3.Text + "' ", con);
            com5.ExecuteNonQuery();

            con.Close();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Messagebox", "alert('แก้ไขแบบฟอร์มเรียบร้อย');", true);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChooseForm.aspx");
            
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM student WHERE SID = '" + SID1.Text + "' ", con);
            SqlDataReader reader = cmd.ExecuteReader();
            bool haveData = false;

            while (reader.Read())
            {
                if (SID1.Text == reader["SID"].ToString())
                {
                    SName1.Text = reader["SName"].ToString();
                    STel1.Text = reader["STel"].ToString();
                    SEmail1.Text = reader["SEmail"].ToString();
                    haveData = true;
                }
            }
            con.Close();
            if(haveData != true)
            {
                SName1.Text = "";
                STel1.Text = "";
                SEmail1.Text = "";
            }        
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM student WHERE SID = '" + SID2.Text + "' ", con);
            SqlDataReader reader = cmd.ExecuteReader();
            bool haveData = false;

            while (reader.Read())
            {
                if (SID2.Text == reader["SID"].ToString())
                {
                    SName2.Text = reader["SName"].ToString();
                    STel2.Text = reader["STel"].ToString();
                    SEmail2.Text = reader["SEmail"].ToString();
                    haveData = true;
                }
            }
            con.Close();
            if (haveData != true)
            {
                SName2.Text = "";
                STel2.Text = "";
                SEmail2.Text = "";
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM student WHERE SID = '" + SID3.Text + "' ", con);
            SqlDataReader reader = cmd.ExecuteReader();
            bool haveData = false;

            while (reader.Read())
            {
                if (SID3.Text == reader["SID"].ToString())
                {
                    SName3.Text = reader["SName"].ToString();
                    STel3.Text = reader["STel"].ToString();
                    SEmail3.Text = reader["SEmail"].ToString();
                    haveData = true;
                }
            }
            con.Close();
            if (haveData != true)
            {
                SName3.Text = "";
                STel3.Text = "";
                SEmail3.Text = "";
            }
        }
                
    }
}