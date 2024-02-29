using System;
using System.Text;
using System.Xml;

namespace ESB.BTS.Components.Interface.Utilities
{
    public class FinancePartnerHelper
    {
        public static string CreateApplicationMessage(string ApplicationId, string Status)
        {
            string success = Config.GetStringConfigValue("StreetUK.SuccessStatus");
            string sent = Config.GetStringConfigValue("StreetUK.SentStatus");
            string error = Config.GetStringConfigValue("StreetUK.ErrorStatus");
            string pending = Config.GetStringConfigValue("StreetUK.PendingStatus");

            StringBuilder applicationUpdateMsg = new StringBuilder();
            applicationUpdateMsg.Append("<update xmlns='urn:partner.soap.sforce.com'>");
            applicationUpdateMsg.Append("<sObjects>");
            applicationUpdateMsg.Append("<type xmlns='urn1:sobject.partner.soap.sforce.com'>Application__c</type>");
            applicationUpdateMsg.Append("<Id>" + ApplicationId + "</Id>");
            if (Status.ToLower().Equals(success.ToLower()))
            {
                applicationUpdateMsg.Append("<Street_Integration_Status__c>" + sent + "</Street_Integration_Status__c>");
            }
            else if (Status.ToLower().Equals(error.ToLower()))
            {
                applicationUpdateMsg.Append("<Street_Integration_Status__c>" + error + "</Street_Integration_Status__c>");
            }
            else if (Status.ToLower().Equals(pending.ToLower()))
            {
                applicationUpdateMsg.Append("<Street_Integration_Status__c>" + pending + "</Street_Integration_Status__c>");
            }
            else
            {
                applicationUpdateMsg.Append("<Street_Integration_Status__c>" + Status + "</Street_Integration_Status__c>");
            }
            applicationUpdateMsg.Append("</sObjects>");
            applicationUpdateMsg.Append("</update>");

            System.Diagnostics.Trace.WriteLine("applicationUpdateMsg " + applicationUpdateMsg.ToString());
            return applicationUpdateMsg.ToString();
        }

        public static string CreateLoanUpdateMessage(string LoanId, string Status)
        {
            string status1 = Config.GetStringConfigValue("StreetUK.LoanStatus.1");
            string status2 = Config.GetStringConfigValue("StreetUK.LoanStatus.2");
            string status3 = Config.GetStringConfigValue("StreetUK.LoanStatus.3");
            string status4 = Config.GetStringConfigValue("StreetUK.LoanStatus.4");
            string status5 = Config.GetStringConfigValue("StreetUK.LoanStatus.5");
            string statusNA = Config.GetStringConfigValue("StreetUK.LoanStatus.NA");

            StringBuilder loanUpdateMsg = new StringBuilder();
            loanUpdateMsg.Append("<update xmlns='urn:partner.soap.sforce.com'>");
            loanUpdateMsg.Append("<sObjects>");
            loanUpdateMsg.Append("<type xmlns='urn1:sobject.partner.soap.sforce.com'>Loan__c</type>");
            loanUpdateMsg.Append("<Id>" + LoanId + "</Id>");
            if (string.IsNullOrEmpty(Status.Trim()))
            {
                //Do Nothing
                //Suppresses status node
            }
            else if (Status.Equals("1"))
            {
                loanUpdateMsg.Append("<Status__c>" + status1 + "</Status__c>");
            }
            else if (Status.Equals("2"))
            {
                loanUpdateMsg.Append("<Status__c>" + status2 + "</Status__c>");
            }
            else if (Status.Equals("3"))
            {
                loanUpdateMsg.Append("<Status__c>" + status3 + "</Status__c>");
            }
            else if (Status.Equals("4"))
            {
                loanUpdateMsg.Append("<Status__c>" + status4 + "</Status__c>");
            }
            else if (Status.Equals("5"))
            {
                loanUpdateMsg.Append("<Status__c>" + status5 + "</Status__c>");
            }
            else
            {
                loanUpdateMsg.Append("<Status__c>" + statusNA + "</Status__c>");
            }
            loanUpdateMsg.Append("</sObjects>");
            loanUpdateMsg.Append("</update>");

            System.Diagnostics.Trace.WriteLine("loanUpdateMsg " + loanUpdateMsg.ToString());
            return loanUpdateMsg.ToString();
        }

