using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using EffortTrackingSystem.Utilities;
using System.Drawing;

namespace EffortTrackingSystem
{
    public partial class ManageDept : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindAllDept();
        }


        private void BindAllDept()
        {
            try
            {
                DBHelper objHepler = new DBHelper("GetAllDept_proc", true);
                DataTable dtLeaveType = objHepler.ResultantTable;
                objHepler.FillDataTable();
                ddlDept.DataSource = dtLeaveType;
                ddlDept.DataValueField = "DeptId";
                ddlDept.DataTextField = "Dept";
                ddlDept.DataBind();
                ddlDept.Items.Insert(0, "--Select--");
                ddlDept.Items.Add(new ListItem("Create new", "new"));
                ddlDept.SelectedIndex = 0;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlDept.SelectedIndex > 0 && ddlDept.SelectedValue != "new")
                {
                    txtDept.Enabled = true;
                    txtDept.Text = ddlDept.SelectedItem.ToString();

                }
                else if (ddlDept.SelectedValue == "new")
                {
                    txtDept.Enabled = true;
                    txtDept.Text = "";

                }
                else
                {
                    txtDept.Text = string.Empty;
                    txtDept.Enabled = false;

                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Object reference"))
                {
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    lblmessage.Text = "There was an error, please try again";
                    lblmessage.ForeColor = Color.Red;
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DBHelper objConnection = new DBHelper("InsertUpdateDept", false);
                if (txtDept.Text != string.Empty)
                {
                    objConnection.OpenConnection();
                    objConnection.AddParameters("@Department", txtDept.Text);

                    if (ddlDept.SelectedIndex > 0 && ddlDept.SelectedValue != "new")
                    {

                        objConnection.AddParameters("@DeptId", ddlDept.SelectedValue);

                    }
                    else if (ddlDept.SelectedValue == "new")
                    {
                        //   objConnection.AddParameters("@LeaveTypeId", 0);

                    }
                    else
                    {
                        lblmessage.Text = "There was an error, Try again";
                        lblmessage.ForeColor = Color.Red;
                    }
                    int success = objConnection.ExecuteNonQuery();
                    if (success > 0)
                    {
                        lblmessage.Text = "Saved Successfully";
                        lblmessage.ForeColor = Color.Green;
                        txtDept.Text = string.Empty;

                        BindAllDept();
                    }
                    else
                    {
                        lblmessage.Text = "There was an error, Try again";
                        lblmessage.ForeColor = Color.Red;
                    }

                }
                else
                {
                    lblmessage.Text = "Select Group";
                    lblmessage.ForeColor = Color.Red;
                }
            }

            catch (Exception ex)
            {
                if (ex.Message.Contains("Violation of PRIMARY KEY constraint"))
                {
                    lblmessage.Text = "Donor Alreary Registered";
                    lblmessage.ForeColor = Color.Red;
                }
                else if (ex.Message.Contains("Violation of UNIQUE KEY constraint"))
                {
                    lblmessage.Text = "Donor Alreary Registered";
                    lblmessage.ForeColor = Color.Red;
                }

                else if (ex.Message.Contains("Object reference"))
                {
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    lblmessage.Text = "There was an error, please try again";
                    lblmessage.ForeColor = Color.Red;
                }
            }
        }
    }
}