using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;

namespace BBB.ESB.BTS.Components.Interface.Utilities
{
    public class ExperianBWCHelper
    {
        public static string UpdateBWCValidateCardDetails(string BankDetailId, XmlDocument msgBWCValCardDetailsResp, out bool runBWCMatchDebitCard)
        {
            XmlNodeReader nodeReader = new XmlNodeReader(msgBWCValCardDetailsResp);
            var RespList = XDocument.Load(nodeReader);
            XNamespace ns = "http://experianpayments.com/bankwizardcard/xsd/2010/09";
            XNamespace ns1 = "http://experianpayments.com/bankwizardcard/wsdl/BankWizardCardService-v1-0";
            runBWCMatchDebitCard = false;

            var response = (from item in RespList.Descendants(ns1 + "ValidateCardDetailsResponse")
                            select new
                            {
                                CardType = item.Element(ns + "CardValidationResponse").Element(ns + "CardType"),
                                SubType = item.Element(ns + "CardValidationResponse").Element(ns + "SubType"),
                                SchemeName = item.Element(ns + "CardValidationResponse").Element(ns + "SchemeName"),
                                IssuerName = item.Element(ns + "CardValidationResponse").Element(ns + "IssuerName"),
                                CardCondition = item.Element(ns + "CardValidationResponse").Element(ns + "CardCondition")
                            }).SingleOrDefault();

            StringBuilder updateMsg = new StringBuilder();
            updateMsg.Append("<update xmlns='urn:partner.soap.sforce.com'>");
            updateMsg.Append("<sObjects xmlns='urn:partner.soap.sforce.com'>");
            updateMsg.Append("<type xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns='urn1:sobject.partner.soap.sforce.com'>Bank_Details__c</type>");
            updateMsg.Append("<Id>" + BankDetailId + "</Id>");

            if (response.IssuerName != null)
            {   //Issuer Name can have &
                updateMsg.Append("<BWC_Card_Issuer_Name__c>" + WebUtility.HtmlEncode(response.IssuerName.Value) + "</BWC_Card_Issuer_Name__c>");
            }
            if (response.SchemeName != null)
            {
                updateMsg.Append("<BWC_Card_Scheme_Name__c>" + response.SchemeName.Value + "</BWC_Card_Scheme_Name__c>");
            }
            if (response.SubType != null)
            {
                updateMsg.Append("<BWC_Card_Sub_Type__c>" + response.SubType.Value + "</BWC_Card_Sub_Type__c>");
            }
            if (response.CardType != null)
            {
                updateMsg.Append("<BWC_Card_Type__c>" + response.CardType.Value + "</BWC_Card_Type__c>");
            }
            //Moved inside condition exists
            //updateMsg.Append("<Card_Validated__c>" + "N" + "</Card_Validated__c>");
            if (response.CardCondition != null)
            {
                if (response.CardCondition.Attribute("Code") != null)
                {
                    string codeDescription = null;
                    switch (response.CardCondition.Attribute("Code").Value.Trim())
                    {
                        case "1":
                            codeDescription = "CVV not valid"; break;
                        case "2":
                            codeDescription = "Valid From date failed validation"; break;
                        case "3":
                            codeDescription = "Issue number was not in the correct format"; break;
                        case "4":
                            codeDescription = "Card number failed validation"; break;
                        case "5":
                            codeDescription = "BIN or Issuer is not valid"; break;
                        case "6":
                            codeDescription = "Expiry Date failed validation"; break;
                        case "999":
                            codeDescription = "Internal service error"; break;
                        default:
                            codeDescription = "Unknown Error"; break;
                    }
                    updateMsg.Append("<Card_Validated__c>" + "N" + "</Card_Validated__c>");
                    updateMsg.Append("<Validation_Result__c>" + codeDescription + "</Validation_Result__c>");
                }
            }
            else
            {
                runBWCMatchDebitCard = true;
                updateMsg.Append("<Validation_Result__c>" + "Success" + " </Validation_Result__c>");
            }
            updateMsg.Append("</sObjects>");
            updateMsg.Append("</update>");
            System.Diagnostics.Trace.WriteLine("UpdateBWCValidateCardDetails Message: " + updateMsg.ToString());

            //todo remove
            //runBWCMatchDebitCard = true;

            return updateMsg.ToString();

        }

