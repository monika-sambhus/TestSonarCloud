using System;
using System.Linq;
using System.Xml;

namespace ESB.BTS.Components.Interface.Utilities
{
    public class Experian
    {
        public static string GetExperianSTSReq()
        {
            string loginsoaprequest = "<ns0:STS xmlns:ns0 = 'http://www.uk.experian.com/WASP/'><ns0:authenticationBlock><![CDATA[<WASPAuthenticationRequest><ApplicationName>[application]</ApplicationName><AuthenticationLevel>[authentication]</AuthenticationLevel><AuthenticationParameters/></WASPAuthenticationRequest>]]></ns0:authenticationBlock></ns0:STS>";

            string application = Config.GetStringConfigValue("Experian.BWCapplication");
            string authentication = Config.GetStringConfigValue("Experian.BWCauthentication");

            loginsoaprequest = loginsoaprequest.Replace("[application]", application);
            loginsoaprequest = loginsoaprequest.Replace("[authentication]", authentication);

            return loginsoaprequest;

        }

        public static string GetExperianLoginReq()
        {
            string loginsoaprequest = "<ns0:LoginWithCertificate xmlns:ns0='http://www.uk.experian.com/WASP/'><ns0:application>[application]</ns0:application><ns0:checkIP>[checkIP]</ns0:checkIP></ns0:LoginWithCertificate>";

            string application = Config.GetStringConfigValue("Experian.application");
            string checkIP = Config.GetStringConfigValue("Experian.checkIP");


            loginsoaprequest = loginsoaprequest.Replace("[application]", application);
            loginsoaprequest = loginsoaprequest.Replace("[checkIP]", checkIP);

            return loginsoaprequest;

        }


        public static string GetExperianBWAReqHeader(string waspToken)
        {
            string headerRequest = "<headers><wsse:Security xmlns:wsse='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd' xmlns:wsu='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd'><wsu:Timestamp wsu:id ='Test Timestamp MI001'><wsu:Created>[createdTime]</wsu:Created><wsu:Expires>[expireTime]</wsu:Expires></wsu:Timestamp><wsse:BinarySecurityToken ValueType='ExperianWASP' EncodingType='wsse:Base64Binary' wsu:Id='SecurityToken'>[idhubToken]</wsse:BinarySecurityToken></wsse:Security></headers>";

            string createdTime = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss");
            //Config value moved to Config data
            DateTime expireTime = DateTime.Parse(createdTime).AddMinutes(ESB.BTS.Components.Interface.Utilities.Config.GetIntConfigValue("BizTalk.TimeToLive"));
            string base64token = Base64EncodeToken(waspToken);

            headerRequest = headerRequest.Replace("[createdTime]", createdTime);
            headerRequest = headerRequest.Replace("[expireTime]", expireTime.ToString("yyyy-MM-ddTHH:mm:ss"));
            headerRequest = headerRequest.Replace("[idhubToken]", base64token);

            return headerRequest;

        }

        public static string GetExperianIDHubReqHeader(string waspToken)
        {
            string headerRequest = "<headers><wsse:Security xmlns:wsse='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd' xmlns:wsu='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd'><wsu:Timestamp wsu:id ='Test Timestamp MI001'><wsu:Created>[createdTime]</wsu:Created><wsu:Expires>[expireTime]</wsu:Expires></wsu:Timestamp><wsse:BinarySecurityToken ValueType='ExperianWASP' EncodingType='wsse:Base64Binary' wsu:Id='SecurityToken'>[idhubToken]</wsse:BinarySecurityToken></wsse:Security></headers>";

            string createdTime = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss");
            //Config value moved to Config data
            DateTime expireTime = DateTime.Parse(createdTime).AddMinutes(ESB.BTS.Components.Interface.Utilities.Config.GetIntConfigValue("BizTalk.TimeToLive"));
            string base64token = Base64EncodeToken(waspToken);

            headerRequest = headerRequest.Replace("[createdTime]", createdTime);
            headerRequest = headerRequest.Replace("[expireTime]", expireTime.ToString("yyyy-MM-ddTHH:mm:ss"));
            headerRequest = headerRequest.Replace("[idhubToken]", base64token);

            return headerRequest;

        }

