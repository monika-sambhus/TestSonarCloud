using System;
using System.Text;
using System.Xml;

namespace BBB.ESB.BTS.Components.Interface.Utilities
{
    public class ExperianIDHubHelper
    {
        public static bool IsAuthenticate = false;
        public static bool IsHRPResults = false;
        public static bool IsLoctAtCloc = false;
        public static bool IsIdandLocAtPL = false;
        public static bool IsIdandLocAtCL = false;
        public static bool IsLoctAtPloc = false;
        public static string CreateIDHubAuthenticateMsg(string ApplicationId, XmlDocument msgIDHubResp)
        {
            StringBuilder authenticateMsg = new StringBuilder();
            String authMappingData = Utilities.IdHubMap.Process(msgIDHubResp, "Authenticate");
            authenticateMsg.Append("<create xmlns='urn:partner.soap.sforce.com'>");
            authenticateMsg.Append("<sObjects xmlns='urn:partner.soap.sforce.com'>");
            authenticateMsg.Append("<type xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns='urn1:sobject.partner.soap.sforce.com'>Authenticate__c</type>");
            authenticateMsg.Append("<Application__c>" + ApplicationId + "</Application__c>");
            authenticateMsg.Append(authMappingData);
            authenticateMsg.Append("</sObjects>");
            authenticateMsg.Append("</create>");
            IsAuthenticate = true;
            System.Diagnostics.Trace.WriteLine("authenticateMsg.ToString() " + authenticateMsg.ToString());
            return authenticateMsg.ToString();
        }

        public static bool CreateIDHubCategoryDataMsg(string AuthResultId, string pathToGetCategoryData, string sectionName, XmlDocument msgIDHubResp, out string CategoryDataResult)
        {
            StringBuilder categoryDataMsg = new StringBuilder();
            bool IsCategoryDataPresent = false;
            CategoryDataResult = null;

            var result = Utilities.IdHubCategoryData.Process(msgIDHubResp, pathToGetCategoryData, AuthResultId, sectionName);

            if (!String.IsNullOrEmpty(result))
            {
                categoryDataMsg.Append("<create xmlns='urn:partner.soap.sforce.com'>");
                categoryDataMsg.Append(result);
                categoryDataMsg.Append("</create>");
                System.Diagnostics.Trace.WriteLine("categoryDataMsg.ToString() " + categoryDataMsg.ToString());
                IsCategoryDataPresent = true;
                CategoryDataResult = categoryDataMsg.ToString();
                switch (sectionName)
                {
                    case "LocAtCloc": IsLoctAtCloc = true; break;
                    case "IDandLocAtPL": IsIdandLocAtPL = true; break;
                    case "IDandLocAtCL": IsIdandLocAtCL = true; break;
                    case "LocAtPloc": IsLoctAtPloc = true; break;
                    default: break;
                }
            }

            return IsCategoryDataPresent;
        }
        public static string CreateIDHubHRPResultsMsg(string AuthResultId, XmlDocument msgIDHubResp)
        {
            StringBuilder hrpResultsMsg = new StringBuilder();
            hrpResultsMsg.Append("<create xmlns='urn:partner.soap.sforce.com'>");
            String hrpMappingData;

            foreach (XmlNode xNode in msgIDHubResp.SelectNodes("//*[local-name()='ProcessConfigResponse' and namespace-uri()='http://schema.uk.experian.com/eih/2014/07']/*[local-name()='ProcessConfigResultsBlock' and namespace-uri()='http://schema.uk.experian.com/eih/2014/07']/*[local-name()='EIAResultBlock' and namespace-uri()='http://schema.uk.experian.com/eih/2014/07']/*[local-name()='EIAResults' and namespace-uri()='http://schema.uk.experian.com/eih/2014/07']/*[local-name()='ReturnedHRP' and namespace-uri()='http://schema.uk.experian.com/eih/2014/07']"))
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(xNode.OuterXml);
                hrpMappingData = Utilities.IdHubMap.Process(xDoc, "HRP_Results");
                hrpResultsMsg.Append("<sObjects xmlns='urn:partner.soap.sforce.com'>");
                hrpResultsMsg.Append("<type xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns='urn1:sobject.partner.soap.sforce.com'>HRP_Results__c</type>");
                hrpResultsMsg.Append("<Authenticate_Result__c>" + AuthResultId + "</Authenticate_Result__c>");
                hrpResultsMsg.Append(hrpMappingData);
                hrpResultsMsg.Append("</sObjects>");
            }

