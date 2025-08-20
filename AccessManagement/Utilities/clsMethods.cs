using AccessManagement.Shared;
using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Xml;

namespace AccessManagement.Utilities
{
    #region UTILITIES METHODS CLASS

    public sealed class Utilities
    {
        public static string DateTimeFormat(DateTime dateTime, int ShortLongDate)
        {
            string sResult = string.Empty;

            if (ShortLongDate == 0)
            {
                sResult = dateTime.ToString("yyyyMMdd");
            }
            else
            {
                sResult = dateTime.ToString("yyyyMMddHHmmss");
            }

            return (sResult);
        }

        public static String HashtableEnumerator(Hashtable ht, string htKeyName)
        {
            try
            {
                IDictionaryEnumerator htEnum = ht.GetEnumerator();


                while (htEnum.MoveNext())
                {
                    if (htEnum.Key.Equals(htKeyName)) return htEnum.Value.ToString();
                }
            }
            catch (Exception err)
            {
                throw new Exception("Error in HashtableEnumerator" + err.Message);
            }

            return String.Empty;
        }


    }
    #endregion

    #region XML METHODS CLASS
    /// <summary>
    /// Summary description for XmlMethods.
    /// </summary>
    public sealed class XmlMethods
    {
        public static Stream GetXMLStream(string xmlString)
        {
            byte[] byteArr;
            Stream xmlStream = null;

            try
            {
                ASCIIEncoding encoding = new ASCIIEncoding();
                byteArr = encoding.GetBytes(xmlString);
                xmlStream = new MemoryStream(byteArr);
            }
            catch (Exception err)
            {
                throw new Exception("Error in GetXMLStream " + err.Message);
            }

            return xmlStream;
        }

        public static byte[] GetXMLBytes(string xmlString)
        {
            byte[] byteArr = null;

            try
            {
                UTF8Encoding encoding = new UTF8Encoding();
                byteArr = encoding.GetBytes(xmlString);
            }
            catch (Exception err)
            {

                TextLogFile.WriteLog("[ERROR] " + "[13.86.10.1] " + err.Message);

                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[ERROR] " + "[13.86.10.1] " + err.Message);
                }
            }

            return byteArr;
        }

        public static bool AddElementValue(ref XmlDocument xmlDoc, string nodeElement, string nodeElementToAdd, string nodeElementValue)
        {
            try
            {
                // Go to our target node.
                XmlNode xmlNode = xmlDoc.SelectSingleNode(nodeElement);

                if (xmlNode != null)
                {
                    XmlElement newElement = xmlDoc.CreateElement(nodeElementToAdd);
                    newElement.InnerText = nodeElementValue;

                    xmlDoc.SelectSingleNode(nodeElement).AppendChild(newElement);

                    return true;
                }
            }
            catch (XmlException err)
            {
                throw new Exception("XML error in AddElementValue " + err.Message);
            }
            catch (Exception err)
            {
                throw new Exception("Error in AddElementValue " + err.Message);
            }

            return false;
        }

        public static bool AddXMLFragment(ref XmlDocument xmlDoc, string nodeElement, string fragmentXML)
        {
            try
            {
                // Go to our target node.
                XmlNode xmlNode = xmlDoc.SelectSingleNode(nodeElement);

                if (xmlNode != null)
                {
                    XmlDocumentFragment docFrag = xmlDoc.CreateDocumentFragment();

                    // Set the contents of the document fragment. 
                    docFrag.InnerXml = fragmentXML;

                    // Add the children of the document fragment to the 
                    // original document. 
                    xmlDoc.SelectSingleNode(nodeElement).AppendChild(docFrag);

                    return true;
                }
            }
            catch (XmlException err)
            {
                throw new Exception("XML error in AddXMLFragment " + err.Message);
            }
            catch (Exception err)
            {
                throw new Exception("Error in AddXMLFragment " + err.Message);
            }

            return false;
        }

        public static bool AppendElementValue(ref XmlDocument xmlDoc, string nodeElement, string newValue)
        {
            try
            {
                // Go to our target node.
                XmlNode xmlNode = xmlDoc.SelectSingleNode(nodeElement);

                if (xmlNode != null)
                {
                    xmlDoc.SelectSingleNode(nodeElement).InnerText = newValue;
                    return true;
                }
            }
            catch (XmlException err)
            {
                throw new Exception("XML error in AppendElementValue " + err.Message);
            }
            catch (Exception err)
            {
                throw new Exception("Error in AppendElementValue " + err.Message);
            }

            return false;
        }

        public static bool AppendElementValue(string xmlPath, string nodeElement, string newValue)
        {
            try
            {
                // Go to our target node.
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlPath);
                XmlNode xmlNode = xmlDoc.SelectSingleNode(nodeElement);

                if (xmlNode != null)
                {
                    xmlDoc.SelectSingleNode(nodeElement).InnerText = newValue;
                    xmlDoc.Save(xmlPath);
                    return true;
                }
            }
            catch (XmlException err)
            {
                throw new Exception("XML error in AppendElementValue " + err.Message);
            }
            catch (Exception err)
            {
                throw new Exception("Error in AppendElementValue " + err.Message);
            }

