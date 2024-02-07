using Newtonsoft.Json;
using System;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace BBB.ESB.BTS.Components.Interface.Utilities
{
    public class Helper
    {
        public static string FormatXmlToString(string xml)
        {
            try
            {
                var stringBuilder = new StringBuilder();
                var element = XElement.Parse(xml);
                var settings = new XmlWriterSettings();
                settings.OmitXmlDeclaration = true;
                settings.Indent = true;
                settings.NewLineOnAttributes = true;
                using (var xmlWriter = XmlWriter.Create(stringBuilder, settings))
                {
                    element.Save(xmlWriter);
                }

                return stringBuilder.ToString();
            }
            catch (Exception)
            {
                //This functionality is AYSNC. Process is not stopped by throwing error
                return xml;
            }

        }

        public static string StringTrim(string strValue, Int32 length)
        {
            if (strValue.Length > length)
            {
                return strValue.Substring(0, length);
            }
            else
            {
                return strValue;
            }
        }

        public static string XmlToJson(XmlDocument xmlDoc)
        {
            RemoveDateFromXmlComment(ref xmlDoc);
            return JsonConvert.SerializeXmlNode(StripNameSpace(xmlDoc), Newtonsoft.Json.Formatting.Indented, true);
        }

        private static XmlDocument StripNameSpace(XmlDocument xDoc)
        {            
            var varXml = XElement.Parse(xDoc.InnerXml);
            foreach (XElement xElement in varXml.DescendantsAndSelf())
            {                
                xElement.Name = xElement.Name.LocalName;                
                xElement.ReplaceAttributes((from xAttribute in xElement.Attributes().Where(xa => !xa.IsNamespaceDeclaration) select new XAttribute(xAttribute.Name.LocalName, xAttribute.Value)));
            }

            //Fixed defect CPB-13
            //Removed whitespaces
            string result = XElement.Parse(varXml.ToString()).ToString(SaveOptions.DisableFormatting);
            xDoc.LoadXml(result);
            return xDoc;
        }

        /// <summary>
        /// Get Date in comment section
        /// </summary>
        /// <param name="xDoc"></param>
        /// <returns></returns>
        public static string GetDateFromXmlComment(XmlDocument xDoc)
        {
            foreach (XmlComment xComment in xDoc.SelectNodes("//comment()"))
            {
                if ((xComment.Value.Contains("DateTime:")))
                {
                    return xComment.Value.Replace("DateTime:", "");
                }
            };
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff \"GMT\"zzz");
        }

        /// <summary>
        /// Write Date in comment
        /// </summary>
        /// <param name="xDoc"></param>
        public static void WriteDateToXmlComment(ref XmlDocument xDoc)
        {
            XmlComment xComment;
            xComment = xDoc.CreateComment("DateTime:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff \"GMT\"zzz"));
            XmlElement xElement = xDoc.DocumentElement;
            xDoc.InsertBefore(xComment, xElement);
        }

        /// <summary>
        /// Remove Date from comment
        /// </summary>
        /// <param name="xDoc"></param>
        public static void RemoveDateFromXmlComment(ref XmlDocument xDoc)
        {
            foreach (XmlComment xComment in xDoc.SelectNodes("//comment()"))
            {
                if ((xComment.Value.Contains("DateTime:")))
                {
                    xDoc.RemoveChild(xComment);
                }
            };
        }

        /// <summary>
        /// Ignore Date from comments
        /// </summary>
        /// <param name="xDoc"></param>
        /// <returns></returns>
        public static XmlDocument IgnoreDateFromXmlComment(XmlDocument xDoc)
        {
            foreach (XmlComment xComment in xDoc.SelectNodes("//comment()"))
            {
                if ((xComment.Value.Contains("DateTime:")))
                {
                    xDoc.RemoveChild(xComment);
                }
            };
            return xDoc;
        }

        public static string GetUriFullPath(string Uri)
        {
            Uri objUri;
            string strFullPath = string.Empty;
            try
            {
                objUri = new Uri(Uri);
                strFullPath = objUri.ToString().Replace(objUri.PathAndQuery, "") + "/";
            }
            catch (Exception)
            { }
            return strFullPath;
        }

        public static string ExtractDelphiError(XmlDocument xDoc)
        {
            string strError = string.Empty;
            try
            {
                foreach (XmlNode xNode in xDoc.SelectNodes("/*[local-name()='InteractiveResponse' and namespace-uri()='http://www.uk.experian.com/experian/wbsv/peinteractive/v100']/*[local-name()='OutputRoot' and namespace-uri()='http://schemas.microsoft.com/BizTalk/2003/Any']/*[local-name()='Output' and namespace-uri()='http://schema.uk.experian.com/experian/cems/msgs/v2.0/ConsumerData']/*[local-name()='Error' or local-name()='OneShotFailure']//*"))
                {
                    strError += xNode.InnerText + " ";
                }
            }
            catch (Exception)
            {                
            }

            if (string.IsNullOrEmpty(strError))
            {
                strError = "Experian Response has failure, Please check integration action.";
            }
            return strError.Trim();
        }
    }
}