        public static string UpdateBWCMatchCardDetails(string BankDetailId, XmlDocument msgBWCMatchDebitCardResp, out bool runBWCVerifyCvv)
        {
            XmlNodeReader nodeReader = new XmlNodeReader(msgBWCMatchDebitCardResp);
            var RespList = XDocument.Load(nodeReader);
            XNamespace ns = "http://experianpayments.com/bankwizardcard/xsd/2010/09";
            XNamespace ns1 = "http://experianpayments.com/bankwizardcard/wsdl/BankWizardCardService-v1-0";
            runBWCVerifyCvv = false;
            var response = (from item in RespList.Descendants(ns1 + "MatchDebitCardDetailsResponse")
                            select new
                            {
                                MatchResult = item.Element(ns + "MatchResult"),
                                CardType = item.Element(ns + "CardValidationResponse").Element(ns + "CardType"),
                                SubType = item.Element(ns + "CardValidationResponse").Element(ns + "SubType"),
                                SchemeName = item.Element(ns + "CardValidationResponse").Element(ns + "SchemeName"),
                                IssuerName = item.Element(ns + "CardValidationResponse").Element(ns + "IssuerName"),
                                CardCondition = item.Element(ns + "CardValidationResponse").Element(ns + "CardCondition")
                            }).SingleOrDefault();

            StringBuilder updateMsg = new StringBuilder();
            updateMsg.Append("<update xmlns='urn:partner.soap.sforce.com'>");
            updateMsg.Append("<sObjects xmlns='urn:partner.soap.sforce.com'>");
            updateMsg.Append("<type xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns='urn1:sobject.partner.soap.sforce.com'>Bank_Details__c</type>");
            updateMsg.Append("<Id>" + BankDetailId + "</Id>");

            if (response.IssuerName != null)
            {
                //Fixed CPB 46
                updateMsg.Append("<BWC_Card_Issuer_Name__c>" + WebUtility.HtmlEncode(response.IssuerName.Value) + "</BWC_Card_Issuer_Name__c>");
            }
            if (response.SchemeName != null)
            {
                updateMsg.Append("<BWC_Card_Scheme_Name__c>" + response.SchemeName.Value + "</BWC_Card_Scheme_Name__c>");
            }
            if (response.SubType != null)
            {
                updateMsg.Append("<BWC_Card_Sub_Type__c>" + response.SubType.Value + "</BWC_Card_Sub_Type__c>");
            }
            if (response.CardType != null)
            {
                updateMsg.Append("<BWC_Card_Type__c>" + response.CardType.Value + "</BWC_Card_Type__c>");
            }

            if (response.MatchResult != null)
            {
                updateMsg.Append("<Validation_Result__c>" + response.MatchResult.Value + "</Validation_Result__c>");

                //HardCode based on the latest mapping.
                //Used to force CVV Verify.
                //Defect Fix - CPB - 12
                response.MatchResult.Value = "BankMatch";

                if ((String.Compare(response.MatchResult.Value.ToLower(), "bankmatch") == 0) || (String.Compare(response.MatchResult.Value.ToLower(), "bankgroupmatch") == 0))
                {
                    updateMsg.Append("<Card_Validated__c>" + "Y" + "</Card_Validated__c>");
                    runBWCVerifyCvv = true;
                }
                else
                {
                    updateMsg.Append("<Card_Validated__c>" + "N" + "</Card_Validated__c>");
                }

            }
            updateMsg.Append("</sObjects>");
            updateMsg.Append("</update>");
            System.Diagnostics.Trace.WriteLine("UpdateBWCMatchCardDetails Message: " + updateMsg.ToString());

            //Todo remove
            //runBWCVerifyCvv = true;

            return updateMsg.ToString();
        }