            hrpResultsMsg.Append("</create>");
            IsHRPResults = true;
            System.Diagnostics.Trace.WriteLine("hrpResultsMsg.ToString() " + hrpResultsMsg.ToString());
            return hrpResultsMsg.ToString();
        }

        public static string CreateIDHubEIAResultsMsg(string AuthResultId, XmlDocument msgIDHubResp)// not mapped 
        {
            StringBuilder eiaResultsMsg = new StringBuilder();
            String eiapMappingData;

            eiaResultsMsg.Append("<create xmlns='urn:partner.soap.sforce.com'>");

            foreach (XmlNode xNode in msgIDHubResp.SelectNodes("//*[local-name()='ProcessConfigResponse' and namespace-uri()='http://schema.uk.experian.com/eih/2014/07']/*[local-name()='ProcessConfigResultsBlock' and namespace-uri()='http://schema.uk.experian.com/eih/2014/07']/*[local-name()='EIAMessageBlock' and namespace-uri()='http://schema.uk.experian.com/eih/2014/07']"))
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(xNode.OuterXml);
                eiapMappingData = Utilities.IdHubMap.Process(xDoc, "EIAResult");

                eiaResultsMsg.Append("<sObjects xmlns='urn:partner.soap.sforce.com'>");
                eiaResultsMsg.Append("<type xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns='urn1:sobject.partner.soap.sforce.com'>EIAResult__c</type>");
                eiaResultsMsg.Append("<Authenticate_Result__c>" + AuthResultId + "</Authenticate_Result__c>");
                eiaResultsMsg.Append(eiapMappingData);
                eiaResultsMsg.Append("</sObjects>");

            }
            eiaResultsMsg.Append("</create>");