        public static string GetExperianDelphiReqHeader(string waspToken)
        {
            string headerRequest = "<headers><wsse:Security xmlns:wsse='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd' xmlns:wsu='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd'><wsse:BinarySecurityToken ValueType='ExperianWASP' EncodingType='wsse:Base64Binary' wsu:Id='SecurityToken'>[DelphiToken]</wsse:BinarySecurityToken></wsse:Security></headers>";

            string base64token = Base64EncodeToken(waspToken);

            headerRequest = headerRequest.Replace("[DelphiToken]", base64token);

            return headerRequest;

        }

        public static string GetExperianBWCReqHeader(string waspToken)
        {
            string headerRequest = "<headers><wsse:Security xmlns:wsse='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd' xmlns:wsu='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd'><wsse:BinarySecurityToken ValueType='ExperianWASP' EncodingType='wsse:Base64Binary' wsu:Id='SecurityToken'>[BWCToken]</wsse:BinarySecurityToken></wsse:Security></headers>";

            string base64token = Base64EncodeToken(waspToken);

            headerRequest = headerRequest.Replace("[BWCToken]", base64token);

            return headerRequest;

        }

        public static string GetExperianStringFromBinaryData(string binaryData)
        {
            byte[] b = System.Convert.FromBase64String(binaryData);
            return System.Text.Encoding.UTF8.GetString(b);
        }

        public static string GetExperianBWAIds(string sfTriggerMsg, string idType)
        {
            var splitArray = sfTriggerMsg.Split('&');

            return (idType.Equals("BankDetailId")) ? splitArray[1].Substring(13) : splitArray[0].Substring(20);
        }

        public static string GetExperianIDHubIds(string sfTriggerMsg, string idType)
        {
            var splitArray = sfTriggerMsg.Split('&');

            return (idType.Equals("ApplicationId")) ? splitArray[1].Substring(14) : splitArray[0].Substring(20);
        }


        public static string GetExperianBWCIds(string sfTriggerMsg, string idType)
        {
            //CPB - 10
            //Changed the logic to ignore order of parameters
            if (string.IsNullOrEmpty(sfTriggerMsg)) { throw new ArgumentNullException(sfTriggerMsg); }
            if (string.IsNullOrEmpty(idType)) { throw new ArgumentNullException(idType); }

            string idValue = null;
            var splitArray = sfTriggerMsg.Split('&').ToList();
            idValue = splitArray.Where(x => x.ToLower().Contains(idType.ToLower())).FirstOrDefault().Split('=')[1].ToString();

            return idValue;
        }


        public static string GetExperianDelphiIds(string sfTriggerMsg, string idType)
        {
            var splitArray = sfTriggerMsg.Split('&');

            return (idType.Equals("ApplicationId")) ? splitArray[1].Substring(14) : splitArray[0].Substring(20);
        }

        public static string GetExperianValidateResponseType(XmlDocument msgValidateResp)
        {
            string respType = "none";
            string processType = msgValidateResp.FirstChild.LocalName.ToLower();
            if (processType.Contains("bwvalidateresponse"))
            {
                respType = "BWValidateResponse";
            }
            if (processType.Contains("fault"))
            {
                respType = "EIHFault";
            }
            return respType;
        }

        public static string GetExperianVerifyResponseType(XmlDocument msgVerifyResp)
        {
            string respType = "none";
            string processType = msgVerifyResp.FirstChild.LocalName.ToLower();
            string ns = "http://schema.uk.experian.com/eih/2014/07";
            if (processType.Contains("processconfigresponse"))
            {
                if (((msgVerifyResp.GetElementsByTagName("BWAMessageBlock", ns).Count) > 0) || (((msgVerifyResp.GetElementsByTagName("RuleTriggered", ns).Count) > 0) && (String.Compare((msgVerifyResp.GetElementsByTagName("RuleTriggered", ns)[0].InnerText), "Error - No rules run") == 0)))
                {
                    respType = "Retry";
                }
                else
                {
                    respType = "ProcessConfigResponse";
                }
            }
            if (processType.Contains("fault"))
            {
                respType = "EIHFault";
            }
            return respType;
        }