        public static string UpdateBWCVerifyCvv(string BankDetailId, XmlDocument msgBWCVerifyAvsCvvResp)
        {
            XmlNodeReader nodeReader = new XmlNodeReader(msgBWCVerifyAvsCvvResp);
            var RespList = XDocument.Load(nodeReader);
            XNamespace ns = "http://experianpayments.com/bankwizardcard/xsd/2010/09";
            XNamespace ns1 = "http://experianpayments.com/bankwizardcard/wsdl/BankWizardCardService-v1-0";

            var response = (from item in RespList.Descendants(ns1 + "VerifyAvsCvvResponse")
                            select new
                            {
                                PreAuthorised = item.Element(ns + "PreAuthorised"),
                                AvsMatched = item.Element(ns + "AvsMatched"),
                                CvvMatched = item.Element(ns + "CvvMatched"),
                                PostcodeMatched = item.Element(ns + "PostcodeMatched"),
                                CardCondition = item.Element(ns + "CardValidationResponse").Element(ns + "CardCondition")
                            }).SingleOrDefault();

            StringBuilder updateMsg = new StringBuilder();
            updateMsg.Append("<update xmlns='urn:partner.soap.sforce.com'>");
            updateMsg.Append("<sObjects xmlns='urn:partner.soap.sforce.com'>");
            updateMsg.Append("<type xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns='urn1:sobject.partner.soap.sforce.com'>Bank_Details__c</type>");
            updateMsg.Append("<Id>" + BankDetailId + "</Id>");

            if (response.CardCondition != null)
            {
                if ((response.CardCondition.Attribute("Code") != null))
                {
                    if ((String.Compare(response.CardCondition.Attribute("Code").Value, "50") == 0))
                    {
                        updateMsg.Append("<Card_Verified__c>" + "Y" + "</Card_Verified__c>");
                    }
                    else
                    {
                        updateMsg.Append("<Card_Verified__c>" + "N" + "</Card_Verified__c>");
                    }
                }
            }
            if (response.AvsMatched != null)
            {
                //CPB-45 fixed
                if (!string.IsNullOrEmpty(response.AvsMatched.Value))
                {
                    updateMsg.Append("<BWC_AVS_Matched__c>" + response.AvsMatched.Value + "</BWC_AVS_Matched__c>");
                }
            }
            if (response.CvvMatched != null)
            {   //CPB-45 fixed
                if (!string.IsNullOrEmpty(response.CvvMatched.Value))
                {
                    updateMsg.Append("<BWC_CVV_Matched__c>" + response.CvvMatched.Value + "</BWC_CVV_Matched__c>");
                }
            }
            if (response.PostcodeMatched != null)
            {   //CPB-45 fixed
                if (!string.IsNullOrEmpty(response.PostcodeMatched.Value))
                {
                    updateMsg.Append("<BWC_Postcode_Matched__c>" + response.PostcodeMatched.Value + "</BWC_Postcode_Matched__c>");
                }
            }

            if (response.PreAuthorised != null)
            {
                if (!string.IsNullOrEmpty(response.PreAuthorised.Value))
                {
                    updateMsg.Append("<BWC_PreAuthorised__c>" + response.PreAuthorised.Value + "</BWC_PreAuthorised__c>");
                }
            }
            updateMsg.Append("</sObjects>");
            updateMsg.Append("</update>");
            System.Diagnostics.Trace.WriteLine("UpdateBWCVerifyCvv Message: " + updateMsg.ToString());
            return updateMsg.ToString();
        }

        public static string UpdateBWCIntActionMessage(string BankDetailId, string IntegrationActionId, bool IsBWCSuccess, string ProcessID, DateTime QueryExecutionDate, XmlDocument soapHeader = null, XmlDocument msgBWCValCardDetailsReq = null, XmlDocument msgBWCValCardDetailsResp = null, XmlDocument msgBWCMatchDebitCardReq = null, XmlDocument msgBWCMatchDebitCardResp = null, XmlDocument msgBWCVerifyAvsCvvReq = null, XmlDocument msgBWCVerifyAvsCvvResp = null, string retryDescription = "")
        {
            string orgId = Config.GetStringConfigValue("SalesForce.OrgId");

            StringBuilder debugLog = new StringBuilder();
            debugLog.AppendLine("Integration Type : Salesforce To BWC");
            debugLog.AppendLine("Current Time (GMT) - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff \"GMT\"zzz"));
            debugLog.AppendLine("Log : BizTalk Environment :" + Environment.MachineName);
            debugLog.AppendLine("Log : Received Org Id : " + orgId);
            debugLog.AppendLine("Log : Received Application Id : " + BankDetailId);
            debugLog.AppendLine("Log : Received Action Id : " + IntegrationActionId);
            debugLog.AppendLine("Log : BizTalk Process Id : " + ProcessID);
            if (IsBWCSuccess)
            {
                debugLog.AppendLine("Status : Success.");
            }
            else
            {
                debugLog.AppendLine("Status : Failed.");
            }

            debugLog.AppendLine();
            debugLog.AppendLine("Salesforce Query Complete - Current Time (GMT) - " + QueryExecutionDate.ToString("yyyy-MM-dd HH:mm:ss.fff \"GMT\"zzz"));

