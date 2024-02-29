namespace BBB.ESB.Atlas.PLS.OnlinePlatform.Maps {
    
    
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"BBB.ESB.Atlas.PLS.OnlinePlatform.Schemas.Contact", typeof(global::BBB.ESB.Atlas.PLS.OnlinePlatform.Schemas.Contact))]
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"BBB.ESB.Atlas.Loans.Common.Schemas.SalesforceCompositeAPI+PostOrPatch", typeof(global::BBB.ESB.Atlas.Loans.Common.Schemas.SalesforceCompositeAPI.PostOrPatch))]
    public sealed class APIReq_To_SalesforceReq : global::Microsoft.XLANGs.BaseTypes.TransformBase {
        
        private const string _strMap = @"<?xml version=""1.0"" encoding=""UTF-16""?>
<xsl:stylesheet xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"" xmlns:msxsl=""urn:schemas-microsoft-com:xslt"" xmlns:var=""http://schemas.microsoft.com/BizTalk/2003/var"" exclude-result-prefixes=""msxsl var s0"" version=""1.0"" xmlns:s0=""http://BBB.ESB.Atlas.PLS.OnlinePlatform.Schemas.Contact"" xmlns:ns0=""http://BBB.ESB.Atlas.Loans.Common.Schemas.SalesforceCompositeAPI"">
  <xsl:output omit-xml-declaration=""yes"" method=""xml"" version=""1.0"" />
  <xsl:template match=""/"">
    <xsl:apply-templates select=""/s0:Document"" />
  </xsl:template>
  <xsl:template match=""/s0:Document"">
    <ns0:PostOrPatch>
      <allOrNone>true</allOrNone>
      <collateSubrequests>true</collateSubrequests>
      <compositeRequest>
        <method>PATCH</method>
        <url>
          <xsl:text>/services/data/v52.0/sobjects/Contact/</xsl:text>
          <xsl:value-of select=""ID""/>
        </url>
        <referenceId>refCT</referenceId>
        <body>
          <xsl:if test=""Online_Platform_Accessed__c != ''"">
            <Online_Platform_Accessed__c>
              <xsl:value-of select=""Online_Platform_Accessed__c"" />
            </Online_Platform_Accessed__c>
          </xsl:if>
        </body>
      </compositeRequest>           
    </ns0:PostOrPatch>
  </xsl:template>
</xsl:stylesheet>";
        
        private const int _useXSLTransform = 0;
        
        private const string _strArgList = @"<ExtensionObjects />";
        
        private const string _strSrcSchemasList0 = @"BBB.ESB.Atlas.PLS.OnlinePlatform.Schemas.Contact";
        
        private const global::BBB.ESB.Atlas.PLS.OnlinePlatform.Schemas.Contact _srcSchemaTypeReference0 = null;
        
        private const string _strTrgSchemasList0 = @"BBB.ESB.Atlas.Loans.Common.Schemas.SalesforceCompositeAPI+PostOrPatch";
        
        private const global::BBB.ESB.Atlas.Loans.Common.Schemas.SalesforceCompositeAPI.PostOrPatch _trgSchemaTypeReference0 = null;
        
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
                _SrcSchemas[0] = @"BBB.ESB.Atlas.PLS.OnlinePlatform.Schemas.Contact";
                return _SrcSchemas;
            }
        }
        
        public override string[] TargetSchemas {
            get {
                string[] _TrgSchemas = new string [1];
                _TrgSchemas[0] = @"BBB.ESB.Atlas.Loans.Common.Schemas.SalesforceCompositeAPI+PostOrPatch";
                return _TrgSchemas;
            }
        }
    }
}