        public static string GetExperianIDHubResponseType(XmlDocument msgIDHubResp)
        {
            string respType = "none";

            string processType = msgIDHubResp.FirstChild.LocalName.ToLower();
            if (processType.Contains("processconfigresponse"))
            {
                respType = "ProcessConfigResponse";
            }
            if (processType.Contains("fault"))
            {
                respType = "EIHFault";
            }
            return respType;
        }

        public static string GetIDFromCreateResponse(XmlDocument msgCreateResp)
        {
            string Id = null;
            bool status = System.Convert.ToBoolean(msgCreateResp.SelectSingleNode("/*[local-name()='createResponse' and namespace-uri()='urn:partner.soap.sforce.com']/*[local-name()='result' and namespace-uri()='urn:partner.soap.sforce.com']/*[local-name()='success' and namespace-uri()='urn:partner.soap.sforce.com']").InnerText);

            if (status)
            {
                Id = msgCreateResp.SelectSingleNode("/*[local-name()='createResponse' and namespace-uri()='urn:partner.soap.sforce.com']/*[local-name()='result' and namespace-uri()='urn:partner.soap.sforce.com']/*[local-name()='id' and namespace-uri()='urn:partner.soap.sforce.com']").InnerText;
            }
            return Id;
        }

        //Added to test validate request
        public static string GetExperianValidateReq()
        {
            string loginsoaprequest = "<ns0:BWValidateRequest xmlns:ns0='http://schema.uk.experian.com/eih/2011/03' xmlns:bws='http://schema.uk.experian.com/eih/2011/03/BankWizard' xmlns:qas='http://schema.uk.experian.com/eih/2011/03/QAS' xmlns:ns1='http://schema.uk.experian.com/eih/2011/03/EIHHeader' language='en' checkingLevel='Account' ISOCountry='GB'><ns1:EIHHeader><ns1:ClientUser/><ns1:ReferenceId/></ns1:EIHHeader><bws:BBAN index='1'>070116</bws:BBAN><bws:BBAN index='2'>00162665</bws:BBAN></ns0:BWValidateRequest>";

            return loginsoaprequest;

        }

        //Added to test VerifyBankAccount i.e. verify request
        //public static string GetExperianVerifyReq()
        //{
        //    string loginsoaprequest = "<ns:ExecuteRequest xmlns:ns='http://schema.uk.experian.com/eih/2011/03' xmlns:bws='http://schema.uk.experian.com/eih/2011/03/BankWizard' xmlns:qas='http://schema.uk.experian.com/eih/2011/03/QAS' xmlns:ns1='http://schema.uk.experian.com/eih/2011/03/EIHHeader'><ns1:EIHHeader><ns1:ClientUser/><ns1:ReferenceId/></ns1:EIHHeader><ns:ProcessConfigReference><ns:ProcessConfigName>Bank Wizard Absolute</ns:ProcessConfigName></ns:ProcessConfigReference><ns:ResponseType>Detail</ns:ResponseType><ns:Consent>Yes</ns:Consent><ns:PersonalData><ns:Name><ns:Title>Mr</ns:Title><ns:Forename>LAURENCE</ns:Forename><ns:Surname>RODGERS</ns:Surname></ns:Name><ns:Gender>Male</ns:Gender><ns:BirthDate>1979-01-16</ns:BirthDate><ns:MaritalStatus>Married</ns:MaritalStatus><ns:ResidentialStatus>Owner</ns:ResidentialStatus></ns:PersonalData><ns:Addresses><ns:Address><ns:AddressDetail><ns:HouseNumber>1</ns:HouseNumber><ns:Address1>A9E0000000YsdgrW0RTIgTEzZJLCYJjMQF0gE5LXIw+X4bWDuVdvIU82rQNl6QUkv31Tn7HOJvca/</ns:Address1><ns:Address3>BEWDLEY</ns:Address3><ns:PostCode>DY121EG</ns:PostCode></ns:AddressDetail><ns:TypeOfAddress>UK</ns:TypeOfAddress><ns:AddressStatus>Current</ns:AddressStatus><ns:ResidentFrom>2014-03-01</ns:ResidentFrom><ns:ResidentTo>2018-05-10</ns:ResidentTo></ns:Address></ns:Addresses><ns:BankInformation><ns:AccountReference><ns:ReferenceIndex>1</ns:ReferenceIndex><ns:Reference>070116</ns:Reference><ns:TypeOfReference>Bank Branch Code</ns:TypeOfReference></ns:AccountReference><ns:AccountReference><ns:ReferenceIndex>2</ns:ReferenceIndex><ns:Reference>00162665</ns:Reference><ns:TypeOfReference>Account Number</ns:TypeOfReference></ns:AccountReference><ns:CheckContext>Direct Debit</ns:CheckContext></ns:BankInformation></ns:ExecuteRequest>";

