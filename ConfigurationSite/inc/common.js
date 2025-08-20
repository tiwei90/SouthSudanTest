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
function birthdayCalendarPicker(strField, strPassportType)
{
    var thiscal;
	thiscal = window.open('BirthdayCalendar.aspx?PType='+strPassportType +'&field=aspnetForm.ctl00_Content_' + strField , 
	'calendarPopup','width=200,height=200,resizable=no,position=absolute,left=600,top=300');
	return thiscal;
}

function GetPcName()
{
    var ax = new ActiveXObject("WScript.Network");
    document.getElementById("ctl00_Content_txtCompName").value =  ax.ComputerName;

        
}   
 function ConfirmDelete()
    {
        if(confirm("Are you sure you want to delete this records?"))
        {
            return true;
        }
        else
        {
             return false;
        } 
    }
    
function calendarPicker(strField)
{
 var thiscal;
	thiscal = window.open('popupCal.aspx?field=aspnetForm.ctl00_Content_' + strField , 
	'calendarPopup','width=200,height=200,resizable=no,position=absolute,left=600,top=300');
return thiscal;
}

function showImage(imgPath)
{
var pp = window.open();
pp.document.writeln('<html><body>');
pp.document.writeln('<img alt="" src="');
pp.document.writeln(imgPath);
pp.document.writeln('" width="600" height="800">');
pp.document.writeln('</body></html>');

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



 