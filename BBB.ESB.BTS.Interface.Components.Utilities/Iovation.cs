using System;
using System.Xml;
using System.Collections.Generic;
using System.Text;

namespace ESB.BTS.Components.Interface.Utilities
{
    [Serializable]
    public class Iovation
    {
        //Added all missing fields for Defect fix for ID: CPB-5
        public string Id, Application__c, Begin_Black_Box__c, Contact__c, End_User_IP__c, Name, Result__c, Reason__c, Type__c;

        private List<Mapper> MapList = new List<Mapper>();

        public static Iovation Load(System.Xml.XmlDocument xdoc)
        {
            Log.WriteDebug("ESB.BTS.Components.Interface.Utilities.Iovation", xdoc, "xx");
            XmlNode record = xdoc.SelectSingleNode("/*[local-name()='queryAllResponse' and namespace-uri()='urn:partner.soap.sforce.com']/*[local-name()='result' and namespace-uri()='urn:partner.soap.sforce.com']/*[local-name()='records' and namespace-uri()='urn:partner.soap.sforce.com'][1]");
            Iovation thisIovation = new Iovation(record);
            return thisIovation;
        }
        
        public Iovation(XmlNode Record)
        {
            ConfigureMapper();
            XmlNode Contactr = null;

            foreach (XmlNode n in Record.ChildNodes)
            {
                string localname = n.LocalName;
                if (localname == "Id") Id = n.InnerText;
                if (localname == "Application__c") Application__c = n.InnerText;
                if (localname == "Begin_Black_Box__c") Begin_Black_Box__c = n.InnerText;
                if (localname == "Contact__c") Contact__c = n.InnerText;
                if (localname == "End_User_IP__c") End_User_IP__c = n.InnerText;
                if (localname == "Name") Name = n.InnerText;
                if (localname == "Result__c") Result__c = n.InnerText;
                if (localname == "Reason__c") Reason__c = n.InnerText;
                if (localname == "Type__c") Type__c = n.InnerText;               
                if (localname == "Contact__r") Contactr = n;
            }

            if (Contactr != null)
            {
                foreach (XmlNode n in Contactr.ChildNodes)
                {
                    var mapp = MapList.Find(delegate (Mapper m)
                    {
                        return m.SourceFieldName == n.LocalName;
                    });

                    if (mapp != null)
                    {
                        mapp.Value = n.InnerText;
                    }
                }
            }


        }

        /// <summary>
        /// To generate key/value xml for Iovation Soap Request
        /// </summary>
        /// <returns></returns>
        public string Txn_Properties()
        {
            string nspc = "ns0";
            StringBuilder body = new StringBuilder();

            //header
            body.Append("<" + nspc + ":txn_properties>");


            foreach (Mapper m in MapList)
            {
                body.Append("<" + nspc + ":property>");
                body.Append("<" + nspc + ":name>" + m.TargetFieldName + "</" + nspc + ":name>");
                body.Append("<" + nspc + ":value>" + m.Value + "</" + nspc + ":value>");
                body.Append("</" + nspc + ":property>");
            }

            //footer
            body.Append("</" + nspc + ":txn_properties>");


            string s = body.ToString();

            return s;

        }


        private void ConfigureMapper()
        {
            MapList = new List<Mapper>();

            AppendToMapList("MailingCity", "BillingCity", null);
            AppendToMapList("MailingState", "BillingRegion", null);
            AppendToMapList("MailingCountry", "BillingCountry", null);
            AppendToMapList("OtherCity", "ShippingCity", null);
            AppendToMapList("OtherState", "ShippingRegion", null);
            AppendToMapList("OtherCountry", "ShippingCountry", null);
            AppendToMapList("", "ValueAmount", null);
            AppendToMapList("", "ValueCurrency", null);
            AppendToMapList("", "SKU", null);
            AppendToMapList("", "UPC", null);
            AppendToMapList("", "CreditCardBin", null);
            AppendToMapList("Id", "eventId", null);
            AppendToMapList("", "billingShippingMismatch", null);
            AppendToMapList("", "emailVerified", null);
            AppendToMapList("", "mobilePhoneVerified", null);
            AppendToMapList("", "mobilePhoneSmsEnabled", null);
            AppendToMapList("", "homePhoneVerified", null);
            AppendToMapList("", "homePhoneSmsEnabled", null);
            AppendToMapList("", "officePhoneVerified", null);
            AppendToMapList("", "officePhoneSmsEnabled", null);
            AppendToMapList("", "serviceId", null);
            AppendToMapList("", "referrerUrl", null);
            //Defect Fix CPB-6 FirstName, LastName, Email
            AppendToMapList("", "firstName", null);
            AppendToMapList("", "lastName", null);
            AppendToMapList("", "Email", null);

        }

        /// <summary>
        /// Create a Mapper object and append to MapList. Only used by the method ConfigureMapper
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="value"></param>
        private void AppendToMapList(string source, string target, string value)
        {
            Mapper m = new Mapper(source, target, value);
            MapList.Add(m);
        }

        public class Mapper
        {
            public string SourceFieldName, TargetFieldName, Value;

            public Mapper(string source, string target, string value)
            {
                SourceFieldName = source;
                TargetFieldName = target;
                Value = value;
            }
        }
    }


}
