<%@ Page Title="" Language="C#" MasterPageFile="~/ETS.Master" AutoEventWireup="true" CodeBehind="ManageEmployee.aspx.cs" Inherits="EffortTrackingSystem.ManageEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table style="font-family: 'Arial Unicode MS'">
<tr><td style="color: #CCCCCC" ><asp:Label ID="lblModId" runat="server" Text="Name"></asp:Label></td><td>
    <asp:DropDownList ID="ddlEmployee" runat="server" CssClass="csddl" 
         AutoPostBack="true" onselectedindexchanged="ddlEmployee_SelectedIndexChanged"  
        ></asp:DropDownList></td></tr>
<tr><td style="color: #CCCCCC"><asp:Label ID="Label1" runat="server" Text="Name"></asp:Label></td><td><asp:TextBox ID="txtName" runat="server" CssClass="cstxt"></asp:TextBox></td></tr>
<tr><td style="color: #CCCCCC"><asp:Label ID="Label2" runat="server" Text="email"></asp:Label></td><td><asp:TextBox ID="txtEmail" runat="server"  CssClass="cstxt"></asp:TextBox></td></tr>
<tr><td style="color: #CCCCCC"><asp:Label ID="Label6" runat="server" Text="Phoneno"></asp:Label></td><td><asp:TextBox ID="txtPhoneno" runat="server"  CssClass="cstxt"></asp:TextBox></td></tr>
<tr><td> <asp:Label ID="Label3" runat="server" Text="Department" 
        ForeColor="#CCCCCC"></asp:Label></td><td><asp:DropDownList ID="ddlDept" runat="server"></asp:DropDownList></td></tr>

<tr><td> <asp:Label ID="Label4" runat="server" Text="Salary(Per Hr)" 
        ForeColor="#CCCCCC"></asp:Label></td><td> <asp:TextBox ID="txtSalary" runat="server"></asp:TextBox> </td></tr>

<tr><td align="right">

    <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
        CssClass="csbuttons" onclick="btnSubmit_Click" 
        Font-Names="Arial Unicode MS" /></td><td align="left">
        <asp:Button ID="btnCancel" runat="server" Text="Cancel"  CssClass="csbuttons" 
            Font-Names="Arial Unicode MS"/></td></tr>
</table>

</asp:Content>
