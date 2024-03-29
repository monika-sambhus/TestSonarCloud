<?xml version="1.0" encoding="UTF-16"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" xmlns:var="http://schemas.microsoft.com/BizTalk/2003/var" exclude-result-prefixes="msxsl var s0" version="1.0" xmlns:s0="http://BBB.ESB.Atlas.PLS.OnlinePlatform.Schemas.Contact" xmlns:ns0="http://BBB.ESB.Atlas.Loans.Common.Schemas.SalesforceCompositeAPI">
  <xsl:output omit-xml-declaration="yes" method="xml" version="1.0" />
  <xsl:template match="/">
    <xsl:apply-templates select="/s0:Document" />
  </xsl:template>
  <xsl:template match="/s0:Document">
    <ns0:PostOrPatch>
      <allOrNone>true</allOrNone>
      <collateSubrequests>true</collateSubrequests>
      <compositeRequest>
        <method>PATCH</method>
        <url>
          <xsl:text>/services/data/v52.0/sobjects/Contact/</xsl:text>
          <xsl:value-of select="ID"/>
        </url>
        <referenceId>refCT</referenceId>
        <body>
          <xsl:if test="Online_Platform_Accessed__c != ''">
            <Online_Platform_Accessed__c>
              <xsl:value-of select="Online_Platform_Accessed__c" />
            </Online_Platform_Accessed__c>
          </xsl:if>
        </body>
      </compositeRequest>           
    </ns0:PostOrPatch>
  </xsl:template>
</xsl:stylesheet>