        //    return loginsoaprequest;

        //}
        // Jitterbit request
        public static string GetExperianVerifyReq()
        {
            string loginsoaprequest = "<ns:ExecuteRequest xmlns:ns='http://schema.uk.experian.com/eih/2011/03' xmlns:bws='http://schema.uk.experian.com/eih/2011/03/BankWizard' xmlns:qas='http://schema.uk.experian.com/eih/2011/03/QAS' xmlns:ns1='http://schema.uk.experian.com/eih/2011/03/EIHHeader'><ns1:EIHHeader><ns1:ClientUser/><ns1:ReferenceId/></ns1:EIHHeader><ns:ProcessConfigReference><ns:ProcessConfigName>Bank Wizard Absolute</ns:ProcessConfigName></ns:ProcessConfigReference><ns:ResponseType>Detail</ns:ResponseType><ns:Consent>Yes</ns:Consent><ns:PersonalData><ns:Name><ns:Title>Mr</ns:Title><ns:Forename>ROBERT</ns:Forename><ns:Surname>ARWAS</ns:Surname></ns:Name><ns:Gender>Male</ns:Gender><ns:BirthDate>1967-05-31</ns:BirthDate><ns:MaritalStatus>Single</ns:MaritalStatus><ns:ResidentialStatus>Living with parents</ns:ResidentialStatus></ns:PersonalData><ns:Addresses><ns:Address><ns:AddressDetail><ns:HouseName>Timpsons</ns:HouseName><ns:HouseNumber>1</ns:HouseNumber><ns:Address1>Alexandra Gardens</ns:Address1><ns:Address3>FOLKESTONE</ns:Address3><ns:PostCode>CT20 1SS</ns:PostCode></ns:AddressDetail><ns:TypeOfAddress>UK</ns:TypeOfAddress><ns:AddressStatus>Current</ns:AddressStatus><ns:ResidentFrom>2013-03-01</ns:ResidentFrom><ns:ResidentTo>2018-07-12</ns:ResidentTo></ns:Address></ns:Addresses><ns:BankInformation><ns:AccountReference><ns:ReferenceIndex>1</ns:ReferenceIndex><ns:Reference>070116</ns:Reference><ns:TypeOfReference>Bank Branch Code</ns:TypeOfReference></ns:AccountReference><ns:AccountReference><ns:ReferenceIndex>2</ns:ReferenceIndex><ns:Reference>00120872</ns:Reference><ns:TypeOfReference>Account Number</ns:TypeOfReference></ns:AccountReference><ns:CheckContext>Direct Debit</ns:CheckContext></ns:BankInformation></ns:ExecuteRequest>";

            return loginsoaprequest;

        }

        // Added to test BWA 

