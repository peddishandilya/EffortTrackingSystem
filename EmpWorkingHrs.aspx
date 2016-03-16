<%@ Page Title="" Language="C#" MasterPageFile="~/ETS.Master" AutoEventWireup="true" CodeBehind="EmpWorkingHrs.aspx.cs" Inherits="EffortTrackingSystem.EmpWorkingHrs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table>
<tr><td style="font-family: 'Arial Unicode MS'; color: #CCCCCC;">Assigned Tasks</td><td><asp:DropDownList ID="ddlAsgnTasks" runat="server"></asp:DropDownList></td></tr>
<tr><td style="font-family: 'Arial Unicode MS'; color: #CCCCCC;">Date</td><td><asp:TextBox ID="txtDate" runat="server"></asp:TextBox> 
    <aj1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate">
    </aj1:CalendarExtender>
</td></tr>
<tr><td style="font-family: 'Arial Unicode MS'; color: #CCCCCC;">Working Hrs</td><td><asp:TextBox ID="txtWorkingHrs" runat="server" ></asp:TextBox></td></tr>
<tr><td colspan="2" align="center"><asp:Button ID="btnSave" runat="server" 
        Text="SAVE" onclick="btnSave_Click" Font-Bold="True" 
        Font-Names="Arial Unicode MS" /></td></tr>
</table>

</asp:Content>
