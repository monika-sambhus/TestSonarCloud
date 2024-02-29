using System;
using System.Text;
using System.Xml;
using System.Net;

namespace ESB.BTS.Components.Interface.Utilities
{
    public class IovationMessageHelper
    {
        public static string CreateCheckTransactionsMsg(Iovation iovation)
        {
            StringBuilder fetchTxnMsg = new StringBuilder();
            var accountCode = string.Empty;

            fetchTxnMsg.Append("<ns0:CheckTransactionDetails xmlns:ns0='http://www.iesnare.com/dra/api/CheckTransactionDetails'>");
            fetchTxnMsg.Append("<ns0:subscriberid>" + Config.GetStringConfigValue("Iovation.subscriberid") + "</ns0:subscriberid>");
            fetchTxnMsg.Append("<ns0:subscriberaccount>" + Config.GetStringConfigValue("Iovation.subscriberaccount") + "</ns0:subscriberaccount>");
            fetchTxnMsg.Append("<ns0:subscriberpasscode>" + Config.GetStringConfigValue("Iovation.subscriberpasscode") + "</ns0:subscriberpasscode>");
            fetchTxnMsg.Append("<ns0:enduserip>" + iovation.End_User_IP__c + "</ns0:enduserip>");
            //fetchTxnMsg.Append("<ns0:enduserip>" + "?" + "</ns0:enduserip>");
            if (string.IsNullOrEmpty(iovation.Application__c))
            {
                accountCode = iovation.Contact__c;
            }
            fetchTxnMsg.Append("<ns0:accountcode>" + accountCode + "</ns0:accountcode>");
            fetchTxnMsg.Append("<ns0:beginblackbox>" + iovation.Begin_Black_Box__c + "</ns0:beginblackbox>");
            fetchTxnMsg.Append("<ns0:type>" + iovation.Type__c + "</ns0:type>"); //Defect fix for ID: CPB-5
            fetchTxnMsg.Append(iovation.Txn_Properties());
            fetchTxnMsg.Append("</ns0:CheckTransactionDetails>");

            return fetchTxnMsg.ToString();
        }

        public static string CreateIovationResultMessage(string IovationId, string IovationType, XmlDocument checkTxnDetailsResponse)
        {
            string result = checkTxnDetailsResponse.SelectSingleNode("/*[local-name()='CheckTransactionDetailsResponse' and namespace-uri()='http://www.iesnare.com/dra/api/CheckTransactionDetails']/*[local-name()='result' and namespace-uri()='http://www.iesnare.com/dra/api/CheckTransactionDetails']") == null ? "" : checkTxnDetailsResponse.SelectSingleNode("/*[local-name()='CheckTransactionDetailsResponse' and namespace-uri()='http://www.iesnare.com/dra/api/CheckTransactionDetails']/*[local-name()='result' and namespace-uri()='http://www.iesnare.com/dra/api/CheckTransactionDetails']").InnerText;
            string reason = checkTxnDetailsResponse.SelectSingleNode("/*[local-name()='CheckTransactionDetailsResponse' and namespace-uri()='http://www.iesnare.com/dra/api/CheckTransactionDetails']/*[local-name()='reason' and namespace-uri()='http://www.iesnare.com/dra/api/CheckTransactionDetails']") == null ? "" : checkTxnDetailsResponse.SelectSingleNode("/*[local-name()='CheckTransactionDetailsResponse' and namespace-uri()='http://www.iesnare.com/dra/api/CheckTransactionDetails']/*[local-name()='reason' and namespace-uri()='http://www.iesnare.com/dra/api/CheckTransactionDetails']").InnerText;
            string endblackbox = checkTxnDetailsResponse.SelectSingleNode("//*[local-name()='CheckTransactionDetailsResponse' and namespace-uri()='http://www.iesnare.com/dra/api/CheckTransactionDetails']/*[local-name()='endblackbox' and namespace-uri()='http://www.iesnare.com/dra/api/CheckTransactionDetails']") == null ? "" : checkTxnDetailsResponse.SelectSingleNode("//*[local-name()='CheckTransactionDetailsResponse' and namespace-uri()='http://www.iesnare.com/dra/api/CheckTransactionDetails']/*[local-name()='endblackbox' and namespace-uri()='http://www.iesnare.com/dra/api/CheckTransactionDetails']").InnerText;

            StringBuilder iovationResultUpdateMsg = new StringBuilder();
            iovationResultUpdateMsg.Append("<update xmlns='urn:partner.soap.sforce.com'>");
            iovationResultUpdateMsg.Append("<sObjects>");
            iovationResultUpdateMsg.Append("<type xmlns='urn1:sobject.partner.soap.sforce.com'>Iovation_Result__c</type>");
            iovationResultUpdateMsg.Append("<Id>" + IovationId + "</Id>");
            iovationResultUpdateMsg.Append("<Type__c>" + IovationType + "</Type__c>"); //Defect fix for ID: CPB-5
            iovationResultUpdateMsg.Append("<Reason__c>" + reason + "</Reason__c>");
            iovationResultUpdateMsg.Append("<Result__c>" + result + "</Result__c>");
            iovationResultUpdateMsg.Append("<End_Blackbox__c>" + endblackbox + "</End_Blackbox__c>");
            iovationResultUpdateMsg.Append("</sObjects>");
            iovationResultUpdateMsg.Append("</update>");

            System.Diagnostics.Trace.WriteLine("iovationResultUpdateMsg.ToString() " + iovationResultUpdateMsg.ToString());
            return iovationResultUpdateMsg.ToString();
        }