            if (msgBWCValCardDetailsReq != null)
            {
                if (!string.IsNullOrEmpty(msgBWCValCardDetailsReq.InnerXml))
                {
                    debugLog.AppendLine();
                    debugLog.AppendLine("Sending data to BWC Validate - Current Time(GMT) - " + Helper.GetDateFromXmlComment(msgBWCValCardDetailsReq));                    
                    debugLog.AppendLine("=============== BWC Validate Request =============== :");
                    debugLog.AppendLine("<?xml version='1.0' encoding='UTF - 8'?>");
                    debugLog.AppendLine("<Envelope xmlns='http://schemas.xmlsoap.org/soap/envelope/' xmlns:ns='http://experianpayments.com/bankwizardcard/wsdl/BankWizardCardService-v1-0' xmlns:ns1='http://experianpayments.com/bankwizardcard/xsd/2010/09' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>");
                    debugLog.AppendLine("<Header>");
                    debugLog.AppendLine(Helper.FormatXmlToString(soapHeader.DocumentElement.InnerXml));
                    debugLog.AppendLine("</Header>");
                    debugLog.AppendLine("<Body>");
                    debugLog.AppendLine(MaskPANAndCVV(Helper.FormatXmlToString(Helper.IgnoreDateFromXmlComment(msgBWCValCardDetailsReq).InnerXml), "xml"));
                    debugLog.AppendLine("</Body>");
                    debugLog.AppendLine("</Envelope>");
                }
            }
            if (msgBWCValCardDetailsResp != null)
            {
                if (!string.IsNullOrEmpty(msgBWCValCardDetailsResp.InnerXml))
                {
                    debugLog.AppendLine();
                    debugLog.AppendLine("Response received from BWC Validate - Current Time(GMT) - " + Helper.GetDateFromXmlComment(msgBWCValCardDetailsResp));                 
                    debugLog.AppendLine("=============== BWC Validate Response =============== :");
                    debugLog.AppendLine("<?xml version='1.0' encoding='UTF - 8'?>");
                    debugLog.AppendLine("<SOAP-ENV:Envelope xmlns='http://schemas.xmlsoap.org/soap/envelope/' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema'>");
                    debugLog.AppendLine("<SOAP-ENV:Header/>");
                    debugLog.AppendLine("<SOAP-ENV:Body>");
                    debugLog.AppendLine(Helper.FormatXmlToString(Helper.IgnoreDateFromXmlComment(msgBWCValCardDetailsResp).InnerXml));
                    debugLog.AppendLine("</SOAP-ENV:Body>");
                    debugLog.AppendLine("</SOAP-ENV:Envelope>");
                }
            }

            if (msgBWCMatchDebitCardReq != null)
            {
                if (!string.IsNullOrEmpty(msgBWCMatchDebitCardReq.InnerXml))
                {
                    debugLog.AppendLine();
                    debugLog.AppendLine("Sending data to BWC Debit Card Validate - Current Time(GMT) - " + Helper.GetDateFromXmlComment(msgBWCMatchDebitCardReq));                    
                    debugLog.AppendLine("=============== BWC Debit Card Validate Request =============== :");
                    debugLog.AppendLine("<?xml version='1.0' encoding='UTF - 8'?>");
                    debugLog.AppendLine("<Envelope xmlns='http://schemas.xmlsoap.org/soap/envelope/' xmlns:ns='http://experianpayments.com/bankwizardcard/wsdl/BankWizardCardService-v1-0' xmlns:ns1='http://experianpayments.com/bankwizardcard/xsd/2010/09' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>");
                    debugLog.AppendLine("<Header>");
                    debugLog.AppendLine(Helper.FormatXmlToString(soapHeader.DocumentElement.InnerXml));
                    debugLog.AppendLine("</Header>");
                    debugLog.AppendLine("<Body>");
                    debugLog.AppendLine(MaskPANAndCVV(Helper.FormatXmlToString(Helper.IgnoreDateFromXmlComment(msgBWCMatchDebitCardReq).InnerXml), "xml"));
                    debugLog.AppendLine("</Body>");
                    debugLog.AppendLine("</Envelope>");
                }
            }
            if (msgBWCMatchDebitCardResp != null)
            {
                if (!string.IsNullOrEmpty(msgBWCMatchDebitCardResp.InnerXml))
                {
                    debugLog.AppendLine();
                    debugLog.AppendLine("Response received from BWC Debit Card Validate - Current Time(GMT) - " + Helper.GetDateFromXmlComment(msgBWCMatchDebitCardResp));                    
                    debugLog.AppendLine("=============== BWC Debit Card Validate Response =============== :");
                    debugLog.AppendLine("<?xml version='1.0' encoding='UTF - 8'?>");
                    debugLog.AppendLine("<SOAP-ENV:Envelope xmlns='http://schemas.xmlsoap.org/soap/envelope/' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema'>");
                    debugLog.AppendLine("<SOAP-ENV:Header/>");
                    debugLog.AppendLine("<SOAP-ENV:Body>");
                    debugLog.AppendLine(Helper.FormatXmlToString(Helper.IgnoreDateFromXmlComment(msgBWCMatchDebitCardResp).InnerXml));
                    debugLog.AppendLine("</SOAP-ENV:Body>");
                    debugLog.AppendLine("</SOAP-ENV:Envelope>");
                }
            }

