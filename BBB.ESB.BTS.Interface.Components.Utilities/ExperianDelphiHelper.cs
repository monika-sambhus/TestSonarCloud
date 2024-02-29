using System;
using System.Text;
using System.Xml;

namespace ESB.BTS.Components.Interface.Utilities
{
    public class ExperianDelphiHelper
    {
        public static string CreateDelphiDetectMsg(string ApplicationId, XmlDocument msgDelphiResp)
        {
            StringBuilder delphiDetectMsg = new StringBuilder();
            String delphiDetect = Utilities.DelphiMap.Process(msgDelphiResp, "Delphi_Detect");
            String delphiRules = Utilities.DelphiDetectRule.Process(msgDelphiResp);
            delphiDetectMsg.Append("<create xmlns='urn:partner.soap.sforce.com'>");
            delphiDetectMsg.Append("<sObjects xmlns='urn:partner.soap.sforce.com'>");
            delphiDetectMsg.Append("<type xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns='urn1:sobject.partner.soap.sforce.com'>Delphi_Detect__c</type>");
            delphiDetectMsg.Append("<Application__c>" + ApplicationId + "</Application__c>");
            delphiDetectMsg.Append(delphiDetect);
            delphiDetectMsg.Append(delphiRules);
            delphiDetectMsg.Append("</sObjects>");
            delphiDetectMsg.Append("</create>");

            System.Diagnostics.Trace.WriteLine("delphiDetectMsg.ToString() " + delphiDetectMsg.ToString());
            return delphiDetectMsg.ToString();
        }

        public static string CreateDelphiSelect1Msg(string ApplicationId, XmlDocument msgDelphiResp)
        {
            StringBuilder delphiSelect1Msg = new StringBuilder();
            String select1Data = Utilities.DelphiMap.Process(msgDelphiResp, "Delphi_Select_1");
            delphiSelect1Msg.Append("<create xmlns='urn:partner.soap.sforce.com'>");
            delphiSelect1Msg.Append("<sObjects xmlns='urn:partner.soap.sforce.com'>");
            delphiSelect1Msg.Append("<type xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns='urn1:sobject.partner.soap.sforce.com'>Delphi_Select_1__c</type>");
            delphiSelect1Msg.Append("<Application__c>" + ApplicationId + "</Application__c>");
            delphiSelect1Msg.Append(select1Data);
            delphiSelect1Msg.Append("</sObjects>");
            delphiSelect1Msg.Append("</create>");

            System.Diagnostics.Trace.WriteLine("delphiSelect1Msg.ToString() " + delphiSelect1Msg.ToString());
            return delphiSelect1Msg.ToString();
        }

        public static string CreateDelphiSelect2Msg(string ApplicationId, XmlDocument msgDelphiResp)
        {
            StringBuilder delphiSelect2Msg = new StringBuilder();
            String select2Data = Utilities.DelphiMap.Process(msgDelphiResp, "Delphi_Select_2");
            delphiSelect2Msg.Append("<create xmlns='urn:partner.soap.sforce.com'>");
            delphiSelect2Msg.Append("<sObjects xmlns='urn:partner.soap.sforce.com'>");
            delphiSelect2Msg.Append("<type xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns='urn1:sobject.partner.soap.sforce.com'>Delphi_Select_2__c</type>");
            delphiSelect2Msg.Append("<Application__c>" + ApplicationId + "</Application__c>");
            delphiSelect2Msg.Append(select2Data);
            delphiSelect2Msg.Append("</sObjects>");
            delphiSelect2Msg.Append("</create>");

            System.Diagnostics.Trace.WriteLine("delphiSelect2Msg.ToString() " + delphiSelect2Msg.ToString());
            return delphiSelect2Msg.ToString();
        }

        public static string UpdateDelphiIntActionMessage(string ApplicationId, string IntegrationActionId, bool isDelphiSuccess, string ProcessId, DateTime QueryExecutionDate, XmlDocument DelphiRequest = null, XmlDocument DelphiReqHeader = null, XmlDocument DelphiResponse = null, string retryDescription = null)
        {
            string orgId = Config.GetStringConfigValue("SalesForce.OrgId");

            StringBuilder debugLog = new StringBuilder();
            debugLog.AppendLine("Integration Type : Salesforce To Delphi Select");
            debugLog.AppendLine("Current Time (GMT) - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff \"GMT\"zzz"));
            debugLog.AppendLine("Log : BizTalk Environment :" + Environment.MachineName);
            debugLog.AppendLine("Log : Received Org Id : " + orgId);
            debugLog.AppendLine("Log : Received Application Id : " + ApplicationId);
            debugLog.AppendLine("Log : Received Action Id : " + IntegrationActionId);
            debugLog.AppendLine("Log : BizTalk Process Id : " + ProcessId);
            if (isDelphiSuccess)
            {
                debugLog.AppendLine("Status : Success");
            }
            else
            {
                debugLog.AppendLine("Status : Failed");
            }

