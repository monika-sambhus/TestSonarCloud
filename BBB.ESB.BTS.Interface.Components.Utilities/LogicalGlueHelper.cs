using System;
using System.Net;
using System.Text;
using System.Xml;

namespace BBB.ESB.BTS.Components.Interface.Utilities
{
    public class LogicalGlueHelper
    {
        public static string CreateApplicationMessage(string ApplicationId, XmlDocument logicalGlueResponse, string Model)
        {
            //string success = Config.GetStringConfigValue("LogicalGlue.SuccessStatus");
            //string sent = Config.GetStringConfigValue("LogicalGlue.SentStatus");
            //string error = Config.GetStringConfigValue("LogicalGlue.ErrorStatus");
            //string pending = Config.GetStringConfigValue("LogicalGlue.PendingStatus");

            string score = logicalGlueResponse.SelectSingleNode("/*[local-name()='Root' and namespace-uri()='http://BBB.ESB.BTS.BizTalk.Interface.LogicalGlue.Schema.LogicalGlueResponse']/*[local-name()='score' and namespace-uri()='']").InnerText;
            string inferenceUri = logicalGlueResponse.SelectSingleNode("/*[local-name()='Root' and namespace-uri()='http://BBB.ESB.BTS.BizTalk.Interface.LogicalGlue.Schema.LogicalGlueResponse']/*[local-name()='inferenceUri' and namespace-uri()='']").InnerText;

            inferenceUri = BBB.ESB.BTS.Components.Interface.Utilities.Config.GetStringConfigValue("LogicalGlue.APIUrl") + inferenceUri;

            StringBuilder applicationUpdateMsg = new StringBuilder();
            applicationUpdateMsg.Append("<update xmlns='urn:partner.soap.sforce.com'>");
            applicationUpdateMsg.Append("<sObjects>");
            applicationUpdateMsg.Append("<type xmlns='urn1:sobject.partner.soap.sforce.com'>Application__c</type>");
            applicationUpdateMsg.Append("<Id>" + ApplicationId + "</Id>");
            if (System.String.IsNullOrEmpty(Model.Trim()) || Model.ToLower() == "neuralnetwork")
            {
                applicationUpdateMsg.Append("<Logical_Glue_Score__c>" + score + "</Logical_Glue_Score__c>");
            }
            if (Model.ToLower() == "fuzzylogic")
            {
                applicationUpdateMsg.Append("<Fuzzy_Logic_Score__c>" + score + "</Fuzzy_Logic_Score__c>");
                applicationUpdateMsg.Append("<Fuzzy_Logic_URL__c>" + WebUtility.HtmlEncode(inferenceUri) + "</Fuzzy_Logic_URL__c>");
            }
            applicationUpdateMsg.Append("</sObjects>");
            applicationUpdateMsg.Append("</update>");

            System.Diagnostics.Trace.WriteLine("applicationUpdateMsg " + applicationUpdateMsg.ToString());
            return applicationUpdateMsg.ToString();
        }

        public static string CreateIntegrationActionMessage(string ApplicationId, string IntegrationActionId, bool isSuccess, string ProcessId, DateTime QueryExecutionDate, XmlDocument logicalGlueRequest = null, XmlDocument logicalGlueResponse = null, string retryDescription = null, string model = null)
        {
            bool isIgnoreFuzzyLogicStatus = false;
            if(model.ToLower() == "fuzzylogic")
            {
                isIgnoreFuzzyLogicStatus = Convert.ToBoolean(BBB.ESB.BTS.Components.Interface.Utilities.Config.GetStringConfigValue("FuzzyLogic.IgnoreStatus"));
            }
            
            string orgId = Config.GetStringConfigValue("SalesForce.OrgId");

            StringBuilder debugLog = new StringBuilder();
            debugLog.AppendLine("Integration Type : Salesforce To Logical Glue");
            debugLog.AppendLine("Current Time (GMT) - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff \"GMT\"zzz"));
            debugLog.AppendLine("Log : BizTalk Environment :" + Environment.MachineName);
            debugLog.AppendLine("Log : Received Org Id : " + orgId);
            debugLog.AppendLine("Log : Received Record Id : " + ApplicationId);
            debugLog.AppendLine("Log : Received Action Id : " + IntegrationActionId);
            debugLog.AppendLine("Log : BizTalk Process Id : " + ProcessId);
            if (isSuccess)
            {
                debugLog.AppendLine("Status : Success");                
            }
            else
            {
                debugLog.AppendLine("Status : Failed");                
            }

            debugLog.AppendLine();
            debugLog.AppendLine("Salesforce Query Complete - Current Time (GMT) - " + QueryExecutionDate.ToString("yyyy-MM-dd HH:mm:ss.fff \"GMT\"zzz"));

            if (logicalGlueRequest != null)
            {
                if (!string.IsNullOrEmpty(logicalGlueRequest.InnerXml))
                {
                    debugLog.AppendLine();
                    debugLog.AppendLine("Sending data to Logical Glue - Current Time(GMT) - " + Helper.GetDateFromXmlComment(logicalGlueRequest));                    
                    debugLog.AppendLine("========== Logical Glue Request ========== ");
                    debugLog.AppendLine(Helper.XmlToJson(Helper.IgnoreDateFromXmlComment(logicalGlueRequest)));
                }
            }
            if (logicalGlueResponse != null)
            {
                if (!string.IsNullOrEmpty(logicalGlueResponse.InnerXml))
                {
                    debugLog.AppendLine();
                    debugLog.AppendLine("Response received from Logical Glue - Current Time(GMT) - " + Helper.GetDateFromXmlComment(logicalGlueResponse));                    
                    debugLog.AppendLine("========== Logical Glue Result ==========");
                    debugLog.AppendLine(Helper.XmlToJson(Helper.IgnoreDateFromXmlComment(logicalGlueResponse)));
                }
            }

            if (!string.IsNullOrEmpty(retryDescription))
            {
                debugLog.AppendLine();
                debugLog.AppendLine(retryDescription);
            }
            debugLog.AppendLine("==============================");
            debugLog.AppendLine();
            debugLog.AppendLine("Updating Integration Action - Current Time (GMT) - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff \"GMT\"zzz"));

            StringBuilder integrationActionUpdateMsg = new StringBuilder();
            integrationActionUpdateMsg.Append("<update xmlns='urn:partner.soap.sforce.com'>");
            integrationActionUpdateMsg.Append("<sObjects>");
            integrationActionUpdateMsg.Append("<type xmlns='urn1:sobject.partner.soap.sforce.com'>Integration_Action__c</type>");
            integrationActionUpdateMsg.Append("<Id>" + IntegrationActionId + "</Id>");
            integrationActionUpdateMsg.Append("<Debug_Log__c><![CDATA[" + debugLog.ToString() + "]]></Debug_Log__c>");
            if (isSuccess || isIgnoreFuzzyLogicStatus)
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
