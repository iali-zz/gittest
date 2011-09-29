<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="datetime.aspx.cs" Inherits="WebApplication1.datetime" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.7.2/jquery-ui.min.js" type="text/javascript"></script>
    <script type="text/javascript">
//        $(function () {
//            // Datepicker
//            $('#datepicker').datepicker({
//                inline: true
//            });
//        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr><td colspan="3">Scheduling Start Date</td></tr>
            <tr>
                <td><asp:TextBox ID="txtStartDate" runat="server"></asp:TextBox></td>
                <td><asp:DropDownList ID="ddlHours1" runat="server"></asp:DropDownList></td>
                <td><asp:DropDownList ID="ddlMinutes1" runat="server"></asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="3"><div id="divError1" style="display:none"><asp:Label ID="lblError1" runat="server"></asp:Label></div></td>
            </tr>
            <tr><td colspan="3">Scheduling End Date</td></tr>
            <tr>
                <td><asp:TextBox ID="txtEndDate" runat="server"></asp:TextBox></td>
                <td><asp:DropDownList ID="ddlHours2" runat="server"></asp:DropDownList></td>
                <td><asp:DropDownList ID="ddlMinutes2" runat="server"></asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="3"><div id="divError2" style="display:none"><asp:Label ID="lblError2" runat="server"></asp:Label></div></td>
            </tr>
            <tr>
                <td colspan="3"><div id="datepicker"></div></td>
            </tr>
        </table>    
        <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" />
    </div>
        <asp:Literal ID="litScript" runat="server"></asp:Literal>
    </form>
</body>
</html>
