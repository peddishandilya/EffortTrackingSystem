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
    public partial class AssignTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAllDept();
            }

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
                ddlDept.SelectedIndex = 0;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDept.SelectedIndex > 0)
            {
                try
                {
                    DBHelper objHepler = new DBHelper("GetDeptTask_proc", true);
                    objHepler.AddParameters("@DeptId", ddlDept.SelectedValue);
                    DataTable dtDeptTask = objHepler.ResultantTable;
                    objHepler.FillDataTable();
                    ddlTask.DataSource = dtDeptTask;
                    ddlTask.DataValueField = "TaskId";
                    ddlTask.DataTextField = "TaskName";
                    ddlTask.DataBind();
                    ddlTask.Items.Insert(0, "--Select--");
                    ddlTask.SelectedIndex = 0;

                    DBHelper objHelp = new DBHelper("GetDeptEmp_proc", true);
                    objHelp.AddParameters("@DeptId",ddlDept.SelectedValue);
                    DataTable dtDeptEmp = objHelp.ResultantTable;
                    objHelp.FillDataTable();
                    lstAllEmp.DataSource = dtDeptEmp;
                    lstAllEmp.DataTextField = "UserName";
                    lstAllEmp.DataValueField = "UserId";
                    lstAllEmp.DataBind();


                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        protected void ddlTask_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTask.SelectedIndex > 0)
            {
                try
                {
                    DBHelper objHepler = new DBHelper("GetTaskEmp_proc", true);
                    objHepler.AddParameters("@TaskId", ddlTask.SelectedValue);
                    DataTable dttaskEmp = objHepler.ResultantTable;
                    objHepler.FillDataTable();
                    lstSelectedEmp.DataSource = dttaskEmp;
                    lstSelectedEmp.DataValueField = "UserId";
                    lstSelectedEmp.DataTextField = "UserName";
                    lstSelectedEmp.DataBind();
                    foreach (ListItem li in lstSelectedEmp.Items)
                    {
                        if (lstAllEmp.Items.Contains(li))
                        {
                            lstAllEmp.Items.Remove(li);
                        }
                          
                    }

                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        protected void btnLone_Click(object sender, EventArgs e)
        {
            lstSelectedEmp.Items.Add(lstAllEmp.SelectedItem);
            lstAllEmp.Items.Remove(lstAllEmp.SelectedItem);
            lstSelectedEmp.SelectedItem.Selected = false;
          
        }

        protected void btnLall_Click(object sender, EventArgs e)
        {
            foreach (ListItem li in lstAllEmp.Items)
            {
                lstSelectedEmp.Items.Add(li);
            }

            lstAllEmp.Items.Clear();
            
        }

        protected void btnRone_Click(object sender, EventArgs e)
        {
            lstAllEmp.Items.Add(lstSelectedEmp.SelectedItem);
            lstSelectedEmp.Items.Remove(lstSelectedEmp.SelectedItem);
            lstAllEmp.SelectedItem.Selected = false;
        }

        protected void btnRall_Click(object sender, EventArgs e)
        {
            foreach (ListItem li in lstSelectedEmp.Items)
            {
                lstAllEmp.Items.Add(li);
            }
            lstSelectedEmp.Items.Clear();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DBHelper objConnection = new DBHelper("ManageAssignTask_proc", false);
            foreach (ListItem li in lstSelectedEmp.Items)
            {
               

                objConnection.OpenConnection();
                objConnection.AddParameters("@TaskId",ddlTask.SelectedValue);
                objConnection.AddParameters("@UserId", li.Value);
                objConnection.AddParameters("@assing", 1);             

                int success = objConnection.ExecuteNonQuery();
                objConnection.RemoveParameters();
                objConnection.CloseConnection();
            }

            foreach (ListItem li in lstAllEmp.Items)
            {


                objConnection.OpenConnection();
                objConnection.AddParameters("@TaskId", ddlTask.SelectedValue);
                objConnection.AddParameters("@UserId", li.Value);
                objConnection.AddParameters("@unassign", 1);


                int success = objConnection.ExecuteNonQuery();
                objConnection.RemoveParameters();
                objConnection.CloseConnection();
            }

        }
    }
}