            return false;
        }

        public static bool SaveXmlToDisk(string fileName, XmlDocument xmlDoc)
        {
            bool bResult = false;
            XmlTextWriter xmlWrite = null;

            try
            {
                xmlWrite = new XmlTextWriter(fileName, Encoding.UTF8);
                xmlDoc.WriteTo(xmlWrite);
                xmlWrite.Close();
                bResult = true;
            }
            catch (XmlException err)
            {
                throw new Exception("XML error in SaveXmlToDisk " + err.Message);
            }
            catch (Exception err)
            {
                throw new Exception("Error in SaveXmlToDisk " + err.Message);
            }
            finally
            {
                if (xmlWrite != null) xmlWrite.Close();
            }

            return bResult;
        }

        public static string GetElementValue(string nodeElement, XmlDocument xmlDoc)
        {
            try
            {
                // Go to our target node.
                XmlNode xmlNode = xmlDoc.SelectSingleNode(nodeElement);

                if (xmlNode != null) return xmlNode.InnerXml.ToString();
            }
            catch (XmlException err)
            {
                throw new Exception("XML error in GetElementValue " + err.Message);
            }
            catch (Exception err)
            {
                throw new Exception("Error in GetElementValue " + err.Message);
            }

            return String.Empty;
        }

        public static string GetElementValue(string nodeElement, string xmlPath)
        {
            XmlDocument xmlDoc = new XmlDocument();

            try
            {
                xmlDoc.Load(xmlPath);

                // Go to our target node.
                XmlNode xmlNode = xmlDoc.SelectSingleNode(nodeElement);

                if (xmlNode != null) return xmlNode.InnerXml.ToString();
            }
            catch (XmlException err)
            {
                throw new Exception("XML error in GetElementValue " + err.Message);
            }
            catch (Exception err)
            {
                throw new Exception("Error in GetElementValue " + err.Message);
            }

            return String.Empty;
        }

        public static string GetElementValue(string nodeElement, Stream xmlStream)
        {
            XmlDocument xmlDoc = new XmlDocument();

            try
            {
                xmlDoc.Load(xmlStream);

                // Go to our target node.
                XmlNode xmlNode = xmlDoc.SelectSingleNode(nodeElement);

                if (xmlNode != null) return xmlNode.InnerXml.ToString();
            }
            catch (XmlException err)
            {
                throw new Exception("XML error in GetElementValue " + err.Message);
            }
            catch (Exception err)
            {
                throw new Exception("Error in GetElementValue " + err.Message);
            }

            return String.Empty;
        }

        public static string GetElementValue(string nodeElement, byte[] xmlBytes)
        {
            XmlDocument xmlDoc = new XmlDocument();
            Stream xmlStream = null;

            try
            {
                xmlStream = new MemoryStream(xmlBytes);
                xmlDoc.Load(xmlStream);

                // Go to our target node.
                XmlNode xmlNode = xmlDoc.SelectSingleNode(nodeElement);

                if (xmlNode != null) return xmlNode.InnerXml.ToString();
            }
            catch (XmlException err)
            {
                throw new Exception("XML error in GetElementValue " + err.Message);
            }
            catch (Exception err)
            {
                throw new Exception("Error in GetElementValue " + err.Message);
            }

            return String.Empty;
        }

        public static string GetElementAttributeValue(string nodeElement, string attributeValue, XmlDocument xmlDoc)
        {
            try
            {
                // Go to our target node.
                XmlNode xmlNode = xmlDoc.SelectSingleNode(nodeElement);

                if (xmlNode != null) return xmlNode.Attributes[attributeValue].Value.ToString();
            }
            catch (XmlException err)
            {
                throw new Exception("XML error in GetElementAttributeValue " + err.Message);
            }
            catch (Exception err)
            {
                throw new Exception("Error in GetElementAttributeValue " + err.Message);
            }

            return String.Empty;
        }

        public static string GetElementAttributeValue(string nodeElement, string attributeValue, string xmlDocPath)
        {
            XmlDocument xmlDoc = new XmlDocument();

            try
            {
                xmlDoc.Load(xmlDocPath);

                // Go to our target node.
                XmlNode xmlNode = xmlDoc.SelectSingleNode(nodeElement);

                if (xmlNode != null) return xmlNode.Attributes[attributeValue].Value.ToString();
            }
            catch (XmlException err)
            {
                throw new Exception("XML error in GetElementAttributeValue " + err.Message);
            }
            catch (Exception err)
            {
                throw new Exception("Error in GetElementAttributeValue " + err.Message);
            }

            return String.Empty;
        }

        public static bool DeleteXmlOnDisk(string fileName)
        {
            bool bResult = false;

            try
            {
                File.Delete(fileName);
            }
            catch (XmlException err)
            {
                throw new Exception("XML error in DeleteXmlOnDisk " + err.Message);
            }
            catch (Exception err)
            {
                throw new Exception("Error in DeleteXmlOnDisk " + err.Message);
            }

            return (bResult);
        }

        public static string CreateXMLElement(string name, string val)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<" + name + ">");
            sb.Append(val);
            sb.Append("</" + name + ">");
            return sb.ToString();
        }

        /// <summary>
        /// Create an XML Element with the HashTable key as element name and its value as content 
        /// </summary>
        /// <param name="name">Element name and hashtable key name</param>
        /// <param name="table">The hashtable to retrive the value from</param>
        public static string CreateXMLElement(string name, Hashtable table)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<" + name + ">");
            sb.Append(GeneralMethods.GetHashtableValue(table, name));
            sb.Append("</" + name + ">");
            return sb.ToString();
        }



        #endregion

    }
}