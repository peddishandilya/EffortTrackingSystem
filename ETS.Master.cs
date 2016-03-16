using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using EffortTrackingSystem.Utilities;

namespace EffortTrackingSystem
{
    public partial class ETS : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["RoleId"] != null)
            {


                if (Session["RoleId"].ToString() == "1")
                {
                    lnkLogout.Visible = true;
                    lnkLogin.Visible = false;
                    pnladmin.Visible = true;
                    pnlLogin.Visible = false;
                    pnluser.Visible = false;

                }
                else if (Session["RoleId"].ToString() == "2")
                {
                    lnkLogout.Visible = true;
                    lnkLogin.Visible = false;
                    pnladmin.Visible = false;
                    pnluser.Visible = true;
                    pnlLogin.Visible = false;
                }

            }
            else
            {
                lnkLogout.Visible = false;
                lnkLogin.Visible = false;
                pnladmin.Visible = false;
                pnlLogin.Visible = true;
                pnluser.Visible = false;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            DBHelper objConnection = new DBHelper("ValidateUser_prc", false);
            try
            {

                objConnection.OpenConnection();
                objConnection.AddParameters("@Email", txtemail.Text);
                objConnection.AddParameters("@Password", txtpassword.Text);
                objConnection.ExecuteReader();
                SqlDataReader dr = objConnection.DataReader;
                if (dr.Read())
                {
                    Session["UserId"] = dr[0].ToString();
                    Session["RoleId"] = dr[1].ToString();
                    string id = Session["RoleId"].ToString();
                    if (id == "2")
                    {

                        DBHelper objConnection1 = new DBHelper("InserLoginTime_proc", false);

                        objConnection1.OpenConnection();
                        objConnection1.AddParameters("@UserId", Session["UserId"]);
                        objConnection1.AddParameters("@LogInTime", DateTime.Now.ToString("hh:mm:ss.fff tt", System.Globalization.DateTimeFormatInfo.InvariantInfo));
                        objConnection1.AddParameters("@date", DateTime.Now.ToShortDateString());
                        int success = objConnection1.ExecuteNonQuery();
                        objConnection1.CloseConnection();


                    }



                    if (id == "1")
                    {
                        Response.Redirect("admin.aspx");
                    }
                    else if (id == "2")
                    {
                        Response.Redirect("employee.aspx");
                    }



                }
                else
                    Page.ClientScript.RegisterStartupScript(typeof(Page), "type3", "<script>alert('Invalid Username/password')</script>");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                objConnection.CloseConnection();
            }
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            DBHelper objConnection1 = new DBHelper("InserLogOutTime_proc", false);
            objConnection1.OpenConnection();
            objConnection1.AddParameters("@UserId", Session["UserId"]);
            objConnection1.AddParameters("@LogOutTime", DateTime.Now.ToString("hh:mm:ss.fff tt", System.Globalization.DateTimeFormatInfo.InvariantInfo));
            objConnection1.AddParameters("@date", DateTime.Now.ToShortDateString());
            int success = objConnection1.ExecuteNonQuery();
            objConnection1.CloseConnection();


            Session.Abandon();
            Session.RemoveAll();
            Response.Redirect("Home.aspx");

        }
    }
}