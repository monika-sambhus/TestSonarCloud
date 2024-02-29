namespace BBB.ESB.Atlas.PLS.Common.Schemas {
    using Microsoft.XLANGs.BaseTypes;
    
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [SchemaType(SchemaTypeEnum.Document)]
    [Schema(@"http://BBB.ESB.Atlas.PLS.Common.Schemas.SalesforceCanonical",@"Root")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "PLSCustomerResponse.Status", XPath = @"/*[local-name()='Root' and namespace-uri()='http://BBB.ESB.Atlas.PLS.Common.Schemas.SalesforceCanonical']/*[local-name()='PLSCustomerResponse' and namespace-uri()='']/*[local-name()='Status' and namespace-uri()='']", XsdType = @"string")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "PLSCustomerResponse.IsSuccess", XPath = @"/*[local-name()='Root' and namespace-uri()='http://BBB.ESB.Atlas.PLS.Common.Schemas.SalesforceCanonical']/*[local-name()='PLSCustomerResponse' and namespace-uri()='']/*[local-name()='IsSuccess' and namespace-uri()='']", XsdType = @"string")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "PLSCustomerResponse.ErrorDescription", XPath = @"/*[local-name()='Root' and namespace-uri()='http://BBB.ESB.Atlas.PLS.Common.Schemas.SalesforceCanonical']/*[local-name()='PLSCustomerResponse' and namespace-uri()='']/*[local-name()='ErrorDescription' and namespace-uri()='']", XsdType = @"string")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "PLSCustomerResponse.RetryDescription", XPath = @"/*[local-name()='Root' and namespace-uri()='http://BBB.ESB.Atlas.PLS.Common.Schemas.SalesforceCanonical']/*[local-name()='PLSCustomerResponse' and namespace-uri()='']/*[local-name()='RetryDescription' and namespace-uri()='']", XsdType = @"string")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "PLSCustomerResponse.PayLoad", XPath = @"/*[local-name()='Root' and namespace-uri()='http://BBB.ESB.Atlas.PLS.Common.Schemas.SalesforceCanonical']/*[local-name()='PLSCustomerResponse' and namespace-uri()='']/*[local-name()='PayLoad' and namespace-uri()='']", XsdType = @"string")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "PLSCustomerResponse.PLSPUniqueId", XPath = @"/*[local-name()='Root' and namespace-uri()='http://BBB.ESB.Atlas.PLS.Common.Schemas.SalesforceCanonical']/*[local-name()='PLSCustomerResponse' and namespace-uri()='']/*[local-name()='PLSPUniqueId' and namespace-uri()='']", XsdType = @"string")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "PLSCustomerResponse.PLSDebugLog", XPath = @"/*[local-name()='Root' and namespace-uri()='http://BBB.ESB.Atlas.PLS.Common.Schemas.SalesforceCanonical']/*[local-name()='PLSCustomerResponse' and namespace-uri()='']/*[local-name()='PLSDebugLog' and namespace-uri()='']", XsdType = @"string")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "PLSCustomerResponse.Request", XPath = @"/*[local-name()='Root' and namespace-uri()='http://BBB.ESB.Atlas.PLS.Common.Schemas.SalesforceCanonical']/*[local-name()='PLSCustomerResponse' and namespace-uri()='']/*[local-name()='Request' and namespace-uri()='']", XsdType = @"string")]
    [System.SerializableAttribute()]
    [SchemaRoots(new string[] {@"Root"})]
    public sealed class SalesforceCanonical : Microsoft.XLANGs.BaseTypes.SchemaBase {
        
        [System.NonSerializedAttribute()]
        private static object _rawSchema;
        
        [System.NonSerializedAttribute()]
        private const string _strSchema = @"<?xml version=""1.0"" encoding=""utf-16""?>
<xs:schema xmlns:b=""http://schemas.microsoft.com/BizTalk/2003"" xmlns:ns1=""http://BBB.ESB.Atlas.PLS.Common.Schemas.SalesforceCanonical"" targetNamespace=""http://BBB.ESB.Atlas.PLS.Common.Schemas.SalesforceCanonical"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
  <xs:element name=""Root"">
    <xs:annotation>
      <xs:appinfo>
        <b:properties>
          <b:property distinguished=""true"" xpath=""/*[local-name()='Root' and namespace-uri()='http://BBB.ESB.Atlas.PLS.Common.Schemas.SalesforceCanonical']/*[local-name()='PLSCustomerResponse' and namespace-uri()='']/*[local-name()='Status' and namespace-uri()='']"" />
          <b:property distinguished=""true"" xpath=""/*[local-name()='Root' and namespace-uri()='http://BBB.ESB.Atlas.PLS.Common.Schemas.SalesforceCanonical']/*[local-name()='PLSCustomerResponse' and namespace-uri()='']/*[local-name()='IsSuccess' and namespace-uri()='']"" />
          <b:property distinguished=""true"" xpath=""/*[local-name()='Root' and namespace-uri()='http://BBB.ESB.Atlas.PLS.Common.Schemas.SalesforceCanonical']/*[local-name()='PLSCustomerResponse' and namespace-uri()='']/*[local-name()='ErrorDescription' and namespace-uri()='']"" />
          <b:property distinguished=""true"" xpath=""/*[local-name()='Root' and namespace-uri()='http://BBB.ESB.Atlas.PLS.Common.Schemas.SalesforceCanonical']/*[local-name()='PLSCustomerResponse' and namespace-uri()='']/*[local-name()='RetryDescription' and namespace-uri()='']"" />
          <b:property distinguished=""true"" xpath=""/*[local-name()='Root' and namespace-uri()='http://BBB.ESB.Atlas.PLS.Common.Schemas.SalesforceCanonical']/*[local-name()='PLSCustomerResponse' and namespace-uri()='']/*[local-name()='PayLoad' and namespace-uri()='']"" />
          <b:property distinguished=""true"" xpath=""/*[local-name()='Root' and namespace-uri()='http://BBB.ESB.Atlas.PLS.Common.Schemas.SalesforceCanonical']/*[local-name()='PLSCustomerResponse' and namespace-uri()='']/*[local-name()='PLSPUniqueId' and namespace-uri()='']"" />
          <b:property distinguished=""true"" xpath=""/*[local-name()='Root' and namespace-uri()='http://BBB.ESB.Atlas.PLS.Common.Schemas.SalesforceCanonical']/*[local-name()='PLSCustomerResponse' and namespace-uri()='']/*[local-name()='PLSDebugLog' and namespace-uri()='']"" />
          <b:property distinguished=""true"" xpath=""/*[local-name()='Root' and namespace-uri()='http://BBB.ESB.Atlas.PLS.Common.Schemas.SalesforceCanonical']/*[local-name()='PLSCustomerResponse' and namespace-uri()='']/*[local-name()='Request' and namespace-uri()='']"" />
        </b:properties>
      </xs:appinfo>
    </xs:annotation>
    <xs:complexType>
      <xs:sequence>
        <xs:element minOccurs=""0"" name=""Integration_Action__c"">
          <xs:complexType>
            <xs:sequence>
              <xs:element name=""Id"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Action_Name__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Alternate_Action_Number__c"" nillable=""true"" type=""xs:double"" />
              <xs:element minOccurs=""0"" name=""Alternative_Page__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""AttachedContentDocuments"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""AttachedContentNotes"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Attachments"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""CombinedAttachments"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""ContactRequests"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""ContentDocumentLinks"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""CreatedBy"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""CreatedById"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""CreatedDate"" nillable=""true"" type=""xs:dateTime"" />
              <xs:element minOccurs=""0"" name=""Createddatetime__c"" nillable=""true"" type=""xs:dateTime"" />
              <xs:element minOccurs=""0"" name=""Current_Action_Number__c"" nillable=""true"" type=""xs:double"" />
              <xs:element minOccurs=""0"" name=""Debug_Log__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""DuplicateRecordItems"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Enddatetime__c"" nillable=""true"" type=""xs:dateTime"" />
              <xs:element minOccurs=""0"" name=""EventRelations"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""FeedSubscriptionsForEntity"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Histories"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Integration_Action_History__r"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Integration_Control__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Integration_Control__r"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Iovation_Type__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""IsDeleted"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""LastModifiedBy"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""LastModifiedById"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""LastModifiedDate"" nillable=""true"" type=""xs:dateTime"" />
              <xs:element minOccurs=""0"" name=""LookedUpFromActivities"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Name"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""NetworkUserHistoryRecentToRecord"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Next_Action_Number__c"" nillable=""true"" type=""xs:double"" />
              <xs:element minOccurs=""0"" name=""Next_Page__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Notes"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""NotesAndAttachments"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Order__c"" nillable=""true"" type=""xs:double"" />
              <xs:element minOccurs=""0"" name=""ParentEntities"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""ProcessExceptions"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""ProcessInstances"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""ProcessSteps"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""RecordActionHistories"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""RecordActions"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""RecordAssociatedGroups"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Status__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""SurveySubjectEntities"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""SystemModstamp"" nillable=""true"" type=""xs:dateTime"" />
              <xs:element minOccurs=""0"" name=""System_Error_Logs__r"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""TaskRelations"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""TopicAssignments"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Type__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""UserRecordAccess"" nillable=""true"" type=""xs:string"" />
            </xs:sequence>
          </xs:complexType>
        </xs:element>
        <xs:element minOccurs=""0"" name=""Contact"">
          <xs:complexType>
            <xs:sequence>
              <xs:element name=""Id"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""AcceptedEventRelations"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Account"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""AccountContactRoles"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""AccountId"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""ActivityHistories"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Age_Group__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Age__c"" nillable=""true"" type=""xs:double"" />
              <xs:element minOccurs=""0"" name=""Agreement_to_SULCo_Privacy_Policy__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Applicant_CRM_Id__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Applicant_Identified_Referral_Source__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Application_Name__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Application_Status_GlobalValueSet__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Application_Status__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Applications1__r"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Applications__r"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Applied_for_First_Loan_Tranche_B__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""Are_you_currently_in_the_UK_on_a_visa__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""AssistantName"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""AssistantPhone"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""AttachedContentDocuments"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""AttachedContentNotes"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Attachments"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""BA_Email__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""BA_First_Name__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""BA_Last_Name__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""BA_Phone__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Birthdate"" nillable=""true"" type=""xs:date"" />
              <xs:element minOccurs=""0"" name=""Business_Type__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""Business_partner__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""CRM_Business_Partner_Email__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""CRM_Business_Partner_First_Name__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""CRM_Business_Partner_Last_Name__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""CRM_Business_Partner__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""CRM_Business_Plan__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""CRM_Business_partner_full_name__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""CRM_Ex_Forces__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""CRM_Is_NEA_Participant__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""CRM_Marketing_Agree__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""CRM_NEA_Business_Plan_Approved__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""CRM_NEA_Business_Plan_SignedOff_Date__c"" nillable=""true"" type=""xs:date"" />
              <xs:element minOccurs=""0"" name=""CRM_Partner_Landing_Reference_URL__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""CRM_Personal_Data__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""CRM_Preferred_Call_Time__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""CRM_Returning_To_Work__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""CRM_Third_Party_Marketing__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""CRM_Trading_Started_Date__c"" nillable=""true"" type=""xs:date"" />
              <xs:element minOccurs=""0"" name=""CRM_Trading_Started__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""CRM_UK_Business__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""CRM_UK_Resident__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""CRM_UK_Right_To_Work__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""CRM_Unemployed__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""CRM_Where_Hear_About_Start_Up_Loans__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Can_Apply_For_FLTranche_B__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""Can_Apply_For_Loan__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""Can_Apply_For_Second_Loan__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""Can_Apply_for_2nd_Loan_Tranche_B__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""CaseContactRoles"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Case_study_candidate__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Case_study_complete__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Cases"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Clear_Other_Address_Fields__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""CombinedAttachments"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Confirm__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""Contact_Details_Change_Check__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""ContentDocumentLinks"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""CreatedBy"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""CreatedById"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""CreatedDate"" nillable=""true"" type=""xs:dateTime"" />
              <xs:element minOccurs=""0"" name=""Current_Application_Balance_Amount__c"" nillable=""true"" type=""xs:double"" />
              <xs:element minOccurs=""0"" name=""Current_Application_Status__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Current_Application__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Current_Application__r"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Current_Bank_Details__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Current_Bank_Details__r"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Current_Iovation_Result__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Current_Iovation_Result__r"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Currently_trading__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""DP_Affiliate_Name__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""DP_Email_Address__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""DP_Phone_Number__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""DP_Referrals__r"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""DP_Website__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Date_Confirmed__c"" nillable=""true"" type=""xs:date"" />
              <xs:element minOccurs=""0"" name=""Days_since_contact_created__c"" nillable=""true"" type=""xs:double"" />
              <xs:element minOccurs=""0"" name=""Days_since_last_Customer_Portal_Login__c"" nillable=""true"" type=""xs:double"" />
              <xs:element minOccurs=""0"" name=""Days_until_application_time_out__c"" nillable=""true"" type=""xs:double"" />
              <xs:element minOccurs=""0"" name=""Declaration_Ready_To_Send__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""Decline_Date__c"" nillable=""true"" type=""xs:date"" />
              <xs:element minOccurs=""0"" name=""DeclinedEventRelations"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Delivery_Partner_Name__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Delivery_Partner__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Delivery_Partner__r"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Department"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Description"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""DirectFraudMatch1__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""DirectFraudMatch2__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""DirectFraudMatch3__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""DirectFraudMatch4__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""DirectFraudMatch5__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""DirectFraudMatch6__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""DirectFraudMatch7__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""DirectFraudMatch8__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""District__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""DoNotCall"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""Do_you_have_an_unspent_conviction__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Drawn_Down_In_Progress_Total_Value__c"" nillable=""true"" type=""xs:double"" />
              <xs:element minOccurs=""0"" name=""DuplicateRecordItems"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Email"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""EmailBouncedDate"" nillable=""true"" type=""xs:dateTime"" />
              <xs:element minOccurs=""0"" name=""EmailBouncedReason"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""EmailMessageRelations"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""EmailStatuses"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""EntitlementContacts"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Ethnocity_Group__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""EventRelations"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""EventWhoRelations"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Events"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Ex_forces_or_military__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""FL_Tranche_A_DrawnDown__c"" nillable=""true"" type=""xs:date"" />
              <xs:element minOccurs=""0"" name=""FP_EmaIL__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""FP_Phone__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""FP_Unique_Address_ID__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""FP_Unique_ID__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""FP_Website__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Failed_Logins__c"" nillable=""true"" type=""xs:double"" />
              <xs:element minOccurs=""0"" name=""Fax"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""FeedSubscriptionsForEntity"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Feeds"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Finance_Partner_Name__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Finance_Partner__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Finance_Partner__r"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""FirstName"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""First_Loan_Application__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""First_Loan_Application__r"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""First_Loan_Tranche_B_Drawn_Down_Date__c"" nillable=""true"" type=""xs:date"" />
              <xs:element minOccurs=""0"" name=""Flat_Number__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Fraud_Case_exists_For_Contact__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""Fraud_Data_Contact__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""Fraud_Mobile_Network__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""Fraud_Nationality__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""Fraud_Postcode__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""Full_Name__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""HasOptedOutOfEmail"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""HasOptedOutOfFax"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""Has_Drawn_Down_First_Loan_Tranche_B__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""Has_Drawn_Down_First_Loan__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""Has_Drawn_Down_Second_Loan_Tranche_B__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""Has_Drawn_Down_Second_Loan__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""Has_Registered__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""Has_applied_for_2nd_Loan_Tranche_B__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""Has_applied_for_Second_Loan__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""Highest_qualification_2__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Histories"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""HomePhone"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""House_Name__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""House_Number__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""IndirectFraudMatch1__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""IndirectFraudMatch2__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""IndirectFraudMatch3__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""IndirectFraudMatch4__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""IndirectFraudMatch5__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Individual_Account__r"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Industry_SIC_code__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Industry_Sector__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Ineligible_reasons__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Integration_Controls__r"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Invalid_Landing_Page_Reference__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""Iovation_Results__r"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Iovation_Review__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""IsDeleted"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""IsEmailBounced"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""Is_First_Loan_a_Core_Loan__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""Is_Second_Loan_Core_Loan__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""Is_Second_Loan_Tranche_A__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""Is_current_FLApplication_Tranche_A__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""Jigsaw"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""JigsawContactId"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""LastActivityDate"" nillable=""true"" type=""xs:date"" />
              <xs:element minOccurs=""0"" name=""LastCURequestDate"" nillable=""true"" type=""xs:dateTime"" />
              <xs:element minOccurs=""0"" name=""LastCUUpdateDate"" nillable=""true"" type=""xs:dateTime"" />
              <xs:element minOccurs=""0"" name=""LastModifiedBy"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""LastModifiedById"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""LastModifiedDate"" nillable=""true"" type=""xs:dateTime"" />
              <xs:element minOccurs=""0"" name=""LastName"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""LastReferencedDate"" nillable=""true"" type=""xs:dateTime"" />
              <xs:element minOccurs=""0"" name=""LastViewedDate"" nillable=""true"" type=""xs:dateTime"" />
              <xs:element minOccurs=""0"" name=""Last_Community_Log_In_date__c"" nillable=""true"" type=""xs:dateTime"" />
              <xs:element minOccurs=""0"" name=""Latest_DP_Referral__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""LeadSource"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""LeadSurveyInvitations"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""LiveChatTranscripts"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Loan_Amount__c"" nillable=""true"" type=""xs:double"" />
              <xs:element minOccurs=""0"" name=""Loan_Offer_Expiry_Date__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Loan_Purpose__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""Loan_Term__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Loan_written_off__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""Loans__r"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""LookedUpFromActivities"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""MCCMNC__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""MailingAddress"" nillable=""true"" type=""ns1:AddressType"" />
              <xs:element minOccurs=""0"" name=""MailingAddress__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""MailingCity"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""MailingCountry"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""MailingGeocodeAccuracy"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""MailingLatitude"" nillable=""true"" type=""xs:double"" />
              <xs:element minOccurs=""0"" name=""MailingLongitude"" nillable=""true"" type=""xs:double"" />
              <xs:element minOccurs=""0"" name=""MailingPostalCode"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""MailingState"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""MailingStreet"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""MasterRecord"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""MasterRecordId"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Mentor_Name__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Mentoring_Intention__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""MiddleName"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Migrated_Experian_ID__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Migrated_From_Seraph__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""MobilePhone"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Mobile_Network__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Mobile_Network_on_Fraud_List__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Mobile_Network_on_Fraud_List__r"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""My_Square_One__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""NEA_Business_Plan_approved__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""NEA_participant__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""NVMStatsSF__NVM_Call_Summaries__r"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Name"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""National_Insurance_Number__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Nationality__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Nationality_on_fraud_list__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Nationality_on_fraud_list__r"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Non_Supported_Businesses__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""Normalised_MobileNetwork__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Normalised_Postcode__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Notes"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""NotesAndAttachments"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Number_of_Applications__c"" nillable=""true"" type=""xs:double"" />
              <xs:element minOccurs=""0"" name=""Number_of_Loans__c"" nillable=""true"" type=""xs:double"" />
              <xs:element minOccurs=""0"" name=""OpenActivities"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Original_Lead_Source__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""OtherAddress"" nillable=""true"" type=""ns1:AddressType"" />
              <xs:element minOccurs=""0"" name=""OtherCity"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""OtherCountry"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""OtherGeocodeAccuracy"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""OtherLatitude"" nillable=""true"" type=""xs:double"" />
              <xs:element minOccurs=""0"" name=""OtherLongitude"" nillable=""true"" type=""xs:double"" />
              <xs:element minOccurs=""0"" name=""OtherPhone"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""OtherPostalCode"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""OtherState"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""OtherStreet"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Other_Address_Validation_Status__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Other_Address_Validation_Timestamp__c"" nillable=""true"" type=""xs:dateTime"" />
              <xs:element minOccurs=""0"" name=""Other_County__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Other_District__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Other_First_Name__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Other_Flat_Name__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Other_Flat_Number__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Other_House_Name__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Other_House_Number__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Other_Known_Name__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Other_Last_Name__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Other_Street_2__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Owner"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""OwnerId"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Owner__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Partner_Relationships1__r"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Partner_Relationships__r"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Partners_Exceeded_Total_Value__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""PersonRecord"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Perx__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Phone"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""PhotoUrl"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Ported_Country_Code__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Ported_Operator_Name__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Postcode_On_Fraud_List__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Postcode_On_Fraud_List__r"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Pre_Registration_Check__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""Previous_Address_In_UK__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Previous_Delivery_Partner_Email__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Previous_Delivery_Partner__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Previous_Delivery_Partner__r"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Previous_Seraph_DP_Name__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""ProcessInstances"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""ProcessSteps"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Process_Results__r"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""QAS_Address_Validation_Status__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""QAS_Address_Validation_Timestamp__c"" nillable=""true"" type=""xs:dateTime"" />
              <xs:element minOccurs=""0"" name=""QAS_BFPO_Name__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""QAS_BFPO_Number__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""QAS_British_Forces_Post_Office_BFPO__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""QAS_Building_Name__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""QAS_Building_Number_Additional__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""QAS_Building_Number_Primary__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""QAS_Country__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""QAS_County__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""QAS_Delivery_Point_Suffix__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""QAS_Department__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""QAS_Dependent_Locality__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""QAS_Dependent_Thoroughfare_Descriptor__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""QAS_Dependent_Thoroughfare_Name__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""QAS_Double_Dependent_Locality__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""QAS_Email_Certainty__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""QAS_Email_Message__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""QAS_Email_Verbose_Output__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""QAS_Organisation__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""QAS_PNR_county__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""QAS_PO_Box_Name__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""QAS_PO_Box_Number__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""QAS_Postcode__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""QAS_Sub_Building_Name__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""QAS_Sub_Building_Number_Additional__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""QAS_Sub_Building_Number_Primary__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""QAS_Submitted_Dependent_thoroughfare__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""QAS_Submitted_PNR_Locality__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""QAS_Submitted_thoroughfare__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""QAS_Tel_Certainty__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""QAS_Tel_Country_Name__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""QAS_Tel_Operator_Name__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""QAS_Tel_Result_Code__c"" nillable=""true"" type=""xs:double"" />
              <xs:element minOccurs=""0"" name=""QAS_Thoroughfare_Descriptor__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""QAS_Thoroughfare_Name__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""QAS_Three_character_ISO_country_code__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""QAS_Town__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""QAS_Whole_Building_Number__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""QAS_Whole_Dependent_Thoroughfare__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""QAS_Whole_PO_Box__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""QAS_Whole_Sub_Building_number__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""QAS_Whole_Thoroughfare__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Questions_Other_Language__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Questions_in_another_language__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Questions_languages__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""RBS__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Re_Registrant__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""RecordActionHistories"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""RecordActions"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""RecordAssociatedGroups"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""RecordType"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""RecordTypeId"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Reference_ID__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""ReportsTo"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""ReportsToId"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Require_Previous_Address__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""Roaming_Country_Code__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Roaming_Network_Name__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Roaming_Network_Prefix__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""SULCo_Marketing_opt_out__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""SYS_Individual_Account_Name__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Salutation"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Second_Loan_Ineligible_Date__c"" nillable=""true"" type=""xs:date"" />
              <xs:element minOccurs=""0"" name=""Second_Loan_Ineligible_in_last_6_months__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""Second_Loan_Outstanding_Balance__c"" nillable=""true"" type=""xs:double"" />
              <xs:element minOccurs=""0"" name=""Second_Loan_Tranche_B_Drawn_Down_date__c"" nillable=""true"" type=""xs:date"" />
              <xs:element minOccurs=""0"" name=""ServiceContracts"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Shares"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Suffix"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""SurveyInvitations"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""SurveyTakers1__r"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""SystemModstamp"" nillable=""true"" type=""xs:dateTime"" />
              <xs:element minOccurs=""0"" name=""TDUID__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""TD_Affiliate__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""TaskRelations"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""TaskWhoRelations"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Tasks"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Third_party_marketing_opt_out__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Title"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""TopicAssignments"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Trading_Two_Years__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""Transfer_Notes__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Transfer_Reason__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Trigger_Can_Apply_For_Loan__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""UTM_Test__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""UndecidedEventRelations"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""UserRecordAccess"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Users"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""VSU_PLS_Pilot__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Validated_Phone_Number__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Virgin_Affiliate_Name__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""Visible_to_DP__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""What_is_your_current_annual_income_incl__c"" nillable=""true"" type=""xs:double"" />
              <xs:element minOccurs=""0"" name=""What_is_your_current_employment_status__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""What_is_your_current_residential_status__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""What_is_your_ethnic_background__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""What_is_your_gender__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""What_is_your_highest_qualification_1__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""What_is_your_marital_status__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""What_type_of_visa_1__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""What_type_of_visa_2__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""When_did_you_move_from_here_Prev__c"" nillable=""true"" type=""xs:date"" />
              <xs:element minOccurs=""0"" name=""When_did_you_move_here_Prev__c"" nillable=""true"" type=""xs:date"" />
              <xs:element minOccurs=""0"" name=""When_did_you_move_here__c"" nillable=""true"" type=""xs:date"" />
              <xs:element minOccurs=""0"" name=""When_did_you_move_here_text__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""When_does_your_visa_expire__c"" nillable=""true"" type=""xs:date"" />
              <xs:element minOccurs=""0"" name=""X2nd_Loan_Tranche_A_Drawn_Down_Date__c"" nillable=""true"" type=""xs:date"" />
              <xs:element minOccurs=""0"" name=""contact_count__c"" nillable=""true"" type=""xs:double"" />
              <xs:element minOccurs=""0"" name=""conversion_field1__c"" nillable=""true"" type=""xs:double"" />
              <xs:element minOccurs=""0"" name=""isRoaming__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""pi__Needs_Score_Synced__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""pi__Pardot_Last_Scored_At__c"" nillable=""true"" type=""xs:dateTime"" />
              <xs:element minOccurs=""0"" name=""pi__campaign__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""pi__comments__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""pi__conversion_date__c"" nillable=""true"" type=""xs:dateTime"" />
              <xs:element minOccurs=""0"" name=""pi__conversion_object_name__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""pi__conversion_object_type__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""pi__created_date__c"" nillable=""true"" type=""xs:dateTime"" />
              <xs:element minOccurs=""0"" name=""pi__first_activity__c"" nillable=""true"" type=""xs:dateTime"" />
              <xs:element minOccurs=""0"" name=""pi__first_search_term__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""pi__first_search_type__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""pi__first_touch_url__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""pi__grade__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""pi__last_activity__c"" nillable=""true"" type=""xs:dateTime"" />
              <xs:element minOccurs=""0"" name=""pi__notes__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""pi__pardot_hard_bounced__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""pi__score__c"" nillable=""true"" type=""xs:double"" />
              <xs:element minOccurs=""0"" name=""pi__url__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""pi__utm_campaign__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""pi__utm_content__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""pi__utm_medium__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""pi__utm_source__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""pi__utm_term__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""prevent_further_application__c"" nillable=""true"" type=""xs:boolean"" />
              <xs:element minOccurs=""0"" name=""utm_source__c"" nillable=""true"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""zzOther_County__c"" nillable=""true"" type=""xs:string"" />
              <xs:element name=""PLS_Unique_Id__c"" type=""xs:string"" />
            </xs:sequence>
          </xs:complexType>
        </xs:element>
        <xs:element minOccurs=""0"" name=""PLSCustomerResponse"">
          <xs:complexType>
            <xs:sequence>
              <xs:element name=""Status"" type=""xs:string"" />
              <xs:element name=""IsSuccess"" type=""xs:string"" />
              <xs:element name=""ErrorDescription"" type=""xs:string"" />
              <xs:element name=""RetryDescription"" type=""xs:string"" />
              <xs:element name=""Request"" type=""xs:string"" />
              <xs:element name=""PayLoad"" type=""xs:string"" />
              <xs:element name=""PLSPUniqueId"" type=""xs:string"" />
              <xs:element name=""PLSDebugLog"" type=""xs:string"" />
            </xs:sequence>
          </xs:complexType>
        </xs:element>
      </xs:sequence>
    </xs:complexType>
  </xs:element>
  <xs:complexType name=""AddressType"">
    <xs:sequence>
      <xs:element name=""city"" nillable=""true"" type=""xs:string"" />
      <xs:element name=""country"" nillable=""true"" type=""xs:string"" />
      <xs:element name=""countryCode"" nillable=""true"" type=""xs:string"" />
      <xs:element name=""geocodeAccuracy"" nillable=""true"" type=""xs:string"" />
      <xs:element name=""postalCode"" nillable=""true"" type=""xs:string"" />
      <xs:element name=""state"" nillable=""true"" type=""xs:string"" />
      <xs:element name=""stateCode"" nillable=""true"" type=""xs:string"" />
      <xs:element name=""street"" nillable=""true"" type=""xs:string"" />
    </xs:sequence>
  </xs:complexType>
</xs:schema>";
        
        public SalesforceCanonical() {
        }
        
        public override string XmlContent {
            get {
                return _strSchema;
            }
        }
        
        public override string[] RootNodes {
            get {
                string[] _RootElements = new string [1];
                _RootElements[0] = "Root";
                return _RootElements;
            }
        }
        
        protected override object RawSchema {
            get {
                return _rawSchema;
            }
            set {
                _rawSchema = value;
            }
        }
    }
}