        public static string CreateUpdateFinancePartnerIDs(string SFContactID, string SFApplicationID, string SFBankID, string FPContactID, string FPAddressID, string FPApplicationID, string FPBankID)
        {
            StringBuilder loanUpdateMsg = new StringBuilder();
            loanUpdateMsg.Append("<update xmlns='urn:partner.soap.sforce.com'>");
            if (!System.String.IsNullOrEmpty(FPContactID) || !System.String.IsNullOrEmpty(FPAddressID))
            {
                loanUpdateMsg.Append("<sObjects>");
                loanUpdateMsg.Append("<type xmlns='urn1:sobject.partner.soap.sforce.com'>Contact</type>");
                loanUpdateMsg.Append("<Id>" + SFContactID + "</Id>");
                if (!System.String.IsNullOrEmpty(FPContactID)) { loanUpdateMsg.Append("<FP_Unique_ID__c>" + FPContactID + "</FP_Unique_ID__c>"); }
                if (!System.String.IsNullOrEmpty(FPAddressID)) { loanUpdateMsg.Append("<FP_Unique_Address_ID__c>" + FPAddressID + "</FP_Unique_Address_ID__c>"); }
                loanUpdateMsg.Append("</sObjects>");
            }
            if (!System.String.IsNullOrEmpty(FPApplicationID))
            {
                loanUpdateMsg.Append("<sObjects>");
                loanUpdateMsg.Append("<type xmlns='urn1:sobject.partner.soap.sforce.com'>Application__c</type>");
                loanUpdateMsg.Append("<Id>" + SFApplicationID + "</Id>");
                loanUpdateMsg.Append("<FP_Unique_ID__c>" + FPApplicationID + "</FP_Unique_ID__c>");
                loanUpdateMsg.Append("</sObjects>");
            }
            if (!System.String.IsNullOrEmpty(FPBankID))
            {
                loanUpdateMsg.Append("<sObjects>");
                loanUpdateMsg.Append("<type xmlns='urn1:sobject.partner.soap.sforce.com'>Bank_Details__c</type>");
                loanUpdateMsg.Append("<Id>" + SFBankID + "</Id>");
                loanUpdateMsg.Append("<FP_Unique_ID__c>" + FPBankID + "</FP_Unique_ID__c>");
                loanUpdateMsg.Append("</sObjects>");
            }

            loanUpdateMsg.Append("</update>");

            System.Diagnostics.Trace.WriteLine("loanUpdateFPIDMsg " + loanUpdateMsg.ToString());
            return loanUpdateMsg.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="LoanId"></param>
        /// <param name="IntegrationActionId"></param>
        /// <param name="isLoanSuccess"></param>
        /// <param name="ProcessId"></param>
        /// <param name="FinancePartnerName"></param>
        /// <param name="QueryExecutionDate"></param>
        /// <param name="LoanRequest">Is used for FP with single web calls Only</param>
        /// <param name="LoanResponse">Is used for FP with single web calls Only</param>
        /// <param name="retryDescription">Is used for FP with single web calls Only</param>
        /// <param name="FPDebugLog">Is used for FP with Multiple web calls Only</param>
        /// <returns></returns>
        public static string UpdateIDHubIntActionMessage(string LoanId, string IntegrationActionId, bool isLoanSuccess, string ProcessId, string FinancePartnerName, DateTime QueryExecutionDate, XmlDocument LoanRequest = null, XmlDocument LoanResponse = null, string ErrorDescription = null, string retryDescription = null, string FPDebugLog = null, string SFUpdateStatus = null)
        {
            string orgId = Config.GetStringConfigValue("SalesForce.OrgId");

            StringBuilder debugLog = new StringBuilder();
            debugLog.AppendLine("Integration Type : Salesforce To FinancePartner - " + FinancePartnerName);
            debugLog.AppendLine("Current Time (GMT) - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff \"GMT\"zzz"));
            debugLog.AppendLine("Log : BizTalk Environment :" + Environment.MachineName);
            debugLog.AppendLine("Log : Received Org Id : " + orgId);
            debugLog.AppendLine("Log : Received Application Id : " + LoanId);
            debugLog.AppendLine("Log : Received Action Id : " + IntegrationActionId);
            debugLog.AppendLine("Log : BizTalk Process Id : " + ProcessId);
            if (isLoanSuccess)
            {
                debugLog.AppendLine("Status :Success");
            }
            else
            {
                debugLog.AppendLine("Status : Failed");
            }

            debugLog.AppendLine();
            debugLog.AppendLine("Salesforce Query Complete - Current Time (GMT) - " + QueryExecutionDate.ToString("yyyy-MM-dd HH:mm:ss.fff \"GMT\"zzz"));

            if (LoanRequest != null)
            {
                if (!string.IsNullOrEmpty(LoanRequest.InnerXml))
                {
                    debugLog.AppendLine();
                    debugLog.AppendLine("Sending data to Finance Partner - " + FinancePartnerName + " Current Time (GMT) - " + Helper.GetDateFromXmlComment(LoanRequest));
                    debugLog.AppendLine("========== " + FinancePartnerName + " Request ========== ");
                    debugLog.AppendLine(Helper.XmlToJson(Helper.IgnoreDateFromXmlComment(LoanRequest)));
                }
            }
            if (LoanResponse != null)
            {
                if (!string.IsNullOrEmpty(LoanResponse.InnerXml))
                {
                    debugLog.AppendLine();
                    debugLog.AppendLine("Response received from Finance Partner - " + FinancePartnerName + " Current Time (GMT) - " + Helper.GetDateFromXmlComment(LoanResponse));
                    debugLog.AppendLine("========== " + FinancePartnerName + " Result ==========");
                    debugLog.AppendLine(Helper.XmlToJson(Helper.IgnoreDateFromXmlComment(LoanResponse)));
                }
            }

            //Used only for multiple calls scenarios
            if (!string.IsNullOrEmpty(FPDebugLog))
            {
                debugLog.AppendLine();
                debugLog.AppendLine(FPDebugLog);
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

            StringBuilder integrationActionUpdateMsg = new StringBuilder();
            integrationActionUpdateMsg.Append("<update xmlns='urn:partner.soap.sforce.com'>");
            integrationActionUpdateMsg.Append("<sObjects>");
            integrationActionUpdateMsg.Append("<type xmlns='urn1:sobject.partner.soap.sforce.com'>Integration_Action__c</type>");
            integrationActionUpdateMsg.Append("<Id>" + IntegrationActionId + "</Id>");
            integrationActionUpdateMsg.Append("<Debug_Log__c><![CDATA[" + debugLog.ToString() + "]]></Debug_Log__c>");
            if (isLoanSuccess)
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

        public static string CreateFPDebugLog(XmlDocument GetDetails, XmlDocument CustomerExistingAddress, XmlDocument CustomerExistingBank, XmlDocument Customer = null, XmlDocument CustomerRes = null, XmlDocument CustomerUpdate = null, XmlDocument CustomerUpdateRes = null, XmlDocument CustomerIdentityUpdate = null, XmlDocument CustomerIdentityUpdateRes = null, XmlDocument CustomerAddress = null, XmlDocument CustomerAddressRes = null, XmlDocument CustomerBank = null, XmlDocument CustomerBankRes = null, string PreviousApplicationStatusLog = null, XmlDocument CustomerApplication = null, XmlDocument CustomerApplicationRes = null, XmlDocument ApplicationBank = null, XmlDocument ApplicationBankRes = null, string FPApplicationStatus = null, XmlDocument ApplicationStatus = null, XmlDocument ApplicationStatusRes = null, string FinancePartnerName = null)
        {
            StringBuilder debugLog = new StringBuilder();
            
            if (GetDetails != null)
            {
                if (!string.IsNullOrEmpty(GetDetails.InnerXml))
                {
                    debugLog.AppendLine("Existing Ids as below" + " Current Time (GMT) - " + Helper.GetDateFromXmlComment(GetDetails));
                    debugLog.AppendLine(Helper.XmlToJson(Helper.IgnoreDateFromXmlComment(GetDetails)));
                }
            }

            if (CustomerExistingAddress != null)
            {
                if (!string.IsNullOrEmpty(CustomerExistingAddress.InnerXml))
                {
                    debugLog.AppendLine();
                    debugLog.AppendLine("Address already present for same move in date. Address Update Skipped" + " Current Time (GMT) - " + Helper.GetDateFromXmlComment(CustomerExistingAddress));
                    debugLog.AppendLine(Helper.XmlToJson(Helper.IgnoreDateFromXmlComment(CustomerExistingAddress)));
                }
            }

            if (CustomerExistingBank != null)
            {
                if (!string.IsNullOrEmpty(CustomerExistingBank.InnerXml))
                {
                    debugLog.AppendLine();
                    debugLog.AppendLine("Same Bank account is already present. Bank account creation Skipped" + " Current Time (GMT) - " + Helper.GetDateFromXmlComment(CustomerExistingAddress));
                    debugLog.AppendLine(Helper.XmlToJson(Helper.IgnoreDateFromXmlComment(CustomerExistingBank)));
                }
            }

            if (Customer != null)
            {
                if (!string.IsNullOrEmpty(Customer.InnerXml))
                {
                    debugLog.AppendLine();
                    debugLog.AppendLine("Sending Customer data to Finance Partner - " + FinancePartnerName + " Current Time (GMT) - " + Helper.GetDateFromXmlComment(Customer));
                    debugLog.AppendLine("========== " + FinancePartnerName + " Request ========== ");
                    debugLog.AppendLine(Helper.XmlToJson(Helper.IgnoreDateFromXmlComment(Customer)));
                }
            }
            if (CustomerRes != null)
            {
                if (!string.IsNullOrEmpty(CustomerRes.InnerXml))
                {
                    debugLog.AppendLine();
                    debugLog.AppendLine("Response received from Finance Partner - " + FinancePartnerName + " Current Time (GMT) - " + Helper.GetDateFromXmlComment(CustomerRes));
                    debugLog.AppendLine("========== " + FinancePartnerName + " Result ==========");
                    debugLog.AppendLine(Helper.XmlToJson(Helper.IgnoreDateFromXmlComment(CustomerRes)));
                }
            }

            if (CustomerUpdate != null)
            {
                if (!string.IsNullOrEmpty(CustomerUpdate.InnerXml))
                {
                    debugLog.AppendLine();
                    debugLog.AppendLine("Sending Customer Update data to Finance Partner - " + FinancePartnerName + " Current Time (GMT) - " + Helper.GetDateFromXmlComment(CustomerUpdate));
                    debugLog.AppendLine("========== " + FinancePartnerName + " Request ========== ");
                    debugLog.AppendLine(Helper.XmlToJson(Helper.IgnoreDateFromXmlComment(CustomerUpdate)));
                }
            }
            if (CustomerUpdateRes != null)
            {
                if (!string.IsNullOrEmpty(CustomerUpdateRes.InnerXml))
                {
                    debugLog.AppendLine();
                    debugLog.AppendLine("Response received from Finance Partner - " + FinancePartnerName + " Current Time (GMT) - " + Helper.GetDateFromXmlComment(CustomerUpdateRes));
                    debugLog.AppendLine("========== " + FinancePartnerName + " Result ==========");
                    debugLog.AppendLine(Helper.XmlToJson(Helper.IgnoreDateFromXmlComment(CustomerUpdateRes)));
                }
            }

            if (CustomerIdentityUpdate != null)
            {
                if (!string.IsNullOrEmpty(CustomerIdentityUpdate.InnerXml))
                {
                    debugLog.AppendLine();
                    debugLog.AppendLine("Sending Customer Identity Update data to Finance Partner - " + FinancePartnerName + " Current Time (GMT) - " + Helper.GetDateFromXmlComment(CustomerIdentityUpdate));
                    debugLog.AppendLine("========== " + FinancePartnerName + " Request ========== ");
                    debugLog.AppendLine(Helper.XmlToJson(Helper.IgnoreDateFromXmlComment(CustomerIdentityUpdate)));
                }
            }
            if (CustomerIdentityUpdateRes != null)
            {
                if (!string.IsNullOrEmpty(CustomerIdentityUpdateRes.InnerXml))
                {
                    debugLog.AppendLine();
                    debugLog.AppendLine("Response received from Finance Partner - " + FinancePartnerName + " Current Time (GMT) - " + Helper.GetDateFromXmlComment(CustomerIdentityUpdateRes));
                    debugLog.AppendLine("========== " + FinancePartnerName + " Result ==========");
                    debugLog.AppendLine(Helper.XmlToJson(Helper.IgnoreDateFromXmlComment(CustomerIdentityUpdateRes)));
                }
            }

            if (CustomerAddress != null)
            {
                if (!string.IsNullOrEmpty(CustomerAddress.InnerXml))
                {
                    debugLog.AppendLine();
                    debugLog.AppendLine("Sending Customer Address data to Finance Partner - " + FinancePartnerName + " Current Time (GMT) - " + Helper.GetDateFromXmlComment(CustomerAddress));
                    debugLog.AppendLine("========== " + FinancePartnerName + " Request ========== ");
                    debugLog.AppendLine(Helper.XmlToJson(Helper.IgnoreDateFromXmlComment(CustomerAddress)));
                }
            }
            if (CustomerAddressRes != null)
            {
                if (!string.IsNullOrEmpty(CustomerAddressRes.InnerXml))
                {
                    debugLog.AppendLine();
                    debugLog.AppendLine("Response received from Finance Partner - " + FinancePartnerName + " Current Time (GMT) - " + Helper.GetDateFromXmlComment(CustomerAddressRes));
                    debugLog.AppendLine("========== " + FinancePartnerName + " Result ==========");
                    debugLog.AppendLine(Helper.XmlToJson(Helper.IgnoreDateFromXmlComment(CustomerAddressRes)));
                }
            }

            if (CustomerBank != null)
            {
                if (!string.IsNullOrEmpty(CustomerBank.InnerXml))
                {
                    debugLog.AppendLine();
                    debugLog.AppendLine("Sending Customer Bank data to Finance Partner - " + FinancePartnerName + " Current Time (GMT) - " + Helper.GetDateFromXmlComment(CustomerBank));
                    debugLog.AppendLine("========== " + FinancePartnerName + " Request ========== ");
                    debugLog.AppendLine(Helper.XmlToJson(Helper.IgnoreDateFromXmlComment(CustomerBank)));
                }
            }
            if (CustomerBankRes != null)
            {
                if (!string.IsNullOrEmpty(CustomerBankRes.InnerXml))
                {
                    debugLog.AppendLine();
                    debugLog.AppendLine("Response received from Finance Partner - " + FinancePartnerName + " Current Time (GMT) - " + Helper.GetDateFromXmlComment(CustomerBankRes));
                    debugLog.AppendLine("========== " + FinancePartnerName + " Result ==========");
                    debugLog.AppendLine(Helper.XmlToJson(Helper.IgnoreDateFromXmlComment(CustomerBankRes)));
                }
            }

            if(!string.IsNullOrEmpty(PreviousApplicationStatusLog))
            {
                debugLog.AppendLine();
                debugLog.AppendLine(PreviousApplicationStatusLog);
            }

            if (CustomerApplication != null)
            {
                if (!string.IsNullOrEmpty(CustomerApplication.InnerXml))
                {
                    debugLog.AppendLine();
                    debugLog.AppendLine("Sending Customer Application data to Finance Partner - " + FinancePartnerName + " Current Time (GMT) - " + Helper.GetDateFromXmlComment(CustomerApplication));
                    debugLog.AppendLine("========== " + FinancePartnerName + " Request ========== ");
                    debugLog.AppendLine(Helper.XmlToJson(Helper.IgnoreDateFromXmlComment(CustomerApplication)));
                }
            }

            if (CustomerApplicationRes != null)
            {
                if (!string.IsNullOrEmpty(CustomerApplicationRes.InnerXml))
                {
                    debugLog.AppendLine();
                    debugLog.AppendLine("Response received from Finance Partner - " + FinancePartnerName + " Current Time (GMT) - " + Helper.GetDateFromXmlComment(CustomerApplicationRes));
                    debugLog.AppendLine("========== " + FinancePartnerName + " Result ==========");
                    debugLog.AppendLine(Helper.XmlToJson(Helper.IgnoreDateFromXmlComment(CustomerApplicationRes)));
                }
            }

            if (ApplicationBank != null)
            {
                if (!string.IsNullOrEmpty(ApplicationBank.InnerXml))
                {
                    debugLog.AppendLine();
                    debugLog.AppendLine("Sending Application Bank data to Finance Partner - " + FinancePartnerName + " Current Time (GMT) - " + Helper.GetDateFromXmlComment(ApplicationBank));
                    debugLog.AppendLine("========== " + FinancePartnerName + " Request ========== ");
                    debugLog.AppendLine(Helper.XmlToJson(Helper.IgnoreDateFromXmlComment(ApplicationBank)));
                }
            }
            if (ApplicationBankRes != null)
            {
                if (!string.IsNullOrEmpty(ApplicationBankRes.InnerXml))
                {
                    debugLog.AppendLine();
                    debugLog.AppendLine("Response received from Finance Partner - " + FinancePartnerName + " Current Time (GMT) - " + Helper.GetDateFromXmlComment(ApplicationBankRes));
                    debugLog.AppendLine("========== " + FinancePartnerName + " Result ==========");
                    debugLog.AppendLine(Helper.XmlToJson(Helper.IgnoreDateFromXmlComment(ApplicationBankRes)));
                }
            }

            if (!string.IsNullOrEmpty(FPApplicationStatus))
            {
                debugLog.AppendLine();
                debugLog.AppendLine("Application Status to Finance Partner - " + FPApplicationStatus);
            }

            if (ApplicationStatus != null)
            {
                if (!string.IsNullOrEmpty(ApplicationStatus.InnerXml))
                {
                    debugLog.AppendLine();
                    debugLog.AppendLine("Sending Application Status data to Finance Partner - " + FinancePartnerName + " Current Time (GMT) - " + Helper.GetDateFromXmlComment(ApplicationStatus));
                    debugLog.AppendLine("========== " + FinancePartnerName + " Request ========== ");
                    debugLog.AppendLine(Helper.XmlToJson(Helper.IgnoreDateFromXmlComment(ApplicationStatus)));
                }
            }
            if (ApplicationStatusRes != null)
            {
                if (!string.IsNullOrEmpty(ApplicationStatusRes.InnerXml))
                {
                    debugLog.AppendLine();
                    debugLog.AppendLine("Response received from Finance Partner - " + FinancePartnerName + " Current Time (GMT) - " + Helper.GetDateFromXmlComment(ApplicationStatusRes));
                    debugLog.AppendLine("========== " + FinancePartnerName + " Result ==========");
                    debugLog.AppendLine(Helper.XmlToJson(Helper.IgnoreDateFromXmlComment(ApplicationStatusRes)));
                }
            }

            return debugLog.ToString();
        }
    }
}

