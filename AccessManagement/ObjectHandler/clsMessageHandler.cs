using AccessManagement.Shared;
using AccessManagement.Utilities;
using System;
using System.Collections;
using System.Xml;
using System.Xml.Schema;

namespace AccessManagement.ObjectHandler
{
    public class MessageHandler
    {
        //private byte[] m_sXMLbytes;
        public Status result;

        public MessageHandler()
        {
            result = new Status();
        }

        public void CleanUp()
        {
            if (result != null)
                result = null;
        }

        #region Common Message Query methods
        public void ProcessMessage(string postXML)
        {
            if (Globals.m_sDebugMode == "1")
            {
                TextLogFile.WriteTrace("[TRACE] ProcessMessage Getting XML Bytes ");
            }

            if (Globals.m_sSaveXML == "1")
            {
                TextLogFile.WriteRequest(postXML);
            }

            ParseXml(XmlMethods.GetXMLBytes(postXML));

            if (Globals.m_sDebugMode == "1")
            {
                TextLogFile.WriteTrace("[TRACE] Initialize Schema Validation Class for " + result.PermissionCode);
            }

            if (System.IO.File.Exists(Globals.m_sSchemaPath + result.PermissionCode + "req.xsd"))
            {
            }
            else
            {
                ValidateUserXml(XmlMethods.GetXMLBytes(postXML), Globals.m_sSchemaPath + "Request.xsd");
            }
            ////			switch  (result.PermissionCode)
            ////			{
            ////
            ////				case "13.63.9":
            ////					ValidateUserXml(XmlMethods.GetXMLBytes(postXML), Globals.m_sSchemaPath +  "Login.xsd") ;	
            ////					break;
            ////
            ////				default:
            ////					ValidateUserXml(XmlMethods.GetXMLBytes(postXML), Globals.m_sSchemaPath +  "Request.xsd") ;
            ////					break;
            ////			}



            if (Globals.m_sDebugMode == "1")
            {
                TextLogFile.WriteTrace("[TRACE] Invoke Message digester for " + result.PermissionCode);
            }

            CallObjectByName(result.ModuleName, result.FunctionName, XmlMethods.GetXMLBytes(postXML));

        }

        private void CallObjectByName(string objNameSpace, string functionName, byte[] postXML)
        {
            try
            {
                if (result.StatusCode == "0")
                {
                    if (Globals.m_sDebugMode.ToString() == "1")
                    {
                        TextLogFile.WriteTrace("[TRACE] CallObjectByName" + " - " + objNameSpace);
                    }

                    if (objNameSpace != String.Empty)
                    {
                        // Prepare the method parameters.
                        object[] oparams = new object[2];
                        oparams[0] = (object)(postXML);
                        oparams[1] = (object)(result);

                        if (Globals.m_sDebugMode == "1")
                        {
                            TextLogFile.WriteTrace("[TRACE] Message digester for " + result.PermissionCode);
                        }

                        // Instantiate object based on the given assembly/namespace
                        Type objectType = Type.GetType(objNameSpace);

                        object oObjectByName = Activator.CreateInstance(objectType);
                        Status OutResult = (Status)objectType.InvokeMember(result.FunctionName, System.Reflection.BindingFlags.InvokeMethod, null, oObjectByName, oparams);

                        result.PermissionCode = OutResult.PermissionCode;
                        result.ActionDescription = OutResult.ActionDescription;
                        result.StatusCode = OutResult.StatusCode;
                        result.StatusMessage = OutResult.StatusMessage;
                        result.Payload = OutResult.Payload;
                    }
                }
            }
            catch (Exception err)
            {
                result.StatusCode = "13.86.10.4";
                result.StatusMessage = "[" + result.PermissionCode + "] " + " [" + result.StatusCode + "] " + err.Message;

                TextLogFile.WriteLog("CallObjectByName", result.StatusMessage);
                if (Globals.m_sDebugMode.ToString() == "1")
                {
                    TextLogFile.WriteTrace("[TRACE] CallObjectByName" + " - " + result.StatusMessage);
                }
            }
            return;
        }

        // Will parse for the class name space. Returns the Object Assembly/namespace
        private void ParseXml(byte[] postXml)
        {
            // Check for previous error.
            if (result.StatusCode == "0")
            {
                XmlTextReader xReader = null;

                result.PermissionCode = XmlMethods.GetElementValue("//VISWEBREQUEST//PERMISSIONCODE", postXml).ToUpper();
                result.ActionDescription = XmlMethods.GetElementValue("//VISWEBREQUEST//ACTIONDESCRIPTION", postXml).ToUpper();

                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE] [PERMMISION CODE]  " + result.PermissionCode);
                }

