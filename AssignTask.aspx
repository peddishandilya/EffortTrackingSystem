<%@ Page Title="" Language="C#" MasterPageFile="~/ETS.Master" AutoEventWireup="true"
    CodeBehind="AssignTask.aspx.cs" Inherits="EffortTrackingSystem.AssignTask" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td style="font-family: 'Arial Unicode MS'; color: #CCCCCC;">
                Department
            </td>
            <td>
                <asp:DropDownList ID="ddlDept" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDept_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="font-family: 'Arial Unicode MS'; color: #CCCCCC;">
                Task
            </td>
            <td>
                <asp:DropDownList ID="ddlTask" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTask_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td style="color: #CCCCCC;">
                Select Members
            </td>
            <td>
            </td>
            <td style="color: #CCCCCC">
                Assigned Members
            </td>
        </tr>
        <tr>
            <td rowspan="4">
                <asp:ListBox ID="lstAllEmp" runat="server"></asp:ListBox>
            </td>
            <td>
                <asp:Button ID="btnLone"  runat="server" Text=">" onclick="btnLone_Click"  />
            </td>
            <td rowspan="4">
            <asp:ListBox ID="lstSelectedEmp" runat="server"></asp:ListBox>
            </td>
        </tr>
        <tr>
        <td>
          <asp:Button ID="btnLall" runat="server" Text=">>" onclick="btnLall_Click" />
        </td>
        </tr>
          <tr>
        <td>
          <asp:Button ID="btnRone" runat="server" Text="<" onclick="btnRone_Click" />
        </td>
        </tr>
          <tr>
        <td>
          <asp:Button ID="btnRall" runat="server" Text="<<" onclick="btnRall_Click" />
        </td>
        </tr>
       <tr>
       <td colspan="3" align="center">
           <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" 
               Font-Bold="True" Font-Names="Arial Unicode MS" /></td>
       </tr>
    </table>
</asp:Content>
