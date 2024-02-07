using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace BBB.ESB.BTS.Components.Interface.Utilities
{
    public class ExperianBWAHelper
    {
        static bool conditionExist = false;
        static bool warningExist = false;
        static bool errorExist = false;
        static string validationStatus = null;

        public static string UpdateBWAValidateStatus(string IntegrationId, string Status)
        {
            StringBuilder validateStatusUpdateMsg = new StringBuilder();
            validateStatusUpdateMsg.Append("<update xmlns='urn:partner.soap.sforce.com'>");
            validateStatusUpdateMsg.Append("<sObjects>");
            validateStatusUpdateMsg.Append("<type xmlns='urn1:sobject.partner.soap.sforce.com'>Integration_Action__c</type>");
            validateStatusUpdateMsg.Append("<Id>" + IntegrationId + "</Id>");
            validateStatusUpdateMsg.Append("<Status__c>" + Status + "</Status__c>");
            validateStatusUpdateMsg.Append("</sObjects>");
            validateStatusUpdateMsg.Append("</update>");

            System.Diagnostics.Trace.WriteLine("validateStatusUpdateMsg.ToString() " + validateStatusUpdateMsg.ToString());
            return validateStatusUpdateMsg.ToString();
        }

        public static string UpdateBWAValidateResponse(string BankDetailId, XmlDocument validateResponseMsg, out bool runBWVerify)
        {
            bool isSevere = false;
            string severity = null;
            int code = 0;
            bool runVerify = false;
            string strValidationResponse = string.Empty;

            conditionExist = false;
            warningExist = false;
            errorExist = false;
            validationStatus = null;

            var conditionsList = XDocument.Parse(validateResponseMsg.OuterXml);
            XNamespace ns = "http://schema.uk.experian.com/eih/2011/03/BankWizard";
            XNamespace ns0 = "http://schema.uk.experian.com/eih/2011/03";
            var response = (from item in conditionsList.Descendants(ns0 + "BWValidateResponse")
                            select new
                            {
                                IBAN = item.Element(ns + "IBAN"),
                                dataAccessKey = item.Element(ns + "dataAccessKey"),
                            }).SingleOrDefault();

            foreach (var condition in conditionsList.Root.Elements(ns + "conditions").Elements(ns + "condition").ToList())
            {
                conditionExist = true;
                if (condition.Attribute("severity").Value != null)
                {
                    severity = condition.Attribute("severity").Value;
                }
                if (condition.Attribute("code").Value != null)
                {
                    code = System.Convert.ToInt32(condition.Attribute("code").Value);
                }
                if (code == 5 || code == 6)
                {
                    if (severity.ToLower() == "warning")
                    {
                        isSevere = true;
                    }
                }
                if (severity.ToLower() == "warning")
                {
                    warningExist = true;
                }
                if (severity.ToLower() == "error")
                {
                    errorExist = true;
                }

                strValidationResponse += severity + "-" + code + "-" + condition.Value + "\r\n";
            }
            if (response.dataAccessKey != null)
            {
                if (((response.dataAccessKey.Value.Length > 0) || warningExist) && !errorExist)
                {
                    runVerify = true;
                }
            }
            else
            {
                runVerify = false;
            }
            runBWVerify = runVerify;

            StringBuilder validateUpdateMsg = new StringBuilder();
            validateUpdateMsg.Append("<update xmlns='urn:partner.soap.sforce.com'>");
            validateUpdateMsg.Append("<sObjects xmlns='urn:partner.soap.sforce.com'>");
            validateUpdateMsg.Append("<type xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns='urn1:sobject.partner.soap.sforce.com'>Bank_Details__c</type>");
            validateUpdateMsg.Append("<Id>" + BankDetailId + "</Id>");
            if (isSevere)
            {
                validateUpdateMsg.Append("<DD_Not_Accepted__c>" + "true" + "</DD_Not_Accepted__c>");
            }

            if (response.IBAN != null)
            {
                validateUpdateMsg.Append("<ID_Hub_IBAN_Validate_Response__c>" + response.IBAN.Value + "</ID_Hub_IBAN_Validate_Response__c>");
            }
            else
            {
                validateUpdateMsg.Append("<ID_Hub_IBAN_Validate_Response__c></ID_Hub_IBAN_Validate_Response__c>");
            }

            if (!conditionExist)
            {
                validateUpdateMsg.Append("<ID_Hub_Validation_Response__c>" + "Validated Successfully" + "</ID_Hub_Validation_Response__c>");
            }
            else
            {
                //Defect CPB-7: fix
                validateUpdateMsg.Append("<ID_Hub_Validation_Response__c>" + strValidationResponse + "</ID_Hub_Validation_Response__c>");
            }

            if (errorExist)
            {
                validationStatus = "Not Validated";
            }
            else
            {
                validationStatus = "Validated";
            }
            validateUpdateMsg.Append("<ID_Hub_Validation_Status__c>" + validationStatus + "</ID_Hub_Validation_Status__c>");

            validateUpdateMsg.Append("</sObjects>");
            validateUpdateMsg.Append("</update>");

            System.Diagnostics.Trace.WriteLine("validateUpdateMsg.ToString() " + validateUpdateMsg.ToString());
            System.Diagnostics.Trace.WriteLine("runBWVerify " + runBWVerify.ToString());

            return validateUpdateMsg.ToString();
        }

        public static string UpdateBWAFault(string BankDetailId, string isBWAValidate = null, string isBWAVerify = null, string FaultMessage = null)
        {
            StringBuilder validateFailedUpdateMsg = new StringBuilder();
            validateFailedUpdateMsg.Append("<update xmlns='urn:partner.soap.sforce.com'>");
            validateFailedUpdateMsg.Append("<sObjects xmlns='urn:partner.soap.sforce.com'>");
            validateFailedUpdateMsg.Append("<type xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns='urn1:sobject.partner.soap.sforce.com'>Bank_Details__c</type>");
            validateFailedUpdateMsg.Append("<Id>" + BankDetailId + "</Id>");

            if (!string.IsNullOrEmpty(isBWAValidate))
            {
                if (isBWAValidate.ToLower() == "true")
                {
                    validateFailedUpdateMsg.Append("<ID_Hub_Validation_Response__c>" + Helper.StringTrim(WebUtility.HtmlEncode(FaultMessage), 1000).Trim('&') + "</ID_Hub_Validation_Response__c>");
                    validateFailedUpdateMsg.Append("<ID_Hub_Validation_Status__c>" + "Validation Failed" + "</ID_Hub_Validation_Status__c>");
                }
            }

            if (!string.IsNullOrEmpty(isBWAVerify))
            {
                if (isBWAVerify.ToLower() == "true")
                {
                    validateFailedUpdateMsg.Append("<ID_Hub_Verification_Response__c>" + Helper.StringTrim(WebUtility.HtmlEncode(FaultMessage), 1000).Trim('&') + "</ID_Hub_Verification_Response__c>");
                    validateFailedUpdateMsg.Append("<ID_Hub_Verification_Status__c>" + "Verification Failed" + "</ID_Hub_Verification_Status__c>");
                }
            }

            validateFailedUpdateMsg.Append("</sObjects>");
            validateFailedUpdateMsg.Append("</update>");

            System.Diagnostics.Trace.WriteLine("validateFailedUpdateMsg.ToString() " + validateFailedUpdateMsg.ToString());
            return validateFailedUpdateMsg.ToString();
        }

        public static string UpdateBWAVerifyResponse(string BankDetailId, XmlDocument msgBWVerifyResp)
        {
            string verifyStatus = null;

            var RespList = XDocument.Parse(msgBWVerifyResp.OuterXml);
            XNamespace ns = "http://schema.uk.experian.com/eih/2014/07";

            var response = (from item in RespList.Descendants(ns + "ProcessConfigResponse")
                            select new
                            {
                                AuthenticationDecision = item.Element(ns + "DecisionHeader").Element(ns + "AuthenticationDecision"),
                                UniqueReferenceNo = item.Element(ns + "DecisionHeader").Element(ns + "UniqueReferenceNo"),
                                RuleTriggered = item.Element(ns + "DecisionHeader").Element(ns + "RuleTriggered"),
                                AccountStatus = item.Element(ns + "ProcessConfigResultsBlock").Element(ns + "BWAResultBlock").Element(ns + "AccountStatus"),
                                AddressScore = item.Element(ns + "ProcessConfigResultsBlock").Element(ns + "BWAResultBlock").Element(ns + "AddressScore"),
                                NameScore = item.Element(ns + "ProcessConfigResultsBlock").Element(ns + "BWAResultBlock").Element(ns + "NameScore"),
                                AccountOpenDateScore = item.Element(ns + "ProcessConfigResultsBlock").Element(ns + "BWAResultBlock").Element(ns + "AccountOpenDateScore"),
                                OwnerTypeResult = item.Element(ns + "ProcessConfigResultsBlock").Element(ns + "BWAResultBlock").Element(ns + "OwnerTypeResult"),
                                BacsCode = item.Element(ns + "ProcessConfigResultsBlock").Element(ns + "BWAResultBlock").Element(ns + "BacsCode"),
                            }).SingleOrDefault();

            StringBuilder verifyUpdateMsg = new StringBuilder();
            verifyUpdateMsg.Append("<update xmlns='urn:partner.soap.sforce.com'>");
            verifyUpdateMsg.Append("<sObjects xmlns='urn:partner.soap.sforce.com'>");
            verifyUpdateMsg.Append("<type xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns='urn1:sobject.partner.soap.sforce.com'>Bank_Details__c</type>");
            verifyUpdateMsg.Append("<Id>" + BankDetailId + "</Id>");
            if (response.AuthenticationDecision != null)
            {
                verifyUpdateMsg.Append("<Authentication_Decision__c>" + response.AuthenticationDecision.Value + "</Authentication_Decision__c>");
            }
            if (response.AccountStatus != null)
            {
                if (response.AccountStatus.Value.ToLower() == "match") { verifyStatus = "Verified"; } else { verifyStatus = "Not Verified"; }
                verifyUpdateMsg.Append("<ID_Hub_AccountStatus_Response__c>" + response.AccountStatus.Value + "</ID_Hub_AccountStatus_Response__c>");
            }
            if (response.AddressScore != null)
            {
                verifyUpdateMsg.Append("<ID_Hub_AddressScore_Response__c>" + response.AddressScore.Value + "</ID_Hub_AddressScore_Response__c>");
            }
            if (response.NameScore != null)
            {
                verifyUpdateMsg.Append("<ID_Hub_NameScore_Response__c>" + response.NameScore.Value + "</ID_Hub_NameScore_Response__c>");
            }
            if (response.AccountStatus != null)
            {
                verifyUpdateMsg.Append("<ID_Hub_Verification_Response__c>" + response.AccountStatus.Value + "</ID_Hub_Verification_Response__c>");
            }
            verifyUpdateMsg.Append("<ID_Hub_Verification_Status__c>" + verifyStatus + "</ID_Hub_Verification_Status__c>");
            if (response.AccountOpenDateScore != null)
            {
                verifyUpdateMsg.Append("<Id_Hub_Account_Open_Date_Score__c>" + response.AccountOpenDateScore.Value + "</Id_Hub_Account_Open_Date_Score__c>");
            }
            if (response.OwnerTypeResult != null)
            {
                verifyUpdateMsg.Append("<Id_Hub_Account_Owner_Type_Result__c>" + response.OwnerTypeResult.Value + "</Id_Hub_Account_Owner_Type_Result__c>");
            }
            if (response.BacsCode != null)
            {
                verifyUpdateMsg.Append("<Id_Hub_BACS_Value__c>" + response.BacsCode.Value + "</Id_Hub_BACS_Value__c>");
                if (response.BacsCode.Attribute("code") != null)
                {
                    verifyUpdateMsg.Append("<Id_Hub_BACS_Code__c>" + response.BacsCode.Attribute("code").Value + "</Id_Hub_BACS_Code__c>");
                }
            }
            if (response.RuleTriggered != null)
            {
                verifyUpdateMsg.Append("<Id_Hub_Verify_Rule_Triggered__c>" + response.RuleTriggered.Value + "</Id_Hub_Verify_Rule_Triggered__c>");
            }
            if (response.UniqueReferenceNo != null)
            {
                verifyUpdateMsg.Append("<Id_Hub_Verify_Unique_Reference_Number__c>" + response.UniqueReferenceNo.Value + "</Id_Hub_Verify_Unique_Reference_Number__c>");
            }
            verifyUpdateMsg.Append("</sObjects>");
            verifyUpdateMsg.Append("</update>");

            return verifyUpdateMsg.ToString();
        }
        
        public static string UpdateBWAIntActionMessage(string BankDetailId, string IntegrationActionId, bool isBWASuccess, string ProcessID, DateTime QueryExecutionDate, XmlDocument validateRequest = null, XmlDocument validateReqHeader = null, XmlDocument validateResponse = null, XmlDocument verifyRequest = null, XmlDocument verifyReqHeader = null, XmlDocument verifyResponse = null, string retryDescription = "")
        {
            string orgId = Config.GetStringConfigValue("SalesForce.OrgId");

            StringBuilder debugLog = new StringBuilder();
            debugLog.AppendLine("Integration Type : Salesforce To BWA");
            debugLog.AppendLine("Current Time (GMT) - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff \"GMT\"zzz"));            
            debugLog.AppendLine("Log : BizTalk Environment :" + Environment.MachineName);
            debugLog.AppendLine("Log : Received Org Id : " + orgId);
            debugLog.AppendLine("Log : Received Record Id : " + BankDetailId);
            debugLog.AppendLine("Log : Received Action Id : " + IntegrationActionId);
            debugLog.AppendLine("Log : BizTalk Process Id : " + ProcessID);

            if (isBWASuccess)
            {
                debugLog.AppendLine("Status : Success.");                
            }
            else
            {
                debugLog.AppendLine("Status : Failed.");                
            }
            debugLog.AppendLine();
            debugLog.AppendLine("Salesforce Query Complete - Current Time (GMT) - " + QueryExecutionDate.ToString("yyyy-MM-dd HH:mm:ss.fff \"GMT\"zzz"));

            if (validateRequest != null)
            {
                if (!string.IsNullOrEmpty(validateRequest.InnerXml))
                {
                    debugLog.AppendLine();
                    debugLog.AppendLine("Sending data to ID Hub Validate - Current Time(GMT) - " + Helper.GetDateFromXmlComment(validateRequest));                    
                    debugLog.AppendLine("=============== ID Hub Validate Request =============== :");
                    debugLog.AppendLine("<?xml version='1.0' encoding='UTF - 8'?>");
                    debugLog.AppendLine("<Envelope xmlns='http://schemas.xmlsoap.org/soap/envelope/' xmlns:ns='http://schema.uk.experian.com/eih/2011/03' xmlns:ns1='http://schema.uk.experian.com/eih/2011/03/EIHHeader' xmlns:ns2='http://schema.uk.experian.com/eih/2011/03/BankWizard' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>");
                    debugLog.AppendLine("<Header>");
                    debugLog.AppendLine(Helper.FormatXmlToString(validateReqHeader.DocumentElement.InnerXml));
                    debugLog.AppendLine("</Header>");
                    debugLog.AppendLine("<Body>");
                    debugLog.AppendLine(Helper.FormatXmlToString(Helper.IgnoreDateFromXmlComment(validateRequest).InnerXml));
                    debugLog.AppendLine("</Body>");
                    debugLog.AppendLine("</Envelope>");
                }
            }
            if (validateResponse != null)
            {
                if (!string.IsNullOrEmpty(validateResponse.InnerXml))
                {
                    debugLog.AppendLine();
                    debugLog.AppendLine("Response received from ID Hub Validate - Current Time(GMT) - " + Helper.GetDateFromXmlComment(validateResponse));                                        
                    debugLog.AppendLine("=============== ID Hub Validate Response =============== :");
                    debugLog.AppendLine("<?xml version='1.0' encoding='UTF - 8'?>");
                    debugLog.AppendLine("<SOAP-ENV:Envelope xmlns='http://schemas.xmlsoap.org/soap/envelope/' xmlns:bws='http://schema.uk.experian.com/eih/2011/03/BankWizard' xmlns:eih='http://schema.uk.experian.com/eih/2011/03' xmlns:header='http://schema.uk.experian.com/eih/2011/03/EIHHeader' xmlns:ns3='http://schemas.xmlsoap.org/soap/envelope/' xmlns:qas='http://schema.uk.experian.com/eih/2011/03/QAS' xmlns:soap='http://schemas.xmlsoap.org/soap/envelope/' xmlns:SOAP-ENV='http://schemas.xmlsoap.org/soap/envelope/'>");
                    debugLog.AppendLine("<SOAP-ENV:Header/>");
                    debugLog.AppendLine("<SOAP-ENV:Body>");
                    debugLog.AppendLine(Helper.FormatXmlToString(Helper.IgnoreDateFromXmlComment(validateResponse).InnerXml));
                    debugLog.AppendLine("</SOAP-ENV:Body>");
                    debugLog.AppendLine("</SOAP-ENV:Envelope>");
                    debugLog.AppendLine("Set Validation status");
                    debugLog.AppendLine("ConditionExist:" + conditionExist);
                    debugLog.AppendLine("ErrorExist:" + errorExist);
                    debugLog.AppendLine("warningExist:" + warningExist);
                    debugLog.AppendLine("validationStatus:" + validationStatus);
                }
            }
            if (verifyRequest != null)
            {
                if (!string.IsNullOrEmpty(verifyRequest.InnerXml))
                {
                    debugLog.AppendLine();
                    debugLog.AppendLine("Sending data to ID Hub Verify - Current Time(GMT) - " + Helper.GetDateFromXmlComment(verifyRequest));                   
                    debugLog.AppendLine("=============== ID Hub Verify Request =============== :");
                    debugLog.AppendLine("<?xml version='1.0' encoding='UTF - 8'?>");
                    debugLog.AppendLine("<Envelope xmlns='http://schemas.xmlsoap.org/soap/envelope/' xmlns:ns='http://schema.uk.experian.com/eih/2011/03' xmlns:ns1='http://schema.uk.experian.com/eih/2011/03/EIHHeader'>");
                    debugLog.AppendLine("<Header>");
                    debugLog.AppendLine(Helper.FormatXmlToString(Helper.IgnoreDateFromXmlComment(verifyReqHeader).DocumentElement.InnerXml));
                    debugLog.AppendLine("</Header>");
                    debugLog.AppendLine("<Body>");
                    debugLog.AppendLine(Helper.FormatXmlToString(Helper.IgnoreDateFromXmlComment(verifyRequest).InnerXml));
                    debugLog.AppendLine("</Body>");
                    debugLog.AppendLine("</Envelope>");
                }
            }
            if (verifyResponse != null)
            {
                if (!string.IsNullOrEmpty(verifyResponse.InnerXml))
                {
                    debugLog.AppendLine();
                    debugLog.AppendLine("Response received from ID Hub Verify - Current Time(GMT) - " + Helper.GetDateFromXmlComment(verifyResponse));                   
                    debugLog.AppendLine("=============== ID Hub Verify Response =============== :");
                    debugLog.AppendLine("<?xml version='1.0' encoding='UTF - 8'?>");
                    debugLog.AppendLine("<env:Envelope xmlns:avs='http://schema.uk.experian.com/eih/core/response/tnex' xmlns:bw='http://schema.uk.experian.com/eih/core/bwex' xmlns:bws='http://schema.uk.experian.com/eih/2011/03/BankWizard' xmlns:eih='http://schema.uk.experian.com/eih/2014/07' xmlns:env='http://schemas.xmlsoap.org/soap/envelope/' xmlns:header='http://schema.uk.experian.com/eih/2013/04/EIHHeader' xmlns:ns3='http://schemas.xmlsoap.org/soap/envelope/' xmlns:qas='http://schema.uk.experian.com/eih/2011/03/QAS'>");
                    debugLog.AppendLine("<env:Header/>");
                    debugLog.AppendLine("<env:Body>");
                    debugLog.AppendLine(Helper.FormatXmlToString(Helper.IgnoreDateFromXmlComment(verifyResponse).InnerXml));
                    debugLog.AppendLine("</env:Body>");
                    debugLog.AppendLine("</env:Envelope>");
                }
            }

            if (!string.IsNullOrEmpty(retryDescription))
            {
                debugLog.AppendLine();
                debugLog.AppendLine(retryDescription);                
            }

            debugLog.AppendLine("==============================");

            //This will be current time
            debugLog.AppendLine();
            debugLog.AppendLine("Updating Integration Action - Current Time (GMT) - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff \"GMT\"zzz"));

            StringBuilder integrationActionUpdateMsg = new StringBuilder();
            integrationActionUpdateMsg.Append("<update xmlns='urn:partner.soap.sforce.com'>");
            integrationActionUpdateMsg.Append("<sObjects>");
            integrationActionUpdateMsg.Append("<type xmlns='urn1:sobject.partner.soap.sforce.com'>Integration_Action__c</type>");
            integrationActionUpdateMsg.Append("<Id>" + IntegrationActionId + "</Id>");
            integrationActionUpdateMsg.Append("<Debug_Log__c><![CDATA[" + debugLog.ToString() + "]]></Debug_Log__c>");
            if (isBWASuccess)
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
