namespace BBB.ESB.Atlas.PLS.Mentoring.Schemas {
    using Microsoft.XLANGs.BaseTypes;
    
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [SchemaType(SchemaTypeEnum.Document)]
    [Schema(@"http://BBB.ESB.Atlas.PLS.Mentoring.Schemas.MentoringSession",@"Document")]
    [System.SerializableAttribute()]
    [SchemaRoots(new string[] {@"Document"})]
    public sealed class MentoringSession : Microsoft.XLANGs.BaseTypes.SchemaBase {
        
        [System.NonSerializedAttribute()]
        private static object _rawSchema;
        
        [System.NonSerializedAttribute()]
        private const string _strSchema = @"<?xml version=""1.0"" encoding=""utf-16""?>
<xs:schema xmlns=""http://BBB.ESB.Atlas.PLS.Mentoring.Schemas.MentoringSession"" xmlns:b=""http://schemas.microsoft.com/BizTalk/2003"" targetNamespace=""http://BBB.ESB.Atlas.PLS.Mentoring.Schemas.MentoringSession"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
  <xs:element name=""Document"">
    <xs:complexType>
      <xs:sequence>
        <xs:element name=""plsEventRequestId"" type=""xs:string"" />
        <xs:element name=""format"" type=""xs:string"" />
        <xs:element name=""status"" type=""xs:string"" />
        <xs:element name=""isComplete"" type=""xs:string"" />
        <xs:element name=""medium"" type=""xs:string"" />
        <xs:element name=""duration"" type=""xs:string"" />
        <xs:element name=""description"" type=""xs:string"" />
        <xs:element name=""updatedAt"" type=""xs:string"" />
      </xs:sequence>
    </xs:complexType>
  </xs:element>
</xs:schema>";
        
        public MentoringSession() {
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
