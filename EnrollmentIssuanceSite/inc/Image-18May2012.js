    

    var sigObj = new ActiveXObject("clsSignature");
    var FileUtil = new ActiveXObject("clsFileUtil");
    
	var now = new Date();
	var sresult;
	var strSignaturePath = "C:\\signature.jpg";   

   

	function FuncCaptureSignature()
      {	
		document.getElementById('ctl00_Content_ChkboxSign').checked = false;	                                          			     		 			             
        sresult = sigObj.CaptureSignature(strSignaturePath, 2000);
          
        if (sresult==3019)
        {
          document.getElementById("ctl00_Content_SIGNIMAGE").value = FileUtil.EncodeFromFileToStr(strSignaturePath);
          ShowSignatureResult("Pass",strSignaturePath);
          document.getElementById('ctl00_Content_ChkboxSign').checked = false;  
        }
        else
        {  
		  
		  alert("No signature captured!");
		  //document.getElementById("ctl00_Content_SIGNIMAGE").value = "";   
          //ShowSignatureResult('Fail',"images\\NoImage2.jpg");
          //document.getElementById('ctl00_Content_ChkboxSign').checked = true;                        
        }
        //document.getElementById('ctl00_Content_btnSave').disabled=false;	
         
      }
      
      function ShowSignatureResult(itm,strPath)
      {	
         if(itm=='Pass')
         {
          //this line is to force the image to replace
             document.getElementById("ctl00_Content_imgSignature").src = strPath+ now.getTime();
             document.getElementById("ctl00_Content_imgSignature").src = strPath;
             document.getElementById('ctl00_Content_ChkboxSign').checked == false;
                             
         }
         else
         {                
			  document.getElementById('ctl00_Content_ChkboxSign').checked == true;
              document.getElementById("ctl00_Content_imgSignature").src = strPath;
          }
     }
         
	 function FuncCapturePhoto()
     {		     		 		
    	     		 			              
        sresult = Obj.CallScanner(strPhotoName, strPhotoPath);
        if (sresult == true)
        {
          document.getElementById('ctl00_Content_FACEIMAGE').value = FileUtil.EncodeFromFileToStr(strPhotoPath);
		  document.getElementById("ctl00_Content_FACEIMAGEJ2K").value = FileUtil.EncodeFromFileToStr(strPhotoJP2Path);
		  //document.getElementById('ctl00_Content_ChkboxPhoto').checked = false;
          ShowPhotoResult('Pass',strPhotoPath); 
        }
        else
        {    
          document.getElementById("ctl00_Content_FACEIMAGE").value = "";   
          document.getElementById("ctl00_Content_FACEIMAGEJ2K").value = "";   
          //document.getElementById('ctl00_Content_ChkboxPhoto').checked = true;
          ShowPhotoResult('Fail',"images\\NoImage.jpg");                          
        } 
       
        sresult = "";
        document.getElementById("ctl00_Content_btnSave").disabled = false;                   			     		 			                                   
      }
      
       function ShowPhotoResult(itm,strPath)
      {
         if(itm=='Pass')
         {
            //this line is to force the image to replace
            document.getElementById("ctl00_Content_imgPhoto").src = strPath+ now.getTime();
            document.getElementById("ctl00_Content_imgPhoto").src = strPath;
          }
          
          else
          {
               document.body.style.cursor = 'default'; 
               document.getElementById("ctl00_Content_imgPhoto").src = strPath;
          }
      }
      

