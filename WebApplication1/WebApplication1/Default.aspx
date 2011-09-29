<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<%--    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>--%>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.7.2/jquery-ui.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to ASP.NET!
    </h2>
    <p>
        To learn more about ASP.NET visit <a href="http://www.asp.net" title="ASP.NET Website">www.asp.net</a>.
    </p>
    <p>
        You can also find <a href="http://go.microsoft.com/fwlink/?LinkID=152368&amp;clcid=0x409"
            title="MSDN ASP.NET Docs">documentation on ASP.NET at MSDN</a>.
    </p>
    <p>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/datetime.aspx">Datetime page</asp:HyperLink>
    &nbsp;
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/SPListWithJS.aspx">SPList page</asp:HyperLink>
    </p>
    <p>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
           <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                onselectedindexchanged="DropDownList1_SelectedIndexChanged">
               <asp:ListItem Value="1">Red</asp:ListItem>
               <asp:ListItem Value="2">Green</asp:ListItem>
               <asp:ListItem Value="3">Blue</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="TextBox1" Display="Dynamic" 
                ErrorMessage="Value is required for this field." SetFocusOnError="True"></asp:RequiredFieldValidator>
            <br />
            <br />
            <br />
            <asp:DropDownList ID="DropDownList3" runat="server">
                <asp:ListItem Selected="True">One</asp:ListItem>
                <asp:ListItem>Two</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:DropDownList ID="DropDownList2" runat="server">
                <asp:ListItem Selected="True">Karachi</asp:ListItem>
                <asp:ListItem>Islamabad</asp:ListItem>
                <asp:ListItem>Lahore</asp:ListItem>
                <asp:ListItem>Quetta</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="Button1" runat="server" Text="Button" OnClientClick="foo()"/>
            <br />
            <br />
            <asp:DropDownList ID="DropDownList4" runat="server">
                <asp:ListItem Value="0">Java</asp:ListItem>
                <asp:ListItem Value="1">C#</asp:ListItem>
                <asp:ListItem Value="2">C++</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:TextBox ID="TextBox2" runat="server" title="AKUEntityDescription"></asp:TextBox>
            <br />
            <br />
            <asp:TextBox ID="TextBox3" runat="server" Text="Text3"></asp:TextBox>
            <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Button" />
            &nbsp;
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox><br />
        </ContentTemplate>
        </asp:UpdatePanel>
    &nbsp;</p>
    <script type="text/javascript">
        function foo() {
            var ddl3 = document.getElementById('<%= DropDownList2.ClientID %>');
            //alert(ddl3.id);
            //alert(ddl3[ddl3.selectedIndex].text);

            var selector = 'input[title*="AKUEntityDescription"]:text';
            var selector2 = 'input[id*="TextBox2"]:text';

            $(document).ready(function () {
                $(selector).val(ddl3[ddl3.selectedIndex].text);
                //alert($(selector).val(ddl3.text));
                //alert("hello");
            });
        }

        function OnEntityChange(ddl) {

            var selector = 'input[title*="AKUEntityDescription"]:text';

            $(document).ready(function () {
                $(selector).val(ddl[ddl.selectedIndex].text);
            });
        }
    </script>

   <%-- <script type="text/javascript">
        var selector = "<%= TextBox4.ClientID %>";
        $(document).ready(function () {
            $(selector).datepicker({
                showOn: "button",
                buttonImage: "IMAGES/calendar.gif",
                buttonImageOnly: true,
                changeMonth: true,
                changeYear: true,
                minDate: null,
                maxDate: 0,
                onSelect: function (selectedDate) {
                    $(selector).value(selectedDate);
                }
            }); 
            $('#ui-datepicker-div').addClass("ui-datepicker-us");
        });
    </script>--%>

    <script type="text/javascript">
        var selector = 'input[id*="<%= TextBox3.ClientID %>"]:text';
        $(function() {
            $(selector).datepicker({ yearRange: '1950:1990' });
	    });
	</script>

</asp:Content>