            if (msgBWCVerifyAvsCvvReq != null)
            {
                if (!string.IsNullOrEmpty(msgBWCVerifyAvsCvvReq.InnerXml))
                {
                    debugLog.AppendLine();
                    debugLog.AppendLine("Sending data to BWC Verify - Current Time(GMT) - " + Helper.GetDateFromXmlComment(msgBWCVerifyAvsCvvReq));                    
                    debugLog.AppendLine("=============== BWC Verify Request =============== :");
                    debugLog.AppendLine("<?xml version='1.0' encoding='UTF - 8'?>");
                    debugLog.AppendLine("<Envelope xmlns='http://schemas.xmlsoap.org/soap/envelope/' xmlns:ns='http://experianpayments.com/bankwizardcard/wsdl/BankWizardCardService-v1-0' xmlns:ns1='http://experianpayments.com/bankwizardcard/xsd/2010/09' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>");
                    debugLog.AppendLine("<Header>");
                    debugLog.AppendLine(Helper.FormatXmlToString(soapHeader.DocumentElement.InnerXml));
                    debugLog.AppendLine("</Header>");
                    debugLog.AppendLine("<Body>");
                    debugLog.AppendLine(MaskPANAndCVV(Helper.FormatXmlToString(Helper.IgnoreDateFromXmlComment(msgBWCVerifyAvsCvvReq).InnerXml), "xml"));
                    debugLog.AppendLine("</Body>");
                    debugLog.AppendLine("</Envelope>");
                }
            }
            if (msgBWCVerifyAvsCvvResp != null)
            {
                if (!string.IsNullOrEmpty(msgBWCVerifyAvsCvvResp.InnerXml))
                {
                    debugLog.AppendLine();
                    debugLog.AppendLine("Response received from BWC Verify - Current Time(GMT) - " + Helper.GetDateFromXmlComment(msgBWCVerifyAvsCvvResp));                    
                    debugLog.AppendLine("=============== BWC Verify Response =============== :");
                    debugLog.AppendLine("<?xml version='1.0' encoding='UTF - 8'?>");
                    debugLog.AppendLine("<SOAP-ENV:Envelope xmlns='http://schemas.xmlsoap.org/soap/envelope/' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema'>");
                    debugLog.AppendLine("<SOAP-ENV:Header/>");
                    debugLog.AppendLine("<SOAP-ENV:Body>");
                    debugLog.AppendLine(Helper.FormatXmlToString(Helper.IgnoreDateFromXmlComment(msgBWCVerifyAvsCvvResp).InnerXml));
                    debugLog.AppendLine("</SOAP-ENV:Body>");
                    debugLog.AppendLine("</SOAP-ENV:Envelope>");
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
            if (IsBWCSuccess)
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

        public static string MaskPANAndCVV(string debugLog, string format)
        {
            try
            {
                if (format.ToLower() == "xml")
                {
                    //Mask after 6 numbers
                    debugLog = Regex.Replace(debugLog, "PAN>\\d{16}", delegate (Match m)
                    {
                        return m.Value.Substring(0, 10) + new String('*', 10);
                    });

                    //Mask all numbers
                    debugLog = Regex.Replace(debugLog, "CVV>\\d{3}", "CVV>***");
                }
                if (format.ToLower() == "string")
                {
                    //Mask after 6 numbers
                    debugLog = Regex.Replace(debugLog, "PAN=\\d{16}", delegate (Match m)
                    {
                        return m.Value.Substring(0, 10) + new String('*', 10);
                    }, RegexOptions.IgnoreCase);

                    //Mask all numbers
                    debugLog = Regex.Replace(debugLog, "CVV=\\d{3}", "CVV=***", RegexOptions.IgnoreCase);
                }

            }
            catch (Exception)
            {

            }
            return debugLog;
        }
    }
}
