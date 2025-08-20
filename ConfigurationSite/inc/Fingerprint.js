/* Note: Finger Code
 ---------------------
  Finger1 refer to finger left 1 
  Finger2 refer to finger right 1
  Finger3 refer to finger left 2
  Finger4 refer to finger right 2
*/

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



  function FuncCaptureThumb(HandType)
  {       
       
        strImgPath1= "C:\\LFinger1.bmp";      
        strwsqPath1="C:\\LFinger1.wsq";
        strImgPath2="C:\\RFinger1.bmp";      
        strwsqPath2 ="C:\\RFinger1.wsq"; 
        FingerCode1 = "L1";
        FingerCode2 = "R1";
        FingerWsq="FINGERIMAGE";
        bio.CaptureDlgCaption = "Fingerprint Capture V1.00";
        bio.LeftButton1Caption = "Capture Left";
        bio.LeftButton2Caption = "Verify Left";
        bio.RightButton1Caption = "Capture Right";
        bio.RightButton2Caption = "Verify Right";     
        
        var open= bio.OpenDevice();
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
            bio.CloseDevice(); 
       }
       if (sresult)
       {
	   	      
    	    //alert("Fingerprint is successfully captured!")
    	    if (HandType == "L")
            {
                ShowFingerResult('H1',"Pass",strImgPath1);
                
            }
		         	 
        }
    
        else
        { 
            bio.CloseDevice(); 
              
            if (HandType == "L")
            {
                //document.getElementById(Finger1Wsq).value = ""; 
                ShowFingerResult('H1','Fail',"images\\NoImage.jpg");
            }

            alert("Failed to capture fingerprint! Please verify your fingerprint before exiting.");

        }                     
                                   			     		 			                     
  }  
  
function ShowFingerResult(hand,itm1,strPath1)
{
   var  imageControl;
   var  fingerCode;
   var  fingerReason ;
 
    
     if(itm1=='Pass')
     {
          document.getElementById("ctl00_Content_imgLFinger").src = strPath1; 
      }               
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
