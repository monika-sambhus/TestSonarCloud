using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BBB.ESB.BTS.Components.Interface.Utilities;


namespace BBB.ESB.Atlas.PLS.Utilities
{
    public class PLSPHelper
    {
        public static string UpdateIDHubIntActionMessage(string plsEventId, string IntegrationActionId, bool isPLSUpdateSuccess, string ProcessId, string PLSPartnerName, string ErrorDescription = null, string retryDescription = null, string PLSPDebugLog = null, string SFUpdateStatus = null)
        {
            string orgId = Config.GetStringConfigValue("SalesForce.OrgId");

            StringBuilder debugLog = new StringBuilder();
            debugLog.AppendLine("Integration Type : Salesforce To PLSPartner - " + PLSPartnerName);
            debugLog.AppendLine("Current Time (GMT) - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff \"GMT\"zzz"));
            debugLog.AppendLine("Log : BizTalk Environment :" + Environment.MachineName);
            debugLog.AppendLine("Log : Received Org Id : " + orgId);
            debugLog.AppendLine("Log : Received PLS Event Id : " + plsEventId);
            debugLog.AppendLine("Log : Received Action Id : " + IntegrationActionId);
            debugLog.AppendLine("Log : BizTalk Process Id : " + ProcessId);
            debugLog.AppendLine("Log : BizTalk API Version : " + "Version 2");
            if (isPLSUpdateSuccess)
            {
                debugLog.AppendLine("Status :Success");
            }
            else
            {
                debugLog.AppendLine("Status : Failed");
            }

            //debugLog.AppendLine();
            //debugLog.AppendLine("Salesforce Query Complete - Current Time (GMT) - " + QueryExecutionDate.ToString("yyyy-MM-dd HH:mm:ss.fff \"GMT\"zzz"));

            //Used only for multiple calls scenarios
            if (!string.IsNullOrEmpty(PLSPDebugLog))
            {
                debugLog.AppendLine();
                debugLog.AppendLine(PLSPDebugLog);
            }

            if (!string.IsNullOrEmpty(ErrorDescription))
            {
                debugLog.AppendLine();
                debugLog.AppendLine(ErrorDescription);
            }

            if (!string.IsNullOrEmpty(retryDescription))
            {
                debugLog.AppendLine();
                debugLog.AppendLine(retryDescription);
            }

            if (!string.IsNullOrEmpty(SFUpdateStatus))
            {
                debugLog.AppendLine();
                debugLog.AppendLine(SFUpdateStatus);
            }

            debugLog.AppendLine("==============================");
            //This is current time
            debugLog.AppendLine();
            debugLog.AppendLine("Updating Integration Action - Current Time (GMT) - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff \"GMT\"zzz"));

            //StringBuilder integrationActionUpdateMsg = new StringBuilder();
            //integrationActionUpdateMsg.Append("<update xmlns='urn:partner.soap.sforce.com'>");
            //integrationActionUpdateMsg.Append("<sObjects>");
            //integrationActionUpdateMsg.Append("<type xmlns='urn1:sobject.partner.soap.sforce.com'>Integration_Action__c</type>");
            //integrationActionUpdateMsg.Append("<Id>" + IntegrationActionId + "</Id>");
            //integrationActionUpdateMsg.Append("<Debug_Log__c><![CDATA[" + debugLog.ToString() + "]]></Debug_Log__c>");
            //if (isLoanSuccess)
            //{
            //    integrationActionUpdateMsg.Append("<Status__c>Completed Success</Status__c>");
            //}
            //else
            //{
            //    integrationActionUpdateMsg.Append("<Status__c>Errors</Status__c>");
            //}

            //integrationActionUpdateMsg.Append("</sObjects>");
            //integrationActionUpdateMsg.Append("</update>");

            System.Diagnostics.Trace.WriteLine("debugLog.ToString() " + debugLog.ToString());
            return debugLog.ToString();
        }

    }
}