            System.Diagnostics.Trace.WriteLine("eiaResultsMsg.ToString() " + eiaResultsMsg.ToString());
            return eiaResultsMsg.ToString();
        }

        public static string UpdateIDHubIntActionMessage(string ApplicationId, string IntegrationActionId, bool isIDHubAuthSuccess, string ProcessId, DateTime QueryExecutionDate, XmlDocument IDHubRequest = null, XmlDocument IDHubReqHeader = null, XmlDocument IDHubResponse = null, string retryDescription = null)
        {
            string orgId = Config.GetStringConfigValue("SalesForce.OrgId");

            StringBuilder debugLog = new StringBuilder();
            debugLog.AppendLine("Integration Type : Salesforce To ID Hub Authenticate");
            debugLog.AppendLine("Current Time (GMT) - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff \"GMT\"zzz"));
            debugLog.AppendLine("Log : BizTalk Environment :" + Environment.MachineName);
            debugLog.AppendLine("Log : Received Org Id : " + orgId);
            debugLog.AppendLine("Log : Received Application Id : " + ApplicationId);
            debugLog.AppendLine("Log : Received Action Id : " + IntegrationActionId);
            debugLog.AppendLine("Log : BizTalk Process Id : " + ProcessId);
            if (isIDHubAuthSuccess)
            {
                debugLog.AppendLine("Status :Success");
            }
            else
            {
                debugLog.AppendLine("Status : Failed");
            }

            debugLog.AppendLine();
            debugLog.AppendLine("Salesforce Query Complete - Current Time (GMT) - " + QueryExecutionDate.ToString("yyyy-MM-dd HH:mm:ss.fff \"GMT\"zzz"));

            if (IDHubRequest != null)
            {
                if (!string.IsNullOrEmpty(IDHubRequest.InnerXml))
                {
                    debugLog.AppendLine();
                    debugLog.AppendLine("Sending data to ID Hub Authenticate - Current Time(GMT) - " + Helper.GetDateFromXmlComment(IDHubRequest));
                    debugLog.AppendLine("=============== ID Hub Request =============== :");
                    debugLog.AppendLine("<?xml version='1.0' encoding='UTF - 8'?>");
                    debugLog.AppendLine("<Envelope xmlns='http://schemas.xmlsoap.org/soap/envelope/' xmlns:ns='http://schema.uk.experian.com/eih/2011/03' xmlns:ns1='http://schema.uk.experian.com/eih/2011/03/EIHHeader'>");
                    debugLog.AppendLine("<Header>");
                    debugLog.AppendLine(Helper.FormatXmlToString(IDHubReqHeader.DocumentElement.InnerXml));
                    debugLog.AppendLine("</Header>");
                    debugLog.AppendLine("<Body>");
                    debugLog.AppendLine(Helper.FormatXmlToString(Helper.IgnoreDateFromXmlComment(IDHubRequest).InnerXml));
                    debugLog.AppendLine("</Body>");
                    debugLog.AppendLine("</Envelope>");
                }
            }
            if (IDHubResponse != null)
            {
                if (!string.IsNullOrEmpty(IDHubResponse.InnerXml))
                {
                    debugLog.AppendLine();
                    debugLog.AppendLine("Response received from ID Hub Authenticate - Current Time(GMT) - " + Helper.GetDateFromXmlComment(IDHubResponse));
                    debugLog.AppendLine("=============== ID Hub Validate Response =============== :");
                    debugLog.AppendLine("<?xml version='1.0' encoding='UTF - 8'?>");
                    debugLog.AppendLine("<SOAP-ENV:Envelope xmlns='http://schemas.xmlsoap.org/soap/envelope/' xmlns:bws='http://schema.uk.experian.com/eih/2011/03/BankWizard' xmlns:eih='http://schema.uk.experian.com/eih/2011/03' xmlns:header='http://schema.uk.experian.com/eih/2011/03/EIHHeader' xmlns:ns3='http://schemas.xmlsoap.org/soap/envelope/' xmlns:qas='http://schema.uk.experian.com/eih/2011/03/QAS' xmlns:soap='http://schemas.xmlsoap.org/soap/envelope/' xmlns:SOAP-ENV='http://schemas.xmlsoap.org/soap/envelope/'>");
                    debugLog.AppendLine("<SOAP-ENV:Header/>");
                    debugLog.AppendLine("<SOAP-ENV:Body>");
                    debugLog.AppendLine(Helper.FormatXmlToString(Helper.IgnoreDateFromXmlComment(IDHubResponse).InnerXml));
                    debugLog.AppendLine("</SOAP-ENV:Body>");
                    debugLog.AppendLine("</SOAP-ENV:Envelope>");
                    if (IsAuthenticate) { debugLog.AppendLine("Log : Authenticate Result Insertion Successful."); }
                    if (IsHRPResults) { debugLog.AppendLine("Log: HRP Results Insertion Successful."); }
                    if (IsLoctAtCloc) { debugLog.AppendLine("Log: Category Data Insertion For LocDataOnlyAtCLoc Successful."); }
                    if (IsIdandLocAtPL) { debugLog.AppendLine("Log: Category Data Insertion For IDandLocDataAtPL Successful."); }
                    if (IsIdandLocAtCL) { debugLog.AppendLine("Log: Category Data Insertion For IDandLocDataAtCL Successful."); }
                    if (IsLoctAtPloc) { debugLog.AppendLine("Log: Category Data Insertion For LocDataOnlyAtPLoc Successful."); }
                }
            }

            if (!string.IsNullOrEmpty(retryDescription))
            {
                debugLog.AppendLine();
                debugLog.AppendLine(retryDescription);
            }

            debugLog.AppendLine("==============================");
            //This is current time
            debugLog.AppendLine();
            debugLog.AppendLine("Updating Integration Action - Current Time (GMT) - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff \"GMT\"zzz"));

            StringBuilder integrationActionUpdateMsg = new StringBuilder();
            integrationActionUpdateMsg.Append("<update xmlns='urn:partner.soap.sforce.com'>");
            integrationActionUpdateMsg.Append("<sObjects>");
            integrationActionUpdateMsg.Append("<type xmlns='urn1:sobject.partner.soap.sforce.com'>Integration_Action__c</type>");
            integrationActionUpdateMsg.Append("<Id>" + IntegrationActionId + "</Id>");
            integrationActionUpdateMsg.Append("<Debug_Log__c><![CDATA[" + debugLog.ToString() + "]]></Debug_Log__c>");
            if (isIDHubAuthSuccess)
            {
                integrationActionUpdateMsg.Append("<Status__c>Completed Success</Status__c>");
            }
            else
            {
                integrationActionUpdateMsg.Append("<Status__c>Errors</Status__c>");
            }

            integrationActionUpdateMsg.Append("</sObjects>");
            integrationActionUpdateMsg.Append("</update>");

            System.Diagnostics.Trace.WriteLine("integrationActionUpdateMsg.ToString() " + integrationActionUpdateMsg.ToString());
            return integrationActionUpdateMsg.ToString();
        }

    }
}

