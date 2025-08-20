//cursor function
function cursor_wait() 
{
  document.body.style.cursor = 'wait';
}

function cursor_clear() 
{
  document.body.style.cursor = 'default';
}
function cursor_pointer()
{
  document.body.style.cursor = 'pointer';
}

//Header Horizontal Menu Function
 function funcMouseOver()
{
	document.getElementById("tbList").style.visibility='visible';
}
 function funcMouseOut()
{
	document.getElementById("tbList").style.visibility='hidden';
}

function birthdayCalendarPicker(strField, strPassportType, strApplicant)
{
    var thiscal;
	thiscal = window.open('BirthdayCalendar.aspx?PType='+strPassportType +'&Applicant='+strApplicant+'&field=aspnetForm.ctl00_Content_' + strField , 
	'calendarPopup','width=200,height=200,resizable=no,position=absolute,left=600,top=300');
	return thiscal;
}

function calendarPicker(strField, strStatus, strText, strType, strDocType)
{
 var thiscal;
	thiscal = window.open('popupCal.aspx?field=aspnetForm.ctl00_Content_' + strField +'&Text='+strText+'&status='+ strStatus+'&Type='+strType+'&DocType='+strDocType, 
	'calendarPopup','width=200,height=200,resizable=no,position=absolute,left=600,top=300');
return thiscal;
}


// Menuitem Function
function HeaderOnclik(tb,td)
{  
	if(document.getElementById(tb).style.display=="none")
	{
	    document.getElementById(tb).style.display="";
	    document.getElementById(td).style.backgroundImage="url(./images/background_parentselected.gif)";

	}
	else
	{
	    document.getElementById(tb).style.display="none";
	    document.getElementById(td).style.backgroundImage="url( ./images/background_parent.gif)";

	}
}

function SubHeaderClick(tb)
{
	if(document.getElementById(tb).style.display == "none")
		document.getElementById(tb).style.display = "";
	else
		document.getElementById(tb).style.display = "none";
}

function getPrint(print_area, areaCode)
{	
	//Creating new page
	//var areaCode = "NASSAU";
    var pp = window.open();
    //Adding HTML opening tag with <HEAD> … </HEAD> portion 
    pp.document.writeln('<HTML><HEAD><title>Print Preview</title>')
    pp.document.writeln('<LINK href="inc/print.css" type="text/css" rel="stylesheet" media="print">') 
    pp.document.writeln('<link href="inc/main.css" rel="stylesheet" type="text/css" />')
    pp.document.writeln('<base target="_self"></HEAD>')
    //Adding Body Tag
    pp.document.writeln('<body onLoad="VBPrint();self.close();">');   
    pp.document.writeln('<table border="0" cellpadding="0" cellspacing="0" style="width: 100%"><tr><td style="width: 20%; height: 30px;" align="right" valign="middle"><img alt="" height="85" src="images/ministrylogo.gif" width="76" /></td><td style="width: 60%;" align="center"><span style="font-family: Arial;font-weight:bold;font-size: 22px;">The Country Name <br /><span style="font-size: 6px"><br /></span>Ministry of Foreign Affairs </span> <span style="font-family: Arial;font-weight:bold;font-size: 18px;"> <br /> Visa Office -');
    pp.document.writeln(areaCode);
    pp.document.writeln('<span style="font-family: Arial;font-weight:bold;font-size: 15px;text-decoration:underline;"><br /><br /> Auxiliary Receipt</span></span></td><td style="width: 20%;" align="left" valign="middle"></td></tr><tr><td align="right" style="width: 20%; height: 30px" valign="middle"></td><td align="center" style="width: 60%; height: 30px"></td><td align="left" style="width: 20%; height: 30px"></td></tr></table>');
    //Writing print area of the calling page
    pp.document.writeln('<table id="tbPrint" align="center" cellspacing="0" cellpadding="0" border="0">')
	pp.document.writeln(document.getElementById(print_area).innerHTML);	
	pp.document.writeln('</table><br /><br /><br />');
	pp.document.writeln('<table align="center" cellpadding="0" cellspacing="0" border="0" style="width: 80%"><tr><td align="center" class="LabelHead">This is a computer generated receipt. No signature is required. This receipt must be submitted in exchange for the new Visa.Thank you.</td></tr></table>');	
	//Ending Tag of </form>, </body> and </HTML>
    pp.document.writeln('<object id=WBControl width=0 height=0 classid=CLSID:8856F961-340A-11D0-A96B-00C04FD705A2></object>');
    pp.document.writeln('<script type="text/vbscript">');
    pp.document.writeln('Sub VBPrint() On Error Resume Next');
    pp.document.writeln('WBControl.ExecWB 6,2,3');
    pp.document.writeln('End Sub');
    pp.document.writeln('</script>');
    pp.document.writeln('</body></HTML>'); 
    pp.blur(); 
    pp.document.close(); 
}	
function GetPcName()
{
    var ax = new ActiveXObject("WScript.Network");
    document.getElementById("ctl00_Content_txtCompName").value =  ax.ComputerName;        
}  

	
   


  
  

	


 