                try
                {
                    // Read out the settings xml file looking for the class name.
                    xReader = new XmlTextReader(Globals.m_sServerPath + "Settings.xml");

                    // Read the whole xml file line by line.
                    while (xReader.Read())
                    {
                        // We are interested with elements and it's contents only.
                        if ((xReader.NodeType == XmlNodeType.Element))
                        {
                            // Get type of class operation
                            if (xReader.Name.ToLower().Equals("type"))
                            {
                                if (xReader.GetAttribute("name").Equals(result.PermissionCode))
                                {
                                    result.ModuleName = xReader.GetAttribute("module");
                                    result.FunctionName = xReader.GetAttribute("function");
                                }
                            }
                        }
                    }
                }
                catch (Exception err)
                {
                    result.StatusCode = "13.86.10.2";
                    result.StatusMessage = "[" + result.PermissionCode + "] " + "[" + result.StatusCode + "] " + err.Message;

                    TextLogFile.WriteLog(result.StatusMessage);
                    if (Globals.m_sDebugMode.ToString() == "1")
                    {
                        TextLogFile.WriteTrace("[TRACE]" + " - " + result.StatusMessage);
                    }
                }
                finally
                {
                    if (xReader != null) xReader.Close();
                }
            }

        }

        public string ResultResponse()
        {
            if (Globals.m_sDebugMode == "1")
            {
                TextLogFile.WriteTrace("[TRACE] Construct Response XML for " + result.PermissionCode);
            }

            XmlDocument xmlDoc = new XmlDocument();
            string sFragment = String.Empty;

            try
            {
                sFragment = @"<?xml version='1.0'?><VISWEBRESPONSE>";
                sFragment += @"<PERMISSIONCODE>" + result.PermissionCode + "</PERMISSIONCODE>";
                sFragment += @"<ACTIONDESCRIPTION>" + result.ActionDescription + "</ACTIONDESCRIPTION>";
                sFragment += @"<TRANSACTIONDATETIME>" + Utilities.Utilities.DateTimeFormat(DateTime.Now, 1) + "</TRANSACTIONDATETIME>";
                sFragment += @"<PAYLOAD></PAYLOAD><STATUS></STATUS></VISWEBRESPONSE>";
                xmlDoc.LoadXml(sFragment);

                sFragment = String.Empty;

                sFragment += @"<STATUSCODE>" + result.StatusCode + "</STATUSCODE>";

                if (result.StatusCode != "0")
                {
                    sFragment += @"<STATUSMESSAGE>" + result.StatusMessage + "</STATUSMESSAGE>";
                    TextLogFile.WriteLog(result.StatusMessage);
                    if (Globals.m_sDebugMode == "1")
                    {
                        TextLogFile.WriteTrace("[RESULT] Transaction Failed " + result.StatusCode);
                    }
                }
                else
                {
                    sFragment += @"<STATUSMESSAGE>SUCCESSFUL</STATUSMESSAGE>";
                    if (Globals.m_sDebugMode == "1")
                    {
                        TextLogFile.WriteTrace("[RESULT] Transaction Succeed " + result.StatusCode);
                    }
                }

                XmlMethods.AddXMLFragment(ref xmlDoc, "//VISWEBRESPONSE//STATUS", sFragment);

                sFragment = String.Empty;

                if (result.Payload.Count != 0)
                {
                    IEnumerator ALEnum = result.Payload.GetEnumerator();

                    while (ALEnum.MoveNext())
                    {
                        sFragment += ALEnum.Current.ToString();
                    }
                }

                XmlMethods.AddXMLFragment(ref xmlDoc, "//VISWEBRESPONSE//PAYLOAD", sFragment);

                return xmlDoc.InnerXml;
            }
            catch (Exception err)
            {
                result.StatusCode = "13.86.10.5";
                result.StatusMessage = "[" + result.PermissionCode + "] " + " [" + result.StatusCode + "] " + err.Message;

                TextLogFile.WriteLog("ResultResponse", err.GetType().ToString());
                if (Globals.m_sDebugMode.ToString() == "1")
                {
                    TextLogFile.WriteTrace("[TRACE] ResultResponse" + " - " + result.StatusMessage);
                }

                return CreateErrorResponse(err.Message);
            }
            finally
            {
                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("*****************************************************************");
                }
            }
        }

        private string CreateErrorResponse(string errMsg)
        {
            if (Globals.m_sDebugMode.ToString() == "1")
            {
                TextLogFile.WriteLog("CreateErrorResponse");
            }

            XmlDocument xmlDoc = new XmlDocument();
            string sFragment = String.Empty;

            StatusDateTime CurrentDateTime = new StatusDateTime(Convert.ToInt64(System.DateTime.Now.ToString("yyyyMMddHHmmssfff")));
            try
            {
                // Build SCS structured xml template
                sFragment = @"<?xml version='1.0'?><VISWEBRESPONSE>";
                sFragment += @"<PERMISSIONCODE>" + result.PermissionCode + "</PERMISSIONCODE>";
                sFragment += @"<ACTIONDESCRIPTION>" + result.ActionDescription + "</ACTIONDESCRIPTION>";
                sFragment += @"<TRANSDATETIME>" + CurrentDateTime.Complete17CharString + "</TRANSDATETIME>";
                sFragment += @"<PAYLOAD></PAYLOAD><STATUS></STATUS></VISWEBRESPONSE>";
                xmlDoc.LoadXml(sFragment);

                sFragment = String.Empty;
                sFragment += @"<STATUSCODE>" + result.StatusCode + "</STATUSCODE>";
                sFragment += @"<STATUSMESSAGE>" + "[" + result.PermissionCode + "] " + errMsg + "</STATUSMESSAGE>";
                XmlMethods.AddXMLFragment(ref xmlDoc, "//VISWEBRESPONSE//STATUS", sFragment);

                // Place response to placeholder
                return xmlDoc.InnerXml;
            }
            catch (Exception err)
            {
                result.StatusMessage = "[" + result.PermissionCode + "] " + " [" + result.StatusCode + "] " + err.Message;

                TextLogFile.WriteLog("CreateErrorResponse", err.GetType().ToString());
                if (Globals.m_sDebugMode.ToString() == "1")
                {
                    TextLogFile.WriteTrace("[TRACE] CreateErrorResponse" + " - " + result.StatusMessage);
                }

                return null;
            }
        }


        //////////		private void UpdateEmptyArrayList()
        //////////		{
        //////////			if (Globals.m_sDebugMode=="1")
        //////////			{
        //////////				TextLogFile.WriteTrace("[TRACE] Construct Empty Array List for " + result.PermissionCode);
        //////////			}
        //////////
        //////////			try
        //////////			{
        //////////				ArrayList AL = new ArrayList();
        //////////
        //////////				AL.Add(@XmlMethods.CreateXMLElement("LOGINNAME", ""));
        //////////				AL.Add(@XmlMethods.CreateXMLElement("TIMESTAMP", ""));
        //////////				AL.Add(@XmlMethods.CreateXMLElement("SESSIONKEY", ""));
        //////////				
        //////////				result.Payload = AL;
        //////////					
        //////////				
        //////////			}
        //////////			catch(Exception err)
        //////////			{
        //////////				throw err;
        //////////				
        //////////			}
        //////////		}


        #endregion

        #region XML Validation methods - 2003
        /*
		public void ValidateUserXml(byte[] postXml, string schema)
		{
			// Check for previous error or null schema
			if (result.StatusCode == "0")
			{
					XmlTextReader Reader = null;
					XmlValidatingReader xValidator = null;
					XmlTextReader xReader = null;
					
					//				if (System.IO.File.Exists(schema)== true)
					//				{
					try
					{	
						XmlSchemaCollection schSchemas = new XmlSchemaCollection();

						// Assign Xml to a reader.
						Reader = new XmlTextReader(new System.IO.MemoryStream(postXml));

						// Get Validator.
						xValidator = new XmlValidatingReader(Reader);

						// Assign Schemas.
						// Open xsd file here. We only load 1 xsd file.
						xReader = new XmlTextReader(schema);

						XmlSchema xmlSchema = XmlSchema.Read(xReader, new ValidationEventHandler(SchemaReadError));
						schSchemas.Add(xmlSchema);
					
						// If the schema loaded not valid, break from try.
						if(result.StatusCode  == "0")
						{
							// Validate our xml with the schema
							xValidator.Schemas.Add(schSchemas);
							xValidator.ValidationType = ValidationType.Auto;
							xValidator.ValidationEventHandler += new ValidationEventHandler(ValidationError);

							// Validate Document Node By Node, empty loop.
							while(xValidator.Read()) 
							{
							
								if (result.StatusCode  != "0") break;
							}
						}
					}
					catch (Exception exp)
					{
						result.StatusCode  = "12.86.11.3";
						result.StatusMessage = "General Schema Validation Error";
						result.TransResult = "[" + result.PermissionCode + "]" 
							+ " [" + result.StatusCode + "]" 
							+ " ["+ result.StatusMessage + "]" 
							+ " [" + exp.GetType().ToString() + "]" 
							+ " [" + exp.Message + "]" ;

						TextLogFile.WriteLog(result.TransResult);
						if (Globals.m_sDebugMode.ToString()== "1")
						{
							TextLogFile.WriteTrace("[TRACE]" + " - " + result.TransResult) ; 
						}
					}
					finally
					{
						if (xReader != null) xReader.Close();
						if (xValidator != null) xValidator.Close();
						if (Reader != null) Reader.Close();
					}
				}
//			}
		}

		private void ValidationError(object sender, ValidationEventArgs arguments)
		{
			result.StatusCode  = "12.86.11.3";
			result.StatusMessage = "Schema Validation Error";
			result.TransResult = "[" + result.PermissionCode + "]" 
				+ " [" + result.StatusCode + "]" 
				+ " ["+ result.StatusMessage + "]" 
				+ " [" + arguments.GetType().ToString() + "]" 
				+ " [" + arguments.Message + "]" ;				

			TextLogFile.WriteLog(result.TransResult);
			if (Globals.m_sDebugMode.ToString()== "1")
			{
				TextLogFile.WriteTrace("[TRACE]" + " - " + result.TransResult) ; 
			}
			
		}

		private void SchemaReadError(object sender, ValidationEventArgs arguments)
		{
			result.StatusCode  = "12.86.11.3";
			result.StatusMessage = "General Schema Validation Error";
			result.TransResult = "[" + result.PermissionCode + "]" 
				+ " [" + result.StatusCode + "]" 
				+ " ["+ result.StatusMessage + "]" 
				+ " [" + arguments.GetType().ToString() + "]" 
				+ " [" + arguments.Message + "]" ;

			TextLogFile.WriteLog(result.TransResult);
			if (Globals.m_sDebugMode.ToString()== "1")
			{
				TextLogFile.WriteTrace("[TRACE]" + " - " + result.TransResult) ; 
			}
		
		}
         */
        #endregion

        #region XML Validation methods - 2005
        public void ValidateUserXml(byte[] postXml, string SchemaFile)
        {
            try
            {
                XmlReaderSettings settings = new XmlReaderSettings();

                settings.ValidationEventHandler += new ValidationEventHandler(ValidationError);

                settings.ValidationType = ValidationType.Schema;
                settings.Schemas.Add(null, XmlReader.Create(SchemaFile));

                XmlTextReader Reader = new XmlTextReader(new System.IO.MemoryStream(postXml));

                using (XmlReader xmlValidatingReader = XmlReader.Create(Reader, settings))
                {
                    while (xmlValidatingReader.Read())
                    {
                        if (result.StatusCode != "0") break;
                    }
                }
            }
            catch (Exception exp)
            {
                result.StatusCode = "12.86.11.3";
                result.StatusMessage = "General Schema Validation Error";
                result.TransResult = "[" + result.PermissionCode + "]"
                    + " [" + result.StatusCode + "]"
                    + " [" + result.StatusMessage + "]"
                    + " [" + exp.GetType().ToString() + "]"
                    + " [" + exp.Message + "]";

                TextLogFile.WriteLog(result.TransResult);
                if (Globals.m_sDebugMode.ToString() == "1")
                {
                    TextLogFile.WriteTrace("[TRACE]" + " - " + result.TransResult);
                }
            }
        }

        private void ValidationError(object sender, ValidationEventArgs arguments)
        {
            result.StatusCode = "12.86.11.3";
            result.StatusMessage = "Schema Validation Error";
            result.TransResult = "[" + result.PermissionCode + "]"
                + " [" + result.StatusCode + "]"
                + " [" + result.StatusMessage + "]"
                + " [" + arguments.GetType().ToString() + "]"
                + " [" + arguments.Message + "]";

            TextLogFile.WriteLog(result.TransResult);
            if (Globals.m_sDebugMode.ToString() == "1")
            {
                TextLogFile.WriteTrace("[TRACE]" + " - " + result.TransResult);
            }

        }

        private void SchemaReadError(object sender, ValidationEventArgs arguments)
        {
            result.StatusCode = "12.86.11.3";
            result.StatusMessage = "General Schema Validation Error";
            result.TransResult = "[" + result.PermissionCode + "]"
                + " [" + result.StatusCode + "]"
                + " [" + result.StatusMessage + "]"
                + " [" + arguments.GetType().ToString() + "]"
                + " [" + arguments.Message + "]";

            TextLogFile.WriteLog(result.TransResult);
            if (Globals.m_sDebugMode.ToString() == "1")
            {
                TextLogFile.WriteTrace("[TRACE]" + " - " + result.TransResult);
            }

        }
        #endregion
    }
}
