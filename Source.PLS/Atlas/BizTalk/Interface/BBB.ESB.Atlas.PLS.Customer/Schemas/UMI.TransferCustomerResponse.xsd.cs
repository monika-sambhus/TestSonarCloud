namespace BBB.ESB.Atlas.PLS.Customer.Schemas {
    using Microsoft.XLANGs.BaseTypes;
    
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [SchemaType(SchemaTypeEnum.Document)]
    [Schema(@"http://BBB.ESB.Atlas.PLS.Customer.Schemas.UMI",@"Response")]
    [System.SerializableAttribute()]
    [SchemaRoots(new string[] {@"Response"})]
    public sealed class UMI_TransferCustomerResponse : Microsoft.XLANGs.BaseTypes.SchemaBase {
        
        [System.NonSerializedAttribute()]
        private static object _rawSchema;
        
        [System.NonSerializedAttribute()]
        private const string _strSchema = @"<?xml version=""1.0"" encoding=""utf-16""?>
<xs:schema xmlns=""http://BBB.ESB.Atlas.PLS.Customer.Schemas.UMI"" xmlns:b=""http://schemas.microsoft.com/BizTalk/2003"" attributeFormDefault=""unqualified"" elementFormDefault=""unqualified"" targetNamespace=""http://BBB.ESB.Atlas.PLS.Customer.Schemas.UMI"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
  <xs:element name=""Response"">
    <xs:complexType>
      <xs:sequence>
        <xs:element name=""message"" type=""xs:string"" />
        <xs:element name=""Data"">
          <xs:complexType>
            <xs:sequence>
              <xs:element minOccurs=""0"" name=""plsUniqueId"" type=""xs:string"" />
            </xs:sequence>
          </xs:complexType>
        </xs:element>
      </xs:sequence>
    </xs:complexType>
  </xs:element>
</xs:schema>";
        
        public UMI_TransferCustomerResponse() {
        }
        
        public override string XmlContent {
            get {
                return _strSchema;
            }
        }
        
        public override string[] RootNodes {
            get {
                string[] _RootElements = new string [1];
                _RootElements[0] = "Response";
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
