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


function ReadMRZ_Click()
{
	if (fReader == "pcsc"){
		
		alert("Please swipe your Visa now...");
			
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
                			//------------------- SURNAME ----------------------------------------------------//  
                			var fullSurname = FullName.substr(0,i);
                			var arrSurname = fullSurname.split("<");
                			var surname = "";
                			var x = 0;
                			while (x < arrSurname.length)
                			{                  
                  				surname = surname + arrSurname[x] + " ";                
                  				if(arrSurname[x] != "")
                     					x+=1;
                 	 			else
                     					x = arrSurname.length;
                			} 
                			document.getElementById("ctl00_Content_lblSurname2").value = trim(surname);
                
                			//------------------- GIVEN NAME ----------------------------------------------------//        
                			var Givename = FullName.substr(i+2);   
                			var arr = Givename.split("<");  
                			var mname = "";            
                			part_num = 0;                
                			while (part_num < arr.length)
                			{                  
                  				mname = mname + arr[part_num] + " ";                
                  				if(arr[part_num] != "")
                     					part_num+=1;
                  				else
                     					part_num = arr.length;
                				}
                			document.getElementById("ctl00_Content_lblFName2").value = trim(mname);
                			i=31; 
            				}            
        		}
        		//Get BirthDate
        		var DOB = MRZ.substr(49,6);
			
        		document.getElementById("ctl00_Content_lblDOB2").value = birthdateformat(DOB);
        
        		//Get Sex
        		var Sex = MRZ.substr(56,1);

        		if(Sex == "M")
            			document.getElementById("ctl00_Content_lblSex2").value = "MALE";
        		else
            			document.getElementById("ctl00_Content_lblSex2").value = "FEMALE";
        
        
         		//Get Visa Type
        		var VisaType = MRZ.substr(1,1);  
			    
        		DocumentTy(VisaType);
        
        		//Get Nationality
        		var Nationality = MRZ.substr(46,3);
			
        		document.getElementById("ctl00_Content_lblNationality2").value = Nationality;
        
        		//Get Visa Details
        		var DOCNO =  MRZ.substr(64,8);
			
        		document.getElementById("ctl00_Content_lblDocNo2").value = DOCNO;
        		//var COI = MRZ.substr(2,3);
        		//document.getElementById("ctl00_Content_PASSPORTCOI").value = COI;
        		var PASSPORTNO = MRZ.substr(36,9);
        		var splitPNO = PASSPORTNO.split("<");
        		document.getElementById("ctl00_Content_lblPersonalNo2").value = splitPNO[0];
        		var DOE = MRZ.substr(57,6);   
        		document.getElementById("ctl00_Content_lblDOE2").value = expirydateformat(DOE);
			
        
        		Compare();
        		CheckRecord(); 

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
		// Create an instance of the BHSPPReaderSDK wrapper		
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
                		//------------------- SURNAME ----------------------------------------------------//  
                		var fullSurname = FullName.substr(0,i);
                		var arrSurname = fullSurname.split("<");
                		var surname = "";
                		var x = 0;
                		while (x < arrSurname.length)
                		{                  
                  			surname = surname + arrSurname[x] + " ";                
                  			if(arrSurname[x] != "")
                     				x+=1;
                 	 		else
                     				x = arrSurname.length;
                		} 
                		document.getElementById("ctl00_Content_lblSurname2").value = trim(surname);
                
                		//------------------- GIVEN NAME ----------------------------------------------------//        
                		var Givename = FullName.substr(i+2);   
                		var arr = Givename.split("<");  
                		var mname = "";            
                		part_num = 0;                
                		while (part_num < arr.length)
                		{                  
                  			mname = mname + arr[part_num] + " ";                
                  			if(arr[part_num] != "")
                     				part_num+=1;
                  			else
                     				part_num = arr.length;
                		}
                		document.getElementById("ctl00_Content_lblFName2").value = trim(mname);
                		i=31; 
            		}            
        	}
        	//Get BirthDate
        	var DOB = MRZ.substr(50,6);
        	document.getElementById("ctl00_Content_lblDOB2").value = birthdateformat(DOB);
        
        	//Get Sex
        	var Sex = MRZ.substr(57,1);
        	if(Sex == "M")
            	document.getElementById("ctl00_Content_lblSex2").value = "MALE";
        	else
            	document.getElementById("ctl00_Content_lblSex2").value = "FEMALE";
        
        
         	//Get Visa Type
        	var VisaType = MRZ.substr(1,1);       
        	DocumentTy(VisaType);
        
        	//Get Nationality
        	var Nationality = MRZ.substr(47,3);
        	document.getElementById("ctl00_Content_lblNationality2").value = Nationality;
        
        	//Get Visa Details
        	var DOCNO =  MRZ.substr(65,8);
        	document.getElementById("ctl00_Content_lblDocNo2").value = DOCNO;
        	//var COI = MRZ.substr(2,3);
        	//document.getElementById("ctl00_Content_PASSPORTCOI").value = COI;
        	var PASSPORTNO = MRZ.substr(37,9);
        	var splitPNO = PASSPORTNO.split("<");
        	document.getElementById("ctl00_Content_lblPersonalNo2").value = splitPNO[0];
        	var DOE = MRZ.substr(58,6);   
        	document.getElementById("ctl00_Content_lblDOE2").value = expirydateformat(DOE);
        
        	Compare();
        	CheckRecord(); 

	}
        
}


    function CheckRecord()
    {
        if (document.getElementById("ctl00_Content_lblDocNo2").value != document.getElementById("ctl00_Content_lblDocNo").value 
            || document.getElementById("ctl00_Content_lblSex2").value != document.getElementById("ctl00_Content_lblSex").value
            || document.getElementById("ctl00_Content_lblPersonalNo2").value != document.getElementById("ctl00_Content_lblPersonalNo").value 
            ||document.getElementById("ctl00_Content_lblDOB2").value != document.getElementById("ctl00_Content_lblDOB").value 
            || document.getElementById("ctl00_Content_lblDOE2").value != document.getElementById("ctl00_Content_lblDOE").value 
            || document.getElementById("ctl00_Content_lblNationality2").value != document.getElementById("ctl00_Content_lblNationality").value             
            || document.getElementById("ctl00_Content_lblDocType2").value != document.getElementById("ctl00_Content_lblDocType").value )
            {
                document.getElementById("ctl00_Content_btn3rdIssue").disabled = true;
	            document.getElementById("ctl00_Content_btnIssue").disabled = true;	          
	            document.getElementById("ctl00_Content_IssueFail").disabled = false;
            }
         else
         {
                document.getElementById("ctl00_Content_btn3rdIssue").disabled = false;
	            document.getElementById("ctl00_Content_btnIssue").disabled = false;	          
	            document.getElementById("ctl00_Content_IssueFail").disabled = false;
         }
    }
    function Compare()
    {
        if (document.getElementById("ctl00_Content_lblPersonalNo2").value != document.getElementById("ctl00_Content_lblPersonalNo").value) 
        {
            document.getElementById("ctl00_Content_lblPersonalNo2").className = "BigLabel";
                  
        }
        else 
        {
            document.getElementById("ctl00_Content_lblPersonalNo2").className = "Label";
        }
        if (document.getElementById("ctl00_Content_lblDocType2").value != document.getElementById("ctl00_Content_lblDocType").value) 
        {
            document.getElementById("ctl00_Content_lblDocType2").className = "BigLabel";
        }
        else
        { 
            document.getElementById("ctl00_Content_lblDocType2").className = "Label";
        }
        if (document.getElementById("ctl00_Content_lblDocNo2").value != document.getElementById("ctl00_Content_lblDocNo").value)
        {
            document.getElementById("ctl00_Content_lblDocNo2").className = "BigLabel";
        }
        else
        {
            document.getElementById("ctl00_Content_lblDocNo2").className = "Label";
        }
        if (document.getElementById("ctl00_Content_lblNationality2").value != document.getElementById("ctl00_Content_lblNationality").value)
        {
            document.getElementById("ctl00_Content_lblNationality2").className = "BigLabel";
        }
        else
        {
            document.getElementById("ctl00_Content_lblNationality2").className = "Label";
        }
        if (document.getElementById("ctl00_Content_lblSex2").value != document.getElementById("ctl00_Content_lblSex").value)
        {
            document.getElementById("ctl00_Content_lblSex2").className = "BigLabel";
        }
        else
        {
            document.getElementById("ctl00_Content_lblSex2").className = "Label";
        }
//        if (document.getElementById("ctl00_Content_lblSurname2").value != document.getElementById("ctl00_Content_lblSurname").value)
//        {
//            document.getElementById("ctl00_Content_lblSurname2").className = "BigLabel";
//        }
//        else
//        {
//            document.getElementById("ctl00_Content_lblSurname2").className = "Label";
//        }
        if (document.getElementById("ctl00_Content_lblDOB2").value != document.getElementById("ctl00_Content_lblDOB").value)
        {
            document.getElementById("ctl00_Content_lblDOB2").className = "BigLabel";
        }
        else
        {
            document.getElementById("ctl00_Content_lblDOB2").className = "Label";
        }
        if (document.getElementById("ctl00_Content_lblDOE2").value != document.getElementById("ctl00_Content_lblDOE").value)
        {
            document.getElementById("ctl00_Content_lblDOE2").className = "BigLabel";
        }
        else
        {
            document.getElementById("ctl00_Content_lblDOE2").className = "Label";
        }
    }
    function DocumentTy(DocType)
    {
            DocType = trim(DocType);
            if(DocType == "D")
            {
                document.getElementById("ctl00_Content_lblDocType2").innerText = "DP - DIPLOMATIC";
            }
            else if(DocType == "O")
            {
                document.getElementById("ctl00_Content_lblDocType2").innerText = "OF - OFFICIAL/SERVICE";
            }
            else if(DocType == "V")
            {
                document.getElementById("ctl00_Content_lblDocType2").innerText = "V - VISITOR";
            }
            else if(DocType == "T")
            {
                document.getElementById("ctl00_Content_lblDocType2").innerText = "T - TRANSIT";
            }
            else if(DocType == "C")
            {
                document.getElementById("ctl00_Content_lblDocType2").innerText = "C - CREW";
            }           
            else
            {
                document.getElementById("ctl00_Content_lblDocType2").innerText = "UNKNOWN"; 
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

function ReadVisa_Click()
{
	if (fReader == "pcsc"){
		
		alert("Please swipe your Visa now ...");
			
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
                			document.getElementById("ctl00_Content_lblSurname2").innerText = FullName.substr(0,i);               
                         
                			var Givename = FullName.substr(i+2);   
                			var arr = Givename.split("<");  
                			var mname = "";            
                			part_num = 0;                
                			while (part_num < arr.length)
                			{                  
                  				mname = mname + arr[part_num] + " ";                
                  				if(arr[part_num] != "")
                     					part_num+=1;
                  				else
                     					part_num = arr.length;
                			}
                			document.getElementById("ctl00_Content_lblFName2").innerText = mname;
                			i=31; 
            			}   
			}    
            		
			//Get BirthDate
            		var DOB = MRZ.substr(49,6);
			
            		document.getElementById("ctl00_Content_lblDOB2").innerText = birthdateformat(DOB);
            
            		//Get Sex
            		var Sex = MRZ.substr(56,1);
			
            		if(Sex == "M")
               			document.getElementById("ctl00_Content_lblSex2").innerText = "MALE";
            		else
               			document.getElementById("ctl00_Content_lblSex2").innerText = "FEMALE";
            	
            
            		//Get Visa Type
            		var VisaType = MRZ.substr(1,1);      
            		DocumentTy(VisaType);
            
            		//Get Nationality
            		var Nationality = MRZ.substr(46,3); 
            		document.getElementById("ctl00_Content_lblNationality2").innerText = Nationality;
            
            		//Get Visa Details
            		var DOCNO =  MRZ.substr(64,8);
            		document.getElementById("ctl00_Content_lblDocNo2").innerText = DOCNO;
            		//var COI = MRZ.substr(2,3);
            		//document.getElementById("ctl00_Content_PASSPORTCOI").value = COI;
            		var PASSPORTNO = MRZ.substr(36,9);
            		var splitPNO = PASSPORTNO.split("<");
            		document.getElementById("ctl00_Content_lblPersonalNo2").innerText = splitPNO[0];
            		var DOE = MRZ.substr(57,6);   
            		document.getElementById("ctl00_Content_lblDOE2").innerText = expirydateformat(DOE);
			
			
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
		// Create an instance of the BHSPPReaderSDK wrapper		
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
                		document.getElementById("ctl00_Content_lblSurname2").innerText = FullName.substr(0,i);               
                         
                		var Givename = FullName.substr(i+2);   
                		var arr = Givename.split("<");  
                		var mname = "";            
                		part_num = 0;                
                		while (part_num < arr.length)
                		{                  
                  			mname = mname + arr[part_num] + " ";                
                  			if(arr[part_num] != "")
                     				part_num+=1;
                  			else
                     				part_num = arr.length;
                		}
                		document.getElementById("ctl00_Content_lblFName2").innerText = mname;
                		i=31; 
            		}       
            		//Get BirthDate
            		var DOB = MRZ.substr(50,6);
            		document.getElementById("ctl00_Content_lblDOB2").innerText = birthdateformat(DOB);
            
            		//Get Sex
            		var Sex = MRZ.substr(57,1);
            		if(Sex == "M")
                		document.getElementById("ctl00_Content_lblSex2").innerText = "MALE";
            		else
                		document.getElementById("ctl00_Content_lblSex2").innerText = "FEMALE";
            
            
             		//Get Visa Type
            		var VisaType = MRZ.substr(1,1);       
            		DocumentTy(VisaType);
            
            		//Get Nationality
            		var Nationality = MRZ.substr(47,3);
            		document.getElementById("ctl00_Content_lblNationality2").innerText = Nationality;
            
            		//Get Visa Details
            		var DOCNO =  MRZ.substr(65,8);
            		document.getElementById("ctl00_Content_lblDocNo2").innerText = DOCNO;
            		//var COI = MRZ.substr(2,3);
            		//document.getElementById("ctl00_Content_PASSPORTCOI").value = COI;
            		var PASSPORTNO = MRZ.substr(37,9);
            		var splitPNO = PASSPORTNO.split("<");
            		document.getElementById("ctl00_Content_lblPersonalNo2").innerText = splitPNO[0];
            		var DOE = MRZ.substr(58,6);   
            		document.getElementById("ctl00_Content_lblDOE2").innerText = expirydateformat(DOE);
             
        	}
	}
	    
}