            debugLog.AppendLine();
            debugLog.AppendLine("Salesforce Query Complete - Current Time (GMT) - " + QueryExecutionDate.ToString("yyyy-MM-dd HH:mm:ss.fff \"GMT\"zzz"));

            if (DelphiRequest != null)
            {
                if (!string.IsNullOrEmpty(DelphiRequest.InnerXml))
                {
                    debugLog.AppendLine();
                    debugLog.AppendLine("Sending data to Delphi - Current Time(GMT) - " + Helper.GetDateFromXmlComment(DelphiRequest));                   
                    debugLog.AppendLine("=============== Delphi Request =============== :");
                    debugLog.AppendLine("Log :");
                    debugLog.AppendLine("<?xml version='1.0' encoding='UTF - 8'?>");
                    debugLog.AppendLine("<Envelope xmlns='http://schemas.xmlsoap.org/soap/envelope/' xmlns:ns='http://schema.uk.experian.com/eih/2011/03' xmlns:ns1='http://schema.uk.experian.com/eih/2011/03/EIHHeader'>");
                    debugLog.AppendLine("<Header>");
                    debugLog.AppendLine(Helper.FormatXmlToString(DelphiReqHeader.DocumentElement.InnerXml));
                    debugLog.AppendLine("</Header>");
                    debugLog.AppendLine("<Body>");
                    debugLog.AppendLine(Helper.FormatXmlToString(Helper.IgnoreDateFromXmlComment(DelphiRequest).InnerXml));
                    debugLog.AppendLine("</Body>");
                    debugLog.AppendLine("</Envelope>");
                }
            }
            if (DelphiResponse != null)
            {
                if (!string.IsNullOrEmpty(DelphiResponse.InnerXml))
                {
                    debugLog.AppendLine();
                    debugLog.AppendLine("Response received from Delphi - Current Time(GMT) - " + Helper.GetDateFromXmlComment(DelphiResponse));                    
                    debugLog.AppendLine("=============== Delphi Response =============== :");
                    debugLog.AppendLine("Log :");
                    debugLog.AppendLine("<?xml version='1.0' encoding='UTF - 8'?>");
                    debugLog.AppendLine("<SOAP-ENV:Envelope xmlns='http://schemas.xmlsoap.org/soap/envelope/' xmlns:bws='http://schema.uk.experian.com/eih/2011/03/BankWizard' xmlns:eih='http://schema.uk.experian.com/eih/2011/03' xmlns:header='http://schema.uk.experian.com/eih/2011/03/EIHHeader' xmlns:ns3='http://schemas.xmlsoap.org/soap/envelope/' xmlns:qas='http://schema.uk.experian.com/eih/2011/03/QAS' xmlns:soap='http://schemas.xmlsoap.org/soap/envelope/' xmlns:SOAP-ENV='http://schemas.xmlsoap.org/soap/envelope/'>");
                    debugLog.AppendLine("<SOAP-ENV:Header/>");
                    debugLog.AppendLine("<SOAP-ENV:Body>");
                    debugLog.AppendLine(Helper.FormatXmlToString(Helper.IgnoreDateFromXmlComment(DelphiResponse).InnerXml));
                    debugLog.AppendLine("</SOAP-ENV:Body>");
                    debugLog.AppendLine("</SOAP-ENV:Envelope>");
                    //debugLog.AppendLine("Received response from Delphi - Current Time (GMT) - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff \"GMT\"zzz"));
                }
            }

            if (!string.IsNullOrEmpty(retryDescription))
            {
                debugLog.AppendLine();
                debugLog.AppendLine(retryDescription);
            }

            //This will be current time
            debugLog.AppendLine();
            debugLog.AppendLine("Updating Integration Action - Current Time (GMT) - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff \"GMT\"zzz"));

            StringBuilder integrationActionUpdateMsg = new StringBuilder();
            integrationActionUpdateMsg.Append("<update xmlns='urn:partner.soap.sforce.com'>");
            integrationActionUpdateMsg.Append("<sObjects>");
            integrationActionUpdateMsg.Append("<type xmlns='urn1:sobject.partner.soap.sforce.com'>Integration_Action__c</type>");
            integrationActionUpdateMsg.Append("<Id>" + IntegrationActionId + "</Id>");
            integrationActionUpdateMsg.Append("<Debug_Log__c><![CDATA[" + debugLog.ToString() + "]]></Debug_Log__c>");
            if (isDelphiSuccess)
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