        public static string CreateIovationResultFaultMessage(string IovationId, string IovationType, string faultMsg)
        {
            //string faultCode = faultMsg.SelectSingleNode("/soapenv:Fault/faultcode").InnerText;
            //string faultString = faultMsg.SelectSingleNode("/soapenv:Fault/faultstring").InnerText;

            StringBuilder iovationResultFaultMsg = new StringBuilder();
            iovationResultFaultMsg.Append("<update xmlns='urn:partner.soap.sforce.com'>");
            iovationResultFaultMsg.Append("<sObjects>");
            iovationResultFaultMsg.Append("<type xmlns='urn1:sobject.partner.soap.sforce.com'>Iovation_Result__c</type>");
            iovationResultFaultMsg.Append("<Id>" + IovationId + "</Id>");
            //Defect fix for ID: CPB-5
            iovationResultFaultMsg.Append("<Type__c>" + IovationType + "</Type__c>");

            //More than 255 charecters doesnt appear in SF, trim & after encode.
            //Changed by Manju
            iovationResultFaultMsg.Append("<Reason__c>" + Helper.StringTrim(WebUtility.HtmlEncode(faultMsg), 255).Trim('&') + "</Reason__c>");

            iovationResultFaultMsg.Append("</sObjects>");
            iovationResultFaultMsg.Append("</update>");

            System.Diagnostics.Trace.WriteLine("iovationResultFaultMsg.ToString() " + iovationResultFaultMsg.ToString());
            return iovationResultFaultMsg.ToString();
        }

        public static string CreateIovationDetailsMessage(string IovationId, XmlDocument detailsNode)
        {
            string nameXPath = "/namesp1:detail/namesp1:name";
            string valueXPath = "/namesp1:detail/namesp1:value";

            XmlNamespaceManager namespaceManager = new XmlNamespaceManager(detailsNode.NameTable);
            namespaceManager.AddNamespace("namesp1", "http://www.iesnare.com/dra/api/CheckTransactionDetails");

            StringBuilder iovationDetailsMsg = new StringBuilder();
            iovationDetailsMsg.Append("<create xmlns='urn:partner.soap.sforce.com'>");
            iovationDetailsMsg.Append("<sObjects>");
            iovationDetailsMsg.Append("<type xmlns='urn1:sobject.partner.soap.sforce.com'>Iovation_Details__c</type>");
            iovationDetailsMsg.Append("<Iovation_Result__c>" + IovationId + "</Iovation_Result__c>");

            string name = detailsNode.SelectSingleNode(nameXPath, namespaceManager).InnerText;
            iovationDetailsMsg.Append("<Name>" + name + "</Name>");
            string value = detailsNode.SelectSingleNode(valueXPath, namespaceManager).InnerText;
            iovationDetailsMsg.Append("<Value__c>" + value + "</Value__c>");

            iovationDetailsMsg.Append("</sObjects>");
            iovationDetailsMsg.Append("</create>");

            System.Diagnostics.Trace.WriteLine("iovationDetailsMsg " + iovationDetailsMsg.ToString());
            return iovationDetailsMsg.ToString();
        }

        public static string CreateIntegrationActionMessage(string IovationId, string IntegrationActionId, bool isSuccess, string ProcessID, DateTime QueryExecutionDate, XmlDocument checkTxnDetailsRequest = null, XmlDocument checkTxnDetailsResponse = null, string RetryDescription = null)
        {
            string orgId = Config.GetStringConfigValue("SalesForce.OrgId");

            DebugLog debugLog = new DebugLog();

            //Added by Manju
            if (!isSuccess)
            {
                debugLog.Append("Iovation System Failure.Process allowed to continue. Original message was:" + Environment.NewLine);
            }

            debugLog.Append("Integration Type : Salesforce To Iovation");
            debugLog.Append("Current Time (GMT) - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff \"GMT\"zzz"));
            debugLog.Append("Log : BizTalk Environment :" + Environment.MachineName);
            debugLog.Append("Log : Received Org Id : " + orgId);
            debugLog.Append("Log : Received Record Id : " + IovationId);
            debugLog.Append("Log : Received Action Id : " + IntegrationActionId);
            debugLog.Append("Log : BizTalk Process Id : " + ProcessID);
            if (isSuccess)
            {
                debugLog.Append("Status : Success");
            }
            else
            {
                debugLog.Append("Status : Failed");
            }

