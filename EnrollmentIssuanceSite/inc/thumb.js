/* Note: Finger Code
 ---------------------
  Finger1 refer to finger left 1 
  Finger2 refer to finger right 1
  Finger3 refer to finger left 2
  Finger4 refer to finger right 2
*/

var Obj = new ActiveXObject("ConversionLib");
var FileUtil = new ActiveXObject("clsFileUtil");
var bio = new ActiveXObject("Bio");	
	bio.ShowRadarDuringCapture = false;
	bio.CaptureMinQuality = 60;
	bio.ShowQualityLevel = true;
	bio.VerifyMinQuality = 60;
	bio.VerifyMinMatchScore = 500;
	bio.VerifySecurityLevel = 1;
var sresult;
var strFilePath1;
var strwsqPath1; 
var strImgPath1;
var strFilePath2;
var strwsqPath2;
var strImgPath2;
var Finger1Template;
var Finger2Template;
var Finger1Bmp;
var Finger2Bmp;
var Finger1Wsq;
var Finger2Wsq;  
var Successful = 8;
var license = 0;
var Endlicense = 1;
var initializeInd;
var open;
strImgPath1= "C:\\LFinger1.bmp";      
strwsqPath1="C:\\LFinger1.wsq";
strImgPath2="C:\\RFinger1.bmp";      
strwsqPath2 ="C:\\RFinger1.wsq"; 
Finger1Wsq="ctl00_Content_FINGER1IMAGE";
Finger2Wsq="ctl00_Content_FINGER2IMAGE";


  function closeDevice()
  {       
         if(bio == "Bio")
         {            
            bio.CloseDevice();
            bio = null;            
         }         
  }
  function FuncCaptureThumb(HandType)
  {       
        initializeInd = document.getElementById("ctl00_Content_INITIALIZE").value;
        FingerCode1 = document.getElementById("ctl00_Content_FINGER1CODE").value;
        FingerCode2 = document.getElementById("ctl00_Content_FINGER2CODE").value;      
        bio.CaptureDlgCaption = "Fingerprint Capture V1.00";
        bio.LeftButton1Caption = "Capture Left";
        bio.LeftButton2Caption = "Verify Left";
        bio.RightButton1Caption = "Capture Right";
        bio.RightButton2Caption = "Verify Right";   
        
        if(initializeInd == "0")
        {  
            open= bio.OpenDevice();          
            document.getElementById("ctl00_Content_INITIALIZE").value = "1";
        }
        else
        {
            open = true;
        }
        if(open) 
       	{  
            if (HandType == "L")
            {
                	bio.NoFinger= HandType;          				     		 			           
                    sresult = bio.CaptureFinger("C:\\LFinger1.bin",strwsqPath1, strImgPath1,FingerType(FingerCode1),
                    "","", "",FingerType(FingerCode2));          
                                 
            }
            else if (HandType == "R")
            {                		           				     		 			           
                   bio.NoFinger= HandType;  
                   sresult = bio.CaptureFinger("","", "",FingerType(FingerCode1),
                    "C:\\RFinger1.bin",strwsqPath2, strImgPath2,FingerType(FingerCode2));
            }           
       }
       else
       {    
             document.getElementById("ctl00_Content_INITIALIZE").value = "0";
             return;
       }
       if (sresult)
       {  	    
            
            if(HandType == "L")
            {
                document.getElementById(Finger1Wsq).value = FileUtil.EncodeFromFileToStr(strwsqPath1);
                document.getElementById("ctl00_Content_LEFTPATH").value = strImgPath1;
                ShowFingerResult('H1',"Pass",strImgPath1);
            }
            else
            {
                 document.getElementById(Finger2Wsq).value = FileUtil.EncodeFromFileToStr(strwsqPath2); 
                 document.getElementById("ctl00_Content_RIGHTPATH").value = strImgPath2;
                 ShowFingerResult('H2',"Pass",strImgPath2);  	   
            }
		         	 
        }
    
        else
        { 
            bio.CloseDevice(); 
            document.getElementById("ctl00_Content_INITIALIZE").value = "0";
              
            if (HandType == "L")
            {
                //document.getElementById(Finger1Wsq).value = ""; 
                ShowFingerResult('H1','Fail',"images\\NoImage.jpg");
            }
            else
            {
               //document.getElementById(Finger2Wsq).value = "";  
               ShowFingerResult('H2','Fail',"images\\NoImage.jpg");  	            
            } 
            alert("Failed to capture fingerprint! Please verify your fingerprint before exiting.");

        }                     
        
        document.getElementById("ctl00_Content_btnSave").disabled= false;
                           			     		 			                     
  }  
  