        public static string GetExperianSFBWAReq()
        {
            string loginsoaprequest = "<ns0:Root xmlns:ns0='http://BBB.ESB.BTS.BizTalk.Common.SalesForce.Schema.ExperianBWA'><BankSortCode>070116</BankSortCode><BankAccountNo>00162665</BankAccountNo><Salutation>Mr</Salutation><FirstName>LAURENCE</FirstName><LastName>RODGERS</LastName><What_Is_Your_Gender__c>Male</What_Is_Your_Gender__c><BirthDate>1979-01-16</BirthDate><What_Is_Your_Marital_Status__c>Married</What_Is_Your_Marital_Status__c><What_Is_Your_Current_Residential_Status__c>Owner</What_Is_Your_Current_Residential_Status__c><House_Number__c>1</House_Number__c><MailingAddress_Street>A9E0000000YsdgrW0RTIgTEzZJLCYJjMQF0gE5LXIw+X4bWDuVdvIU82rQNl6QUkv31Tn7HOJvca/</MailingAddress_Street><MailingAddress_City>BEWDLEY</MailingAddress_City><MailingAddress_postalCode>DY121EG</MailingAddress_postalCode><When_did_you_move_here__c>2014-03-01</When_did_you_move_here__c></ns0:Root>";

            return loginsoaprequest;

        }
        //Added to test IDhub
        public static string GetExperianSFIDHubReq()
        {
            string loginsoaprequest = "<ns0:ExperianIdHub xmlns:ns0='http://BBB.ESB.BTS.BizTalk.Common.SalesForce.Schema.ExperianIdHub'><Title>Title_0</Title><FirstName>DEEPAK</FirstName><LastName>MUSIEZAK</LastName><What_Is_Your_Gender__c>Male</What_Is_Your_Gender__c><Birthdate>1991-08-21</Birthdate><What_Is_Your_Marital_Status__c>Married</What_Is_Your_Marital_Status__c><What_Is_Your_Current_Residential_Status__c>Living with parents</What_Is_Your_Current_Residential_Status__c><House_Number__c>1</House_Number__c><MailingStreet>Alder Close</MailingStreet><MailingCity>HODDESDON</MailingCity><MailingPostalCode>EN11 0PW</MailingPostalCode><When_Did_You_Move_Here__c>2008-01-01</When_Did_You_Move_Here__c><Sort_Code__c>230699</Sort_Code__c><Bank_Account_Number__c>22334455</Bank_Account_Number__c><Email>vgandham+12245656@qaworks.com</Email></ns0:ExperianIdHub>";

            return loginsoaprequest;
        }

        //Added to test Delphi
        public static string GetExperianSFDelphiReq()
        {
            string loginsoaprequest = "<ns0:Delphi xmlns:ns0='http://BBB.ESB.BTS.BizTalk.Common.SalesForce.Schema.ExperianDelphi'><Record><Age__c>38</Age__c><Birthdate>23041980</Birthdate><District__c>Elstow</District__c><Email>matthew.cutteratlasuat+200066@gmail.com</Email><FirstName>TERENCE</FirstName><House_Number__c>1</House_Number__c><LastName>KOZAR</LastName><MailingCity>BEDFORD</MailingCity><MailingPostalCode>MK42 9GP</MailingPostalCode><MailingStreet>Abbey Fields</MailingStreet><MobilePhone>07808200066</MobilePhone><Salutation>Mr</Salutation>  <What_is_your_current_annual_income_incl__c>35000</What_is_your_current_annual_income_incl__c><What_is_your_current_employment_status__c>Self-employed professional</What_is_your_current_employment_status__c><What_is_your_current_residential_status__c>Owner</What_is_your_current_residential_status__c><What_is_your_gender__c>Male</What_is_your_gender__c><What_is_your_marital_status__c>Married</What_is_your_marital_status__c><When_did_you_move_here__c>01052011</When_did_you_move_here__c> <Bank_account_number__c>00065143</Bank_account_number__c><Sort_code_number__c>070116</Sort_code_number__c></Record></ns0:Delphi>";

            return loginsoaprequest;
        }


        public static string Base64EncodeToken(string waspToken)
        {
            var tokenTextBytes = System.Text.Encoding.UTF8.GetBytes(waspToken);
            return System.Convert.ToBase64String(tokenTextBytes);
        }
    }
}
