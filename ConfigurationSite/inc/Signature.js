
var oSFs;
oSFS = new ActiveXObject("Scripting.FileSystemObject");

if (oSFS.FolderExists("C:\\vis")) {
    var strSignaturePath = "C:\\vis\\signature.jpg";  
}
else
{
	var strSignaturePath = "C:\\signature.jpg";   
}   


    var sigObj = new ActiveXObject("clsSignature");
    var FileUtil = new ActiveXObject("clsFileUtil");
    
	var now = new Date();
	var sresult;
	 
   
	function FuncCaptureSignature()
      {	
        sresult = sigObj.CaptureSignature(strSignaturePath, 2000);
          
        if (sresult==3019)
        {
          ShowSignatureResult("Pass",strSignaturePath);
        }
        else
        {  
		  
		  alert("No signature captured!");
        }
         
      }
      
      function ShowSignatureResult(itm,strPath)
      {	
         if(itm=='Pass')
         {
             document.getElementById("ctl00_Content_imgSignature").src = strPath + "?" + new Date().getTime(); 
             //document.getElementById("ctl00_Content_imgSignature").src = strPath+ now.getTime();
             //document.getElementById("ctl00_Content_imgSignature").src = strPath;                             
         }
         else
         {                
              document.getElementById("ctl00_Content_imgSignature").src = strPath;
          }
     }         	               

