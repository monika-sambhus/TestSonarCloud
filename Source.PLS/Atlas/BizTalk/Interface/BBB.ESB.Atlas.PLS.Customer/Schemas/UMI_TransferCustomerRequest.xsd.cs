namespace BBB.ESB.Atlas.PLS.Customer.Schemas {
    using Microsoft.XLANGs.BaseTypes;
    
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [SchemaType(SchemaTypeEnum.Document)]
    [Schema(@"http://BBB.ESB.Atlas.PLS.Customer.Schemas.UMI",@"Document")]
    [System.SerializableAttribute()]
    [SchemaRoots(new string[] {@"Document"})]
    public sealed class UMI_TransferCustomerRequest : Microsoft.XLANGs.BaseTypes.SchemaBase {
        
        [System.NonSerializedAttribute()]
        private static object _rawSchema;
        
        [System.NonSerializedAttribute()]
        private const string _strSchema = @"<?xml version=""1.0"" encoding=""utf-16""?>
<xs:schema xmlns=""http://BBB.ESB.Atlas.PLS.Customer.Schemas.UMI"" xmlns:b=""http://schemas.microsoft.com/BizTalk/2003"" attributeFormDefault=""unqualified"" elementFormDefault=""unqualified"" targetNamespace=""http://BBB.ESB.Atlas.PLS.Customer.Schemas.UMI"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
  <xs:element name=""Document"">
    <xs:complexType>
      <xs:sequence>
        <xs:element name=""meta"">
          <xs:complexType>
            <xs:sequence>
              <xs:element name=""organisationId"" type=""xs:string"" />
              <xs:element name=""integrationActionId"" type=""xs:string"" />
            </xs:sequence>
          </xs:complexType>
        </xs:element>
        <xs:element name=""data"">
          <xs:complexType>
            <xs:sequence>
              <xs:element name=""object"" type=""xs:string"" />
              <xs:element name=""id"" type=""xs:string"" />
              <xs:element name=""salutation"" type=""xs:string"" />
              <xs:element name=""firstName"" type=""xs:string"" />
              <xs:element name=""lastName"" type=""xs:string"" />
              <xs:element name=""middleName"" type=""xs:string"" />
              <xs:element name=""dateOfBirth"" type=""xs:string"" />
              <xs:element name=""email"" type=""xs:string"" />
              <xs:element name=""phoneNumber"" type=""xs:string"" />
              <xs:element name=""mobilePhoneNumber"" type=""xs:string"" />
              <xs:element name=""otherPhoneNumber"" type=""xs:string"" />
              <xs:element name=""application"">
                <xs:complexType>
                  <xs:sequence>
                    <xs:element name=""applicationNumber"" type=""xs:string"" />
                  </xs:sequence>
                </xs:complexType>
              </xs:element>
              <xs:element name=""plsEvent"">
                <xs:complexType />
              </xs:element>
              <xs:element name=""id"" type=""xs:string"" />
            </xs:sequence>
          </xs:complexType>
        </xs:element>
      </xs:sequence>
    </xs:complexType>
  </xs:element>
</xs:schema>";
        
        public UMI_TransferCustomerRequest() {
        }
        
        public override string XmlContent {
            get {
                return _strSchema;
            }
        }
        
        public override string[] RootNodes {
            get {
                string[] _RootElements = new string [1];
                _RootElements[0] = "Document";
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