            debugLog.Append("");
            debugLog.Append("Salesforce Query Complete - Current Time (GMT) - " + QueryExecutionDate.ToString("yyyy-MM-dd HH:mm:ss.fff \"GMT\"zzz"));

            if (checkTxnDetailsRequest != null)
            {
                if (!string.IsNullOrEmpty(checkTxnDetailsRequest.InnerXml))
                {
                    debugLog.Append("");
                    debugLog.Append("Sending data to Iovation - Current Time(GMT) - " + Helper.GetDateFromXmlComment(checkTxnDetailsRequest));                                        
                    debugLog.Append("========== Iovation Request ========== ");
                    debugLog.Append("<?xml version='1.0' encoding='UTF - 8'?>");
                    debugLog.Append("<Envelope xmlns='http://schemas.xmlsoap.org/soap/envelope/' xmlns:ns='http://www.iesnare.com/dra/api/CheckTransactionDetails' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>");
                    debugLog.Append("<Body>");
                    debugLog.Append(Helper.FormatXmlToString(Helper.IgnoreDateFromXmlComment(checkTxnDetailsRequest).InnerXml));
                    debugLog.Append("</Body>");
                    debugLog.Append("</Envelope>");                    
                }
            }
            if (checkTxnDetailsResponse != null)
            {
                if (!string.IsNullOrEmpty(checkTxnDetailsResponse.InnerXml))
                {
                    debugLog.Append("");
                    debugLog.Append("Response received from Iovation - Current Time(GMT) - " + Helper.GetDateFromXmlComment(checkTxnDetailsResponse));                    
                    debugLog.Append("========== Iovation Result ==========");
                    debugLog.Append("<?xml version='1.0' encoding='UTF - 8'?>");
                    debugLog.Append("<SOAP-ENV:Envelope xmlns:xsd='http://www.w3.org/2001/XMLSchema' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:SOAP-ENC='http://schemas.xmlsoap.org/soap/encoding/ xmlns:SOAP-ENV='http://schemas.xmlsoap.org/soap/envelope/' SOAP-ENV:encodingStyle='http://schemas.xmlsoap.org/soap/encoding/'>");
                    debugLog.Append("<SOAP-ENV:Body>");
                    debugLog.Append(Helper.FormatXmlToString(Helper.IgnoreDateFromXmlComment(checkTxnDetailsResponse).InnerXml));
                    debugLog.Append("</SOAP-ENV:Body>");
                    debugLog.Append("</SOAP-ENV:Envelope>");
                }
            }
            debugLog.Append("==============================");
            if (!string.IsNullOrEmpty(RetryDescription))
            {
                debugLog.Append("");
                debugLog.Append(RetryDescription);
            }

            //This should be current time
            debugLog.Append("");
            debugLog.Append("Updating Integration Action - Current Time (GMT) - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff \"GMT\"zzz"));

            StringBuilder integrationActionUpdateMsg = new StringBuilder();
            integrationActionUpdateMsg.Append("<update xmlns='urn:partner.soap.sforce.com'>");
            integrationActionUpdateMsg.Append("<sObjects>");
            integrationActionUpdateMsg.Append("<type xmlns='urn1:sobject.partner.soap.sforce.com'>Integration_Action__c</type>");
            integrationActionUpdateMsg.Append("<Id>" + IntegrationActionId + "</Id>");
            integrationActionUpdateMsg.Append("<Debug_Log__c><![CDATA[" + debugLog.GetData() + "]]></Debug_Log__c>");
            if (isSuccess)
            {
                integrationActionUpdateMsg.Append("<Status__c>Completed Success</Status__c>");
            }
            else
            {
                //Changed
                //integrationActionUpdateMsg.Append("<Status__c>Errors</Status__c>");
                integrationActionUpdateMsg.Append("<Status__c>Completed Success</Status__c>");
            }

            integrationActionUpdateMsg.Append("</sObjects>");
            integrationActionUpdateMsg.Append("</update>");

            System.Diagnostics.Trace.WriteLine("integrationActionUpdateMsg.ToString() " + integrationActionUpdateMsg.ToString());
            return integrationActionUpdateMsg.ToString();
        }

        public static string GetIovationIds(string triggerMsg, string idType)
        //XmlDocument sfTriggerMsg, string idType)
        {
            //string triggerMsg = sfTriggerMsg.InnerText;

            var splitArray = triggerMsg.Split('&');

            return (idType.Equals("IovationResultId")) ? splitArray[1].Substring(17) : splitArray[0].Substring(20);
        }

        public static string GetStringFromBinaryData(string binaryData)
        {
            byte[] b = System.Convert.FromBase64String(binaryData);
            return System.Text.Encoding.UTF8.GetString(b);
        }
    }
}
