var oPFs;
oPFs = new ActiveXObject("Scripting.FileSystemObject");

// JScript File
var FileUtil = new ActiveXObject("clsFileUtil");
var doc = new ActiveXObject("WIAScannerLibClass");	

var now = new Date();
var strImgSrc;
var strImgPath;
var strBase64;
var strPhoto;
var strPhotoJP2;
var strPhotoName;
var strDocName;
var strWindowCaption;
 
function CaptureImage(img,displayBox,txtbase64)
{
	if (oPFs.FolderExists("C:\\vis")){
		 // Create an instance of the WIAScanner wrapper		
		 strWindowCaption = "The Visa Document Scanner";	
		 strImgPath = "C:\\vis\\"+ img + ".jpg"; 			
		 strImgSrc = "ctl00_Content_" + displayBox;
		 strBase64 = "ctl00_Content_" + txtbase64;
		 strDocName = img + ".jpg";

		var Result = doc.CallScanner(strWindowCaption, strDocName, "C:\\vis\\","2");

	}
	else
	{
		 // Create an instance of the WIAScanner wrapper		
		 strWindowCaption = "The Visa Document Scanner";	
		 strImgPath = "C:\\"+ img + ".jpg"; 			
		 strImgSrc = "ctl00_Content_" + displayBox;
		 strBase64 = "ctl00_Content_" + txtbase64;
		 strDocName = img + ".jpg";

		 var Result = doc.CallScanner(strWindowCaption, strDocName, "C:\\","2");				 		   
	}


	   
		 
		
         document.getElementById(strImgSrc).src= "images/spacer.gif";
         document.getElementById(strBase64).value = "";
         
		 			 
		 
		 
		 if (Result == false) //call failed
		 {
		    alert("Failed to scan supporting document!");
		    document.getElementById(strBase64).value = "";
		    ShowImageResult("Fail","images\\NoImage.jpg",strImgSrc);
		 }
		 else
		 {		     
		     
		     document.getElementById(strBase64).value = FileUtil.EncodeFromFileToStr(strImgPath);
		     ShowImageResult("Pass",strImgPath,strImgSrc);
		    
		 }
		 return;

}
function CapturePhoto(img,displayBox,txtbase64, txtjp2)
{
	if (oPFs.FolderExists("C:\\vis")){
		 strWindowCaption = "The Visa Photograph Scanner";   
		 strImgSrc = "ctl00_Content_" + displayBox;
		 strBase64 = "ctl00_Content_" + txtbase64;
		 strjp2 = "ctl00_Content_" + txtjp2;
		 strImgPath = "C:\\vis\\"+ img + ".jpg";
		 strPhotoJP2 = "C:\\vis\\Photo.jp2";
		 strPhotoName = img + ".jpg";	
		 	
		  //var Result = true;
		  var Result = doc.CallScanner(strWindowCaption, strPhotoName, "C:\\vis\\", "1");

	}
	else
	{
		strWindowCaption = "The Visa Photograph Scanner";   
		 strImgSrc = "ctl00_Content_" + displayBox;
		 strBase64 = "ctl00_Content_" + txtbase64;
		 strjp2 = "ctl00_Content_" + txtjp2;
		 strImgPath = "C:\\"+ img + ".jpg";
		 strPhotoJP2 = "C:\\Photo.jp2";
		 strPhotoName = img + ".jpg";	
		 	
		  //var Result = true;
		  var Result = doc.CallScanner(strWindowCaption, strPhotoName, "C:\\", "1");			 		   
	}


	     	

		
		 
		 
		 if (Result == false) //call failed
		 {
		    alert("No photo captured!");		
		 }
		 else
		 {		     
		     
		     document.getElementById(strBase64).value = FileUtil.EncodeFromFileToStr(strImgPath);
		     document.getElementById(strjp2).value = FileUtil.EncodeFromFileToStr(strPhotoJP2);
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
function  showImage(imgPath)
{
    var pp = window.open();
    pp.document.writeln('<html><body>');
    pp.document.writeln('<img alt="" src="');
    pp.document.writeln(imgPath);
    pp.document.writeln('" width="600" height="800">');       
    pp.document.writeln('</body></html>');

}
function BrowsePhoto(imgName,displayBox,txtbase64, txtjp2)
{

	if (oPFs.FolderExists("C:\\vis")){
		 var height = "320";
    		var width = "240";
    		var windowTitle = "The Visa Photograph";
    		var bannerTitle = "The Visa Enrollment"; 
    		strImgSrc = "ctl00_Content_" + displayBox;
    		strBase64 = "ctl00_Content_" + txtbase64;
    		strjp2 = "ctl00_Content_" + txtjp2;
    		strImgPath = "C:\\vis\\"+ imgName + ".bmp";
    		strPhotoJP2 = "C:\\vis\\Photo.jp2";
    		strPhotoName = imgName + ".bmp";
    		strImgName = "vis//" + imgName

	}
	else
	{
		var height = "320";
    		var width = "240";
    		var windowTitle = "The Visa Photograph";
    		var bannerTitle = "The Visa Enrollment"; 
    		strImgSrc = "ctl00_Content_" + displayBox;
    		strBase64 = "ctl00_Content_" + txtbase64;
    		strjp2 = "ctl00_Content_" + txtjp2;
    		strImgPath = "C:\\"+ imgName + ".bmp";
    		strPhotoJP2 = "C:\\Photo.jp2";
    		strPhotoName = imgName + ".bmp";		 		   
	}


    
    
    
    var ObjPhoto = new ActiveXObject("LoadImageLib");
        
    if(ObjPhoto == "LoadScannedDocLib.LoadImageLib")
    {
	if (oPFs.FolderExists("C:\\vis")){
		 var result = ObjPhoto.ActivateUI(windowTitle, bannerTitle, strImgName, height, width);

	}
	else
	{
		var result = ObjPhoto.ActivateUI(windowTitle, bannerTitle, imgName, height, width);  		 		   
	}

           
        if(result)
        {
             document.getElementById(strBase64).value = FileUtil.EncodeFromFileToStr(strImgPath);
	         document.getElementById(strjp2).value = FileUtil.EncodeFromFileToStr(strPhotoJP2);
	         ShowImageResult("Pass",strImgPath,strImgSrc);            
        }
        else
            alert("Failed to capture photograph!");
    }
    else
    {
        alert("Mobile photograph component is not installed.\nPlease contact your system administrator.");
    }
    
}
  
      

    
    
          
              