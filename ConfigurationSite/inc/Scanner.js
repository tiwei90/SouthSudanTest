var oPFs;
oPFs = new ActiveXObject("Scripting.FileSystemObject");

// JScript File
var FileUtil = new ActiveXObject("clsFileUtil");
var doc = new ActiveXObject("WIAScannerLib.WIAScannerLibClass");	

var now = new Date();
var strImgSrc;
var strImgPath;
var strBase64;
var strPhoto;
var strPhotoJP2;
var strPhotoName;
var strDocName;
var strWindowCaption;
 
function CaptureImage(displayBox)
{

	if (oPFs.FolderExists("C:\\vis")){
		 
		 img = "temp";   
		 strWindowCaption = "Document Scanner";
		 strImgPath = "C:\\vis\\" + img + ".jpg"; 		
		 strImgSrc =  "ctl00_Content_" + displayBox;
		 strDocName = img + ".bmp";

		 var Result = doc.CallScanner(strWindowCaption, strDocName, "C:\\vis\\", "2");


	}
	else
	{
		 img = "temp";   
		 strWindowCaption = "Document Scanner";	
		 strImgPath = "C:\\"+ img + ".jpg"; 		
		 strImgSrc =  "ctl00_Content_" + displayBox;
		 strDocName = img + ".bmp";	

		 var Result = doc.CallScanner(strWindowCaption, strDocName, "C:\\","2");		 		   
	}


         	 
		 
		
         document.getElementById(strImgSrc).src= "images/spacer.gif";
         
		 			 
		 
		 
		 if (Result == false) //call failed
		 {
		    alert("Failed to scan supporting document!");
		    
		    ShowImageResult("Fail","images\\NoImage.jpg",strImgSrc);
		 }
		 else
		 {		     
		     
		     ShowImageResult("Pass",strImgPath,strImgSrc);
		    
		 }
		 return;

}

function ShowImageResult(code, strPath, strSrc)
{
   if(code== "Pass")
   {
       document.getElementById(strSrc).src = strPath + "?" + new Date().getTime(); 
       //document.getElementById(strSrc).src = strPath+ now.getTime();
       //document.getElementById(strSrc).src = strPath;
   }
   else
   {
      document.getElementById(strSrc).src = strPath;
   }
   
}

  
      

    
    
          
              