function ShowFingerResult(hand,itm1,strPath1)
{
   var  imageControl;
   var  fingerCode;
   var  fingerReason ;

   
    if(hand=="H1")
    {
        imageControl = "ctl00_Content_imgLFinger1";
        fingerCode = "ctl00_Content_FINGER1CODE";
        fingerReason ="ctl00_Content_FINGER1REASON";
    }
    else
    {
        imageControl = "ctl00_Content_imgRFinger1";
        fingerCode = "ctl00_Content_FINGER2CODE";
        fingerReason ="ctl00_Content_FINGER2REASON";
    }

    
     if(itm1=='Pass')
     {
          document.getElementById(imageControl).src = strPath1; 
      }
      else
      {             
          //document.getElementById(imageControl).src = strPath1;
          document.getElementById(fingerCode).className = "cssSelect";
          document.getElementById(fingerReason).className = "cssSelect";  
     }                  

  }  
  

function ConvertMsg(MsgCode)
{
    if      (MsgCode == -1) return "UNEXPECTED_ERROR!";
    else if (MsgCode == 0 ) return "LICENSE_SUCCESSFULLY_CREATED!";
    else if (MsgCode == 1 ) return "LICENSE_SUCCESSFULLY_DESTROYED!";
    else if (MsgCode == 2 ) return "WSQ_FILE_NOT_FOUND!";
    else if (MsgCode == 3 ) return "BMP_FILE_NOT_FOUND!";
    else if (MsgCode == 4 ) return "UNABLE_TO_CREATE_WSQ_IMAGE!";
    else if (MsgCode == 5 ) return "UNABLE_TO_CREATE_TEMPLATE_FROM_IMAGE!";
    else if (MsgCode == 6 ) return "UNABLE_TO_WRITE_CONVERTED_BIN_TO_DISK!";
    else if (MsgCode == 7 ) return "UNABLE_TO_WRITE_CONVERTED_WSQ_TO_DISK!";
    //else if (MsgCode == 8 ) return "CONVERSION_SUCCESSFUL!";
    else if (MsgCode == 9 ) return "BSDK_LICENSE_NOT_FOUND!";
    else if (MsgCode == 10 ) return "INPUT_OUTPUT_FILE_PATH_IS_INVALID!";
    else if (MsgCode == 11 ) return "BSDK_LICENSE_FOUND_BUT_IS_ILLEGITIMATE!";
    else if (MsgCode == 12 ) return "UNABLE_TO_CREATE_BMP_FROM_IMAGE!";
    else if (MsgCode == 13 ) return "UNABLE_TO_WRITE_CONVERTED_BMP_TO_DISK!";
}



function FingerType(fingerCode)
{ 
   switch(fingerCode)
   {
     case "L1":
     return 6;
     break;
     case "L2":
     return 7;
     break;
     case "L3":
     return 8;
     break;
     case "L4":
     return 9;
     break;
     case "L5":
     return 10;
     break;
     case "R1":
     return 1;
     break;
     case "R2":
     return 2;
     break;
     case "R3":
     return 3;
     break;
     case "R4":
     return 4;
     break;
     case "R5":
     return 5;
     break;
     default:
     break;
   }
  
}
