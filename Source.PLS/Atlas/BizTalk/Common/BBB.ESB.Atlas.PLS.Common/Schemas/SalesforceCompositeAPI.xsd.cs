namespace BBB.ESB.Atlas.PLS.Common.Schemas {
    using Microsoft.XLANGs.BaseTypes;
    
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [SchemaType(SchemaTypeEnum.Document)]
    [System.SerializableAttribute()]
    [SchemaRoots(new string[] {@"PostOrPatch", @"PostOrPatchResponse"})]
    public sealed class SalesforceCompositeAPI : Microsoft.XLANGs.BaseTypes.SchemaBase {
        
        [System.NonSerializedAttribute()]
        private static object _rawSchema;
        
        [System.NonSerializedAttribute()]
        private const string _strSchema = @"<?xml version=""1.0"" encoding=""utf-16""?>
<xs:schema xmlns=""http://BBB.ESB.Atlas.PLS.Common.Schemas.SalesforceCompositeAPI"" xmlns:b=""http://schemas.microsoft.com/BizTalk/2003"" attributeFormDefault=""unqualified"" elementFormDefault=""unqualified"" targetNamespace=""http://BBB.ESB.Atlas.PLS.Common.Schemas.SalesforceCompositeAPI"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
  <xs:element name=""PostOrPatch"">
    <xs:complexType>
      <xs:sequence>
        <xs:element minOccurs=""0"" name=""allOrNone"" type=""xs:boolean"" />
        <xs:element minOccurs=""0"" name=""collateSubrequests"" type=""xs:boolean"" />
        <xs:element minOccurs=""0"" maxOccurs=""unbounded"" name=""compositeRequest"">
          <xs:complexType>
            <xs:sequence>
              <xs:element minOccurs=""0"" name=""method"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""url"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""referenceId"" type=""xs:string"" />
              <xs:element minOccurs=""0"" name=""body"">
                <xs:complexType>
                  <xs:sequence>
                    <xs:any />
                    <xs:sequence minOccurs=""0"">
                      <xs:element minOccurs=""0"" name=""allOrNone"" type=""xs:boolean"" />
                      <xs:element minOccurs=""0"" maxOccurs=""unbounded"" name=""records"">
                        <xs:complexType>
                          <xs:sequence>
                            <xs:element name=""attributes"">
                              <xs:complexType>
                                <xs:sequence>
                                  <xs:element minOccurs=""0"" name=""type"" type=""xs:string"" />
                                </xs:sequence>
                              </xs:complexType>
                            </xs:element>
                            <xs:any />
                          </xs:sequence>
                        </xs:complexType>
                      </xs:element>
                    </xs:sequence>
                  </xs:sequence>
                </xs:complexType>
              </xs:element>
            </xs:sequence>
          </xs:complexType>
        </xs:element>
      </xs:sequence>
    </xs:complexType>
  </xs:element>
  <xs:element name=""PostOrPatchResponse"">
    <xs:complexType>
      <xs:sequence>
        <xs:element maxOccurs=""unbounded"" name=""compositeResponse"">
          <xs:complexType>
            <xs:sequence>
              <xs:element name=""body"">
                <xs:complexType>
                  <xs:sequence>
                    <xs:element name=""id"" type=""xs:string"" />
                    <xs:element name=""success"" type=""xs:boolean"" />
                    <xs:element name=""message"" type=""xs:string"" />
                    <xs:element name=""errors"" type=""xs:string"" />
                    <xs:element name=""errorCode"" type=""xs:string"" />
                    <xs:element name=""fields"" type=""xs:string"" />
                  </xs:sequence>
                </xs:complexType>
              </xs:element>
              <xs:element name=""httpHeaders"" type=""xs:string"" />
              <xs:element name=""httpStatusCode"" type=""xs:string"" />
              <xs:element name=""referenceId"" type=""xs:string"" />
            </xs:sequence>
          </xs:complexType>
        </xs:element>
      </xs:sequence>
    </xs:complexType>
  </xs:element>
</xs:schema>";
        
        public SalesforceCompositeAPI() {
        }
        
        public override string XmlContent {
            get {
                return _strSchema;
            }
        }
        
        public override string[] RootNodes {
            get {
                string[] _RootElements = new string [2];
                _RootElements[0] = "PostOrPatch";
                _RootElements[1] = "PostOrPatchResponse";
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
        
        [Schema(@"http://BBB.ESB.Atlas.PLS.Common.Schemas.SalesforceCompositeAPI",@"PostOrPatch")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"PostOrPatch"})]
        public sealed class PostOrPatch : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public PostOrPatch() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "PostOrPatch";
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
        
        [Schema(@"http://BBB.ESB.Atlas.PLS.Common.Schemas.SalesforceCompositeAPI",@"PostOrPatchResponse")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"PostOrPatchResponse"})]
        public sealed class PostOrPatchResponse : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public PostOrPatchResponse() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "PostOrPatchResponse";
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
}
