namespace BBB.ESB.Atlas.PLS.Customer.Maps {
    
    
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"BBB.ESB.Atlas.Loans.Common.Schemas.APIRequest", typeof(global::BBB.ESB.Atlas.Loans.Common.Schemas.APIRequest))]
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"BBB.ESB.Atlas.PLS.Customer.Schemas.UMI_TransferCustomerRequest", typeof(global::BBB.ESB.Atlas.PLS.Customer.Schemas.UMI_TransferCustomerRequest))]
    public sealed class Xform_TransferCustomerRequest : global::Microsoft.XLANGs.BaseTypes.TransformBase {
        
        private const string _strMap = @"<?xml version=""1.0"" encoding=""UTF-16""?>
<xsl:stylesheet xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"" xmlns:msxsl=""urn:schemas-microsoft-com:xslt"" xmlns:var=""http://schemas.microsoft.com/BizTalk/2003/var"" exclude-result-prefixes=""msxsl var"" version=""1.0"" xmlns:ns0=""http://BBB.ESB.Atlas.PLS.Customer.Schemas.UMI"">
  <xsl:output omit-xml-declaration=""yes"" method=""xml"" version=""1.0"" />
  <xsl:template match=""/"">
    <xsl:apply-templates select=""/Document"" />
  </xsl:template>
  <xsl:template match=""/Document"">
    <ns0:Document>
      <xsl:for-each select=""meta"">
        <meta>
          <xsl:if test=""organisationId"">
            <organisationId>
              <xsl:value-of select=""organisationId/text()"" />
            </organisationId>
          </xsl:if>
          <xsl:if test=""integrationActionId"">
            <integrationActionId>
              <xsl:value-of select=""integrationActionId/text()"" />
            </integrationActionId>
          </xsl:if>
          <xsl:value-of select=""./text()"" />
        </meta>
      </xsl:for-each>
      <xsl:for-each select=""data"">
        <data>
          <xsl:if test=""object"">
            <object>
              <xsl:value-of select=""object/text()"" />
            </object>
          </xsl:if>
          <xsl:if test=""id"">
            <id>
              <xsl:value-of select=""id/text()"" />
            </id>
          </xsl:if>
          <xsl:if test=""salutation"">
            <salutation>
              <xsl:value-of select=""salutation/text()"" />
            </salutation>
          </xsl:if>
          <xsl:if test=""firstName"">
            <firstName>
              <xsl:value-of select=""firstName/text()"" />
            </firstName>
          </xsl:if>
          <xsl:if test=""lastName"">
            <lastName>
              <xsl:value-of select=""lastName/text()"" />
            </lastName>
          </xsl:if>
          <xsl:if test=""middleName"">
            <middleName>
              <xsl:value-of select=""middleName/text()"" />
            </middleName>
          </xsl:if>
          <xsl:if test=""dateOfBirth"">
            <dateOfBirth>
              <xsl:value-of select=""dateOfBirth/text()"" />
            </dateOfBirth>
          </xsl:if>
          <xsl:if test=""email"">
            <email>
              <xsl:value-of select=""email/text()"" />
            </email>
          </xsl:if>
          <xsl:if test=""phoneNumber"">
            <phoneNumber>
              <xsl:value-of select=""phoneNumber/text()"" />
            </phoneNumber>
          </xsl:if>
          <xsl:if test=""mobilePhoneNumber"">
            <mobilePhoneNumber>
              <xsl:value-of select=""mobilePhoneNumber/text()"" />
            </mobilePhoneNumber>
          </xsl:if>
          <xsl:if test=""otherPhoneNumber"">
            <otherPhoneNumber>
              <xsl:value-of select=""otherPhoneNumber/text()"" />
            </otherPhoneNumber>
          </xsl:if>
          <xsl:for-each select=""application"">
            <application>
              <xsl:if test=""applicationNumber"">
                <applicationNumber>
                  <xsl:value-of select=""applicationNumber/text()"" />
                </applicationNumber>
              </xsl:if>
            </application>
          </xsl:for-each>
          <xsl:for-each select=""plsEvent"">
            <plsEvent>
              <xsl:if test=""id"">
                <id>
                  <xsl:value-of select=""id/text()"" />
                </id>
              </xsl:if>
            </plsEvent>
          </xsl:for-each>
          <xsl:value-of select=""./text()"" />
        </data>
      </xsl:for-each>
    </ns0:Document>
  </xsl:template>
</xsl:stylesheet>";
        
        private const int _useXSLTransform = 0;
        
        private const string _strArgList = @"<ExtensionObjects />";
        
        private const string _strSrcSchemasList0 = @"BBB.ESB.Atlas.Loans.Common.Schemas.APIRequest";
        
        private const global::BBB.ESB.Atlas.Loans.Common.Schemas.APIRequest _srcSchemaTypeReference0 = null;
        
        private const string _strTrgSchemasList0 = @"BBB.ESB.Atlas.PLS.Customer.Schemas.UMI_TransferCustomerRequest";
        
        private const global::BBB.ESB.Atlas.PLS.Customer.Schemas.UMI_TransferCustomerRequest _trgSchemaTypeReference0 = null;
        
        public override string XmlContent {
            get {
                return _strMap;
            }
        }
        
        public override int UseXSLTransform {
            get {
                return _useXSLTransform;
            }
        }
        
        public override string XsltArgumentListContent {
            get {
                return _strArgList;
            }
        }
        
        public override string[] SourceSchemas {
            get {
                string[] _SrcSchemas = new string [1];
                _SrcSchemas[0] = @"BBB.ESB.Atlas.Loans.Common.Schemas.APIRequest";
                return _SrcSchemas;
            }
        }
        
        public override string[] TargetSchemas {
            get {
                string[] _TrgSchemas = new string [1];
                _TrgSchemas[0] = @"BBB.ESB.Atlas.PLS.Customer.Schemas.UMI_TransferCustomerRequest";
                return _TrgSchemas;
            }
        }
    }
}
