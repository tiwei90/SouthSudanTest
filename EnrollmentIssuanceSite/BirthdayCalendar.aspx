<%@ Page Language="C#" AutoEventWireup="true" Inherits="EnrollmentIssuanceSite.BirthdayCalendar" EnableEventValidation="false" Codebehind="BirthdayCalendar.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
	<head>
		<title>Calendar</title>
		<script type="text/javascript">
		var n;
		
        function ConfirmDate(age,msg)
        {
            if(confirm("Applicant's age is "+ age + " years old. Are you sure you want to enter this date"+ msg +"?"))
            {
                n = "1";
            }
            else
            {
                n = "0";
            }
        }
		</script>
	</head>
	<body>
		<form id="Form1" method="post" runat="server">
		
			<div >
				<asp:DropDownList id="ddlMonth" runat="server" Width="100px" Height="24px" CssClass="Panel" Font-Size="X-Small"
					BackColor="#FEF0C5" AutoPostBack="True" onselectedindexchanged="ddlMonth_SelectedIndexChanged">
					<asp:ListItem Value="01">January</asp:ListItem>
					<asp:ListItem Value="02">February</asp:ListItem>
					<asp:ListItem Value="03">March</asp:ListItem>
					<asp:ListItem Value="04">April</asp:ListItem>
					<asp:ListItem Value="05">May</asp:ListItem>
					<asp:ListItem Value="06">June</asp:ListItem>
					<asp:ListItem Value="07">July</asp:ListItem>
					<asp:ListItem Value="08">August</asp:ListItem>
					<asp:ListItem Value="09">September</asp:ListItem>
					<asp:ListItem Value="10">October</asp:ListItem>
					<asp:ListItem Value="11">November</asp:ListItem>
					<asp:ListItem Value="12">December</asp:ListItem>
				</asp:DropDownList>
				<asp:DropDownList id="ddlYear" runat="server" Width="65px" CssClass="Panel" Height="24px" Font-Size="X-Small"
					BackColor="#FEF0C5" AutoPostBack="True" onselectedindexchanged="ddlYear_SelectedIndexChanged"></asp:DropDownList>
				<asp:Calendar id="cal" runat="server" BorderWidth="2px" BackColor="White" Width="170px" ForeColor="Black"
					Height="100px" Font-Size="10px" Font-Names="Arial" BorderColor="#999999" BorderStyle="Outset"
					DayNameFormat="FirstTwoLetters" CellPadding="4" ShowTitle="False" OnSelectionChanged="cal_SelectionChanged">
					<TodayDayStyle Font-Bold="True" ForeColor="Black" BackColor="WhiteSmoke"></TodayDayStyle>
					<SelectorStyle BackColor="#C0FFFF"></SelectorStyle>
					<NextPrevStyle VerticalAlign="Bottom"></NextPrevStyle>
					<DayHeaderStyle Font-Size="11px" Font-Names="Arial" Font-Bold="True" BackColor="#FAF1D7"></DayHeaderStyle>
					<SelectedDayStyle Font-Bold="True" ForeColor="Black" BackColor="Gainsboro"></SelectedDayStyle>
					<TitleStyle Font-Bold="True" BorderColor="Black" BackColor="#FAEECA"></TitleStyle>
					<WeekendDayStyle BackColor="#FEFEE0"></WeekendDayStyle>
					<OtherMonthDayStyle ForeColor="Gray"></OtherMonthDayStyle>
				</asp:Calendar>
               
			</div><div style="visibility:hidden">
		<asp:Textbox id="IsDFDelete" text="0" runat="server"></asp:Textbox></div>
            <script type="text/javascript">
            if(n=="1")
            {
                document.getElementById("IsDFDelete").value= "1";
                Form1.submit();
            }
            </script>
		</form>
	</body>
</html>
