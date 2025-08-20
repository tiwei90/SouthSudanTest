using IdentityManagement.Shared;
using System;
using System.Xml;
using System.Xml.Schema;

namespace IdentityManagement.Utilities
{
    /// <summary>
    /// Summary description for clsValidation.
    /// </summary>
    public class Validation
    {

        public void ValidateUserXml(byte[] postXml, string schema, ref Status InResult)
        {
            // Check for previous error or null schema
            if (InResult.StatusCode == "0")
            {
                XmlReader Reader = null;
                XmlReaderSettings xValidator = null;
                XmlTextReader xReader = null;



                try
                {
                    XmlSchemaSet schSchemas = new XmlSchemaSet();

                    // Get Validator.
                    xValidator = new XmlReaderSettings();

                    // Assign Schemas.
                    // Open xsd file here. We only load 1 xsd file.
                    xReader = new XmlTextReader(schema);

                    XmlSchema xmlSchema = XmlSchema.Read(xReader, new ValidationEventHandler(SchemaReadError));
                    schSchemas.Add(xmlSchema);

                    // If the schema loaded not valid, break from try.
                    if (InResult.StatusCode == "0")
                    {
                        // Validate our xml with the schema
                        xValidator.Schemas.Add(schSchemas);
                        xValidator.ValidationType = ValidationType.Schema;
                        xValidator.ValidationEventHandler += new ValidationEventHandler(ValidationError);

                        // Assign Xml to a reader.
                        Reader = XmlReader.Create((new System.IO.MemoryStream(postXml)));


                        // Validate Document Node By Node, empty loop.
                        while (Reader.Read())
                        {
                            if (InResult.StatusCode == "0") break;
                        }
                    }
                }
                catch (XmlException err)
                {
                    InResult.StatusCode = "13.86.10.3";
                    InResult.LogMessage = "[" + InResult.PermissionCode + "] " + "[" + InResult.StatusCode + "] " + err.Message;
                    TextLogFile.WriteLog(InResult.LogMessage);

                    if (Globals.m_sDebugMode == "1")
                    {
                        TextLogFile.WriteTrace(InResult.LogMessage);
                    }
                }
                catch (Exception err)
                {
                    InResult.StatusCode = "17.86.10.3";
                    InResult.LogMessage = "[" + InResult.PermissionCode + "] " + "[" + InResult.StatusCode + "] " + err.Message;
                    TextLogFile.WriteLog(InResult.LogMessage);

                    if (Globals.m_sDebugMode == "1")
                    {
                        TextLogFile.WriteTrace(InResult.LogMessage);
                    }

                }
                finally
                {
                    if (xReader != null) xReader.Close();
                    if (Reader != null) Reader.Close();
                }
            }

        }

        private void ValidationError(object sender, ValidationEventArgs arguments)
        {
            TextLogFile.WriteLog("XML Schema validation error");
        }

        private void SchemaReadError(object sender, ValidationEventArgs arguments)
        {
            TextLogFile.WriteLog("Read XML Schema Error", arguments.GetType().ToString());
        }
    }
}

