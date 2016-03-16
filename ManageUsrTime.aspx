<%@ Page Title="" Language="C#" MasterPageFile="~/ETS.Master" AutoEventWireup="true" CodeBehind="ManageUsrTime.aspx.cs" Inherits="EffortTrackingSystem.ManageUsrTime" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
<tr><td style="font-family: 'Arial Unicode MS'; color: #CCCCCC;">Department</td><td><asp:DropDownList ID="ddlDept" runat="server" AutoPostBack="true" 
        onselectedindexchanged="ddlDept_SelectedIndexChanged"></asp:DropDownList></td></tr>
<tr><td style="font-family: 'Arial Unicode MS'; color: #CCCCCC;">Tasks</td><td><asp:DropDownList ID="ddlTask" runat="server"></asp:DropDownList></td></tr>
<tr><td style="font-family: 'Arial Unicode MS'; color: #CCCCCC;">Date</td><td><asp:TextBox ID="txtDate" runat="server" AutoPostBack="true"
        ontextchanged="txtDate_TextChanged" ></asp:TextBox> 
    <aj1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate" >
    </aj1:CalendarExtender>
</td></tr>
<tr><td style="font-family: 'Arial Unicode MS'; color: #CCCCCC; text-align: center;" 
        colspan="2">
    <asp:Button ID="Button1" runat="server" Font-Bold="True" 
        Font-Names="Arial Unicode MS" onclick="Button1_Click" Text="Submit" />
    </td></tr>
</table>

<asp:GridView ID="gvEmpPendingTime" runat="server" AutoGenerateColumns="false"  EmptyDataText="No Records To Display"
        AutoGenerateEditButton="true" 
        onrowcancelingedit="gvEmpPendingTime_RowCancelingEdit" 
        onrowediting="gvEmpPendingTime_RowEditing" 
        onrowupdating="gvEmpPendingTime_RowUpdating" Font-Names="Arial Unicode MS" 
        onselectedindexchanged="gvEmpPendingTime_SelectedIndexChanged">
 <Columns>
    <asp:TemplateField  Visible="false">
    <ItemTemplate>
    <asp:Label ID="lblTaskTimeId" runat="server" Text='<%# Bind("UserTaskTimeId") %>' ></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="UserName">
    <ItemTemplate>
    <asp:Label ID="lblUserName" runat="server" Text='<%#Bind("UserName") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
  <asp:TemplateField HeaderText="Dept">
  <ItemTemplate>
  <asp:Label ID="lblDept" runat="server" Text='<%#Bind("Dept") %>'></asp:Label>
  </ItemTemplate>
  </asp:TemplateField>
   <asp:TemplateField HeaderText="TaskName">
  <ItemTemplate>
  <asp:Label ID="lblTaskName" runat="server" Text='<%#Bind("TaskName") %>'></asp:Label>
  </ItemTemplate>
  </asp:TemplateField>

   <asp:TemplateField HeaderText="WorkingHours">
  <ItemTemplate>
  <asp:Label ID="lblWorkingHours" runat="server" Text='<%#Bind("WorkingHours") %>'></asp:Label>
  </ItemTemplate>
  <EditItemTemplate>
  <asp:TextBox ID="txtWorkingHours" runat="server" Text='<%#Bind("WorkingHours") %>'> ></asp:TextBox>
  </EditItemTemplate>
  </asp:TemplateField>
  <asp:TemplateField HeaderText="Status">
  <ItemTemplate>
  <asp:Label ID="lblStatus" runat="server" Text='<%#Bind("Status") %>'></asp:Label>
  </ItemTemplate>
  <EditItemTemplate>  
  <asp:DropDownList ID="ddlStatus" runat="server"  >   
    <asp:ListItem Value="1">Approve</asp:ListItem>
    <asp:ListItem Value="2">Reject</asp:ListItem>
  </asp:DropDownList>
  </EditItemTemplate>
  </asp:TemplateField>
    </Columns>
</asp:GridView>
    <br />
    <asp:GridView ID="emplogin" runat="server" EmptyDataText="No Records To Display">
    </asp:GridView>
</asp:Content>
