//To swap between pcsc and pro
var oFs, oFile, fString, fReader;
oFS = new ActiveXObject("Scripting.FileSystemObject");

if (oFS.FileExists("C:\\vis\\fReaderConfig.ini")){
	oFile = oFS.OpenTextFile("C:\\vis\\fReaderConfig.ini", 1, true);
	fString = oFile.ReadLine(); 
		
	if (fString == "pcsc")
	{
		fReader = "pcsc";
	}
	else
	{
		fReader = "pro";
	}

	oFile.Close();
		
		
}
else{
	fReader = "pro";
}


	function ReadEPP_Click()
	{
		if (fReader == "pcsc"){
		
			alert("Please swipe your passport now ...");
			
			var obj = new ActiveXObject("clsIRISMRZSwiper");	
 
            		//ReaderMode: proprietary(0) ; pcsc(1)
            		obj.ReaderMode = 1;

            		//May leave PCSCReaderName="" if proprietary mode 
            		obj.PCSCReaderName = "EPP PCSC READER 0";
            
           		 var iMRZLen = obj.GetMRZ();
			
			if (iMRZLen != -1 && iMRZLen != -99)
            		{	
				// Get FirstName, MiddleName, LastName
				var MRZ = obj.MRZ;
		
				var FullName = MRZ.substr(5,31);

				for (var i=0; i < FullName.length; i++)
        			{           
            				if(FullName.substr(i,2)== "<<")
            				{
                				var firstname = FullName.substr(0,i);                      
                				var splitFN = firstname.split("<");           
                				var x = 0;
                				var fname="";
                				while (x < splitFN.length)
                				{                  
                  					fname = fname + splitFN[x] + " ";                  
                  					if(fname[x] != "")
                     						x+=1;
                  					else
                     						x = fname.length;
                				}
               					document.getElementById("ctl00_Content_SURNAME").value = fname;                
                				var Givename = FullName.substr(i+2);   
                				var arr = Givename.split("<"); 
               
                				var mname="";
                				part_num = 1;              
                				document.getElementById("ctl00_Content_FIRSTNAME").value = arr[0];             
                
                				while (part_num < arr.length)
                				{                  
                  					mname = mname + arr[part_num];                
                  					if(arr[part_num] != "")
                     						part_num+=1;
                  					else
                     						part_num = arr.length;
                				}
                				document.getElementById("ctl00_Content_MIDDLENAME").value = mname;
                				i=39;                   
            				}            
        			}
        			//Get BirthDate
        			var DOB = MRZ.substr(57,6);
        			document.getElementById("ctl00_Content_BIRTHDATE").value = birthdateformat(DOB);
        
        			//Get Sex      
        			var Sex = MRZ.substr(64,1);        
        			if(Sex == "M")
            				document.forms["aspnetForm"].ctl00$Content$SEX[0].checked = true;
        			else        
            				document.forms["aspnetForm"].ctl00$Content$SEX[1].checked =  true;

				
        			//Get Nationality
        			var Nationality = MRZ.substr(54,3);
        			document.getElementById("ctl00_Content_NATIONALITY").value = Nationality;
        			

        			//Get Passport Details
        			var PASSPORTCOI = MRZ.substr(2,3);
        			document.getElementById("ctl00_Content_PASSPORTCOI").value = PASSPORTCOI;
        			var PASSPORTNO = MRZ.substr(44,9);
        			var splitPNO = PASSPORTNO.split("<");
        			document.getElementById("ctl00_Content_PASSPORTNO").value = splitPNO[0];
        			var PASSPORTDOE = MRZ.substr(65,6); 
        			document.getElementById("ctl00_Content_PASSPORTDOE").value = expirydateformat(PASSPORTDOE);

             
               			//document.getElementById("ctl00_Content_lblPersonalNo").innerText	= obj.MRZ1;
               			//document.getElementById("ctl00_Content_lblDocNo").innerText		  = obj.MRZ2;
               			//document.getElementById("ctl00_Content_lblSurname").innerText		= obj.MRZ3;
               			//document.getElementById("ctl00_Content_lblFName").innerText	  	= obj.MRZ;
              
            		}
			else if (iMRZLen == -99)
	    		{
                		alert(" Initialize passport failed. \n Please make sure reader is connected. \n If problem persists, please unplug and plug in the reader to try again.\n \n Debugging Info : <DetailLog.txt> consists of APDU logging info.");
	    		} 
 	          	else
	          	{
                  	alert("Error in getting MRZ, please try again ...");
	          	} 
	



		}
		else
   		{

	     		// Create an instance of the wrapper		
		 	var Obj = new ActiveXObject("GetMRZ");		 

		 
		
			if(!Obj.SwipeMRZ())	
		    	return;	
		 
			// Get FirstName, MiddleName, LastName
			var MRZ = Obj.F1000MRZ;		
			var FullName = MRZ.substr(5,31);
			for (var i=0; i < FullName.length; i++)
        		{           
            			if(FullName.substr(i,2)== "<<")
            			{
                			var firstname = FullName.substr(0,i);                      
                			var splitFN = firstname.split("<");           
                			var x = 0;
                			var fname="";
                			while (x < splitFN.length)
                			{                  
                  				fname = fname + splitFN[x] + " ";                  
                  				if(fname[x] != "")
                     					x+=1;
                  				else
                     					x = fname.length;
                			}
               				document.getElementById("ctl00_Content_SURNAME").value = fname;                
                			var Givename = FullName.substr(i+2);   
                			var arr = Givename.split("<"); 
               
                			var mname="";
                			part_num = 1;              
                			document.getElementById("ctl00_Content_FIRSTNAME").value = arr[0];             
                
                			while (part_num < arr.length)
                			{                  
                  				mname = mname + arr[part_num];                
                  				if(arr[part_num] != "")
                     					part_num+=1;
                  				else
                     					part_num = arr.length;
                			}
                			document.getElementById("ctl00_Content_MIDDLENAME").value = mname;
                			i=39;                   
            			}            
        		}
        		//Get BirthDate
        		var DOB = MRZ.substr(58,6);
        		document.getElementById("ctl00_Content_BIRTHDATE").value = birthdateformat(DOB);
        
        		//Get Sex      
       	 		var Sex = MRZ.substr(65,1);        
        		if(Sex == "M")
            		document.forms["aspnetForm"].ctl00$Content$SEX[0].checked = true;
        		else        
            		document.forms["aspnetForm"].ctl00$Content$SEX[1].checked =  true;
        
        		//Get Nationality
        		var Nationality = MRZ.substr(55,3);
        		document.getElementById("ctl00_Content_NATIONALITY").value = Nationality;
        
        		//Get Passport Details
        		var PASSPORTCOI = MRZ.substr(2,3);
        		document.getElementById("ctl00_Content_PASSPORTCOI").value = PASSPORTCOI;
        		var PASSPORTNO = MRZ.substr(44,10);
        		var splitPNO = PASSPORTNO.split("<");
        		document.getElementById("ctl00_Content_PASSPORTNO").value = splitPNO[0];
        		var PASSPORTDOE = MRZ.substr(66,6);   
        		document.getElementById("ctl00_Content_PASSPORTDOE").value = expirydateformat(PASSPORTDOE);
		}
    }
   
    function birthdateformat(inputstr)
    {
       var date;
       var currentTime = new Date();
       var year = currentTime.getFullYear();
       var temp = year.toLocaleString();
       var yearBack = temp.substring(3,5);
       var yearFront = temp.substring(0,1) + temp.substring(2,3);
       temp = yearFront + inputstr.substring(0,2);
    

        if( temp <= year)
        {
             date = inputstr.substring(4) + "/"  + inputstr.substring(2,4) + "/" + yearFront + inputstr.substring(0,2);
        }
        else
        {
             date = inputstr.substring(4) + "/"  + inputstr.substring(2,4) + "/" + (yearFront-1) + inputstr.substring(0,2);
        }
        return date;
     }
     function expirydateformat(inputstr)
    {
        var date;
        var currentTime = new Date();
        var year1 = currentTime.getFullYear();
        var year = year1.toLocaleString();
        var yearBack = year.substring(3,5);
        var yearFront = year.substring(0,1) + year.substring(2,3);
        var temp = inputstr.substring(0,2);
        var added = yearFront + temp;    

        date = inputstr.substring(4) + "/"  + inputstr.substring(2,4) + "/" + yearFront + inputstr.substring(0,2);
        return date;
    }	 

		
    function trim(s)
    {	
            if((s==null)||(typeof(s)!='string')||!s.length)return'';
            return s.replace(/^\s+/,'').replace(/\s+$/,'');
    }